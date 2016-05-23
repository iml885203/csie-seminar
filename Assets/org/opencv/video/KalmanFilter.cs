﻿
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class KalmanFilter
//javadoc: KalmanFilter
	public class KalmanFilter : DisposableOpenCVObject
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						video_KalmanFilter_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}

		protected KalmanFilter (IntPtr addr) : base(addr)
		{
		
		}
	
	

	
	
		//
		// C++:   KalmanFilter()
		//
	
		//javadoc: KalmanFilter::KalmanFilter()
		public   KalmanFilter ()
		{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			nativeObj = video_KalmanFilter_KalmanFilter_10 ();
		
			return;
#else
return;
#endif
		}

		//
		// C++:   KalmanFilter(int dynamParams, int measureParams, int controlParams = 0, int type = CV_32F)
		//
		
		//javadoc: KalmanFilter::KalmanFilter(dynamParams, measureParams, controlParams, type)
		public   KalmanFilter (int dynamParams, int measureParams, int controlParams, int type)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			nativeObj = video_KalmanFilter_KalmanFilter_11 (dynamParams, measureParams, controlParams, type);
			
			return;
			#else
			return;
			#endif
		}
		
		//javadoc: KalmanFilter::KalmanFilter(dynamParams, measureParams)
		public   KalmanFilter (int dynamParams, int measureParams)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			nativeObj = video_KalmanFilter_KalmanFilter_12 (dynamParams, measureParams);
			
			return;
			#else
			return;
			#endif
		}
	
	
		//
		// C++:  Mat predict(Mat control = Mat())
		//
	
		//javadoc: KalmanFilter::predict(control)
		public  Mat predict (Mat control)
		{
			ThrowIfDisposed ();
			if (control != null)
				control.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_predict_10 (nativeObj, control.nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
		//javadoc: KalmanFilter::predict()
		public  Mat predict ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_predict_11 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat correct(Mat measurement)
		//
	
		//javadoc: KalmanFilter::correct(measurement)
		public  Mat correct (Mat measurement)
		{
			ThrowIfDisposed ();
			if (measurement != null)
				measurement.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_correct_10 (nativeObj, measurement.nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::statePre
		//
	
		//javadoc: KalmanFilter::get_statePre()
		public  Mat get_statePre ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1statePre_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::statePre
		//
	
		//javadoc: KalmanFilter::set_statePre(statePre)
		public  void set_statePre (Mat statePre)
		{
			ThrowIfDisposed ();
			if (statePre != null)
				statePre.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1statePre_10 (nativeObj, statePre.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::statePost
		//
	
		//javadoc: KalmanFilter::get_statePost()
		public  Mat get_statePost ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1statePost_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::statePost
		//
	
		//javadoc: KalmanFilter::set_statePost(statePost)
		public  void set_statePost (Mat statePost)
		{
			ThrowIfDisposed ();
			if (statePost != null)
				statePost.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1statePost_10 (nativeObj, statePost.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::transitionMatrix
		//
	
		//javadoc: KalmanFilter::get_transitionMatrix()
		public  Mat get_transitionMatrix ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1transitionMatrix_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::transitionMatrix
		//
	
		//javadoc: KalmanFilter::set_transitionMatrix(transitionMatrix)
		public  void set_transitionMatrix (Mat transitionMatrix)
		{
			ThrowIfDisposed ();
			if (transitionMatrix != null)
				transitionMatrix.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1transitionMatrix_10 (nativeObj, transitionMatrix.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::controlMatrix
		//
	
		//javadoc: KalmanFilter::get_controlMatrix()
		public  Mat get_controlMatrix ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1controlMatrix_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::controlMatrix
		//
	
		//javadoc: KalmanFilter::set_controlMatrix(controlMatrix)
		public  void set_controlMatrix (Mat controlMatrix)
		{
			ThrowIfDisposed ();
			if (controlMatrix != null)
				controlMatrix.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1controlMatrix_10 (nativeObj, controlMatrix.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::measurementMatrix
		//
	
		//javadoc: KalmanFilter::get_measurementMatrix()
		public  Mat get_measurementMatrix ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1measurementMatrix_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::measurementMatrix
		//
	
		//javadoc: KalmanFilter::set_measurementMatrix(measurementMatrix)
		public  void set_measurementMatrix (Mat measurementMatrix)
		{
			ThrowIfDisposed ();
			if (measurementMatrix != null)
				measurementMatrix.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1measurementMatrix_10 (nativeObj, measurementMatrix.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::processNoiseCov
		//
	
		//javadoc: KalmanFilter::get_processNoiseCov()
		public  Mat get_processNoiseCov ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1processNoiseCov_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::processNoiseCov
		//
	
		//javadoc: KalmanFilter::set_processNoiseCov(processNoiseCov)
		public  void set_processNoiseCov (Mat processNoiseCov)
		{
			ThrowIfDisposed ();
			if (processNoiseCov != null)
				processNoiseCov.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1processNoiseCov_10 (nativeObj, processNoiseCov.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::measurementNoiseCov
		//
	
		//javadoc: KalmanFilter::get_measurementNoiseCov()
		public  Mat get_measurementNoiseCov ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1measurementNoiseCov_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::measurementNoiseCov
		//
	
		//javadoc: KalmanFilter::set_measurementNoiseCov(measurementNoiseCov)
		public  void set_measurementNoiseCov (Mat measurementNoiseCov)
		{
			ThrowIfDisposed ();
			if (measurementNoiseCov != null)
				measurementNoiseCov.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1measurementNoiseCov_10 (nativeObj, measurementNoiseCov.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::errorCovPre
		//
	
		//javadoc: KalmanFilter::get_errorCovPre()
		public  Mat get_errorCovPre ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1errorCovPre_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::errorCovPre
		//
	
		//javadoc: KalmanFilter::set_errorCovPre(errorCovPre)
		public  void set_errorCovPre (Mat errorCovPre)
		{
			ThrowIfDisposed ();
			if (errorCovPre != null)
				errorCovPre.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1errorCovPre_10 (nativeObj, errorCovPre.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::gain
		//
	
		//javadoc: KalmanFilter::get_gain()
		public  Mat get_gain ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1gain_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::gain
		//
	
		//javadoc: KalmanFilter::set_gain(gain)
		public  void set_gain (Mat gain)
		{
			ThrowIfDisposed ();
			if (gain != null)
				gain.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1gain_10 (nativeObj, gain.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: Mat KalmanFilter::errorCovPost
		//
	
		//javadoc: KalmanFilter::get_errorCovPost()
		public  Mat get_errorCovPost ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (video_KalmanFilter_get_1errorCovPost_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: void KalmanFilter::errorCovPost
		//
	
		//javadoc: KalmanFilter::set_errorCovPost(errorCovPost)
		public  void set_errorCovPost (Mat errorCovPost)
		{
			ThrowIfDisposed ();
			if (errorCovPost != null)
				errorCovPost.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_KalmanFilter_set_1errorCovPost_10 (nativeObj, errorCovPost.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR

		// C++:   KalmanFilter()
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_KalmanFilter_10 ();

		// C++:   KalmanFilter(int dynamParams, int measureParams, int controlParams = 0, int type = CV_32F)
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_KalmanFilter_11 (int dynamParams, int measureParams, int controlParams, int type);
		
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_KalmanFilter_12 (int dynamParams, int measureParams);

		
		// C++:  Mat predict(Mat control = Mat())
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_predict_10 (IntPtr nativeObj, IntPtr control_nativeObj);
		
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_predict_11 (IntPtr nativeObj);
		
		// C++:  Mat correct(Mat measurement)
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_correct_10 (IntPtr nativeObj, IntPtr measurement_nativeObj);
		
		// C++: Mat KalmanFilter::statePre
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1statePre_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::statePre
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1statePre_10 (IntPtr nativeObj, IntPtr statePre_nativeObj);
		
		// C++: Mat KalmanFilter::statePost
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1statePost_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::statePost
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1statePost_10 (IntPtr nativeObj, IntPtr statePost_nativeObj);
		
		// C++: Mat KalmanFilter::transitionMatrix
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1transitionMatrix_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::transitionMatrix
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1transitionMatrix_10 (IntPtr nativeObj, IntPtr transitionMatrix_nativeObj);
		
		// C++: Mat KalmanFilter::controlMatrix
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1controlMatrix_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::controlMatrix
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1controlMatrix_10 (IntPtr nativeObj, IntPtr controlMatrix_nativeObj);
		
		// C++: Mat KalmanFilter::measurementMatrix
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1measurementMatrix_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::measurementMatrix
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1measurementMatrix_10 (IntPtr nativeObj, IntPtr measurementMatrix_nativeObj);
		
		// C++: Mat KalmanFilter::processNoiseCov
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1processNoiseCov_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::processNoiseCov
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1processNoiseCov_10 (IntPtr nativeObj, IntPtr processNoiseCov_nativeObj);
		
		// C++: Mat KalmanFilter::measurementNoiseCov
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1measurementNoiseCov_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::measurementNoiseCov
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1measurementNoiseCov_10 (IntPtr nativeObj, IntPtr measurementNoiseCov_nativeObj);
		
		// C++: Mat KalmanFilter::errorCovPre
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1errorCovPre_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::errorCovPre
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1errorCovPre_10 (IntPtr nativeObj, IntPtr errorCovPre_nativeObj);
		
		// C++: Mat KalmanFilter::gain
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1gain_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::gain
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1gain_10 (IntPtr nativeObj, IntPtr gain_nativeObj);
		
		// C++: Mat KalmanFilter::errorCovPost
		[DllImport("__Internal")]
		private static extern IntPtr video_KalmanFilter_get_1errorCovPost_10 (IntPtr nativeObj);
		
		// C++: void KalmanFilter::errorCovPost
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_set_1errorCovPost_10 (IntPtr nativeObj, IntPtr errorCovPost_nativeObj);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void video_KalmanFilter_delete (IntPtr nativeObj);
#else

		// C++:   KalmanFilter()
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_KalmanFilter_10 ();

		// C++:   KalmanFilter(int dynamParams, int measureParams, int controlParams = 0, int type = CV_32F)
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_KalmanFilter_11 (int dynamParams, int measureParams, int controlParams, int type);
		
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_KalmanFilter_12 (int dynamParams, int measureParams);

	
		// C++:  Mat predict(Mat control = Mat())
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_predict_10 (IntPtr nativeObj, IntPtr control_nativeObj);

		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_predict_11 (IntPtr nativeObj);
	
		// C++:  Mat correct(Mat measurement)
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_correct_10 (IntPtr nativeObj, IntPtr measurement_nativeObj);
	
		// C++: Mat KalmanFilter::statePre
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1statePre_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::statePre
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1statePre_10 (IntPtr nativeObj, IntPtr statePre_nativeObj);
	
		// C++: Mat KalmanFilter::statePost
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1statePost_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::statePost
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1statePost_10 (IntPtr nativeObj, IntPtr statePost_nativeObj);
	
		// C++: Mat KalmanFilter::transitionMatrix
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1transitionMatrix_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::transitionMatrix
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1transitionMatrix_10 (IntPtr nativeObj, IntPtr transitionMatrix_nativeObj);
	
		// C++: Mat KalmanFilter::controlMatrix
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1controlMatrix_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::controlMatrix
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1controlMatrix_10 (IntPtr nativeObj, IntPtr controlMatrix_nativeObj);
	
		// C++: Mat KalmanFilter::measurementMatrix
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1measurementMatrix_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::measurementMatrix
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1measurementMatrix_10 (IntPtr nativeObj, IntPtr measurementMatrix_nativeObj);
	
		// C++: Mat KalmanFilter::processNoiseCov
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1processNoiseCov_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::processNoiseCov
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1processNoiseCov_10 (IntPtr nativeObj, IntPtr processNoiseCov_nativeObj);
	
		// C++: Mat KalmanFilter::measurementNoiseCov
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1measurementNoiseCov_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::measurementNoiseCov
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1measurementNoiseCov_10 (IntPtr nativeObj, IntPtr measurementNoiseCov_nativeObj);
	
		// C++: Mat KalmanFilter::errorCovPre
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1errorCovPre_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::errorCovPre
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1errorCovPre_10 (IntPtr nativeObj, IntPtr errorCovPre_nativeObj);
	
		// C++: Mat KalmanFilter::gain
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1gain_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::gain
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1gain_10 (IntPtr nativeObj, IntPtr gain_nativeObj);
	
		// C++: Mat KalmanFilter::errorCovPost
		[DllImport("opencvforunity")]
		private static extern IntPtr video_KalmanFilter_get_1errorCovPost_10 (IntPtr nativeObj);
	
		// C++: void KalmanFilter::errorCovPost
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_set_1errorCovPost_10 (IntPtr nativeObj, IntPtr errorCovPost_nativeObj);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void video_KalmanFilter_delete (IntPtr nativeObj);
#endif
	
	}
}
