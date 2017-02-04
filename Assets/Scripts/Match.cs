using System;
using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading;

public class Match : MonoBehaviour {
    /*color match*/
    private Scalar _blockColor = new Scalar(255, 0, 0);
    private Scalar _backgroundColor = new Scalar(0, 255, 0);
    private Texture2D _matchTexture;
    private int _matchWidth;
    private int _matchHeight;
    private Mat hsvMat;
    private Mat thresholdMat;

    //最小depth物件趴數參數
    private const float _minDepthObjectSizePer = .001f;

    /*drawBlock*/
    public DrawBlock _drawBlock;
    private Mat blockMat;
    /*public data*/
    public int Width { get; private set; }
    public int Height { get; private set; }
    
    //變動區塊範圍
    public List<OpenCVForUnity.Rect> _changeRectList { get; set;}

    //物體資訊
    public List<BaseObject> SensingResults = new List<BaseObject>();
    public int _clolrRange = 15;
    public int _colorHsvRange = 10;
    public int _distanceRange = 2;
    public int _colorDiffRange = 23;
    //物體資訊Text讀存檔
    public GameObject ColorSaveData;
    //是否可以儲存感測到的物件
    private bool isSave = new bool();

    //傳給遊戲的結果
    private OpenCVForUnity.Rect _DepthRect;

    private GameStateIndex _gmaeStatusManager;
    private bool _useRotateLaserGenerator;


    //偵測到的Object
    public List<MatchObject> _matchObjectList { get; set; } 
    public List<MatchObject> _matchColorObjectList { get; set; }
    public Texture2D GetMatchTexture()
    {
        return _matchTexture;
    }
    public OpenCVForUnity.Rect GetDepthRect()
    {
        return _DepthRect;
    }
  
    // Use this for initialization
    void Start()
    {
        _matchWidth = 800;
        _matchHeight = 450;
        _matchTexture = new Texture2D(_matchWidth, _matchHeight);
        isSave = false;
        _matchObjectList = new List<MatchObject>();
        _matchColorObjectList = new List<MatchObject>();
        _changeRectList = new List<OpenCVForUnity.Rect>();
        _gmaeStatusManager = transform.root.Find("/GameState").GetComponent<GameStateIndex>();
        //讀取ObjectColor.txt
        SensingResults = ColorSaveData.GetComponent<ColorSaveData>().ReadColorData();
        _useRotateLaserGenerator = true;
    }
    // Update is called once per frame
    void Update () {
        if (_gmaeStatusManager.CurrentStateIndex != GameState.GameRun && _gmaeStatusManager.CurrentStateIndex != GameState.Menu)
        {
            _matchColorObjectList.Clear();
            return;
        }
        //確認已開啟攝影機
        if (_drawBlock.MatchHeight == 0 && _drawBlock.MatchWidth == 0) return;
        // ==========================
        // set public Width Height ==
        // ==========================
        Width = _drawBlock.MatchWidth;
        Height = _drawBlock.MatchHeight;
        //設定是否儲存特徵物體
        SetIsSave();
        //設定是否使用旋轉砲台
        SetUseRotate();
        //宣告存放深度與色彩影像
        Mat _ClolrMat = new Mat();
        Mat _DepthMat = new Mat();
        //取得影像資訊
        _ClolrMat = _drawBlock.GetBlockMat();
        _DepthMat = _drawBlock.GetBlockDepthMat();
        if (_ClolrMat == null || _DepthMat == null)
            return;
        //宣告結果影像
        Mat BlackMat = new Mat();
        Mat BlackDepthMat = new Mat();

        getContours(_ClolrMat, _DepthMat).copyTo(BlackMat);
        getDepthContours(_DepthMat, BlackDepthMat);

        //getContours(_DepthMat, BlackMat);

        //將結果影像轉換影像格式與大小設定
        Mat resizeMat = new Mat(_matchHeight, _matchWidth, CvType.CV_8UC1);
        Imgproc.resize(BlackMat, resizeMat, resizeMat.size());
        Utils.matToTexture2D(resizeMat, _matchTexture);
        _matchTexture.Apply();

        _ClolrMat.Dispose();
        //因為CreatePlane也要用不能刪掉
        //if(_DepthMat != null) _DepthMat.Dispose();
        BlackMat.Dispose();
        resizeMat.Dispose();
        BlackDepthMat.Dispose();
    }

    private void SetUseRotate()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            _useRotateLaserGenerator = (_useRotateLaserGenerator) ? false : true;
        }
    }

    //深度影像處理
    public  bool getDepthContours(Mat _depthMat,Mat blackMat)
    {
        if (_depthMat == null)
        {
            Debug.Log("_DepthMat Mat is Null");
            return false;
        }
        
        //載入影像
        Mat SrcMat = new Mat();
        _depthMat.copyTo(SrcMat);
        
        //宣告存放偵測結果資料
        Mat result = new Mat(_depthMat.height(), _depthMat.width(),CvType.CV_8UC3);
        result.setTo(new Scalar(0, 0, 0));
        Mat hierarchy = new Mat();
        List<MatOfPoint> contours = new List<MatOfPoint>();
        
        //宣告存放MatchObject的List
        List<MatchObject> tempObjectList = new List<MatchObject>();
        
        //找輪廓並編號
        Imgproc.findContours(SrcMat, contours, hierarchy, Imgproc.RETR_EXTERNAL, Imgproc.CHAIN_APPROX_SIMPLE);
        //取得輪廓數量
        int _ContoursCount = contours.Count;
        //跑迴圈確認輪廓
        if (_ContoursCount > 0)
        {
            for (int index = 0; index < _ContoursCount; index++)
            {
                if (!analysisContoursRect(index, contours, result, tempObjectList))
                {
                    //Debug.Log("analysisContours fail");
                }

            }
        }
        _changeRectList = analysisContours(contours);
        //Debug.Log("tempObjectList Count = " + tempObjectList.Count);
        _matchObjectList = new List<MatchObject>(tempObjectList);

        // Imgproc.cvtColor(result, result, Imgproc.COLOR_BGR2RGB);
        result.copyTo(blackMat);
        result.Dispose();
        hierarchy.Dispose();
        contours.Clear();
        SrcMat.Dispose();
        return true;
    }

    //辨識輪廓
    private bool analysisContoursRect(int index,List<MatOfPoint> contours,Mat result,List<MatchObject> matchObject)
    {
        OpenCVForUnity.Rect _testDepthRect = Imgproc.boundingRect(contours[index]);
        float minAreaSize = _minDepthObjectSizePer * _drawBlock.MatchHeight * _drawBlock.MatchWidth;
        if (_testDepthRect.area() > minAreaSize)
        {
            //宣告放置點資料
            MatOfInt hullInt = new MatOfInt();
            List<Point> hullPointList = new List<Point>();
            MatOfPoint hullPointMat = new MatOfPoint();
            List<MatOfPoint> hullPoints = new List<MatOfPoint>();
            MatOfInt4 defects = new MatOfInt4();
            //篩選點資料
            MatOfPoint2f Temp2f = new MatOfPoint2f();
            //Convert contours(i) from MatOfPoint to MatOfPoint2f
            contours[index].convertTo(Temp2f, CvType.CV_32FC2);
            //Processing on mMOP2f1 which is in type MatOfPoint2f
            Imgproc.approxPolyDP(Temp2f, Temp2f, 30, true);
            //Convert back to MatOfPoint and put the new values back into the contours list
            Temp2f.convertTo(contours[index], CvType.CV_32S);

            //计算轮廓围绕的凸形壳
            Imgproc.convexHull(contours[index], hullInt);
            List<Point> pointMatList = contours[index].toList();
            List<int> hullIntList = hullInt.toList();
            for (int j = 0; j < hullInt.toList().Count; j++)
            {
                hullPointList.Add(pointMatList[hullIntList[j]]);
                hullPointMat.fromList(hullPointList);
                hullPoints.Add(hullPointMat);
            }
            if (hullInt.toList().Count == 4)
            {
                if(!setMatchObject(index, pointMatList, contours, hullPoints, result, matchObject))
                {
                    //Debug.Log("setMatchObject fail");
                }
            }
            //清空記憶體
            defects.Dispose();
            hullPointList.Clear();
            hullPointMat.Dispose();
            hullInt.Dispose();
            hullPoints.Clear();
            return true;
        }
        return false;
    }
    //不辨識輪廓直接產生物體
    private List<OpenCVForUnity.Rect> analysisContours(List<MatOfPoint> contours)
    {
        List<OpenCVForUnity.Rect> depthImageChangeRectList = new List<OpenCVForUnity.Rect>();

        for (int index = 0; index < contours.Count; index++)
        {
            OpenCVForUnity.Rect testDepthRect = Imgproc.boundingRect(contours[index]);
            if (testDepthRect.height > 0 && testDepthRect.width > 0 && testDepthRect.area() > 0)
            {
                depthImageChangeRectList.Add(testDepthRect);
            }
        }
            return depthImageChangeRectList;
    }

    //設定偵測物體參數
    private bool setMatchObject(int index,List<Point> pointMatList, List<MatOfPoint> contours, List<MatOfPoint> hullPoints,Mat result,List<MatchObject> matchObjectList)
    {
        pointMatList = arrangedPoint(pointMatList);
        float RectWidth = calculateWidth(pointMatList);
        float RectHeight = calculateHeight(pointMatList);
        if (RectWidth > 3 && RectHeight > 3 && pointsTooClose(pointMatList))
        {
            _DepthRect = Imgproc.boundingRect(contours[index]);
            MatchObject matchObject = new MatchObject();
            matchObject._pos = calculateCenter(pointMatList);
            matchObject._scale = new Vector3(RectWidth, RectHeight, 10);
            matchObject._rotation = calculateSlope(pointMatList);
            Imgproc.drawContours(result, hullPoints, -1, new Scalar(0, 255, 0), 2);
            matchObjectList.Add(matchObject);
            return true;
        }
        return false;
    }
    //求物體中心點
    public Vector3 calculateCenter(List<Point> point)
    {
        Vector3 totalPos = new Vector3(0,0,0);
        for(int i = 0; i < 4; i++)
        {
            totalPos.x += (float)point[i].x;
            totalPos.y += (float)point[i].y;
        }
        totalPos.x /= 4;
        totalPos.y /= 4;
        totalPos.z = -30;
        return totalPos;
    }
    //判斷點之間是否太接近形成錯誤的多邊形
    public bool pointsTooClose(List<Point> point)
    {
        float Dx1 = 0, Dx2 = 0;
        float Dy1 = 0, Dy2 = 0;

        Dx1 = (float)Math.Abs(point[2].x - point[0].x);
        Dy1 = (float)Math.Abs(point[2].y - point[0].y);

        Dx2 = (float)Math.Abs(point[3].x - point[1].x);
        Dy2 = (float)Math.Abs(point[3].y - point[1].y);

        float distanceA = (float)Math.Sqrt(Dx1 * Dx1 + Dy1 * Dy1);
        float distanceB = (float)Math.Sqrt(Dx2 * Dx2 + Dy2 * Dy2);

        float difference = Math.Abs(distanceA - distanceB) / distanceA;

        if (difference > 0.5)
        {
            return false;
        }
        return true;
    }

    //重新排列4個點的順序(分上下兩組)
    public List<Point> arrangedPoint(List<Point> point)
    {
        List<Point> newPoint = new List<Point>();
        float avgY =(float) (point[0].y + point[1].y + point[2].y + point[3].y) / 4;
        for(int i = 0; i < 4; i++)
        {
            if(point[i].y<=avgY)
                newPoint.Add(point[i]);
        }
        for (int i = 0; i < 4; i++)
        {
            if (point[i].y > avgY)
                newPoint.Add(point[i]);
        }
        return newPoint;
    }

    //求出方形寬度
    public float calculateWidth(List<Point> point)
    {
        float Width=0;
        float Dx = (float)Math.Abs(point[0].x - point[1].x);
        float Dy = (float)Math.Abs(point[0].y - point[1].y);
        Width = (float)Math.Sqrt(Dx * Dx + Dy * Dy);
        return Width;
    }

    //求方形高度
    public float calculateHeight(List<Point> point)
    {
        float Height=0;
        float upX = (float)(point[0].x + point[1].x) / 2;
        float upY = (float)(point[0].y + point[1].y) / 2;
        float downX = (float)(point[2].x + point[3].x) / 2;
        float downY = (float)(point[2].y + point[3].y) / 2;
        float Dx = (float)Math.Abs(upX - downX);
        float Dy = (float)Math.Abs(upY - downY);
        Height = (float)Math.Sqrt(Dx * Dx + Dy * Dy);
        return Height;
    }

    //計算傾斜角度
    public float calculateSlope(List<Point> point)
    {
        float DRoation = 0;
        float upX = (float)(point[0].x + point[1].x) / 2;
        float upY = (float)(point[0].y + point[1].y) / 2;
        float downX = (float)(point[2].x + point[3].x) / 2;
        float downY = (float)(point[2].y + point[3].y) / 2;
        float Dx = upX - downX;
        float Dy = upY - downY;
        DRoation = (float)(Math.Atan2(Dy, Dx) / Math.PI);
        return DRoation;
    }

    //利用深度的輪廓做RGB的顏色判斷
    public Mat getContours(Mat srcColorMat,Mat srcDepthMat)
    {
        Mat ColorMat = new Mat();
        Mat DepthMat = new Mat();
        Mat HsvMat = new Mat();
        srcColorMat.copyTo(ColorMat);
        srcDepthMat.copyTo(DepthMat);
        Imgproc.cvtColor(ColorMat, HsvMat, Imgproc.COLOR_BGR2HSV);

        List<ColorObject> colorObjects = new List<ColorObject>();
        Mat resultMat = new Mat(DepthMat.height(), DepthMat.width(), CvType.CV_8UC1);
        Mat hierarchy = new Mat();
        List<Point> ConsistP = new List<Point>();
        List<MatOfPoint> contours = new List<MatOfPoint>();
        List<List<Point>> trianglePointList = new List<List<Point>>();

        Imgproc.findContours(DepthMat, contours, hierarchy, Imgproc.RETR_EXTERNAL, Imgproc.CHAIN_APPROX_SIMPLE);
        
        int numObjects = contours.Count;
        List<Scalar> clickRGB = new List<Scalar>();
        List<Scalar> clickHSV = new List<Scalar>();
        List<int> HullCountList = new List<int>();
        for (int i = 0; i < numObjects; i++)
        {
            Imgproc.drawContours(resultMat, contours, i, new Scalar(255),1);
        }
        double[] GetRGB = new double[10];
        float minAreaSize = _minDepthObjectSizePer * _drawBlock.MatchHeight * _drawBlock.MatchWidth;
        if (numObjects > 0)
        {
            for (int index = 0; index < numObjects; index++)
            {

                OpenCVForUnity.Rect R0 = Imgproc.boundingRect(contours[index]);

                if (R0.area() > minAreaSize)
                {
                    //宣告放置點資料
                    MatOfInt hullInt = new MatOfInt();
                    List<Point> hullPointList = new List<Point>();
                    MatOfPoint hullPointMat = new MatOfPoint();
                    List<MatOfPoint> hullPoints = new List<MatOfPoint>();
                    MatOfInt4 defects = new MatOfInt4();
                    //篩選點資料
                    MatOfPoint2f Temp2f = new MatOfPoint2f();
                    //Convert contours(i) from MatOfPoint to MatOfPoint2f
                    contours[index].convertTo(Temp2f, CvType.CV_32FC2);
                    //Processing on mMOP2f1 which is in type MatOfPoint2f
                    Imgproc.approxPolyDP(Temp2f, Temp2f, 30, true);
                    //Convert back to MatOfPoint and put the new values back into the contours list
                    Temp2f.convertTo(contours[index], CvType.CV_32S);

                    //计算轮廓围绕的凸形壳
                    Imgproc.convexHull(contours[index], hullInt);
                    List<Point> pointMatList = contours[index].toList();
                    List<int> hullIntList = hullInt.toList();
                    for (int j = 0; j < hullInt.toList().Count; j++)
                    {
                        hullPointList.Add(pointMatList[hullIntList[j]]);
                        hullPointMat.fromList(hullPointList);
                        hullPoints.Add(hullPointMat);
                    }
                    ConsistP.Add(new Point(R0.x, R0.y));
                    ConsistP.Add(new Point(R0.x + R0.width, R0.y + R0.height));
                    ConsistP.Add(new Point(R0.x + R0.width, R0.y));
                    ConsistP.Add(new Point(R0.x, R0.y + R0.height));
                    clickRGB.Add(clickcolor(ColorMat, R0));
                    clickHSV.Add(clickcolor(HsvMat, R0));
                    HullCountList.Add(hullIntList.Count);
                    trianglePointList.Add(pointMatList);
                    //清空記憶體
                    defects.Dispose();
                    hullPointList.Clear();
                    hullPointMat.Dispose();
                    hullInt.Dispose();
                    hullPoints.Clear();

                    
                    //Debug.Log("ID = " +  index + " Color = " + clickcolor(ColorMat, R0));
                }
            }
            //使用顏色找尋物體
            _matchColorObjectList = setColorMatchObject(ConsistP, trianglePointList, clickRGB, clickHSV, resultMat, HullCountList);
        }
        return resultMat;
    }
    //設定偵測物體參數
    private List<MatchObject> setColorMatchObject(List<Point> ConsistP, List<List<Point>> trianglePointList, List<Scalar> clickRGB, List<Scalar> clickHsv, Mat resultMat, List<int> HullCountList)
    {
        List<MatchObject> matchObjectList = new List<MatchObject>();
        for (int i = 0; i < ConsistP.Count; i += 4)
        {
            int ID = inRange(ConsistP[i], ConsistP[i + 1], clickRGB[i / 4], clickHsv[i / 4]);
            if ((ID == 0 || ID == 1) && HullCountList[i/4] != 3)
            {
                continue;
            }
            if (ID != -1)
            {
                List<Point> nowPoint = new List<Point>();
                nowPoint.Add(ConsistP[i]);
                nowPoint.Add(ConsistP[i + 1]);
                nowPoint.Add(ConsistP[i + 2]);
                nowPoint.Add(ConsistP[i + 3]);
                Imgproc.rectangle(resultMat, ConsistP[i], ConsistP[i + 1], new Scalar(255, 0, 255), 1);
                Imgproc.putText(resultMat, "ID=" + ID.ToString(), ConsistP[i], 1, 1, new Scalar(255, 0, 255), 1);
                MatchObject matchObject = new MatchObject();
                matchObject._centerPos = calculateCenter(nowPoint);
                if(ID == 0 || ID == 1)
                {
                    matchObject._pos = getTriangleCenter(trianglePointList[i / 4]);
                }
                else
                {
                    matchObject._pos = calculateCenter(nowPoint);
                }
                //Debug.Log("center: "+ matchObject._pos);
                matchObject._scale = new Vector3(22, 22, 22);
                matchObject._id = ID;
                if (ID == 2)
                {
                    matchObject._rotation = 0;
                }
                else
                {
                    if (_useRotateLaserGenerator)
                    {
                        matchObject._rotation = (float)(getTriangleRotate(trianglePointList[i / 4], new Point(matchObject._pos.x, matchObject._pos.y)) * 180 / Math.PI);
                    }
                    else
                    {
                        if (matchObject._pos.x > resultMat.width() / 2)
                        {
                            matchObject._rotation = 180f;
                        }
                        else
                        {
                            matchObject._rotation = 0f;
                        }

                    }

                }
                matchObjectList.Add(matchObject);
            }
        }
        _matchColorObjectList.Clear();
        return matchObjectList;
    }

    private Vector3 getTriangleCenter(List<Point> trianglePoints)
    {
        //排序三點
        trianglePoints = sortTrianglePoints(trianglePoints);
        //取得三邊長度
        double lengthA = getLengthByTwoPoint(trianglePoints[0], trianglePoints[1]);
        double lengthB = getLengthByTwoPoint(trianglePoints[1], trianglePoints[2]);
        double lengthC = getLengthByTwoPoint(trianglePoints[2], trianglePoints[0]);
        float centerX = (float)((lengthB * trianglePoints[0].x + lengthC * trianglePoints[1].x + lengthA * trianglePoints[2].x) / (lengthA + lengthB + lengthC));
        float centerY = (float)((lengthB * trianglePoints[0].y + lengthC * trianglePoints[1].y + lengthA * trianglePoints[2].y) / (lengthA + lengthB + lengthC));
        return new Vector3(centerX, centerY, -30);
    }

    //取得三角形旋轉角度(角度最小)
    private double getTriangleRotate(List<Point> trianglePoints, Point centerPoint)
    {
        //排序三點
        trianglePoints = sortTrianglePoints(trianglePoints);
        //取得三邊長度
        double lengthA = getLengthByTwoPoint(trianglePoints[0], trianglePoints[1]);
        double lengthB = getLengthByTwoPoint(trianglePoints[1], trianglePoints[2]);
        double lengthC = getLengthByTwoPoint(trianglePoints[2], trianglePoints[0]);
        //計算三點角度
        List<double> CosABC = new List<double>();
        CosABC.Add((lengthC * lengthC + lengthA * lengthA - lengthB * lengthB) / (2 * lengthA * lengthC));
        CosABC.Add((lengthA * lengthA + lengthB * lengthB - lengthC * lengthC) / (2 * lengthB * lengthA));
        CosABC.Add((lengthC * lengthC + lengthB * lengthB - lengthA * lengthA) / (2 * lengthB * lengthC));
        List<double> angles = new List<double>();
        foreach(double cos in CosABC)
        {
            angles.Add(Math.Acos(cos) * (180 / Math.PI));
        }
        //抓出最小角度的點
        int minIndex = 0;
        for(int i = 0; i<angles.Count; i++)
        {
            if(angles[minIndex] > angles[i])
            {
                minIndex = i;
            }
        }
        //透過象限分別計算角度
        return getTriangleRotateByCoordinate(centerPoint, trianglePoints[minIndex]);
    }

    //透過象限分別計算角度
    private double getTriangleRotateByCoordinate(Point centerPoint, Point point)
    {
        double lengthX = Math.Abs(point.x - centerPoint.x);
        double lengthY = Math.Abs(point.y - centerPoint.y);
        double returnAngle = 0.0;
        if(point.x > centerPoint.x && point.y > centerPoint.y)//第一象限
        {
            returnAngle = Math.Atan2(lengthY, lengthX);
        }
        else if (point.x < centerPoint.x && point.y > centerPoint.y)//第二象限
        {
            returnAngle = Math.PI - Math.Atan2(lengthY, lengthX);
        }
        else if (point.x < centerPoint.x && point.y < centerPoint.y)//第三象限
        {
            returnAngle = Math.PI + Math.Atan2(lengthY, lengthX);
        }
        else if (point.x > centerPoint.x && point.y < centerPoint.y)//第四象限
        {
            returnAngle = 2 * Math.PI - Math.Atan2(lengthY, lengthX);
        }
        return returnAngle;
    }

    //以X軸由小到大排序
    private List<Point> sortTrianglePoints(List<Point> trianglePoints)
    {
        for(int i=0; i <trianglePoints.Count; i++)
        {
            for (int j = i + 1; j < trianglePoints.Count; j++)
            {
                if(trianglePoints[i].x > trianglePoints[j].x)
                {
                    Point storePoint = trianglePoints[i];
                    trianglePoints[i] = trianglePoints[j];
                    trianglePoints[j] = storePoint;
                }
            }
        }
        return trianglePoints;
    }

    //兩點求邊函式
    private double getLengthByTwoPoint(Point a, Point b)
    {
        double disX = Math.Abs(a.x - b.x);
        double disY = Math.Abs(a.y - b.y);
        return Math.Sqrt((disX * disX) + (disY * disY));
    }

    //侵蝕膨脹消除雜訊
    public void morphOps(Mat thresh)
    {
        //創造兩個矩陣做 侵蝕、膨脹(erode、dilate)
        //the element chosen here is a 3px by 3px rectangle
        Mat erodeElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(3, 3));
        //dilate with larger element so make sure object is nicely visible
        Mat dilateElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(3, 3));

        Imgproc.erode(thresh, thresh, erodeElement);
        Imgproc.erode(thresh, thresh, erodeElement);

        Imgproc.dilate(thresh, thresh, dilateElement);
        Imgproc.dilate(thresh, thresh, dilateElement);

    }
    //取得平均色彩
    public  Scalar clickcolor(Mat src, OpenCVForUnity.Rect R)
    {
        double average_R = 0, average_G = 0, average_B = 0;
        double[] _getrgb_Mid = src.get((int)R.y + R.height / 2, (int)R.x + R.width / 2);
        double[] _getrgb_Lift = src.get((int)R.y + R.height / 2, (int)R.x + R.width / 4);
        double[] _getrgb_Right = src.get((int)R.y + R.height / 2, (int)R.x + R.width / 4 * 3);
        double[] _getrgb_Top = src.get((int)R.y + R.height / 4, (int)R.x + R.width / 2);
        double[] _getrgb_Bot = src.get((int)R.y + R.height / 4 * 3, (int)R.x + R.width / 2);


        average_R = (_getrgb_Mid[0] + _getrgb_Lift[0] + _getrgb_Right[0] + _getrgb_Top[0] + _getrgb_Bot[0])/5;
        average_G = (_getrgb_Mid[1] + _getrgb_Lift[1] + _getrgb_Right[1] + _getrgb_Top[1] + _getrgb_Bot[1])/5;
        average_B = (_getrgb_Mid[2] + _getrgb_Lift[2] + _getrgb_Right[2] + _getrgb_Top[2] + _getrgb_Bot[2])/5;
        
        return new Scalar((int)average_R, (int)average_G, (int)average_B);
    }
    //當偵測到的物體平均色彩符合則比對成功
    public  int inRange(Point P1 , Point P2, Scalar src, Scalar srcHsv)
    {
        double[] _srcColor =src.val;
        double[] _srcHsvColor = srcHsv.val;
        double[] _colorDiff = new double[3];
        _colorDiff[0] = _srcColor[0] - _srcColor[1];
        _colorDiff[1] = _srcColor[1] - _srcColor[2];
        _colorDiff[2] = _srcColor[2] - _srcColor[0];

        for (int i = 0; i < SensingResults.Count; i++)
        {
            double[] getHsv = SensingResults[i].getColorHsv().val;
            Point ResultsP1 = SensingResults[i]._objectBlock[0];
            Point ResultsP2 = SensingResults[i]._objectBlock[1];
            double[] _resultsDiffColor = SensingResults[i].getColorDiff();

            if (_srcHsvColor[0] < (getHsv[0] + _colorHsvRange) % 180 &&
               _srcHsvColor[0] > (getHsv[0] - _colorHsvRange) % 180)
           {
                //Debug.Log(i + "Use ColorHSV");
                SensingResults[i].SetPoint(P1, P2);
                return i;
           }
           else if (
                _colorDiff[0] < (_resultsDiffColor[0] + _colorDiffRange) &&
                _colorDiff[0] > (_resultsDiffColor[0] - _colorDiffRange) &&
                _colorDiff[1] < (_resultsDiffColor[1] + _colorDiffRange) &&
                _colorDiff[1] > (_resultsDiffColor[1] - _colorDiffRange) &&
                _colorDiff[2] < (_resultsDiffColor[2] + _colorDiffRange) &&
                _colorDiff[2] > (_resultsDiffColor[2] - _colorDiffRange))
           {
                //Debug.Log(i +"Use Diff Color");
                SensingResults[i].SetPoint(P1, P2);
                return i;
           }
        }
        //Debug.Log("Count = " + _matchColorObjectList.Count);
        for (int i = 0; i < _matchColorObjectList.Count; i++)
        {
            Point ResultsCenter = new Point(_matchColorObjectList[i]._centerPos.x, _matchColorObjectList[i]._centerPos.y);
            //Debug.Log("i = " + i + "Match ResultsCenter = " + ResultsCenter + "P1 P2" + P1 + P2);
            if (pointDistanceToFar(P1, P2, ResultsCenter))
            {
                //Debug.Log(_matchColorObjectList[i]._id + "Use Depth");
                return _matchColorObjectList[i]._id;
            }
        }
        //判斷使否開啟特徵存檔
        if (isSave)
        {
            Debug.Log("Create" + SensingResults.Count);
            SensingResults.Add(new BaseObject(SensingResults.Count,P1, P2, src, srcHsv));
            Debug.Log("Color =" + src);
            ColorSaveData.GetComponent<ColorSaveData>().SaveColorData(SensingResults);
            return SensingResults.Count;
        }
        else return -1;
    }

    //比對深度位置是否相同
    //設定是否開啟儲存特徵物體的bool(預設快捷鍵為U)
    public void SetIsSave()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            isSave = (isSave) ? false : true;
            Debug.Log((isSave) ? "isSave Set True" : "isSave Set false");
            if (isSave)
            {
                
                SensingResults.Clear();
                _matchColorObjectList.Clear();
            }
        }
    }
    private bool pointDistanceToFar(Point P1,Point P2,Point center)
    {

        if ((P1.x + P2.x) / 2 < center.x + _distanceRange &&
            (P1.x + P2.x) / 2 > center.x - _distanceRange &&
            (P1.y + P2.y) / 2 < center.y + _distanceRange &&
            (P1.y + P2.y) / 2 > center.y - _distanceRange)
        {
            return true;
        }
        return false;
    }
//============================================================
//=================以下為沒有再使用的函式=====================
//============================================================

    //找出特徵的顏色方法三(ORB特徵點比對)
    public bool descriptorsORB(Mat RGB, Mat cameraFeed,string targetName)
    {
        if (RGB == null)
        {
            Debug.Log("RGB Mat is Null");
            return false;
        }
        //將傳入的RGB存入Src
        Mat SrcMat = new Mat();
        RGB.copyTo(SrcMat);
        //比對樣本載入
        Texture2D imgTexture = Resources.Load(targetName) as Texture2D;
        
        //Texture2D轉Mat
        Mat targetMat = new Mat(imgTexture.height, imgTexture.width, CvType.CV_8UC3);
        Utils.texture2DToMat(imgTexture, targetMat);

        //創建 ORB的特徵點裝置
        FeatureDetector detector = FeatureDetector.create(FeatureDetector.ORB);
        DescriptorExtractor extractor = DescriptorExtractor.create(DescriptorExtractor.ORB);

        //產生存放特徵點Mat
        MatOfKeyPoint keypointsTarget = new MatOfKeyPoint();
        Mat descriptorsTarget = new Mat();
        MatOfKeyPoint keypointsSrc = new MatOfKeyPoint();
        Mat descriptorsSrc = new Mat();

        //找特徵點圖Target
        detector.detect(targetMat, keypointsTarget);
        extractor.compute(targetMat, keypointsTarget, descriptorsTarget);

        //找特徵點圖Src
        detector.detect(SrcMat, keypointsSrc);
        extractor.compute(SrcMat, keypointsSrc, descriptorsSrc);

        //創建特徵點比對物件
        DescriptorMatcher matcher = DescriptorMatcher.create(DescriptorMatcher.BRUTEFORCE_HAMMINGLUT);
        MatOfDMatch matches = new MatOfDMatch();
        //丟入兩影像的特徵點
        matcher.match(descriptorsTarget, descriptorsSrc, matches);
        DMatch[] arrayDmatch = matches.toArray();

        //做篩選
        double max_dist = 0;
        double min_dist = 100;
        //-- Quick calculation of max and min distances between keypoints
        double dist = new double();
        for (int i = 0; i < matches.rows(); i++)
        {
            dist = arrayDmatch[i].distance;
            if (dist < min_dist) min_dist = dist;
            if (dist > max_dist) max_dist = dist;
        }
        Debug.Log("Max dist :" + max_dist);
        Debug.Log("Min dist :" + min_dist);

        List<DMatch> matchesGoodList = new List<DMatch>();
        
        MatOfDMatch matchesGood = new MatOfDMatch();
        matchesGood.fromList(matchesGoodList);
        
        //Draw Keypoints
        Features2d.drawKeypoints(SrcMat, keypointsSrc, SrcMat);

        List<Point> pTarget = new List<Point>();
        List<Point> pSrc = new List<Point>();

        Debug.Log("MatchCount"+matchesGoodList.Count);
        for (int i = 0; i < matchesGoodList.Count; i++)
        {
            pTarget.Add(new Point(keypointsTarget.toArray()[matchesGoodList[i].queryIdx].pt.x, keypointsTarget.toArray()[matchesGoodList[i].queryIdx].pt.y));
            pSrc.Add(new Point(keypointsSrc.toArray()[matchesGoodList[i].trainIdx].pt.x, keypointsSrc.toArray()[matchesGoodList[i].trainIdx].pt.y));
        }

        MatOfPoint2f p2fTarget = new MatOfPoint2f(pTarget.ToArray());
        MatOfPoint2f p2fSrc = new MatOfPoint2f(pSrc.ToArray());

        Mat matrixH = Calib3d.findHomography(p2fTarget, p2fSrc, Calib3d.RANSAC, 3);

        List<Point> srcPointCorners = new List<Point>();
        srcPointCorners.Add(new Point(0, 0));
        srcPointCorners.Add(new Point(targetMat.width(), 0));
        srcPointCorners.Add(new Point(targetMat.width(), targetMat.height()));
        srcPointCorners.Add(new Point(0, targetMat.height()));
        Mat originalRect = Converters.vector_Point2f_to_Mat(srcPointCorners);

        List<Point> srcPointCornersEnd = new List<Point>();
        srcPointCornersEnd.Add(new Point(0, targetMat.height()));
        srcPointCornersEnd.Add(new Point(0, 0));
        srcPointCornersEnd.Add(new Point(targetMat.width(), 0));
        srcPointCornersEnd.Add(new Point(targetMat.width(), targetMat.height()));
        Mat changeRect = Converters.vector_Point2f_to_Mat(srcPointCornersEnd);

        Core.perspectiveTransform(originalRect, changeRect, matrixH);
        List<Point> srcPointCornersSave = new List<Point>();

        Converters.Mat_to_vector_Point(changeRect, srcPointCornersSave);

        if ((srcPointCornersSave[2].x - srcPointCornersSave[0].x) < 5 || (srcPointCornersSave[2].y - srcPointCornersSave[0].y) < 5)
        {
            Debug.Log("Match Out Put image is to small");
            SrcMat.copyTo(cameraFeed);
            SrcMat.release();
            Imgproc.putText(cameraFeed,targetName, srcPointCornersSave[0], 0, 1, new Scalar(255, 255, 255), 2);
            return false;
        }
        //畫出框框
        Imgproc.line(SrcMat, srcPointCornersSave[0], srcPointCornersSave[1], new Scalar(255, 0, 0), 3);
        Imgproc.line(SrcMat, srcPointCornersSave[1], srcPointCornersSave[2], new Scalar(255, 0, 0), 3);
        Imgproc.line(SrcMat, srcPointCornersSave[2], srcPointCornersSave[3], new Scalar(255, 0, 0), 3);
        Imgproc.line(SrcMat, srcPointCornersSave[3], srcPointCornersSave[0], new Scalar(255, 0, 0), 3);
        //畫中心
        Point middlePoint = new Point((srcPointCornersSave[0].x + srcPointCornersSave[2].x) / 2, (srcPointCornersSave[0].y + srcPointCornersSave[2].y) / 2);
        Imgproc.line(SrcMat,  middlePoint, middlePoint, new Scalar(0, 0, 255), 10);


        SrcMat.copyTo(cameraFeed);
        keypointsTarget.release();
        targetMat.release();
        SrcMat.release();
        return true;
    }
    public bool descriptorsORB_Old(Mat RGB, Mat cameraFeed, string targetName)//找出特徵的顏色方法三(可運行但效率不佳放棄)
    {
        if (RGB == null)
        {
            Debug.Log("RGB Mat is Null");
            return false;
        }
        //將傳入的RGB存入Src
        Mat SrcMat = new Mat();

        RGB.copyTo(SrcMat);
        //比對樣本
        Texture2D imgTexture = Resources.Load(targetName) as Texture2D;
        //  Texture2D imgTexture2 = Resources.Load("lenaK") as Texture2D;

        //Texture2D轉Mat
        Mat img1Mat = new Mat(imgTexture.height, imgTexture.width, CvType.CV_8UC3);
        Utils.texture2DToMat(imgTexture, img1Mat);

        //創建 ORB的特徵點裝置
        FeatureDetector detector = FeatureDetector.create(FeatureDetector.ORB);
        DescriptorExtractor extractor = DescriptorExtractor.create(DescriptorExtractor.ORB);
        //產生存放特徵點Mat
        MatOfKeyPoint keypoints1 = new MatOfKeyPoint();
        Mat descriptors1 = new Mat();
        MatOfKeyPoint keypointsSrc = new MatOfKeyPoint();
        Mat descriptorsSrc = new Mat();
        //找特徵點圖1
        detector.detect(img1Mat, keypoints1);
        extractor.compute(img1Mat, keypoints1, descriptors1);
        //找特徵點圖Src
        detector.detect(SrcMat, keypointsSrc);
        extractor.compute(SrcMat, keypointsSrc, descriptorsSrc);

        DescriptorMatcher matcher = DescriptorMatcher.create(DescriptorMatcher.BRUTEFORCE_HAMMINGLUT);
        MatOfDMatch matches = new MatOfDMatch();
        matcher.match(descriptors1, descriptorsSrc, matches);
        DMatch[] arrayDmatch = matches.toArray();

        for (int i = arrayDmatch.Length - 1; i >= 0; i--)
        {
            //   Debug.Log("match " + i + ": " + arrayDmatch[i].distance);
        }
        //做篩選
        double max_dist = 0;
        double min_dist = 100;
        //-- Quick calculation of max and min distances between keypoints
        double dist = new double();
        for (int i = 0; i < matches.rows(); i++)
        {
            dist = arrayDmatch[i].distance;
            if (dist < min_dist) min_dist = dist;
            if (dist > max_dist) max_dist = dist;
        }
        Debug.Log("Max dist :" + max_dist);
        Debug.Log("Min dist :" + min_dist);
        //只畫好的點

        List<DMatch> matchesGoodList = new List<DMatch>();

        for (int i = 0; i < matches.rows(); i++)
        {
            //if (arrayDmatch[i].distance < RateDist.value * min_dist)
            //{
            //    //Debug.Log("match " + i + ": " + arrayDmatch[i].distance);
            //    matchesGoodList.Add(arrayDmatch[i]);
            //}
        }
        MatOfDMatch matchesGood = new MatOfDMatch();
        matchesGood.fromList(matchesGoodList);

        //Draw Keypoints
        Features2d.drawKeypoints(SrcMat, keypointsSrc, SrcMat);

        //做輸出的轉換予宣告

        Mat resultImg = new Mat();
        // Features2d.drawMatches(img1Mat, keypoints1, SrcMat, keypointsSrc, matchesGood, resultImg);

        List<Point> P1 = new List<Point>();
        // List<Point> P2 = new List<Point>();
        List<Point> pSrc = new List<Point>();

        Debug.Log("MatchCount" + matchesGoodList.Count);
        for (int i = 0; i < matchesGoodList.Count; i++)
        {
            P1.Add(new Point(keypoints1.toArray()[matchesGoodList[i].queryIdx].pt.x, keypoints1.toArray()[matchesGoodList[i].queryIdx].pt.y));
            pSrc.Add(new Point(keypointsSrc.toArray()[matchesGoodList[i].trainIdx].pt.x, keypointsSrc.toArray()[matchesGoodList[i].trainIdx].pt.y));
            //Debug.Log("ID = " + matchesGoodList[i].queryIdx );
            //Debug.Log("x,y =" + (int)keypoints1.toArray()[matchesGoodList[i].queryIdx].pt.x + "," + (int)keypoints1.toArray()[matchesGoodList[i].queryIdx].pt.y);
            //Debug.Log("x,y =" + (int)keypoints2.toArray()[matchesGoodList[i].trainIdx].pt.x + "," + (int)keypoints2.toArray()[matchesGoodList[i].trainIdx].pt.y);
        }

        MatOfPoint2f p2fTarget = new MatOfPoint2f(P1.ToArray());
        MatOfPoint2f p2fSrc = new MatOfPoint2f(pSrc.ToArray());

        Mat matrixH = Calib3d.findHomography(p2fTarget, p2fSrc, Calib3d.RANSAC, 3);
        List<Point> srcPointCorners = new List<Point>();
        srcPointCorners.Add(new Point(0, 0));
        srcPointCorners.Add(new Point(img1Mat.width(), 0));
        srcPointCorners.Add(new Point(img1Mat.width(), img1Mat.height()));
        srcPointCorners.Add(new Point(0, img1Mat.height()));

        Mat originalRect = Converters.vector_Point2f_to_Mat(srcPointCorners);
        List<Point> srcPointCornersEnd = new List<Point>();
        srcPointCornersEnd.Add(new Point(0, img1Mat.height()));
        srcPointCornersEnd.Add(new Point(0, 0));
        srcPointCornersEnd.Add(new Point(img1Mat.width(), 0));
        srcPointCornersEnd.Add(new Point(img1Mat.width(), img1Mat.height()));

        Mat changeRect = Converters.vector_Point2f_to_Mat(srcPointCornersEnd);

        Core.perspectiveTransform(originalRect, changeRect, matrixH);
        List<Point> srcPointCornersSave = new List<Point>();

        Converters.Mat_to_vector_Point(changeRect, srcPointCornersSave);

        if ((srcPointCornersSave[2].x - srcPointCornersSave[0].x) < 5 || (srcPointCornersSave[2].y - srcPointCornersSave[0].y) < 5)
        {
            Debug.Log("Match Out Put image is to small");
            SrcMat.copyTo(cameraFeed);
            SrcMat.release();
            Imgproc.putText(cameraFeed, "X-S", new Point(10, 50), 0, 1, new Scalar(255, 255, 255), 2);
            return false;
        }
        //    Features2d.drawMatches(img1Mat, keypoints1, SrcMat, keypointsSrc, matchesGood, resultImg);
        Imgproc.line(SrcMat, srcPointCornersSave[0], srcPointCornersSave[1], new Scalar(255, 0, 0), 3);
        Imgproc.line(SrcMat, srcPointCornersSave[1], srcPointCornersSave[2], new Scalar(255, 0, 0), 3);
        Imgproc.line(SrcMat, srcPointCornersSave[2], srcPointCornersSave[3], new Scalar(255, 0, 0), 3);
        Imgproc.line(SrcMat, srcPointCornersSave[3], srcPointCornersSave[0], new Scalar(255, 0, 0), 3);

        SrcMat.copyTo(cameraFeed);
        keypoints1.release();
        img1Mat.release();
        SrcMat.release();
        return true;
    }
}
