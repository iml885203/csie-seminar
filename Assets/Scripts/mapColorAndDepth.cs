using UnityEngine;
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
        
        

        //_mapperMat = colorMat;
    }

    public Point DepthIndexToColorPoint(int depthIndex)
    {
        return new Point(colorSpace[depthIndex].X, colorSpace[depthIndex].Y);
    }

    public Point ColorPointToDepthPoint(Point colorPoint)
    {
        int colorIndex = (int)(colorPoint.x * colorPoint.y);
        Debug.Log(depthSpace.Length + ", " + colorIndex);
        return new Point(depthSpace[colorIndex].X, depthSpace[colorIndex].Y);
    }

    public Vector2 CameraSpacePointToColorVector2(CameraSpacePoint CSP)
    {
        var colorPoint = _Mapper.MapCameraPointToColorSpace(CSP);
        return new Vector2(colorPoint.X, colorPoint.Y);
    }
}
