using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Match : MonoBehaviour {
    /*color match*/
    private Scalar _blockColor = new Scalar(255, 0, 0);
    private Scalar _backgroundColor = new Scalar(0, 255, 0);
    private Texture2D _matchTexture;
    private int _matchWidth;
    private int _matchHeight;
    private Mat hsvMat;
    private Mat thresholdMat;
    //colorObject
    ColorObject blue = new ColorObject("blue");
    ColorObject yellow = new ColorObject("yellow");
    ColorObject red = new ColorObject("red");
    ColorObject green = new ColorObject("green");
    /*kinect color */
    private int _colorWidth;
    private int _colorHeight;
    /*drawBlock*/
    public DrawBlock _drawBlock;
    private Mat blockMat;
    /*public data*/
    public int Width { get; private set; }
    public int Height { get; private set; }
    //public List<Point> MatchObjectPoint { get; private set; }

    //物體資訊
    public List<BaseObject> SensingResults = new List<BaseObject>();
    private int _clolrRange = 10;
    //是否可以儲存感測到的物件
    private bool isSave = new bool();

    public Texture2D GetMatchTexture()
    {
        return _matchTexture;
    }
    // Use this for initialization
    void Start()
    {
        _matchWidth = 800;
        _matchHeight = 450;
        //_colorWidth = _drawBlock.MatchWidth;
        //_colorHeight = _drawBlock.MatchHeight;
        _matchTexture = new Texture2D(_matchWidth, _matchHeight);

        ColorObject blue = new ColorObject("blue");
        ColorObject yellow = new ColorObject("yellow");
        ColorObject red = new ColorObject("red");
        ColorObject green = new ColorObject("green");
        isSave = false;
    }
	// Update is called once per frame
	void Update () {
        if (_drawBlock.MatchHeight == 0 && _drawBlock.MatchWidth == 0) return;
        //Mat resizeMat = new Mat(_matchHeight, _matchWidth, CvType.CV_8UC3);
        //Imgproc.resize(_drawBlock.GetBlockMat(), resizeMat, resizeMat.size());
        //進行辨識 getFeature(輸入影像,MaxR,minR,MaxG,minG,MaxB,minB);

        SetIsSave();

        Mat _NewTowMat = new Mat(_drawBlock.MatchHeight, _drawBlock.MatchWidth, CvType.CV_8UC3);
        
        _NewTowMat = _drawBlock.GetBlockMat();
        // ==========================
        // set public Width Height ==
        // ==========================
        Width = _drawBlock.MatchWidth;
        Height = _drawBlock.MatchHeight;

        Mat BlackMat = new Mat(_drawBlock.MatchHeight, _drawBlock.MatchWidth, CvType.CV_8UC3);

       // _NewDepthMat = DepthManager.GetData();
       // BlackMat.setTo(new Scalar(10, 10, 10));
        //_NewTowMat = getFeature(resizeMat, 196, 136, 214, 154, 94, 34);
        //morphOps(_NewTowMat);
        //getMaxMin(_NewTowMat);
        //
        hsvMat = new Mat();
        thresholdMat = new Mat();

        Imgproc.cvtColor(_NewTowMat, hsvMat, Imgproc.COLOR_RGB2HSV);
        //找綠色
       // Core.inRange(hsvMat, green.getHSVmin(), green.getHSVmax(), thresholdMat);
       // morphOps(thresholdMat);
       // trackFilteredObject(green, thresholdMat, hsvMat, BlackMat);
       // // 找yellow色
       // Core.inRange(hsvMat, yellow.getHSVmin(), yellow.getHSVmax(), thresholdMat);
       // morphOps(thresholdMat);
       // trackFilteredObject(yellow, thresholdMat, hsvMat, BlackMat);
       //// 找red
       // Core.inRange(hsvMat, red.getHSVmin(), red.getHSVmax(), thresholdMat);
       // morphOps(thresholdMat);
       // trackFilteredObject(red, thresholdMat, hsvMat, BlackMat);


        getContours(_NewTowMat, BlackMat);


        Mat resizeMat = new Mat(_matchHeight, _matchWidth, CvType.CV_8UC3);
        Imgproc.resize(BlackMat, resizeMat, resizeMat.size());
        Utils.matToTexture2D(resizeMat, _matchTexture);
        _matchTexture.Apply();
       
    }

    public Mat getFeature(Mat _inImage, int Br, int Sr, int Bg, int Sg, int Bb, int Sb)
    {

        //設定輸出的mat
        Mat Temp = new Mat(_inImage.height(), _inImage.width(), CvType.CV_8UC3);


        Core.inRange(_inImage, new Scalar(Sr, Sg, Sb), new Scalar(Br, Bg, Bb), Temp);
        //Debug.Log(Temp.get(1, 1)[0]);
        return Temp;
    }
    void morphOps(Mat thresh)
    {
        //創造兩個矩陣做 侵蝕、膨脹(erode、dilate)
        //the element chosen here is a 3px by 3px rectangle
        Mat erodeElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(3, 3));
        //dilate with larger element so make sure object is nicely visible
        Mat dilateElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(3, 3));

        //Imgproc.erode(thresh, thresh, erodeElement);
        //Imgproc.erode(thresh, thresh, erodeElement);

        Imgproc.dilate(thresh, thresh, dilateElement);
        Imgproc.dilate(thresh, thresh, dilateElement);
        //Imgproc.erode(thresh, thresh, erodeElement);
        //Imgproc.erode(thresh, thresh, erodeElement);
    }
    List<Point> getMaxMin(Mat _inImage)
    {
        //設定red框位置初值
        int MaxX = 0, minX = 9999, MaxY = 0, minY = 9999;
        //設定兩點位置初值
        Point _liftP = new Point(0, 0);
        Point _rightP = new Point(0, 0);
        List<Point> coner = new List<Point>();
        int row = _inImage.rows();
        int col = _inImage.cols();
        //
        double[] _goalPixel = new double[3];
        //

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {

                _goalPixel = _inImage.get(i, j);
                if (_goalPixel[0] >= 240)
                {
                    if (j > MaxX)
                    {
                        MaxX = j;
                    }
                    else if (j < minX)
                    {
                        minX = j;
                    }
                    if (i > MaxY)
                    {
                        MaxY = i;
                    }
                    else if (i < minY)
                    {
                        minY = i;
                    }
                }
            }
        }
        //設定紅框兩點
        _liftP.x = MaxX;
        _liftP.y = MaxY;
        _rightP.x = minX;
        _rightP.y = minY;

        coner.Add(_liftP);
        coner.Add(_rightP);
        //畫出紅框
        Imgproc.rectangle(_inImage, _liftP, _rightP, _blockColor, 2);
        return coner;
    }
    void trackFilteredObject(ColorObject theColorObject, Mat threshold, Mat HSV, Mat cameraFeed)//找出特徵的顏色
    {
        Point src_center = new Point(threshold.cols() / 2.0, threshold.rows() / 2.0);
        Mat rot_mat = Imgproc.getRotationMatrix2D(src_center, 180, 1.0);
        Imgproc.warpAffine(threshold, threshold, rot_mat, threshold.size());

        Point cof_center = new Point(cameraFeed.cols() / 2.0, cameraFeed.rows() / 2.0);
        Mat cof_mat = Imgproc.getRotationMatrix2D(cof_center, 180, 1.0);
        Imgproc.warpAffine(cameraFeed, cameraFeed, cof_mat, cameraFeed.size());


        List<ColorObject> colorObjects = new List<ColorObject>();
        Mat temp = new Mat();
        threshold.copyTo(temp);
        Mat hierarchy = new Mat();
        List<Point> ConsistP = new List<Point>();
        List<MatOfPoint> contours = new List<MatOfPoint>();
        //find contours of filtered image using openCV findContours function
        Imgproc.findContours(temp, contours, hierarchy, Imgproc.RETR_EXTERNAL, Imgproc.CHAIN_APPROX_NONE);
        int numObjects = hierarchy.rows();
        if (numObjects > 0)
        {
            for (int index = 0; index < numObjects; index++)
            {

                OpenCVForUnity.Rect R0 = Imgproc.boundingRect(contours[index]);

                if (R0.height > 10 && R0.width > 10)
                {
                    ConsistP.Add(new Point(R0.x, R0.y));
                    ConsistP.Add(new Point(R0.x + R0.width, R0.y + R0.height));
                    Imgproc.drawContours(cameraFeed, contours, index, new Scalar(128, 128, 128));
                }
            }

            for (int i = 0; i < ConsistP.Count; i += 2)
            {
                Imgproc.rectangle(cameraFeed, ConsistP[i], ConsistP[i + 1], new Scalar(255, 0, 255), 3);
                Imgproc.putText(cameraFeed, theColorObject.getType(), ConsistP[i + 1], 1, 1, new Scalar(255,0,255), 1);
            }
            ConsistP.Clear();
        }

        Imgproc.warpAffine(cameraFeed, cameraFeed, cof_mat, cameraFeed.size());
        Imgproc.warpAffine(threshold, threshold, rot_mat, threshold.size());
        
    }
    void getContours(Mat RGB, Mat cameraFeed)//找出特徵的顏色方法二
    {
        Point cof_center = new Point(cameraFeed.cols() / 2.0, cameraFeed.rows() / 2.0);
        Mat cof_mat = Imgproc.getRotationMatrix2D(cof_center, 180, 1.0);
        Imgproc.warpAffine(cameraFeed, cameraFeed, cof_mat, cameraFeed.size());

        Mat src = new Mat();
        RGB.copyTo(src);

        List<ColorObject> colorObjects = new List<ColorObject>();
        Mat temp = new Mat();
       // threshold.copyTo(temp);
        Mat hierarchy = new Mat();
        List<Point> ConsistP = new List<Point>();
        List<MatOfPoint> contours = new List<MatOfPoint>();

        Imgproc.blur(RGB, RGB, new Size(3, 3));
        Imgproc.Canny(RGB, temp, 50,150);
        morphOps(temp);
        //cameraFeed = RGB;
        //RGB.copyTo(cameraFeed);
        //Debug.Log("Test");
        Imgproc.findContours(temp, contours, hierarchy, Imgproc.RETR_EXTERNAL, Imgproc.CHAIN_APPROX_NONE);//Imgproc.RETR_EXTERNAL那邊0-3都可以
        
        int numObjects = contours.Count;
        List<Scalar> clickRGB = new List<Scalar>();
        for (int i = 0; i < numObjects; i++)
        {
            Imgproc.drawContours(temp, contours, i, new Scalar(255, 255, 255),1);
        }
        double[] GetRGB = new double[10];
        if (numObjects > 0)
        {
            for (int index = 0; index < numObjects; index++)
            {

                OpenCVForUnity.Rect R0 = Imgproc.boundingRect(contours[index]);

                if (R0.height > 20 && R0.width > 20 && R0.height <_drawBlock.MatchHeight-10 && R0.width < _drawBlock.MatchWidth-10)
                {
                    ConsistP.Add(new Point(R0.x, R0.y));
                    ConsistP.Add(new Point(R0.x + R0.width, R0.y + R0.height));
                    clickRGB.Add(clickcolor(RGB, R0));
                    //骰子
                    //int diceCount = matchDice(src, R0, temp);
                    //diceCount = (diceCount - 2) / 2;
                    //Debug.Log("dice count = " + diceCount);
                    //Mat bestLabel = new Mat();
                    //OpenCVForUnity.Core.kmeans(temp, 6, bestLabel, new TermCriteria(3,10, 1.0),1,OpenCVForUnity.Core.KMEANS_RANDOM_CENTERS);
                    //bestLabel.copyTo(temp);
                }
            }

            for (int i = 0; i < ConsistP.Count; i += 2)
            {
                int ID = inRange(ConsistP[i], ConsistP[i + 1], clickRGB[i / 2]);
                if (ID != -1)
                {
                    Imgproc.rectangle(temp, ConsistP[i], ConsistP[i + 1], new Scalar(255, 0, 255), 1);
                    Imgproc.putText(temp, "ID=" + ID.ToString(), ConsistP[i], 1, 1, new Scalar(255, 0, 255), 1);
                }
            }
            // =================================
            // set public MatchObjectPoint =====
            // =================================
            //MatchObjectPoint = ConsistP;

            //ConsistP.Clear();
        }
        temp.copyTo(cameraFeed);
        Imgproc.warpAffine(cameraFeed, cameraFeed, cof_mat, cameraFeed.size());
    }
    Scalar clickcolor(Mat src, OpenCVForUnity.Rect R)
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
    int inRange(Point P1 , Point P2, Scalar src)
    {
        double[] _srcColor =src.val;
        for (int i = 0; i < SensingResults.Count; i++)
        {
            double[] _getrgb = SensingResults[i].getColor().val;
          // Debug.Log(_getrgb[0] + "," + _getrgb[1] + ","+_getrgb[2]);
           if (_srcColor[0] < _getrgb[0] + _clolrRange &&
               _srcColor[0] > _getrgb[0] - _clolrRange &&
               _srcColor[1] < _getrgb[1] + _clolrRange &&
               _srcColor[1] > _getrgb[1] - _clolrRange &&
               _srcColor[2] < _getrgb[2] + _clolrRange &&
               _srcColor[2] > _getrgb[2] - _clolrRange)
           {
                SensingResults[i].SetPoint(P1, P2);
               return i;
           }
        }
       
        if (isSave)
        {
            Debug.Log("Create" + SensingResults.Count);
            SensingResults.Add(new BaseObject(P1, P2, src));
            return SensingResults.Count;
        }
        else return -1;
    }
    int matchDice(Mat src,OpenCVForUnity.Rect rect,Mat temp)//src原圖,point1.2是contour左上右下點,rect是框選區,temp是
    {
        //int DiceNum = 0;
        //Point pt;
        Mat subRGB = new Mat(src, rect);
        //--FindCircleProcess--//
        Mat grayMat = new Mat();
        Imgproc.cvtColor(subRGB, grayMat, Imgproc.COLOR_RGB2GRAY);

        //morphOps(grayMat);
        //Imgproc.Canny(grayMat, grayMat, 20, 40);

        Mat circles = new Mat();
        //int minRadius = 10;
        //int maxRadius = 50;

        // Apply the Hough Transform to find the circles

        //Imgproc.HoughCircles(grayMat, circles, Imgproc.CV_HOUGH_GRADIENT, 2, grayMat.rows() / 10, 200, 60, 10, 40); //16:00
        //Imgproc.HoughCircles(grayMat, circles, Imgproc.CV_HOUGH_GRADIENT, 2, grayMat.rows() / 10, 100, 60, 10, 40);//最接近

        Mat hierarchy = new Mat();
        List<MatOfPoint> contours = new List<MatOfPoint>();
        Imgproc.Canny(grayMat, grayMat, 50, 150);

        //morphOps(grayMat);

        Imgproc.findContours(grayMat, contours, hierarchy, Imgproc.RETR_LIST, Imgproc.CHAIN_APPROX_SIMPLE);
        for(int i = 0; i < contours.Count; i++)
        {
            Imgproc.drawContours(temp, contours, i, new Scalar(255, 255, 255), 2);
        }

        // Debug.Log("circles toString " + circles.ToString());
        // Debug.Log("circles dump" + circles.dump());

        /*if (circles.cols() > 0)
        {//找到圓的個數
            for (int x = 0; x < Math.Min(circles.cols(), 6); x++)
            {
                double[] vCircle = circles.get(0, x);

                if (vCircle == null)
                    break;

                pt = new Point(Math.Round(vCircle[0]), Math.Round(vCircle[1]));
                int radius = (int)Math.Round(vCircle[2]);
                // draw the find circle center
                //Debug.Log("find circle x =" + pt.x + ", y =" + pt.y);
                Imgproc.circle(temp, pt, 3, new Scalar(255, 255, 255), -1, 8, 0);
                // draw the found circle  
                Imgproc.circle(temp, pt, radius, new Scalar(255, 255, 255), 3, 8, 0);
                DiceNum++;
            }
        }*/
        //int[] face = { Core.FONT_HERSHEY_SIMPLEX };
        //Imgproc.putText(temp, DiceNum.ToString(), new Point(0, 50), face[0], 1.2, new Scalar(255, 255, 255), 2, Imgproc.LINE_AA, false);
        return contours.Count;
    }
    public void SetIsSave()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            isSave = (isSave) ? false : true;
            Debug.Log((isSave) ? "isSave Set True" : "isSave Set false");
        }
    }
}
