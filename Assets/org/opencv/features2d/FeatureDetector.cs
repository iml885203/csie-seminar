
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class javaFeatureDetector
//javadoc: javaFeatureDetector
	public class FeatureDetector : DisposableOpenCVObject
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						features2d_FeatureDetector_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		protected FeatureDetector (IntPtr addr) : base(addr)
		{
		
		}
	
		private const int
			GRIDDETECTOR = 1000,
			PYRAMIDDETECTOR = 2000,
			DYNAMICDETECTOR = 3000;
		public const int
			FAST = 1,
			STAR = 2,
			SIFT = 3,
			SURF = 4,
			ORB = 5,
			MSER = 6,
			GFTT = 7,
			HARRIS = 8,
			SIMPLEBLOB = 9,
			DENSE = 10,
			BRISK = 11,
			AKAZE = 12,
			GRID_FAST = GRIDDETECTOR + FAST,
			GRID_STAR = GRIDDETECTOR + STAR,
			GRID_SIFT = GRIDDETECTOR + SIFT,
			GRID_SURF = GRIDDETECTOR + SURF,
			GRID_ORB = GRIDDETECTOR + ORB,
			GRID_MSER = GRIDDETECTOR + MSER,
			GRID_GFTT = GRIDDETECTOR + GFTT,
			GRID_HARRIS = GRIDDETECTOR + HARRIS,
			GRID_SIMPLEBLOB = GRIDDETECTOR + SIMPLEBLOB,
			GRID_DENSE = GRIDDETECTOR + DENSE,
			GRID_BRISK = GRIDDETECTOR + BRISK,
			GRID_AKAZE = GRIDDETECTOR + AKAZE,
			PYRAMID_FAST = PYRAMIDDETECTOR + FAST,
			PYRAMID_STAR = PYRAMIDDETECTOR + STAR,
			PYRAMID_SIFT = PYRAMIDDETECTOR + SIFT,
			PYRAMID_SURF = PYRAMIDDETECTOR + SURF,
			PYRAMID_ORB = PYRAMIDDETECTOR + ORB,
			PYRAMID_MSER = PYRAMIDDETECTOR + MSER,
			PYRAMID_GFTT = PYRAMIDDETECTOR + GFTT,
			PYRAMID_HARRIS = PYRAMIDDETECTOR + HARRIS,
			PYRAMID_SIMPLEBLOB = PYRAMIDDETECTOR + SIMPLEBLOB,
			PYRAMID_DENSE = PYRAMIDDETECTOR + DENSE,
			PYRAMID_BRISK = PYRAMIDDETECTOR + BRISK,
			PYRAMID_AKAZE = PYRAMIDDETECTOR + AKAZE,
			DYNAMIC_FAST = DYNAMICDETECTOR + FAST,
			DYNAMIC_STAR = DYNAMICDETECTOR + STAR,
			DYNAMIC_SIFT = DYNAMICDETECTOR + SIFT,
			DYNAMIC_SURF = DYNAMICDETECTOR + SURF,
			DYNAMIC_ORB = DYNAMICDETECTOR + ORB,
			DYNAMIC_MSER = DYNAMICDETECTOR + MSER,
			DYNAMIC_GFTT = DYNAMICDETECTOR + GFTT,
			DYNAMIC_HARRIS = DYNAMICDETECTOR + HARRIS,
			DYNAMIC_SIMPLEBLOB = DYNAMICDETECTOR + SIMPLEBLOB,
			DYNAMIC_DENSE = DYNAMICDETECTOR + DENSE,
			DYNAMIC_BRISK = DYNAMICDETECTOR + BRISK,
			DYNAMIC_AKAZE = DYNAMICDETECTOR + AKAZE;
	
	

		//
		// C++:  void detect(Mat image, vector_KeyPoint& keypoints, Mat mask = Mat())
		//
		
		//javadoc: javaFeatureDetector::detect(image, keypoints, mask)
		public  void detect (Mat image, MatOfKeyPoint keypoints, Mat mask)
		{
			ThrowIfDisposed ();
			if (image != null)
				image.ThrowIfDisposed ();
			if (keypoints != null)
				keypoints.ThrowIfDisposed ();
			if (mask != null)
				mask.ThrowIfDisposed ();
			
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat keypoints_mat = keypoints;
			features2d_FeatureDetector_detect_10 (nativeObj, image.nativeObj, keypoints_mat.nativeObj, mask.nativeObj);
			
			return;
			#else
			return;
			#endif
		}
		
		//javadoc: javaFeatureDetector::detect(image, keypoints)
		public  void detect (Mat image, MatOfKeyPoint keypoints)
		{
			ThrowIfDisposed ();
			if (image != null)
				image.ThrowIfDisposed ();
			if (keypoints != null)
				keypoints.ThrowIfDisposed ();
			
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat keypoints_mat = keypoints;
			features2d_FeatureDetector_detect_11 (nativeObj, image.nativeObj, keypoints_mat.nativeObj);
			
			return;
			#else
			return;
			#endif
		}
	
		//
		// C++:  void detect(vector_Mat images, vector_vector_KeyPoint& keypoints, vector_Mat masks = std::vector<Mat>())
		//
	
		//javadoc: javaFeatureDetector::detect(images, keypoints, masks)
		public  void detect (List<Mat> images, List<MatOfKeyPoint> keypoints, List<Mat> masks)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat images_mat = Converters.vector_Mat_to_Mat (images);
			Mat keypoints_mat = new Mat ();
			Mat masks_mat = Converters.vector_Mat_to_Mat (masks);
			features2d_FeatureDetector_detect_12 (nativeObj, images_mat.nativeObj, keypoints_mat.nativeObj, masks_mat.nativeObj);
			Converters.Mat_to_vector_vector_KeyPoint (keypoints_mat, keypoints);
			return;
#else
return;
#endif
		}
	
		//javadoc: javaFeatureDetector::detect(images, keypoints)
		public  void detect (List<Mat> images, List<MatOfKeyPoint> keypoints)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat images_mat = Converters.vector_Mat_to_Mat (images);
			Mat keypoints_mat = new Mat ();
			features2d_FeatureDetector_detect_13 (nativeObj, images_mat.nativeObj, keypoints_mat.nativeObj);
			Converters.Mat_to_vector_vector_KeyPoint (keypoints_mat, keypoints);
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  bool empty()
		//
	
		//javadoc: javaFeatureDetector::empty()
		public  bool empty ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			bool retVal = features2d_FeatureDetector_empty_10 (nativeObj);
		
			return retVal;
#else
return false;
#endif
		}


	
	
		//
		// C++: static javaFeatureDetector* create(int detectorType)
		//
	
		//javadoc: javaFeatureDetector::create(detectorType)
		public static FeatureDetector create (int detectorType)
		{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			FeatureDetector retVal = new FeatureDetector (features2d_FeatureDetector_create_10 (detectorType));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  void write(String fileName)
		//
	
		//javadoc: javaFeatureDetector::write(fileName)
		public  void write (string fileName)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			features2d_FeatureDetector_write_10 (nativeObj, fileName);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void read(String fileName)
		//
	
		//javadoc: javaFeatureDetector::read(fileName)
		public  void read (string fileName)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			features2d_FeatureDetector_read_10 (nativeObj, fileName);
		
			return;
#else
return;
#endif
		}
	
	

	
		#if UNITY_IOS && !UNITY_EDITOR

		// C++:  void detect(Mat image, vector_KeyPoint& keypoints, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern void features2d_FeatureDetector_detect_10 (IntPtr nativeObj, IntPtr image_nativeObj, IntPtr keypoints_mat_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void features2d_FeatureDetector_detect_11 (IntPtr nativeObj, IntPtr image_nativeObj, IntPtr keypoints_mat_nativeObj);


		// C++:  void detect(vector_Mat images, vector_vector_KeyPoint& keypoints, vector_Mat masks = std::vector<Mat>())
		[DllImport("__Internal")]
		private static extern void features2d_FeatureDetector_detect_12 (IntPtr nativeObj, IntPtr images_mat_nativeObj, IntPtr keypoints_mat_nativeObj, IntPtr masks_mat_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void features2d_FeatureDetector_detect_13 (IntPtr nativeObj, IntPtr images_mat_nativeObj, IntPtr keypoints_mat_nativeObj);
		
		// C++:  bool empty()
		[DllImport("__Internal")]
		private static extern bool features2d_FeatureDetector_empty_10 (IntPtr nativeObj);


		
		// C++: static javaFeatureDetector* create(int detectorType)
		[DllImport("__Internal")]
		private static extern IntPtr features2d_FeatureDetector_create_10 (int detectorType);
		
		// C++:  void write(String fileName)
		[DllImport("__Internal")]
		private static extern void features2d_FeatureDetector_write_10 (IntPtr nativeObj, string fileName);
		
		// C++:  void read(String fileName)
		[DllImport("__Internal")]
		private static extern void features2d_FeatureDetector_read_10 (IntPtr nativeObj, string fileName);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void features2d_FeatureDetector_delete (IntPtr nativeObj);
#else
	
		// C++:  void detect(Mat image, vector_KeyPoint& keypoints, Mat mask = Mat())
		[DllImport("opencvforunity")]
		private static extern void features2d_FeatureDetector_detect_10 (IntPtr nativeObj, IntPtr image_nativeObj, IntPtr keypoints_mat_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("opencvforunity")]
		private static extern void features2d_FeatureDetector_detect_11 (IntPtr nativeObj, IntPtr image_nativeObj, IntPtr keypoints_mat_nativeObj);


		// C++:  void detect(vector_Mat images, vector_vector_KeyPoint& keypoints, vector_Mat masks = std::vector<Mat>())
		[DllImport("opencvforunity")]
		private static extern void features2d_FeatureDetector_detect_12 (IntPtr nativeObj, IntPtr images_mat_nativeObj, IntPtr keypoints_mat_nativeObj, IntPtr masks_mat_nativeObj);

		[DllImport("opencvforunity")]
		private static extern void features2d_FeatureDetector_detect_13 (IntPtr nativeObj, IntPtr images_mat_nativeObj, IntPtr keypoints_mat_nativeObj);
	
		// C++:  bool empty()
		[DllImport("opencvforunity")]
		private static extern bool features2d_FeatureDetector_empty_10 (IntPtr nativeObj);


	
		// C++: static javaFeatureDetector* create(int detectorType)
		[DllImport("opencvforunity")]
		private static extern IntPtr features2d_FeatureDetector_create_10 (int detectorType);
	
		// C++:  void write(String fileName)
		[DllImport("opencvforunity")]
		private static extern void features2d_FeatureDetector_write_10 (IntPtr nativeObj, string fileName);
	
		// C++:  void read(String fileName)
		[DllImport("opencvforunity")]
		private static extern void features2d_FeatureDetector_read_10 (IntPtr nativeObj, string fileName);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void features2d_FeatureDetector_delete (IntPtr nativeObj);
#endif
	
	}
}
