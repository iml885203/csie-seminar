
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class javaDescriptorExtractor
//javadoc: javaDescriptorExtractor
	public class DescriptorExtractor : DisposableOpenCVObject
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						features2d_DescriptorExtractor_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}

		protected DescriptorExtractor (IntPtr addr) : base(addr)
		{
		
		}
	
		private const int
			OPPONENTEXTRACTOR = 1000;
		public const int
			SIFT = 1,
			SURF = 2,
			ORB = 3,
			BRIEF = 4,
			BRISK = 5,
			FREAK = 6,
			AKAZE = 7,
			OPPONENT_SIFT = OPPONENTEXTRACTOR + SIFT,
			OPPONENT_SURF = OPPONENTEXTRACTOR + SURF,
			OPPONENT_ORB = OPPONENTEXTRACTOR + ORB,
			OPPONENT_BRIEF = OPPONENTEXTRACTOR + BRIEF,
			OPPONENT_BRISK = OPPONENTEXTRACTOR + BRISK,
			OPPONENT_FREAK = OPPONENTEXTRACTOR + FREAK,
			OPPONENT_AKAZE = OPPONENTEXTRACTOR + AKAZE;
	
	
		//
		// C++:  void compute(Mat image, vector_KeyPoint& keypoints, Mat descriptors)
		//
	
		//javadoc: javaDescriptorExtractor::compute(image, keypoints, descriptors)
		public  void compute (Mat image, MatOfKeyPoint keypoints, Mat descriptors)
		{
			ThrowIfDisposed ();
			if (image != null)
				image.ThrowIfDisposed ();
			if (keypoints != null)
				keypoints.ThrowIfDisposed ();
			if (descriptors != null)
				descriptors.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat keypoints_mat = keypoints;
			features2d_DescriptorExtractor_compute_10 (nativeObj, image.nativeObj, keypoints_mat.nativeObj, descriptors.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void compute(vector_Mat images, vector_vector_KeyPoint& keypoints, vector_Mat& descriptors)
		//
	
		//javadoc: javaDescriptorExtractor::compute(images, keypoints, descriptors)
		public  void compute (List<Mat> images, List<MatOfKeyPoint> keypoints, List<Mat> descriptors)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat images_mat = Converters.vector_Mat_to_Mat (images);
			List<Mat> keypoints_tmplm = new List<Mat> ((keypoints != null) ? keypoints.Count : 0);
			Mat keypoints_mat = Converters.vector_vector_KeyPoint_to_Mat (keypoints, keypoints_tmplm);
			Mat descriptors_mat = new Mat ();
			features2d_DescriptorExtractor_compute_11 (nativeObj, images_mat.nativeObj, keypoints_mat.nativeObj, descriptors_mat.nativeObj);
			Converters.Mat_to_vector_vector_KeyPoint (keypoints_mat, keypoints);
			keypoints_mat.release();
			Converters.Mat_to_vector_Mat (descriptors_mat, descriptors);
			descriptors_mat.release();
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int descriptorSize()
		//
	
		//javadoc: javaDescriptorExtractor::descriptorSize()
		public  int descriptorSize ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = features2d_DescriptorExtractor_descriptorSize_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  int descriptorType()
		//
	
		//javadoc: javaDescriptorExtractor::descriptorType()
		public  int descriptorType ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = features2d_DescriptorExtractor_descriptorType_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  bool empty()
		//
	
		//javadoc: javaDescriptorExtractor::empty()
		public  bool empty ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			bool retVal = features2d_DescriptorExtractor_empty_10 (nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++: static javaDescriptorExtractor* create(int extractorType)
		//
	
		//javadoc: javaDescriptorExtractor::create(extractorType)
		public static DescriptorExtractor create (int extractorType)
		{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			DescriptorExtractor retVal = new DescriptorExtractor (features2d_DescriptorExtractor_create_10 (extractorType));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  void write(String fileName)
		//
	
		//javadoc: javaDescriptorExtractor::write(fileName)
		public  void write (string fileName)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			features2d_DescriptorExtractor_write_10 (nativeObj, fileName);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void read(String fileName)
		//
	
		//javadoc: javaDescriptorExtractor::read(fileName)
		public  void read (string fileName)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			features2d_DescriptorExtractor_read_10 (nativeObj, fileName);
		
			return;
#else
return;
#endif
		}
	
	

	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  void compute(Mat image, vector_KeyPoint& keypoints, Mat descriptors)
		[DllImport("__Internal")]
		private static extern void features2d_DescriptorExtractor_compute_10 (IntPtr nativeObj, IntPtr image_nativeObj, IntPtr keypoints_mat_nativeObj, IntPtr descriptors_nativeObj);
		
		// C++:  void compute(vector_Mat images, vector_vector_KeyPoint& keypoints, vector_Mat& descriptors)
		[DllImport("__Internal")]
		private static extern void features2d_DescriptorExtractor_compute_11 (IntPtr nativeObj, IntPtr images_mat_nativeObj, IntPtr keypoints_mat_nativeObj, IntPtr descriptors_mat_nativeObj);
		
		// C++:  int descriptorSize()
		[DllImport("__Internal")]
		private static extern int features2d_DescriptorExtractor_descriptorSize_10 (IntPtr nativeObj);
		
		// C++:  int descriptorType()
		[DllImport("__Internal")]
		private static extern int features2d_DescriptorExtractor_descriptorType_10 (IntPtr nativeObj);
		
		// C++:  bool empty()
		[DllImport("__Internal")]
		private static extern bool features2d_DescriptorExtractor_empty_10 (IntPtr nativeObj);
		
		// C++: static javaDescriptorExtractor* create(int extractorType)
		[DllImport("__Internal")]
		private static extern IntPtr features2d_DescriptorExtractor_create_10 (int extractorType);
		
		// C++:  void write(String fileName)
		[DllImport("__Internal")]
		private static extern void features2d_DescriptorExtractor_write_10 (IntPtr nativeObj, string fileName);
		
		// C++:  void read(String fileName)
		[DllImport("__Internal")]
		private static extern void features2d_DescriptorExtractor_read_10 (IntPtr nativeObj, string fileName);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void features2d_DescriptorExtractor_delete (IntPtr nativeObj);
#else
	
		// C++:  void compute(Mat image, vector_KeyPoint& keypoints, Mat descriptors)
		[DllImport("opencvforunity")]
		private static extern void features2d_DescriptorExtractor_compute_10 (IntPtr nativeObj, IntPtr image_nativeObj, IntPtr keypoints_mat_nativeObj, IntPtr descriptors_nativeObj);
	
		// C++:  void compute(vector_Mat images, vector_vector_KeyPoint& keypoints, vector_Mat& descriptors)
		[DllImport("opencvforunity")]
		private static extern void features2d_DescriptorExtractor_compute_11 (IntPtr nativeObj, IntPtr images_mat_nativeObj, IntPtr keypoints_mat_nativeObj, IntPtr descriptors_mat_nativeObj);
	
		// C++:  int descriptorSize()
		[DllImport("opencvforunity")]
		private static extern int features2d_DescriptorExtractor_descriptorSize_10 (IntPtr nativeObj);
	
		// C++:  int descriptorType()
		[DllImport("opencvforunity")]
		private static extern int features2d_DescriptorExtractor_descriptorType_10 (IntPtr nativeObj);
	
		// C++:  bool empty()
		[DllImport("opencvforunity")]
		private static extern bool features2d_DescriptorExtractor_empty_10 (IntPtr nativeObj);
	
		// C++: static javaDescriptorExtractor* create(int extractorType)
		[DllImport("opencvforunity")]
		private static extern IntPtr features2d_DescriptorExtractor_create_10 (int extractorType);
	
		// C++:  void write(String fileName)
		[DllImport("opencvforunity")]
		private static extern void features2d_DescriptorExtractor_write_10 (IntPtr nativeObj, string fileName);
	
		// C++:  void read(String fileName)
		[DllImport("opencvforunity")]
		private static extern void features2d_DescriptorExtractor_read_10 (IntPtr nativeObj, string fileName);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void features2d_DescriptorExtractor_delete (IntPtr nativeObj);
#endif
	
	}
}
