using UnityEngine;
using System.Collections;
using System;
using OpenCVForUnity;

namespace OpenCVForUnitySample
{
	/// <summary>
	/// Texture2D to mat sample.
	/// </summary>
	public class DiceRecognition : MonoBehaviour
	{
        Point pt;
        int circleCount = 0;
		// Use this for initialization
		void Start ()
		{

			Texture2D imgTexture = Resources.Load ("5") as Texture2D;

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

            /*--DrawSomthing--//
            Imgproc.rectangle(imgMat, new Point(150, 200), new Point(300, 300), new Scalar(0, 200, 0), 5);
            Imgproc.circle(imgMat, new Point(500, 300), 80, new Scalar(200, 0, 0), 1);
            double angle = 50;
            Imgproc.ellipse(imgMat, new Point(200, 400), new Size(80, 150), angle, angle - 200, angle + 100, new Scalar(255, 255, 255), -1);
            int[] face = {Core.FONT_HERSHEY_SIMPLEX};
            Imgproc.putText(imgMat, "OpenCV", new Point(50, 50), face[0], 1.2, new Scalar(0, 0, 200), 2, Imgproc.LINE_AA, false);
            //--DrawSomething--*/

            Texture2D texture = new Texture2D(imgMat.cols(), imgMat.rows(), TextureFormat.RGBA32, false);

            Utils.matToTexture2D(imgMat, texture);
			

			gameObject.GetComponent<Renderer> ().material.mainTexture = texture;

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void OnBackButton ()
		{
						
		}
	}
}
