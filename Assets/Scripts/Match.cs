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
    public ColorSourceManager _ColorSourceManager;
    private int _colorWidth;
    private int _colorHeight;
    /*drawBlock*/
    public DrawBlock _drawBlock;
    private Mat blockMat;

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
    }
	// Update is called once per frame
	void Update () {
        if (_drawBlock.MatchHeight == 0 && _drawBlock.MatchWidth == 0) return;
        //Mat resizeMat = new Mat(_matchHeight, _matchWidth, CvType.CV_8UC3);
        //Imgproc.resize(_drawBlock.GetBlockMat(), resizeMat, resizeMat.size());
        //進行辨識 getFeature(輸入影像,MaxR,minR,MaxG,minG,MaxB,minB);
        
        Mat _NewTowMat = new Mat(_drawBlock.MatchHeight, _drawBlock.MatchWidth, CvType.CV_8UC3);
        _NewTowMat = _drawBlock.GetBlockMat();
        
        //_NewTowMat = getFeature(resizeMat, 196, 136, 214, 154, 94, 34);
        //morphOps(_NewTowMat);
        //getMaxMin(_NewTowMat);
        //
        hsvMat = new Mat();
        thresholdMat = new Mat();

        Imgproc.cvtColor(_NewTowMat, hsvMat, Imgproc.COLOR_RGB2HSV);
        //找綠色
        Core.inRange(hsvMat, green.getHSVmin(), green.getHSVmax(), thresholdMat);
        morphOps(thresholdMat);
        trackFilteredObject(green, thresholdMat, hsvMat, _NewTowMat);
        //找yellow色
        Core.inRange(hsvMat, yellow.getHSVmin(), yellow.getHSVmax(), thresholdMat);
        morphOps(thresholdMat);
        trackFilteredObject(yellow, thresholdMat, hsvMat, _NewTowMat);
        //找red
        Core.inRange(hsvMat, red.getHSVmin(), red.getHSVmax(), thresholdMat);
        morphOps(thresholdMat);
        trackFilteredObject(red, thresholdMat, hsvMat, _NewTowMat);

        Mat resizeMat = new Mat(_matchHeight, _matchWidth, CvType.CV_8UC3);
        Imgproc.resize(_NewTowMat, resizeMat, resizeMat.size());
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
        Mat dilateElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(8, 8));

        Imgproc.erode(thresh, thresh, erodeElement);
        Imgproc.erode(thresh, thresh, erodeElement);

        Imgproc.dilate(thresh, thresh, dilateElement);
        Imgproc.dilate(thresh, thresh, dilateElement);
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

        List<ColorObject> colorObjects = new List<ColorObject>();
        Mat temp = new Mat();
        threshold.copyTo(temp);
        Mat hierarchy = new Mat();
        List<Point> ConsistP = new List<Point>();
        List<MatOfPoint> contours = new List<MatOfPoint>();
        //find contours of filtered image using openCV findContours function
        Imgproc.findContours(temp, contours, hierarchy, Imgproc.RETR_CCOMP, Imgproc.CHAIN_APPROX_SIMPLE);
        int numObjects = hierarchy.rows();
        //Imgproc.contourArea(temp);
        //temp.copyTo(cameraFeed);
        //use moments method to find our filtered object

        //Point []ConsistP = new Point()[];
        //Imgproc.drawContours(cameraFeed, contours, 0, new Scalar(255, 0, 0));
        //Imgproc.drawContours(cameraFeed, contours, 1, new Scalar(255, 0, 0));
        //Imgproc.drawContours(cameraFeed, contours, 2, new Scalar(255, 0, 0));
        if (numObjects > 0)
        {
            //Debug.Log("Num" + numObjects);
            for (int index = 0; index < numObjects; index++)
            {

                OpenCVForUnity.Rect R0 = Imgproc.boundingRect(contours[index]);

                if (R0.height > 20 && R0.width > 20)
                {
                    ConsistP.Add(new Point(R0.x, R0.y));
                    ConsistP.Add(new Point(R0.x + R0.width, R0.y + R0.height));
                    //Debug.Log(ConsistP.Count);
                }


            }
            //Debug.Log("Count" + ConsistP.Count);

            for (int i = 0; i < ConsistP.Count; i += 2)
            {
                Imgproc.rectangle(cameraFeed, ConsistP[i], ConsistP[i + 1], new Scalar(255, 0, 0), 3);
                Imgproc.putText(cameraFeed, theColorObject.getType(), ConsistP[i + 1], 3, 1, theColorObject.getColor(), 3);
                
            }

            ConsistP.Clear();
        }

        //Debug.Log(hierarchy.rows());
        //drawObject(colorObjects, cameraFeed, temp, contours, hierarchy);
        //cameraFeed = temp;

        
    }
}
