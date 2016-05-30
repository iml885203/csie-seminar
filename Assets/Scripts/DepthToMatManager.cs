using UnityEngine;
using System.Collections;
using Windows.Kinect;
using OpenCVForUnity;
using UnityEngine.UI;

public class DepthToMatManager : MonoBehaviour
{
    private KinectSensor _Sensor;
    private CoordinateMapper _Mapper;
    private Mesh _Mesh;
    private Vector3[] _Vertices;
    private Vector2[] _UV;
    private int[] _Triangles;

    // Only works at 4 right now
    private const int _DownsampleSize = 2;
    private const double _DepthScale = 0.02f;
    private const int _Speed = 50;

    public MultiSourceManager _MultiManager;
    public ColorSourceManager _ColorManager;
    public DepthSourceManager _DepthManager;

    //二質化index
    public Slider _binaryIndex;
    public Text _kinectDistance;

    //設定桌面深度旗標
    bool _flagDeskDepth = false;

    //放深度mat
    private Mat _Depth;

    int _maxCountKey = -1;

    //各點距離
    public double Distance_UpLeft { get; private set; }
    public double Distance_UpRight { get; private set; }
    public double Distance_DownLeft { get; private set; }
    public double Distance_DonwRight { get; private set; }

    public Mat getDepthMat()
    {
        return _Depth;
    }
    public int getWidth()
    {
        return _Depth.width();
    }
    public int getheight()
    {
        return _Depth.height();
    }
    public int getDownsampleSize()
    {
        return _DownsampleSize;
    }
	// Use this for initialization
	void Start () {
        _Sensor = KinectSensor.GetDefault();
        if (_Sensor != null)
        {
            _Mapper = _Sensor.CoordinateMapper;
            var frameDesc = _Sensor.DepthFrameSource.FrameDescription;
            int newWidth = frameDesc.Width / _DownsampleSize;
            int newHeight = frameDesc.Height / _DownsampleSize;
            _Depth = new Mat(newHeight, newWidth, CvType.CV_8UC1);
            _Vertices = new Vector3[newWidth * newHeight];
            // Downsample to lower resolution
            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (_Sensor == null)
        {
            return;
        }

        if (_MultiManager == null)
        {
            return;
        }
        if (_DepthManager == null)
        {
            return;
        }
        RefreshData(_MultiManager.GetDepthData(),
                    _MultiManager.ColorWidth,
                    _MultiManager.ColorHeight);

	}
    private void RefreshData(ushort[] depthData, int colorWidth, int colorHeight)
    {

        var frameDesc = _Sensor.DepthFrameSource.FrameDescription;

        ColorSpacePoint[] colorSpace = new ColorSpacePoint[depthData.Length];
        _Mapper.MapDepthFrameToColorSpace(depthData, colorSpace);
        Hashtable depthCount = new Hashtable();
        if(_flagDeskDepth){
            int maxCount = 0;
            for (int i = 0; i < depthData.Length; i++)
            {
                if (depthCount.ContainsKey(depthData[i]))
                {
                    if ((int)depthData[i] !=0) depthCount[depthData[i]] = (int)depthCount[depthData[i]] + 1;
                    if ((int)depthCount[depthData[i]] > maxCount)
                    {
                        maxCount = (int)depthCount[depthData[i]];
                        _maxCountKey = depthData[i];
                    }
                }
                else
                {
                    depthCount.Add(depthData[i], 1);
                }
            }
            _flagDeskDepth = false;
            Debug.Log(_maxCountKey);
            //Debug.Log("Max" + maxCountKey);
        }
        //foreach (ushort key in depthCount.Keys)
        //{
        //    if((int)depthCount[key] > maxCount)
        //    {
        //        maxCount = (int)depthCount[key];
        //        maxCountKey = key;
        //    }
        //}
        //Debug.Log(maxCountKey);
        //設定存放depth的Mat大小
        _Depth = new Mat(frameDesc.Height / _DownsampleSize, frameDesc.Width/_DownsampleSize, CvType.CV_8UC1);

        for (int y = 0; y < frameDesc.Height; y += _DownsampleSize)
        {
            for (int x = 0; x < frameDesc.Width; x += _DownsampleSize)
            {
                int indexX = x / _DownsampleSize;
                int indexY = y / _DownsampleSize;
                int smallIndex = (indexY * (frameDesc.Width / _DownsampleSize)) + indexX;

                double avg = GetAvg(depthData, x, y, frameDesc.Width, frameDesc.Height);

                //avg = avg * _DepthScale;
                
                if(indexX == 64 && indexY == 53 && _kinectDistance !=null)
                {
                    _kinectDistance.text = "distance: " + avg;
                }
                if(x == 0 && y == 0)
                {
                    Distance_UpLeft = avg;
                }
                if(x == (frameDesc.Width - _DownsampleSize) && y == 0)
                {
                    Distance_UpRight = avg;
                }
                if (x == 0 && y == (frameDesc.Height - _DownsampleSize))
                {
                    Distance_DownLeft = avg;
                }
                if (x == (frameDesc.Width - _DownsampleSize) && y == (frameDesc.Height - _DownsampleSize))
                {
                    Distance_DonwRight = avg;
                }
                //距離1000mm正負200mm
                //avg = (avg > (845)) ? 0 : 255;
                avg = (avg > (double)(_maxCountKey + _binaryIndex.value)) ? 0 : 255;
                //avg = (avg - 800) / 3200 * 255;

                _Vertices[smallIndex].z = (float)avg;
                _Depth.put(y / _DownsampleSize, frameDesc.Width / _DownsampleSize - x / _DownsampleSize, avg);
                // Update UV mapping with CDRP
                //var colorSpacePoint = colorSpace[(y * frameDesc.Width) + x];
               // _UV[smallIndex] = new Vector2(colorSpacePoint.X / colorWidth, colorSpacePoint.Y / colorHeight);
            }
        }
        
        
    }
    private double GetAvg(ushort[] depthData, int x, int y, int width, int height)
    {
        double sum = 0.0;

        for (int y1 = y; y1 < y + _DownsampleSize; y1++)
        {
            for (int x1 = x; x1 < x + _DownsampleSize; x1++)
            {
                int fullIndex = (y1 * width) + x1;

                if (depthData[fullIndex] == 0)
                    sum += 0;
                else
                    sum += depthData[fullIndex];
            }
        }
        sum = sum / (_DownsampleSize * _DownsampleSize);
        //if(sum <= 30.0)return 0;
        return sum;
    }
    public void InitDeskDepth()
    {
        _flagDeskDepth = true;
        return;
    }
}
