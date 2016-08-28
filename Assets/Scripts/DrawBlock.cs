using UnityEngine;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System.Threading;

public class DrawBlock : MonoBehaviour {

    public RawImage _inoutImg;
    public RawImage _blockImg;
    public RawImage _blockDepthImg;
    private Mat _sourceMat;
    private Mat _sourceMat_backup;
    private Mat _sourceMatDepth;

    //結果圖片
    private Mat _blockImage;
    private Mat _blockDepthImage;
    public int MatchWidth { get; private set; }
    public int MatchHeight { get; private set; }
    //儲存點擊位置
    private Point _pointOne = new Point();
    private Point _pointTwo = new Point();
    private int _minX = 0, _maxX = 0, _minY = 0, _maxY = 0;

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

    //screen size to source size
    private clickPositionTrans _positionTrans;

    //暫停畫面switch變數
    private bool isInput;

    //mapManager
    public mapColorAndDepth _map;

    //選取區深度資料
    List<ushort> _depthDataSub = new List<ushort>();
    List<Point> _depthDataSubColorPoint = new List<Point>();

    //設定深度偵測距離(mm)
    public int _minDepthDistance = 500;
    public int _maxDepthDistance = 1000;
    //同步影像
    private bool _SyncFlag;
    private Mat _blockImageBuffer;

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
        Debug.Log(_inputWidth);
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
        _blockDepthTexture = new Texture2D(100, 100);

        isInput = false;
        //設定同步旗標
        _SyncFlag = false;
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
        }
        //畫選取框框
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

    public void pointDown()//滑鼠點擊
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
        float x = Input.mousePosition.x;
        float y = Screen.height - Input.mousePosition.y;
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
        Point src_center = new Point(_blockImage.cols() / 2.0, _blockImage.rows() / 2.0);
        Mat rot_mat = Imgproc.getRotationMatrix2D(src_center, 180, 1.0);
        Imgproc.warpAffine(_blockImage, _blockImage, rot_mat, _blockImage.size());

        //區塊畫面壓縮輸出
        Mat outMat = new Mat(100, 100, CvType.CV_8UC3);
        Imgproc.resize(_blockImage, outMat, outMat.size());

        //擷取輸出
        Utils.matToTexture2D(outMat, _blockTexture);
        _blockImg.texture = _blockTexture;
    }

    // =====================
    // depth資料影像處理 ===
    // =====================

    private void updateDepthTexture()
    {
        _blockDepthImage = new Mat();
        
        // 畫出選取區的depth畫面
        Thread thread = new Thread(drawDepthSourceMat);
        thread.IsBackground = true;
        thread.Start();

        //做一個新的depthMat存放切割後的depthMat
        Mat subDepthMat = new Mat();
        if(_SyncFlag)
            subDepthMat = _sourceMatDepth.submat((_sourceMatDepth.height() - _maxY), (_sourceMatDepth.height() - _minY), _minX, _maxX);
        else
            subDepthMat = _blockImageBuffer.submat((_blockImageBuffer.height() - _maxY), (_blockImageBuffer.height() - _minY), _minX, _maxX);
        //反轉化面
        Mat TempWarpMat = new Mat();
        Point src_center = new Point(subDepthMat.cols() / 2.0, subDepthMat.rows() / 2.0);
        Mat rot_mat = Imgproc.getRotationMatrix2D(src_center, 180, 1.0);
        Imgproc.warpAffine(subDepthMat, TempWarpMat, rot_mat, _blockImage.size());

        // 膨脹收縮 處理depth影像
        Mat depthMatchImagePorcess = new Mat();
        TempWarpMat.copyTo(depthMatchImagePorcess);
        Mat erodeElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(7, 7));
        Mat dilateElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(5, 5));

        Imgproc.dilate(depthMatchImagePorcess, depthMatchImagePorcess, dilateElement);
        Imgproc.erode(depthMatchImagePorcess, depthMatchImagePorcess, erodeElement);
        //Imgproc.erode(depthMatchImagePorcess, depthMatchImagePorcess, erodeElement);

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
        Mat outDepthMat = new Mat(100, 100, CvType.CV_8UC1);
        Imgproc.resize(_blockDepthImage, outDepthMat, outDepthMat.size());

        //擷取輸出(顯示深度的切割結果)
        Utils.matToTexture2D(outDepthMat, _blockDepthTexture);
        _blockDepthImg.texture = _blockDepthTexture;
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
        // 獲得depth資料與座標
        getDepthData(_minX, _minY, _maxX, _maxY);

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
                avg = 255 - ((double)(_depthDataSub[i] - _minDepthDistance) / (_maxDepthDistance - _minDepthDistance) * 255); //顯示範圍內深度顏色
                //avg = 255; //binary
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
    }
}
