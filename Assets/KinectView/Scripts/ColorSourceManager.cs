using UnityEngine;
using System.Collections;
using Windows.Kinect;
using OpenCVForUnity;
using System.Collections.Generic;

public class ColorSourceManager : MonoBehaviour 
{
    public int ColorWidth { get; private set; }
    public int ColorHeight { get; private set; }
    private KinectSensor _Sensor;
    private ColorFrameReader _Reader;
    private Texture2D _Texture;
    private byte[] _Data;

    private Mat _colorMat;

    public Texture2D GetColorTexture()
    {
        return _Texture;
    }
    public Mat GetColorMat()
    {
        return _colorMat;
    }
    

    void Start()
    {
        _Sensor = KinectSensor.GetDefault();
        
        if (_Sensor != null) 
        {
            _Reader = _Sensor.ColorFrameSource.OpenReader();
            
            var frameDesc = _Sensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Rgba);

            
            ColorWidth = frameDesc.Width;
            ColorHeight = frameDesc.Height;
            
            Debug.Log("ColorSize:" + ColorWidth + "x" + ColorHeight);
            //init mat
            _colorMat = new Mat(frameDesc.Height, frameDesc.Width, CvType.CV_8UC3);

            _Texture = new Texture2D(frameDesc.Width, frameDesc.Height, TextureFormat.RGBA32, false);
            _Data = new byte[frameDesc.BytesPerPixel * frameDesc.LengthInPixels];
            
            
            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }
    }
    
    void Update () 
    {
        
        if (_Reader != null) 
        {
            var frame = _Reader.AcquireLatestFrame();

            if (frame != null)
            {
                frame.CopyConvertedFrameDataToArray(_Data, ColorImageFormat.Rgba);

                _Texture.LoadRawTextureData(_Data);

                Utils.texture2DToMat(_Texture, _colorMat);
                
                _Texture.Apply();
                frame.Dispose();
                frame = null;
            }
        }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    Point p = new Point(Input.mousePosition.x, Input.mousePosition.y);
        //    roiPointList.Add(p);
        //    Debug.Log("::" + p.x + ":" + p.y);
        //}

    }
    void OnApplicationQuit()
    {
        if (_Reader != null) 
        {
            _Reader.Dispose();
            _Reader = null;
        }
        
        if (_Sensor != null) 
        {
            if (_Sensor.IsOpen)
            {
                _Sensor.Close();
            }
            
            _Sensor = null;
        }
    }
    
    
    
}
