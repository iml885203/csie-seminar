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
    private Mat _sourceMat_backup;
    public Mat _sourceMatDepth;

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
    public ushort[] _depthData;

    //滑鼠是否點擊
    private bool mouseclick = false;
    
    //繪圖顏色
    Scalar _color = new Scalar(255, 0, 0);

    //get kinect color texture
    public ColorSourceManager ColorSourceManager;
    public DepthSourceManager DepthSourceManager;

    //output to texture
    Texture2D _souceOut;
    Texture2D _matchDepthOut100;
    Texture2D _matchOut100;

    //screen size to source size
    private clickPositionTrans _positionTrans;

    private double _rateWidthRGBDepth = 1;
    private double _rateHeightRGBDepth = 1;

    private bool isInput;

    //mapManager
    public mapColorAndDepth _map;

    //選取區深度資料
    List<ushort> _depthDataSub = new List<ushort>();
    List<Point> _depthDataSubColorPoint = new List<Point>();

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
        _depthData = DepthSourceManager.GetData();
        Debug.Log(_depthData.Length);
        //_inputDepthWidth = DepthToMatManager.getWidth();
        //_inputDepthHeight = DepthToMatManager.getheight();
        //取得RGB和depth的倍數關係
        //_rateWidthRGBDepth = (double)_inputWidth / (double)_inputDepthWidth;
        //_rateHeightRGBDepth = (double)_inputHeight / (double)_inputDepthHeight;
        _currentWidth = Screen.width;
        _currentHeight = Screen.height;
        //螢幕大小與來源比例初始化
        _positionTrans = new clickPositionTrans(_currentWidth, _currentHeight, _inputWidth, _inputHeight);
        
        //text size
        _currentWidth = _inputWidth;
        _currentHeight = _inputHeight;
        //創造mat儲存影像
        _sourceMat = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC3);
        _sourceMat_backup = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC3);
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
            _sourceMat.copyTo(_sourceMat_backup);
        }
        else
        {
            _sourceMat_backup.copyTo(_sourceMat);
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


        int minX = 0, maxX = 1000, minY = 0, maxY = 1000;
        if (_pointTwo.x >= _pointOne.x)
        {
            maxX = (int)_pointTwo.x;
            minX = (int)_pointOne.x;
        }
        else if (_pointTwo.x < _pointOne.x)
        {
            maxX = (int)_pointOne.x;
            minX = (int)_pointTwo.x;
        }
        if (_pointTwo.y >= _pointOne.y)
        {
            maxY = (int)_pointTwo.y;
            minY = (int)_pointOne.y;
        }
        else if (_pointTwo.y < _pointOne.y)
        {
            maxY = (int)_pointOne.y;
            minY = (int)_pointTwo.y;
        }
        updateColorTexture(minX, minY, maxX, maxY);
        updateDepthTexture(minX, minY, maxX, maxY);
        
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

    // =====================
    // color資料影像處理 ===
    // =====================
    private void updateColorTexture(int minX, int minY, int maxX, int maxY)
    {
        MatchWidth = maxX - minX;
        MatchHeight = maxY - minY;
        //MatchDepthWidth = (int)((double)(maxX - minX) / _rateWidthRGBDepth);
        //MatchDepthHeight = (int)((double)(maxY - minY) / _rateHeightRGBDepth);
        _matchImage = new Mat(MatchWidth, MatchHeight, CvType.CV_8UC3);

        //抓取sub depth data
        Debug.Log(minX + ", " + minY);
        Debug.Log(maxX + ", " + maxY);

        //做一個新的Mat存放切割後的Mat
        Mat subMat = new Mat();
        subMat = _sourceMat.submat(minY, maxY, minX, maxX);
        subMat.copyTo(_matchImage);

        //反轉化面
        Point src_center = new Point(_matchImage.cols() / 2.0, _matchImage.rows() / 2.0);
        Mat rot_mat = Imgproc.getRotationMatrix2D(src_center, 180, 1.0);
        Imgproc.warpAffine(_matchImage, _matchImage, rot_mat, _matchImage.size());

        //比對圖形輸出
        Mat _OutMatchMat = new Mat(100, 100, CvType.CV_8UC3);
        Imgproc.resize(_matchImage, _OutMatchMat, _OutMatchMat.size());

        //擷取輸出
        Utils.matToTexture2D(_OutMatchMat, _matchOut100);
        _blockImg.texture = _matchOut100;
    }

    // =====================
    // depth資料影像處理 ===
    // =====================

    private void updateDepthTexture(int minX, int minY, int maxX, int maxY)
    {
        MatchWidth = maxX - minX;
        MatchHeight = maxY - minY;
        _matchDepthImage = new Mat(MatchDepthWidth, MatchDepthHeight, CvType.CV_8UC1);

        // 獲得depth資料與座標
        getDepthData(minX, minY, maxX, maxY);

        // 新建與_sourceMat一樣大的mat，並畫出選取區的depth畫面
        Mat newDepthSource = new Mat(_sourceMat.height(), _sourceMat.width(), CvType.CV_8UC1);
        drawDepthSourceMat(newDepthSource);

        //做一個新的depthMat存放切割後的depthMat
        Mat subDepthMat = new Mat();
        subDepthMat = newDepthSource.submat(minY, maxY, minX, maxX);

        // 膨脹收縮 處理depth影像
        Mat depthMatchImagePorcess = new Mat();
        subDepthMat.copyTo(depthMatchImagePorcess);
        Mat erodeElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(7, 7));
        Mat dilateElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(5, 5));

        Imgproc.dilate(depthMatchImagePorcess, depthMatchImagePorcess, dilateElement);
        Imgproc.erode(depthMatchImagePorcess, depthMatchImagePorcess, erodeElement);
        Imgproc.erode(depthMatchImagePorcess, depthMatchImagePorcess, erodeElement);

        depthMatchImagePorcess.copyTo(_matchDepthImage);

        // canny 取出輪廓
        //Imgproc.blur(matchImagePorcess, matchImagePorcess, new Size(3, 3));
        //Imgproc.Canny(matchImagePorcess, _matchDepthImage, 50, 150);

        //Imgproc.dilate(_matchDepthImage, _matchDepthImage, dilateElement);
        //Imgproc.dilate(_matchDepthImage, _matchDepthImage, dilateElement);

        //Mat hierarchy = new Mat();
        //List<MatOfPoint> contours = new List<MatOfPoint>();
        ////Imgproc.findContours(_matchImage, contours, hierarchy, Imgproc.RETR_EXTERNAL, Imgproc.CHAIN_APPROX_NONE);//Imgproc.RETR_EXTERNAL那邊0-3都可以
        //Imgproc.findContours(_matchImage, contours, hierarchy, Imgproc.RETR_LIST, Imgproc.CHAIN_APPROX_SIMPLE);
        //for (int i = 0; i < contours.Count; i++)
        //{
        //    Imgproc.drawContours(_matchImage, contours, i, new Scalar(255, 255, 255), 2);
        //}

        //比對圖形輸出(深度)
        Mat outMatchDepthMat = new Mat(100, 100, CvType.CV_8UC1);
        Imgproc.resize(_matchDepthImage, outMatchDepthMat, outMatchDepthMat.size());

        //擷取輸出(顯示深度的切割結果)
        Utils.matToTexture2D(outMatchDepthMat, _matchDepthOut100);
        _blockDepthImg.texture = _matchDepthOut100;
    }

    private void getDepthData(int minX, int minY, int maxX, int maxY)
    {
        _depthDataSub.Clear();
        _depthDataSubColorPoint.Clear();
        for (int depthIndex = 0; depthIndex < _depthData.Length; depthIndex++)
        {
            Point colorPoint = _map.DepthIndexToColorPoint(depthIndex);
            if (colorPoint.x > minX && colorPoint.x < maxX && colorPoint.y > minY && colorPoint.y < maxY)
            {
                _depthDataSubColorPoint.Add(colorPoint);
                _depthDataSub.Add(_depthData[depthIndex]);
            }
        }
    }

    private void drawDepthSourceMat(Mat newDepthSource)
    {
        for (int i = 0; i < _depthDataSub.Count; i++)
        {
            double avg;
            if (_depthDataSub[i] > 1000) //大於100公分不顯示
            {
                avg = 0;
            }
            else
            {
                avg = 255 - ((double)(_depthDataSub[i] - 500) / 500 * 255); //顯示50公分到100公分深度顏色
                //avg = 255; //binary
            }

            double[] color = new double[1] { avg };
            newDepthSource.put((int)_depthDataSubColorPoint[i].y, (int)_depthDataSubColorPoint[i].x, color);
        }
    }
}
