using UnityEngine;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;

public class DrawBlock : MonoBehaviour {

    public RawImage _inoutImg;
    public RawImage _blockImg;
    public RawImage _blockDepthImg;
    private Mat _screenMat;
    public Mat _sourceMat;
    //public Mat _sourceMatDepth;

    //結果圖片
    private Mat _matchImage;
    private Mat _matchDepthImage;
    public int MatchWidth { get; private set; }
    public int MatchHeight { get; private set; }
    public int MatchDepthWidth { get; private set; }
    public int MatchDepthHeight { get; private set; }
    //儲存點擊位置
    Point _pointOne = new Point();
    Point _pointTwo = new Point();

    //設定螢幕與輸入cam的影像大小
    int _currentWidth;
    int _currentHeight;
    public int _inputWidth;
    public int _inputHeight;
    public int _inputDepthWidth ;
    public int _inputDepthHeight;
    
    //滑鼠是否點擊
    private bool mouseclick = false;
    
    //繪圖顏色
    Scalar _color = new Scalar(255, 0, 0);

    //get kinect color texture
    public ColorSourceManager ColorSourceManager;
    public DepthToMatManager DepthToMatManager;

    //output to texture
    Texture2D _souceOut;
    Texture2D _matchDepthOut100;
    Texture2D _matchOut100;

    //screen size to source size
    private clickPositionTrans _positionTrans;

    private double _rateWidthRGBDepth = 1;
    private double _rateHeightRGBDepth = 1;

    private bool isInput;

    public Mat GetBlockMat()
    {
        return _matchImage;
    }
    public Mat GetBlockDepthMat()
    {
        return _matchDepthImage;
    }
    // Use this for initialization
    void Start () {
        //this.gameObject.transform.localScale = new Vector3(Screen.width, Screen.height);
        //cam設定與啟用
        MatchWidth = 0;
        MatchHeight = 0;
        MatchDepthWidth = 0;
        MatchDepthHeight = 0;

        //取得螢幕與輸入cam的影像大小
        _inputWidth = ColorSourceManager.ColorWidth;
        _inputHeight = ColorSourceManager.ColorHeight;
        Debug.Log(_inputWidth);
        //_inputDepthWidth = DepthToMatManager.getWidth();
        //_inputDepthHeight = DepthToMatManager.getheight();
        //取得RGB和depth的倍數關係
        _rateWidthRGBDepth = (double)_inputWidth / (double)_inputDepthWidth;
        _rateHeightRGBDepth = (double)_inputHeight / (double)_inputDepthHeight;
        _currentWidth = Screen.width;
        _currentHeight = Screen.height;
        //螢幕大小與來源比例初始化
        _positionTrans = new clickPositionTrans(_currentWidth, _currentHeight, _inputWidth, _inputHeight);
        
        //text size
        _currentWidth = _inputWidth;
        _currentHeight = _inputHeight;
        //創造mat儲存影像
        _sourceMat = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC3);
        //_sourceMatDepth = new Mat(_inputDepthHeight, _inputDepthWidth, CvType.CV_8UC1);

        //創造mat儲存比對用mat(原始比對圖形為未改變比例)
        _matchImage = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC3);
        //_matchDepthImage = new Mat(_inputDepthHeight, _inputDepthWidth, CvType.CV_8UC1);
        _souceOut = new Texture2D(_inputWidth, _inputHeight);
        _matchOut100 = new Texture2D(100, 100);
        _matchDepthOut100 = new Texture2D(100, 100);

        isInput = false;
    }
	
	// Update is called once per frame
	void Update () {

        //將輸入轉成mat方便openCV使用
        //Utils.webCamTextureToMat(_webcam, _nMat);
        if (Input.GetKeyUp(KeyCode.Z))
        {
            isInput = !isInput;
        }
        if (!isInput)
        {
            ColorSourceManager.GetColorMat().copyTo(_sourceMat);
        }
        
        //_sourceMatDepth = DepthToMatManager.getDepthMat();
        //將輸入的影像轉換成螢幕大小
        //Imgproc.resize(_sourceMat, _screenMat, _screenMat.size());
        if(mouseclick)TestPointmove();

        if (!mouseclick && MatchHeight != 0 && MatchWidth != 0) {
            TestPointUp();
        }
        //畫框框
        Imgproc.rectangle(_sourceMat, _pointOne, _pointTwo, _color, 4);

        //創造2D影像(空的)
        if(_souceOut == null)
        {
            _souceOut = new Texture2D(_inputWidth, _inputHeight);
        }
        //將mat轉換回2D影像
        
        Utils.matToTexture2D(_sourceMat, _souceOut);
        //放入輸出rawImage
        _inoutImg.texture = _souceOut;        
	}

    public void TestPointDown()//滑鼠點擊
    {
        //取得滑鼠在螢幕上點擊的位置
        float x = Input.mousePosition.x;
        float y = Screen.height - Input.mousePosition.y;

        if (Input.GetMouseButton(1))
        {
            Point newPos = _positionTrans.TransToScreen2Pos(new Point(x, y));
            double[] getPix = _sourceMat.get((int)newPos.y, (int)newPos.x);
            Debug.Log(getPix[0] + ","  + getPix[1] + "," + getPix[2]);
        }
        else
        {
        

            //存入list
            _pointOne = _positionTrans.TransToScreen2Pos(new Point(x, y));
            _pointTwo = _positionTrans.TransToScreen2Pos(new Point(x, y));


            Debug.Log(Input.mousePosition.x.ToString() + " " + Input.mousePosition.y.ToString());
            mouseclick = true;
        }
        
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
        MatchDepthWidth = (int)((double)(MaxX - minX) / _rateWidthRGBDepth);
        MatchDepthHeight = (int)((double)(MaxY - minY) / _rateHeightRGBDepth);
        _matchImage = new Mat(MatchWidth, MatchHeight,CvType.CV_8UC3);
        //_matchDepthImage = new Mat(MatchDepthWidth, MatchDepthHeight, CvType.CV_8UC1);

        //做一個新的Mat存放切割後的Mat
        Mat subMat = new Mat();
        subMat = _sourceMat.submat(minY, MaxY, minX, MaxX);
        subMat.copyTo(_matchImage);        

        //_matchImage = _sourceMat.submat(minY, MaxY, minX, MaxX);
        //_matchDepthImage = _sourceMatDepth.submat(
        //    (int)((double)minY / _rateHeightRGBDepth),
        //    (int)((double)MaxY / _rateHeightRGBDepth),
        //    (int)((double)minX / _rateWidthRGBDepth),
        //    (int)((double)MaxX / _rateWidthRGBDepth));
        //反轉化面
        Point src_center = new Point(_matchImage.cols() / 2.0, _matchImage.rows() / 2.0);
        Mat rot_mat = Imgproc.getRotationMatrix2D(src_center, 180, 1.0);
        Imgproc.warpAffine(_matchImage, _matchImage, rot_mat, _matchImage.size());

        //比對圖形輸出
        Mat _OutMatchMat = new Mat(100, 100, CvType.CV_8UC3);
        Imgproc.resize(_matchImage, _OutMatchMat, _OutMatchMat.size());

        //比對圖形輸出(深度)
        Mat _OutMatchDepthMat = new Mat(100, 100, CvType.CV_8UC1);
        //Imgproc.resize(_matchDepthImage, _OutMatchDepthMat, _OutMatchDepthMat.size());

        //擷取輸出
        Utils.matToTexture2D(_OutMatchMat, _matchOut100);
        _blockImg.texture = _matchOut100;
        //擷取輸出(顯示深度的切割結果)
        //Utils.matToTexture2D(_OutMatchDepthMat, _matchDepthOut100);
        //_blockDepthImg.texture = _matchDepthOut100;
    }
    public void TestPointmove()//滑鼠放開
    {
        //取得滑鼠在螢幕放開的位置
        float x = Input.mousePosition.x;
        float y = Screen.height - Input.mousePosition.y;
        //存入list
        _pointTwo = _positionTrans.TransToScreen2Pos(new Point(x, y));

        //Debug.Log(Input.mousePosition.x.ToString() + " " + Input.mousePosition.y.ToString());
    }
}
