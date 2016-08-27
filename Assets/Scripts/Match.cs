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
    DiceRecognition _dice = new DiceRecognition();

    //物體資訊
    public List<BaseObject> SensingResults = new List<BaseObject>();
    private int _clolrRange = 15;
    //是否可以儲存感測到的物件
    private bool isSave = new bool();
    //拉霸 distRate
    //public Slider RateDist;
    //public Slider KeyPointMinCount; 

    public Mat src;
    public OpenCVForUnity.Rect R0;
    public Mat Temp;

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
        hsvMat = new Mat();
        thresholdMat = new Mat();
       // _NewDepthMat = DepthManager.GetData();
       // BlackMat.setTo(new Scalar(10, 10, 10));
        //_NewTowMat = getFeature(resizeMat, 196, 136, 214, 154, 94, 34);
        //morphOps(_NewTowMat);
        //getMaxMin(_NewTowMat);
        //


      
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

        //方法二 用顏色抓物件
       Imgproc.cvtColor(_NewTowMat, hsvMat, Imgproc.COLOR_RGB2HSV);
        getContours(_NewTowMat, BlackMat);
        //方法三 用特徵點抓物件
        //descriptorsORB(_NewTowMat, BlackMat, "queen");
        //descriptorsORB(BlackMat, BlackMat, "lena");

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
        int maxX = 0, minX = 9999, maxY = 0, minY = 9999;
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
                    if (j > maxX)
                    {
                        maxX = j;
                    }
                    else if (j < minX)
                    {
                        minX = j;
                    }
                    if (i > maxY)
                    {
                        maxY = i;
                    }
                    else if (i < minY)
                    {
                        minY = i;
                    }
                }
            }
        }
        //設定紅框兩點
        _liftP.x = maxX;
        _liftP.y = maxY;
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

                R0 = Imgproc.boundingRect(contours[index]);

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

        src = new Mat();
        RGB.copyTo(src);

        List<ColorObject> colorObjects = new List<ColorObject>();
        Temp = new Mat(RGB.height(),RGB.width(), CvType.CV_8UC3);
       // threshold.copyTo(temp);
        Mat hierarchy = new Mat();
        List<Point> ConsistP = new List<Point>();
        List<MatOfPoint> contours = new List<MatOfPoint>();

        Imgproc.blur(src, src, new Size(3, 3));
        Imgproc.Canny(src, Temp, 50, 150);
        morphOps(Temp);
        //cameraFeed = RGB;
        //RGB.copyTo(cameraFeed);
        //Debug.Log("Test");
        Imgproc.findContours(Temp, contours, hierarchy, Imgproc.RETR_EXTERNAL, Imgproc.CHAIN_APPROX_NONE);//Imgproc.RETR_EXTERNAL那邊0-3都可以
        
        int numObjects = contours.Count;
        List<Scalar> clickRGB = new List<Scalar>();
        for (int i = 0; i < numObjects; i++)
        {
            Imgproc.drawContours(Temp, contours, i, new Scalar(255, 255, 255),1);
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
                    clickRGB.Add(clickcolor(src, R0));
                    //骰子
                    //int diceCount = _dice.matchDice(src, R0, Temp);
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
                    Imgproc.rectangle(Temp, ConsistP[i], ConsistP[i + 1], new Scalar(255, 0, 255), 1);
                    Imgproc.putText(Temp, "ID=" + ID.ToString(), ConsistP[i], 1, 1, new Scalar(255, 0, 255), 1);
                }
            }
            // =================================
            // set public MatchObjectPoint =====
            // =================================
            //MatchObjectPoint = ConsistP;

            //ConsistP.Clear();
        }
        Temp.copyTo(cameraFeed);
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

    public void SetIsSave()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            isSave = (isSave) ? false : true;
            Debug.Log((isSave) ? "isSave Set True" : "isSave Set false");
        }
    }
    public bool descriptorsORB(Mat RGB, Mat cameraFeed,string targetName)//找出特徵的顏色方法三(可運行但效率不佳放棄)
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

        //DescriptorMatcher matcher = DescriptorMatcher.create(DescriptorMatcher.BRUTEFORCE);
        //DescriptorMatcher matcher = DescriptorMatcher.create (DescriptorMatcher.BRUTEFORCE_HAMMINGLUT);
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



        //if (matchesGoodList.Count > KeyPointMinCount.value)
        //{
        //    Debug.Log("GoodPoint is not enough to Identify");
        //    SrcMat.copyTo(cameraFeed);
        //    SrcMat.release();
        //    Imgproc.putText(cameraFeed, "X-E", new Point(10, 50), 0, 1, new Scalar(255, 255, 255),2);
        //    return false;
        //}
        Debug.Log("MatchCount"+matchesGoodList.Count);
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
        //A.fromArray(keypoints1.toArray());        

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
        //NewMat.setTo(new Scalar(45, 45, 45));
        // Imgproc.rectangle(NewMat,new Point(0,0),new Point(img1Mat.height(),img1Mat.width()),new Scalar(255,0,0),3);
        //Mat ChangeMat = new Mat();
        // H = Imgproc.getPerspectiveTransform(startM, endM);

        Core.perspectiveTransform(originalRect, changeRect, matrixH);
        List<Point> srcPointCornersSave = new List<Point>();

        // endM.copyTo(srcPointCorners);

        //ChangeMat.copyTo(resultImg);
        Converters.Mat_to_vector_Point(changeRect, srcPointCornersSave);

        //Debug.Log("1 X,Y = " + (int)srcPointCornersSave[0].x + " ," + (int)srcPointCornersSave[0].y);
        //Debug.Log("2 X,Y = " + (int)srcPointCornersSave[1].x + " ," + (int)srcPointCornersSave[1].y);
        //Debug.Log("3 X,Y = " + (int)srcPointCornersSave[2].x + " ," + (int)srcPointCornersSave[2].y);
        //Debug.Log("4 X,Y = " + (int)srcPointCornersSave[3].x + " ," + (int)srcPointCornersSave[3].y);

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
        //Texture2D texture = new Texture2D(resultImg.cols(), resultImg.rows(), TextureFormat.RGBA32, false);

        //Utils.matToTexture2D(resultImg, texture);

        //gameObject.GetComponent<Renderer>().material.mainTexture = texture;
        return true;
    }
}
