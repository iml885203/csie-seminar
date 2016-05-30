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
        if(_mapperMat == null)
        {
            _mapperMat = new Mat(_colorTexture.height, _colorTexture.width, CvType.CV_8UC3);
        }
        

        //mapper
        ColorSpacePoint[] colorSpace = new ColorSpacePoint[depthData.Length];
        _Mapper.MapDepthFrameToColorSpace(depthData, colorSpace);
        int spaceIndex = 0;
        float x = 0;
        float y = 0;
        for(int i =0; i<colorSpace.Length; i++)
        {
            if(!float.IsNegativeInfinity(colorSpace[i].X) && !float.IsNegativeInfinity(colorSpace[i].Y))
            {
                if(i == 1)
                {
                    spaceIndex = i;
                    x = colorSpace[i].X;
                    y = colorSpace[i].Y;
                }
                
                //colorMat.put((int)x, (int)y, new byte[3]{ 0, 0, 0});
                _colorTexture.SetPixel((int)colorSpace[i].X, (int)colorSpace[i].Y, new Color(0, 0, 0));
            }
        }
        Debug.Log(spaceIndex + ": " + x + ", " + y);
        Utils.texture2DToMat(_colorTexture, _mapperMat);
        //_mapperMat = colorMat;
    }
}
