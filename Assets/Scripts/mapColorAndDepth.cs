using UnityEngine;
using System.Collections;
using Windows.Kinect;
using OpenCVForUnity;

public class mapColorAndDepth : MonoBehaviour {

    private KinectSensor _Sensor;
    private CoordinateMapper _Mapper;

    public DepthSourceManager _DepthSourceManager;
    public ColorSourceManager _ColorSourceManager;

    private Mat _mapperMat;

    private Texture2D _colorTexture;

    private ColorSpacePoint[] colorSpace;
    private DepthSpacePoint[] depthSpace;

    public Mat GetMapperMat()
    {
        return _mapperMat;
    }

	// Use this for initialization
	void Start () {
        _Sensor = KinectSensor.GetDefault();
        if (_Sensor != null)
        {
            _Mapper = _Sensor.CoordinateMapper;
            // Downsample to lower resolution
            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if(_Sensor == null || _ColorSourceManager == null || _DepthSourceManager == null)
        {
            return;
        }
        Mat colorMat = _ColorSourceManager.GetColorMat();
        ushort[] depthData = _DepthSourceManager.GetData();
        _colorTexture = _ColorSourceManager.GetColorTexture();
        if (_mapperMat == null)
        {
            _mapperMat = new Mat(_colorTexture.height, _colorTexture.width, CvType.CV_8UC3);
        }

        //mapper
        colorSpace = new ColorSpacePoint[depthData.Length];
        depthSpace = new DepthSpacePoint[_colorTexture.width * _colorTexture.height];
        _Mapper.MapDepthFrameToColorSpace(depthData, colorSpace);
        _Mapper.MapColorFrameToDepthSpace(depthData, depthSpace);
        
        

        int spaceIndex = 0;
        float x = 0;
        float y = 0;

        //  MapDepthFrameToColorSpace
        //for (int i = 0; i < colorSpace.Length; i++)
        //{
        //    if (!float.IsNegativeInfinity(colorSpace[i].X) && !float.IsNegativeInfinity(colorSpace[i].Y))
        //    {
        //        spaceIndex = i;
        //        x = colorSpace[i].X;
        //        y = colorSpace[i].Y;
        //        //colorMat.put((int)x, (int)y, new byte[3]{ 0, 0, 0});
        //        _colorTexture.SetPixel((int)x, (int)y, new Color((float)depthData[i] / 4000 *255, (float)depthData[i] / 4000 * 255, (float)depthData[i] / 4000 * 255));
        //    }
        //}

        // MapColorFrameToDepthSpace
        // 濾掉沒深度的地方
        float depthIndex = 0f;
        float color = 0f;
        for (int i = 0; i < depthSpace.Length; i++)
        {
            if (!float.IsNegativeInfinity(depthSpace[i].X) && !float.IsNegativeInfinity(depthSpace[i].Y))
            {
                spaceIndex = i;
                depthIndex = depthSpace[i].X * depthSpace[i].Y;
                color = 1-(float)((depthData[(int)depthIndex] / 4000f));


                //colorMat.put((int)x, (int)y, new byte[3]{ 0, 0, 0});
                //_colorTexture.SetPixel((int)i % _colorTexture.width, (int)i / _colorTexture.width, new Color(color, color, color));
                //_colorTexture.SetPixel((int)depthSpace[i].X, (int)depthSpace[i].Y, new Color(0, 0, 0));
            }
            else
            {
                _colorTexture.SetPixel((int)i % _colorTexture.width, (int)i / _colorTexture.width, new Color(0, 0, 0));

            }
        }

        //Debug.Log("#"+ depthIndex+": depth :" + depthData[(int)depthIndex] + ", " + color);

        Utils.texture2DToMat(_colorTexture, _mapperMat);
        //_mapperMat = colorMat;
    }

    public Point DepthPointToColorPoint(Point depthPoint)
    {
        int depthIndex = (int)(depthPoint.x * depthPoint.y);
        return new Point(colorSpace[depthIndex].X, colorSpace[depthIndex].Y);
    }

    public Point ColorPointToDepthPoint(Point colorPoint)
    {
        int colorIndex = (int)(colorPoint.x * colorPoint.y);
        return new Point(depthSpace[colorIndex].X, depthSpace[colorIndex].Y);
    }
}
