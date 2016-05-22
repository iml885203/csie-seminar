using UnityEngine;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;

public class DrawBlock : MonoBehaviour {

    public RawImage _output;
    public RawImage _mImg;
    Mat _mat;
    public Mat _nMat;

    //結果圖片
    private Mat _matchImage;
    public int MatchWidth { get; private set; }
    public int MatchHeight { get; private set; }

    //儲存點擊位置
    Point _pointOne = new Point();
    Point _pointTwo = new Point();

    //設定螢幕與輸入cam的影像大小
    int _currentWidth;
    int _currentHeight;
    public int _inputWidth;
    public int _inputHeight;
    
    
    //滑鼠是否點擊
    private bool mouseclick = false;
    
    //繪圖顏色
    Scalar _color = new Scalar(255, 0, 0);

    //get kinect color texture
    public ColorSourceManager ColorSourceManager;

    //output to texture
    Texture2D tex;
    Texture2D _matchOut2D;

    public Mat GetBlockMat()
    {
        return _matchImage;
    }

    // Use this for initialization
    void Start () {
        //this.gameObject.transform.localScale = new Vector3(Screen.width, Screen.height);
        //cam設定與啟用
        MatchWidth = 0;
        MatchHeight = 0;
        //取得螢幕與輸入cam的影像大小
        _inputWidth = ColorSourceManager.ColorWidth;
        _inputHeight = ColorSourceManager.ColorHeight;
        _currentWidth = Screen.width;
        _currentHeight = Screen.height;

        //創造mat儲存影像
        _nMat = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC3);
        _mat = new Mat(Screen.height, Screen.width, CvType.CV_8UC3);

        //創造mat儲存比對用mat(原始比對圖形為未改變比例)
        _matchImage = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC3);
        tex = new Texture2D(_currentWidth, _currentHeight);
        _matchOut2D = new Texture2D(100, 100);
    }
	
	// Update is called once per frame
	void Update () {

        //將輸入轉成mat方便openCV使用
        //Utils.webCamTextureToMat(_webcam, _nMat);
        _nMat = ColorSourceManager.GetColorMat();
        //將輸入的影像轉換成螢幕大小
        Imgproc.resize(_nMat, _mat, _mat.size());
        if(mouseclick)TestPointmove();

        if (!mouseclick && MatchHeight != 0 && MatchWidth != 0) {
            TestPointUp();
            
        }
        //畫框框
        Imgproc.rectangle(_mat, _pointOne, _pointTwo, _color, 4);

        //創造2D影像(空的)
        
        //將mat轉換回2D影像
        Utils.matToTexture2D(_mat, tex);
        //放入輸出rawImage
        _output.texture = tex;
        
	}

    public void TestPointDown()//滑鼠點擊
    {
        //取得滑鼠在螢幕上點擊的位置
        float x = Input.mousePosition.x;
        float y = Screen.height - Input.mousePosition.y;
        //存入list
        _pointOne = new Point(x, y);
        _pointTwo = new Point(x, y);

        Debug.Log(Input.mousePosition.x.ToString() + " " + Input.mousePosition.y.ToString());
        mouseclick = true;
    }

    public void TestPointUp()//滑鼠放開
    {
        //設定滑鼠點擊
        mouseclick = false;
        // Imgproc.rectangle(_mat, _pointOne[i], _pointTwo[i], _color, 3);


        int minX = 0, MaxX = 1000, minY = 0, MaxY = 1000;
        if (_pointTwo.x >= _pointOne.x)
        {
            MaxX = (int)_pointTwo.x;
            minX = (int)_pointOne.x;
        }
        else if (_pointTwo.x < _pointOne.x)
        {
            MaxX = (int)_pointOne.x;
            minX = (int)_pointTwo.x;
        }
        if (_pointTwo.y >= _pointOne.y)
        {
            MaxY = (int)_pointTwo.y;
            minY = (int)_pointOne.y;
        }
        else if (_pointTwo.y < _pointOne.y)
        {
            MaxY = (int)_pointOne.y;
            minY = (int)_pointTwo.y;
        }
        MatchWidth = MaxX - minX;
        MatchHeight = MaxY - minY;

        _matchImage = new Mat(MatchWidth, MatchHeight,CvType.CV_8UC3);


        _matchImage = _mat.submat(minY, MaxY, minX, MaxX);
        //_matchImage = _mat.submat(0, 100, 0, 100);
        Point src_center = new Point(_matchImage.cols() / 2.0, _matchImage.rows() / 2.0);
        Mat rot_mat = Imgproc.getRotationMatrix2D(src_center, 180, 1.0);
        Imgproc.warpAffine(_matchImage, _matchImage, rot_mat, _matchImage.size());

        //比對圖形輸出
        Mat _OutMatchMat = new Mat(100, 100, CvType.CV_8UC3);
        Imgproc.resize(_matchImage, _OutMatchMat, _OutMatchMat.size());

         
         Utils.matToTexture2D(_OutMatchMat, _matchOut2D);
         _mImg.texture = _matchOut2D;

    }
    public void TestPointmove()//滑鼠放開
    {
        //取得滑鼠在螢幕放開的位置
        float x = Input.mousePosition.x;
        float y = Screen.height - Input.mousePosition.y;
        //存入list
        _pointTwo.x = x;
        _pointTwo.y = y;

        //Debug.Log(Input.mousePosition.x.ToString() + " " + Input.mousePosition.y.ToString());
    }
}
