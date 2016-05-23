
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class StereoMatcher
//javadoc: StereoMatcher
	public class StereoMatcher : Algorithm
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						calib3d_StereoMatcher_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
	
		protected StereoMatcher (IntPtr addr) : base(addr)
		{
		}
	
		public const int
			DISP_SHIFT = 4,
			DISP_SCALE = (1 << DISP_SHIFT);
	
	
		//
		// C++:  void compute(Mat left, Mat right, Mat& disparity)
		//
	
		//javadoc: StereoMatcher::compute(left, right, disparity)
		public  void compute (Mat left, Mat right, Mat disparity)
		{
			ThrowIfDisposed ();
			if (left != null)
				left.ThrowIfDisposed ();
			if (right != null)
				right.ThrowIfDisposed ();
			if (disparity != null)
				disparity.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			calib3d_StereoMatcher_compute_10 (nativeObj, left.nativeObj, right.nativeObj, disparity.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getMinDisparity()
		//
	
		//javadoc: StereoMatcher::getMinDisparity()
		public  int getMinDisparity ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			int retVal = calib3d_StereoMatcher_getMinDisparity_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setMinDisparity(int minDisparity)
		//
	
		//javadoc: StereoMatcher::setMinDisparity(minDisparity)
		public  void setMinDisparity (int minDisparity)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			calib3d_StereoMatcher_setMinDisparity_10 (nativeObj, minDisparity);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getNumDisparities()
		//
	
		//javadoc: StereoMatcher::getNumDisparities()
		public  int getNumDisparities ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			int retVal = calib3d_StereoMatcher_getNumDisparities_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setNumDisparities(int numDisparities)
		//
	
		//javadoc: StereoMatcher::setNumDisparities(numDisparities)
		public  void setNumDisparities (int numDisparities)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			calib3d_StereoMatcher_setNumDisparities_10 (nativeObj, numDisparities);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getBlockSize()
		//
	
		//javadoc: StereoMatcher::getBlockSize()
		public  int getBlockSize ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			int retVal = calib3d_StereoMatcher_getBlockSize_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setBlockSize(int blockSize)
		//
	
		//javadoc: StereoMatcher::setBlockSize(blockSize)
		public  void setBlockSize (int blockSize)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			calib3d_StereoMatcher_setBlockSize_10 (nativeObj, blockSize);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getSpeckleWindowSize()
		//
	
		//javadoc: StereoMatcher::getSpeckleWindowSize()
		public  int getSpeckleWindowSize ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			int retVal = calib3d_StereoMatcher_getSpeckleWindowSize_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setSpeckleWindowSize(int speckleWindowSize)
		//
	
		//javadoc: StereoMatcher::setSpeckleWindowSize(speckleWindowSize)
		public  void setSpeckleWindowSize (int speckleWindowSize)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			calib3d_StereoMatcher_setSpeckleWindowSize_10 (nativeObj, speckleWindowSize);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getSpeckleRange()
		//
	
		//javadoc: StereoMatcher::getSpeckleRange()
		public  int getSpeckleRange ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			int retVal = calib3d_StereoMatcher_getSpeckleRange_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setSpeckleRange(int speckleRange)
		//
	
		//javadoc: StereoMatcher::setSpeckleRange(speckleRange)
		public  void setSpeckleRange (int speckleRange)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			calib3d_StereoMatcher_setSpeckleRange_10 (nativeObj, speckleRange);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getDisp12MaxDiff()
		//
	
		//javadoc: StereoMatcher::getDisp12MaxDiff()
		public  int getDisp12MaxDiff ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			int retVal = calib3d_StereoMatcher_getDisp12MaxDiff_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setDisp12MaxDiff(int disp12MaxDiff)
		//
	
		//javadoc: StereoMatcher::setDisp12MaxDiff(disp12MaxDiff)
		public  void setDisp12MaxDiff (int disp12MaxDiff)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			calib3d_StereoMatcher_setDisp12MaxDiff_10 (nativeObj, disp12MaxDiff);
		
			return;
#else
return;
#endif
		}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  void compute(Mat left, Mat right, Mat& disparity)
		[DllImport("__Internal")]
		private static extern void calib3d_StereoMatcher_compute_10 (IntPtr nativeObj, IntPtr left_nativeObj, IntPtr right_nativeObj, IntPtr disparity_nativeObj);
		
		// C++:  int getMinDisparity()
		[DllImport("__Internal")]
		private static extern int calib3d_StereoMatcher_getMinDisparity_10 (IntPtr nativeObj);
		
		// C++:  void setMinDisparity(int minDisparity)
		[DllImport("__Internal")]
		private static extern void calib3d_StereoMatcher_setMinDisparity_10 (IntPtr nativeObj, int minDisparity);
		
		// C++:  int getNumDisparities()
		[DllImport("__Internal")]
		private static extern int calib3d_StereoMatcher_getNumDisparities_10 (IntPtr nativeObj);
		
		// C++:  void setNumDisparities(int numDisparities)
		[DllImport("__Internal")]
		private static extern void calib3d_StereoMatcher_setNumDisparities_10 (IntPtr nativeObj, int numDisparities);
		
		// C++:  int getBlockSize()
		[DllImport("__Internal")]
		private static extern int calib3d_StereoMatcher_getBlockSize_10 (IntPtr nativeObj);
		
		// C++:  void setBlockSize(int blockSize)
		[DllImport("__Internal")]
		private static extern void calib3d_StereoMatcher_setBlockSize_10 (IntPtr nativeObj, int blockSize);
		
		// C++:  int getSpeckleWindowSize()
		[DllImport("__Internal")]
		private static extern int calib3d_StereoMatcher_getSpeckleWindowSize_10 (IntPtr nativeObj);
		
		// C++:  void setSpeckleWindowSize(int speckleWindowSize)
		[DllImport("__Internal")]
		private static extern void calib3d_StereoMatcher_setSpeckleWindowSize_10 (IntPtr nativeObj, int speckleWindowSize);
		
		// C++:  int getSpeckleRange()
		[DllImport("__Internal")]
		private static extern int calib3d_StereoMatcher_getSpeckleRange_10 (IntPtr nativeObj);
		
		// C++:  void setSpeckleRange(int speckleRange)
		[DllImport("__Internal")]
		private static extern void calib3d_StereoMatcher_setSpeckleRange_10 (IntPtr nativeObj, int speckleRange);
		
		// C++:  int getDisp12MaxDiff()
		[DllImport("__Internal")]
		private static extern int calib3d_StereoMatcher_getDisp12MaxDiff_10 (IntPtr nativeObj);
		
		// C++:  void setDisp12MaxDiff(int disp12MaxDiff)
		[DllImport("__Internal")]
		private static extern void calib3d_StereoMatcher_setDisp12MaxDiff_10 (IntPtr nativeObj, int disp12MaxDiff);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void calib3d_StereoMatcher_delete (IntPtr nativeObj);
#else
		// C++:  void compute(Mat left, Mat right, Mat& disparity)
		[DllImport("opencvforunity")]
		private static extern void calib3d_StereoMatcher_compute_10 (IntPtr nativeObj, IntPtr left_nativeObj, IntPtr right_nativeObj, IntPtr disparity_nativeObj);
	
		// C++:  int getMinDisparity()
		[DllImport("opencvforunity")]
		private static extern int calib3d_StereoMatcher_getMinDisparity_10 (IntPtr nativeObj);
	
		// C++:  void setMinDisparity(int minDisparity)
		[DllImport("opencvforunity")]
		private static extern void calib3d_StereoMatcher_setMinDisparity_10 (IntPtr nativeObj, int minDisparity);
	
		// C++:  int getNumDisparities()
		[DllImport("opencvforunity")]
		private static extern int calib3d_StereoMatcher_getNumDisparities_10 (IntPtr nativeObj);
	
		// C++:  void setNumDisparities(int numDisparities)
		[DllImport("opencvforunity")]
		private static extern void calib3d_StereoMatcher_setNumDisparities_10 (IntPtr nativeObj, int numDisparities);
	
		// C++:  int getBlockSize()
		[DllImport("opencvforunity")]
		private static extern int calib3d_StereoMatcher_getBlockSize_10 (IntPtr nativeObj);
	
		// C++:  void setBlockSize(int blockSize)
		[DllImport("opencvforunity")]
		private static extern void calib3d_StereoMatcher_setBlockSize_10 (IntPtr nativeObj, int blockSize);
	
		// C++:  int getSpeckleWindowSize()
		[DllImport("opencvforunity")]
		private static extern int calib3d_StereoMatcher_getSpeckleWindowSize_10 (IntPtr nativeObj);
	
		// C++:  void setSpeckleWindowSize(int speckleWindowSize)
		[DllImport("opencvforunity")]
		private static extern void calib3d_StereoMatcher_setSpeckleWindowSize_10 (IntPtr nativeObj, int speckleWindowSize);
	
		// C++:  int getSpeckleRange()
		[DllImport("opencvforunity")]
		private static extern int calib3d_StereoMatcher_getSpeckleRange_10 (IntPtr nativeObj);
	
		// C++:  void setSpeckleRange(int speckleRange)
		[DllImport("opencvforunity")]
		private static extern void calib3d_StereoMatcher_setSpeckleRange_10 (IntPtr nativeObj, int speckleRange);
	
		// C++:  int getDisp12MaxDiff()
		[DllImport("opencvforunity")]
		private static extern int calib3d_StereoMatcher_getDisp12MaxDiff_10 (IntPtr nativeObj);
	
		// C++:  void setDisp12MaxDiff(int disp12MaxDiff)
		[DllImport("opencvforunity")]
		private static extern void calib3d_StereoMatcher_setDisp12MaxDiff_10 (IntPtr nativeObj, int disp12MaxDiff);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void calib3d_StereoMatcher_delete (IntPtr nativeObj);
#endif
	
	}
}

