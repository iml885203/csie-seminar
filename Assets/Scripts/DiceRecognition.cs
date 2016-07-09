using UnityEngine;
using System.Collections;
using System;
using OpenCVForUnity;
using System.Collections.Generic;

public class DiceRecognition : MonoBehaviour
{
    Point pt;
    public int circleCount = 0;
	// Use this for initialization

		/*Texture2D imgTexture = Resources.Load ("5") as Texture2D;

		Mat imgMat = new Mat (imgTexture.height, imgTexture.width, CvType.CV_8UC4);

        Utils.texture2DToMat(imgTexture, imgMat);
        //Debug.Log("imgMat dst ToString " + imgMat.ToString());

        //--FindCircleProcess--//
        Mat grayMat = new Mat();
        Imgproc.cvtColor(imgMat, grayMat, Imgproc.COLOR_RGB2GRAY);

        Imgproc.Canny(grayMat, grayMat, 50, 200);

        Mat circles = new Mat();
        int minRadius = 0;
        int maxRadius = 0;

        // Apply the Hough Transform to find the circles

        Imgproc.HoughCircles(grayMat, circles, Imgproc.CV_HOUGH_GRADIENT, 2, grayMat.rows() / 4, 200, 60, minRadius, maxRadius);

        Debug.Log("circles toString " + circles.ToString());
        Debug.Log("circles dump" + circles.dump());

        if (circles.cols() > 0)
            for (int x = 0; x < Math.Min(circles.cols(), 10); x++)
            {
                double[] vCircle = circles.get(0, x);

                if (vCircle == null)
                    break;

                pt = new Point(Math.Round(vCircle[0]), Math.Round(vCircle[1]));
                int radius = (int)Math.Round(vCircle[2]);
                // draw the find circle center
                Imgproc.circle(imgMat, pt, 3, new Scalar(0, 255, 0), -1, 8, 0);
                // draw the found circle  
                Imgproc.circle(imgMat, pt, radius, new Scalar(0, 0, 255), 3, 8, 0);
                circleCount++;
            }

        int[] face = { Core.FONT_HERSHEY_SIMPLEX };
        Imgproc.putText(imgMat, circleCount.ToString(), new Point(0, 50), face[0], 1.2, new Scalar(255, 255, 255), 2, Imgproc.LINE_AA, false);
        //--FindCircleProcess--//

        //--DrawSomthing--//
        //Imgproc.rectangle(imgMat, new Point(150, 200), new Point(300, 300), new Scalar(0, 200, 0), 5);
        //Imgproc.circle(imgMat, new Point(500, 300), 80, new Scalar(200, 0, 0), 1);
        //double angle = 50;
        //Imgproc.ellipse(imgMat, new Point(200, 400), new Size(80, 150), angle, angle - 200, angle + 100, new Scalar(255, 255, 255), -1);
        //int[] face = { Core.FONT_HERSHEY_SIMPLEX };
        //Imgproc.putText(imgMat, "OpenCV", new Point(50, 50), face[0], 1.2, new Scalar(0, 0, 200), 2, Imgproc.LINE_AA, false);
        //--DrawSomething--//

        Texture2D texture = new Texture2D(imgMat.cols(), imgMat.rows(), TextureFormat.RGBA32, false);

        Utils.matToTexture2D(imgMat, texture);
			

		gameObject.GetComponent<Renderer> ().material.mainTexture = texture;*/
        
	
	// Update is called once per frame
	

    public int matchDice(Mat src, OpenCVForUnity.Rect rect, Mat temp)
    {
        Mat subRGB = new Mat(src, rect);

        //灰階
        Mat grayMat = new Mat();
        Imgproc.cvtColor(subRGB, grayMat, Imgproc.COLOR_RGB2GRAY);

        //morphOps(grayMat);//侵蝕膨脹
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
        for (int i = 0; i < contours.Count; i++)
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
        circleCount = contours.Count;
        return circleCount;
    }
}
