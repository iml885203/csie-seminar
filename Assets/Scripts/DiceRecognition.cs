using UnityEngine;
using System.Collections;
using System;
using OpenCVForUnity;
using System.Collections.Generic;

public class DiceRecognition : MonoBehaviour
{
    public int matchDice(Mat src, OpenCVForUnity.Rect rect, Mat temp)
    {
        Mat subRGB = new Mat(src, rect);

        //灰階
        Mat grayMat = new Mat();
        Imgproc.cvtColor(subRGB, grayMat, Imgproc.COLOR_RGB2GRAY);

        Mat hierarchy = new Mat();
        List<MatOfPoint> contours = new List<MatOfPoint>();

        //模糊.Canny.侵蝕膨脹
        Imgproc.blur(grayMat, grayMat, new Size(3, 3));
        Imgproc.Canny(grayMat, grayMat, 50, 150);
        morphOps(grayMat);

        //找輪廓
        Imgproc.findContours(grayMat, contours, hierarchy, Imgproc.RETR_LIST, Imgproc.CHAIN_APPROX_SIMPLE);
        for (int i = 0; i < contours.Count; i++)
        {
            Imgproc.drawContours(temp, contours, i, new Scalar(255, 255, 255), 2);
        }
        //回傳輪廓數目
        return contours.Count;
    }

    //public int HoughCircles(Mat src, OpenCVForUnity.Rect rect, Mat temp)
    //{
    //    //int DiceNum = 0;
    //    Mat subRGB = new Mat(src, rect);

    //    //灰階
    //    Mat grayMat = new Mat();
    //    Imgproc.cvtColor(subRGB, grayMat, Imgproc.COLOR_RGB2GRAY);

    //    //morphOps(grayMat);//侵蝕膨脹
    //    //Imgproc.Canny(grayMat, grayMat, 20, 40);

    //    //Mat circles = new Mat();
    //    //int minRadius = 10;
    //    //int maxRadius = 50;
    //    //Imgproc.HoughCircles(grayMat, circles, Imgproc.CV_HOUGH_GRADIENT, 2, grayMat.rows() / 10, 200, 60, 10, 40); //16:00
    //    //Imgproc.HoughCircles(grayMat, circles, Imgproc.CV_HOUGH_GRADIENT, 2, grayMat.rows() / 10, 100, 60, 10, 40);//最接近

    //    Mat hierarchy = new Mat();
    //    List<MatOfPoint> contours = new List<MatOfPoint>();

    //    Imgproc.blur(grayMat, grayMat, new Size(3, 3));
    //    Imgproc.Canny(grayMat, grayMat, 50, 150);
    //    morphOps(grayMat);

    //    Imgproc.findContours(grayMat, contours, hierarchy, Imgproc.RETR_LIST, Imgproc.CHAIN_APPROX_SIMPLE);
    //    for (int i = 0; i < contours.Count; i++)
    //    {
    //        Imgproc.drawContours(temp, contours, i, new Scalar(255, 255, 255), 2);
    //    }

    //    // Debug.Log("circles toString " + circles.ToString());
    //    // Debug.Log("circles dump" + circles.dump());

    //    //if (circles.cols() > 0)
    //    //{//找到圓的個數
    //    //    for (int x = 0; x < Math.Min(circles.cols(), 6); x++)
    //    //    {
    //    //        double[] vCircle = circles.get(0, x);

    //    //        if (vCircle == null)
    //    //            break;

    //    //        pt = new Point(Math.Round(vCircle[0]), Math.Round(vCircle[1]));
    //    //        int radius = (int)Math.Round(vCircle[2]);
    //    //        // draw the find circle center
    //    //        //Debug.Log("find circle x =" + pt.x + ", y =" + pt.y);
    //    //        Imgproc.circle(temp, pt, 3, new Scalar(255, 255, 255), -1, 8, 0);
    //    //        // draw the found circle  
    //    //        Imgproc.circle(temp, pt, radius, new Scalar(255, 255, 255), 3, 8, 0);
    //    //        DiceNum++;
    //    //    }
    //    //}

    //    //int[] face = { Core.FONT_HERSHEY_SIMPLEX };
    //    //Imgproc.putText(temp, DiceNum.ToString(), new Point(0, 50), face[0], 1.2, new Scalar(255, 255, 255), 2, Imgproc.LINE_AA, false);
    //    return contours.Count;
    //}

    void morphOps(Mat thresh)
    {
        //創造兩個矩陣做 侵蝕、膨脹(erode、dilate)
        //the element chosen here is a 3px by 3px rectangle
        Mat erodeElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(3, 3));
        //dilate with larger element so make sure object is nicely visible
        Mat dilateElement = Imgproc.getStructuringElement(Imgproc.MORPH_RECT, new Size(3, 3));

        Imgproc.dilate(thresh, thresh, dilateElement);
        Imgproc.dilate(thresh, thresh, dilateElement);
        //Imgproc.erode(thresh, thresh, erodeElement);
        //Imgproc.erode(thresh, thresh, erodeElement);
    }
}
