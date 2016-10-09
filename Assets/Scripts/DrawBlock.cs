using UnityEngine;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System.Threading;

public class DrawBlock : MonoBehaviour {

    //輸出畫面
    public RawImage _inoutImg;
    public RawImage _blockImg;
    public RawImage _blockDepthImg;
    public RawImage _blockDepthBg;

    //輸出畫面資料
    private Mat _sourceMat;
    private Mat _sourceMat_backup;
    private Mat _sourceMatDepth;

    //結果圖片
    private Mat _blockImage;
    private Mat _blockDepthImage;
    private Mat _blockDepthBackGroundImage;
    //穩定狀態的畫面
    private Mat _smoothesImage;
    public int MatchWidth { get; private set; }
    public int MatchHeight { get; private set; }
    //儲存點擊位置
    private Point _pointOne = new Point();
    private Point _pointTwo = new Point();
    public int _minX { get; private set; }
    public int _maxX { get; private set; }
    public int _minY { get; private set; }
    public int _maxY { get; private set; }
    public bool SelectedBlock { get; private set; }

    //設定螢幕與輸入cam的影像大小
    private int _currentWidth;
    private int _currentHeight;
    private int _inputWidth;
    private int _inputHeight;
    private ushort[] _depthData;

    //滑鼠是否點擊
    private bool mouseclick = false;
    
    //繪圖顏色
    Scalar _color = new Scalar(255, 0, 0);

    //get kinect color texture
    public ColorSourceManager ColorSourceManager;
    public DepthSourceManager DepthSourceManager;

    //output to texture
    Texture2D _souceOut;
    Texture2D _blockDepthTexture;
    Texture2D _blockTexture;
    Texture2D _blockDepthTextureBg;

    //screen size to source size
    private clickPositionTrans _positionTrans;

    //暫停畫面switch變數
    private bool isInput;

    //mapManager
    public mapColorAndDepth _map;

    //選取區深度資料
    List<ushort> _depthDataSub = new List<ushort>();
    List<Point> _depthDataSubColorPoint = new List<Point>();
    //深度的背景
    List<ushort> _depthDataSubBackGround = new List<ushort>();

    //設定深度偵測距離(mm)
    public int _minDepthDistance = 500;
    public int _maxDepthDistance = 1000;
    //同步影像
    private bool _SyncFlag;
    private Mat _blockImageBuffer;
    //是否完成影像處理的旗標
    public bool _ScreenSettingCompletionFlag { get; set; }
    //是否有發生影像變動旗標
    public bool _DepthImageChangeFlag { get; set; }

    //thread
    Thread _thread;

    public Mat GetBlockMat()
    {
        return _blockImage;
    }
    public Mat GetBlockDepthMat()
    {
        return _blockDepthImage;
    }
    // Use this for initialization
    void Start () {
        //cam設定與啟用
        MatchWidth = 0;
        MatchHeight = 0;

        //取得螢幕與輸入cam的影像大小
        _inputWidth = ColorSourceManager.ColorWidth;
        _inputHeight = ColorSourceManager.ColorHeight;
        _depthData = DepthSourceManager.GetData();
        //Debug.Log(_depthData.Length);

        //螢幕大小與來源比例初始化
        _currentWidth = Screen.width;
        _currentHeight = Screen.height;
        _positionTrans = new clickPositionTrans(_currentWidth, _currentHeight, _inputWidth, _inputHeight);
        
        //創造mat儲存輸出影像
        _sourceMat = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC3);
        _sourceMat_backup = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC3);
        _sourceMatDepth = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC1);
        _blockImageBuffer = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC1);
        //創造mat儲存比對用mat(原始比對圖形為未改變比例)
        _blockImage = new Mat(_inputHeight, _inputWidth, CvType.CV_8UC3);
        _souceOut = new Texture2D(_inputWidth, _inputHeight);
        _blockTexture = new Texture2D(100, 100);
        _blockDepthTexture = new Texture2D(320, 180);
        _blockDepthTextureBg = new Texture2D(320, 180);

        isInput = false;
        //設定同步旗標
        _SyncFlag = false;
        //thread
        _thread = new Thread(drawDepthSourceMat);
        //設定是否完成影像背景偵測
        _ScreenSettingCompletionFlag = false;
        //選擇範圍初始化
        _minX = 0; _maxX = 0; _minY = 0; _maxY = 0;
        SelectedBlock = false;
        //設定影像改變旗標
        _DepthImageChangeFlag = true;
    }
	
	// Update is called once per frame
	void Update () {
        //讓選框狀態時暫停影像
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
        //滑鼠點擊判斷
        if (mouseclick)
        {
            pointMove();
        }
        else if (!mouseclick && MatchHeight != 0 && MatchWidth != 0) {
            runDrawBlock();
            if(!SelectedBlock) SelectedBlock = true;
        }
        else
        {
            if (SelectedBlock) SelectedBlock = false;
        }
        //畫選取框框
        Imgproc.rectangle(_sourceMat, _pointOne, _pointTwo, _color, 4);

        //創造2D影像(空的)
        if(_souceOut == null)
        {
            _souceOut = new Texture2D(_inputWidth, _inputHeight);
        }
        //翻轉影像
        ReversedImage(_sourceMat).copyTo(_sourceMat);
        //將mat轉換回2D影像
        Utils.matToTexture2D(_sourceMat, _souceOut);
        //放入輸出rawImage
        _inoutImg.texture = _souceOut;        
	}

    public void pointDown()//滑鼠點擊
    {
        //取得滑鼠在螢幕上點擊的位置
        float x = Screen.width - Input.mousePosition.x;
        float y = Input.mousePosition.y;

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
            mouseclick = true;
        }
        
    }

    public void pointUp()//滑鼠放開
    {
        //設定滑鼠點擊
        mouseclick = false;
        //儲存選取區塊座標
        if (_pointTwo.x >= _pointOne.x)
        {
            _maxX = (int)_pointTwo.x;
            _minX = (int)_pointOne.x;
        }
        else if (_pointTwo.x < _pointOne.x)
        {
            _maxX = (int)_pointOne.x;
            _minX = (int)_pointTwo.x;
        }
        if (_pointTwo.y >= _pointOne.y)
        {
            _maxY = (int)_pointTwo.y;
            _minY = (int)_pointOne.y;
        }
        else if (_pointTwo.y < _pointOne.y)
        {
            _maxY = (int)_pointOne.y;
            _minY = (int)_pointTwo.y;
        }

        MatchWidth = _maxX - _minX;
        MatchHeight = _maxY - _minY;
    }

    public void runDrawBlock()//區塊影像處理
    {
        updateColorTexture();
        updateDepthTexture();

    }

    public void pointMove()//滑鼠移動
    {
        //取得滑鼠在螢幕放開的位置
        float x = Screen.width - Input.mousePosition.x;
        float y = Input.mousePosition.y;
        //存入list
        _pointTwo = _positionTrans.TransToScreen2Pos(new Point(x, y));

        //Debug.Log(Input.mousePosition.x.ToString() + " " + Input.mousePosition.y.ToString());
    }

    // =====================
    // color資料影像處理 ===
    // =====================
    private void updateColorTexture()
    {
        _blockImage = new Mat();

        //抓取sub depth data
       // Debug.Log(_minX + ", " + _minY);
        //Debug.Log(_maxX + ", " + _maxY);

        //做一個新的Mat存放切割後的Mat
        Mat subMat = new Mat();
        subMat = _sourceMat.submat(_minY, _maxY, _minX, _maxX);
        subMat.copyTo(_blockImage);

        //反轉化面
        ReversedImage(_blockImage).copyTo(_blockImage);

        //區塊畫面壓縮輸出
        Mat outMat = new Mat(100, 100, CvType.CV_8UC3);
        Imgproc.resize(_blockImage, outMat, outMat.size());

        //擷取輸出
        Utils.matToTexture2D(outMat, _blockTexture);
        _blockImg.texture = _blockTexture;

        subMat.release();
        outMat.release();
    }

    // =====================
    // depth資料影像處理 ===
    // =====================

    private void updateDepthTexture()
    {
        _blockDepthImage = new Mat();
        // 獲得depth資料與座標
        getDepthData(_minX, _minY, _maxX, _maxY);
        // 畫出選取區的depth畫面
        _thread = new Thread(drawDepthSourceMat);
        _thread.Start();
        _thread.Join();
        _thread.Abort();

        //做一個新的depthMat存放切割後的depthMat
        Mat subDepthMat = new Mat();
        if(_SyncFlag)
            subDepthMat = _sourceMatDepth.submat((_sourceMatDepth.height() - _maxY), (_sourceMatDepth.height() - _minY), _minX, _maxX);
        else
            subDepthMat = _blockImageBuffer.submat((_blockImageBuffer.height() - _maxY), (_blockImageBuffer.height() - _minY), _minX, _maxX);
        //反轉化面
        ReversedImage(subDepthMat).copyTo(subDepthMat);

        // 膨脹收縮 處理depth影像
        Mat depthMatchImagePorcess = new Mat();
        subDepthMat.copyTo(depthMatchImagePorcess);
        Mat erodeElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(7, 7));
        Mat dilateElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(5, 5));
        
        Imgproc.dilate(depthMatchImagePorcess, depthMatchImagePorcess, dilateElement);
        Imgproc.erode(depthMatchImagePorcess, depthMatchImagePorcess, erodeElement);
        //Imgproc.erode(depthMatchImagePorcess, depthMatchImagePorcess, erodeElement);

        //設定背景深度 快捷鍵L
        setDepthSourceBackGroundMat(depthMatchImagePorcess);

        
        //減去背景深度
        Core.absdiff(depthMatchImagePorcess, _blockDepthBackGroundImage, depthMatchImagePorcess);

        //二值化
        Imgproc.threshold(depthMatchImagePorcess, depthMatchImagePorcess, 50, 255, Imgproc.THRESH_BINARY);

        //平滑處理(之後嘗試看看)
        SmoothesImage(depthMatchImagePorcess).copyTo(depthMatchImagePorcess);

        //設定Canny參數
        //double threshold = 50.0;
        //做Canny輪廓化
        //Imgproc.Canny(depthMatchImagePorcess, depthMatchImagePorcess, threshold, threshold * 3);
        Imgproc.blur(depthMatchImagePorcess, depthMatchImagePorcess, new OpenCVForUnity.Size(8, 8));
        Imgproc.threshold(depthMatchImagePorcess, depthMatchImagePorcess, 50, 255, Imgproc.THRESH_BINARY);
        //傳出深度
        depthMatchImagePorcess.copyTo(_blockDepthImage);


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

        //圖形壓縮輸出(深度)
        Mat outDepthMat = new Mat(180, 320, CvType.CV_8UC1);
        Imgproc.resize(_blockDepthImage, outDepthMat, outDepthMat.size());

        //反轉化面
        ReversedImage(outDepthMat).copyTo(outDepthMat);

        //擷取輸出(顯示深度的切割結果)
        Utils.matToTexture2D(outDepthMat, _blockDepthTexture);
        _blockDepthImg.texture = _blockDepthTexture;

        //輸出到遊戲背景
        Imgproc.dilate(outDepthMat, outDepthMat, dilateElement);
        Imgproc.blur(outDepthMat, outDepthMat, new Size(20, 20));
        Core.bitwise_not(outDepthMat, outDepthMat);
        Utils.matToTexture2D(outDepthMat, _blockDepthTextureBg);
        _blockDepthBg.texture = _blockDepthTextureBg;


        subDepthMat.release();
        depthMatchImagePorcess.release();
        outDepthMat.release();
    }

    private void getDepthData(int minX, int minY, int maxX, int maxY)//透過color影像使用內建map class抓取區塊深度資料
    {
        _depthDataSub.Clear();
        _depthDataSubColorPoint.Clear();
        for (int depthIndex = 0; depthIndex < _depthData.Length; depthIndex++)
        {
            Point colorPoint = _map.DepthIndexToColorPoint(depthIndex);
            if (colorPoint.x > minX && colorPoint.x < maxX && colorPoint.y > (_sourceMatDepth.height() - maxY) && colorPoint.y < (_sourceMatDepth.height() - minY))
            {
                _depthDataSubColorPoint.Add(colorPoint);
                _depthDataSub.Add(_depthData[depthIndex]);
            }
        }
    }

    private void drawDepthSourceMat()//畫出depth影像
    {

        Mat procMat = new Mat(_sourceMatDepth.height(), _sourceMatDepth.width(), CvType.CV_8UC1);
        for (int i = 0; i < _depthDataSub.Count; i++)
        {
            double avg;
            if (_depthDataSub[i] > _maxDepthDistance || _depthDataSub[i] < _minDepthDistance) //大於最大距離不顯示
            {
                avg = 0;
            }
            else
            {
                if(_depthDataSubBackGround.Count > 0)
                {
                    avg = 255 - ((double)(_depthDataSub[i] - _depthDataSubBackGround[i]) / (1) * 255); //顯示範圍內深度顏色
                }
                else
                    avg = 255 - ((double)(_depthDataSub[i] - _minDepthDistance) / (_maxDepthDistance - _minDepthDistance) * 255); //顯示範圍內深度顏色
               // avg = 255; //binary
            }

            double[] color = new double[1] { avg };
            procMat.put((int)_depthDataSubColorPoint[i].y, (int)_depthDataSubColorPoint[i].x, color);
        }
        if (_SyncFlag)
        {
            procMat.copyTo(_blockImageBuffer);
            _SyncFlag = false;
        }
        else{
            procMat.copyTo(_sourceMatDepth);
            _SyncFlag = true;
        }
        procMat.release();
    }
    private void setDepthSourceBackGroundMat(Mat BackGround)//取得背景Depth資訊
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            _depthDataSubBackGround.Clear();
            for (int i = 0;i< _depthDataSub.Count; i++)
            {
                _depthDataSubBackGround.Add(_depthDataSub[i]);
            }
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            int MaxDepth = 0;
            for (int i = 0; i < _depthDataSub.Count; i++)
            {
                if (_depthDataSub[i] > MaxDepth) MaxDepth = _depthDataSub[i];
            }
            _maxDepthDistance = MaxDepth;
            _minDepthDistance = MaxDepth - 200;
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            //創造背景深度Mat
            _blockDepthBackGroundImage = new Mat();
            BackGround.copyTo(_blockDepthBackGroundImage);
            _ScreenSettingCompletionFlag = true;
        }
        else if (_blockDepthBackGroundImage == null)
        {
            _blockDepthBackGroundImage = new Mat();
            _blockDepthBackGroundImage.setTo(new Scalar(0, 0, 0));
        }
    }
    //平滑影像(若與上一張圖片相差過少將不更新畫面)
    private Mat SmoothesImage(Mat currentImage)
    {
        Mat hierarchy = new Mat();
        List<MatOfPoint> contours = new List<MatOfPoint>();
        Mat diffImage = new Mat();
        if (_smoothesImage == null)
        {
            _smoothesImage = new Mat(currentImage.height(), currentImage.width(), CvType.CV_8UC1);
            currentImage.copyTo(_smoothesImage);
        }
        Core.absdiff(currentImage, _smoothesImage, diffImage);
        Imgproc.findContours(diffImage, contours, hierarchy,Imgproc.RETR_EXTERNAL, Imgproc.CHAIN_APPROX_SIMPLE);
        for (int index = 0; index < contours.Count; index++)
        {
            OpenCVForUnity.Rect tempRect = Imgproc.boundingRect(contours[index]);
            //差異面積
            if(tempRect.area() > 1000)
            {
                currentImage.copyTo(_smoothesImage);
                _DepthImageChangeFlag = true;
                return currentImage;
            }
        }
        return _smoothesImage;
    }
    //反轉畫面
    private Mat ReversedImage(Mat inImage)
    {
        Mat TempWarpMat = new Mat();
        Point src_center = new Point(inImage.cols() / 2.0, inImage.rows() / 2.0);
        Mat rot_mat = Imgproc.getRotationMatrix2D(src_center, 180, 1.0);
        Imgproc.warpAffine(inImage, TempWarpMat, rot_mat, inImage.size());
        TempWarpMat.copyTo(inImage);
        return inImage;
    }
}
