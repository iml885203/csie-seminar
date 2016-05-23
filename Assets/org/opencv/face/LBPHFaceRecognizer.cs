
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class LBPHFaceRecognizer
//javadoc: LBPHFaceRecognizer
		public class LBPHFaceRecognizer : FaceRecognizer
		{

				protected override void Dispose (bool disposing)
				{
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						try {
				
								if (disposing) {
								}
				
								if (IsEnabledDispose) {
										if (nativeObj != IntPtr.Zero)
												face_LBPHFaceRecognizer_delete (nativeObj);
										nativeObj = IntPtr.Zero;
								}
				
						} finally {
								base.Dispose (disposing);
						}
			
						#else
			return;
						#endif
				}
		
				public LBPHFaceRecognizer (IntPtr addr) : base(addr)
				{
				}
	
	
	
	

	
	
				//
				// C++:  int getGridX()
				//
	
				//javadoc: LBPHFaceRecognizer::getGridX()
				public  int getGridX ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						int retVal = face_LBPHFaceRecognizer_getGridX_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void setGridX(int val)
				//
	
				//javadoc: LBPHFaceRecognizer::setGridX(val)
				public  void setGridX (int val)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						face_LBPHFaceRecognizer_setGridX_10 (nativeObj, val);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int getGridY()
				//
	
				//javadoc: LBPHFaceRecognizer::getGridY()
				public  int getGridY ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						int retVal = face_LBPHFaceRecognizer_getGridY_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void setGridY(int val)
				//
	
				//javadoc: LBPHFaceRecognizer::setGridY(val)
				public  void setGridY (int val)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						face_LBPHFaceRecognizer_setGridY_10 (nativeObj, val);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int getRadius()
				//
	
				//javadoc: LBPHFaceRecognizer::getRadius()
				public  int getRadius ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						int retVal = face_LBPHFaceRecognizer_getRadius_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void setRadius(int val)
				//
	
				//javadoc: LBPHFaceRecognizer::setRadius(val)
				public  void setRadius (int val)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						face_LBPHFaceRecognizer_setRadius_10 (nativeObj, val);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int getNeighbors()
				//
	
				//javadoc: LBPHFaceRecognizer::getNeighbors()
				public  int getNeighbors ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						int retVal = face_LBPHFaceRecognizer_getNeighbors_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void setNeighbors(int val)
				//
	
				//javadoc: LBPHFaceRecognizer::setNeighbors(val)
				public  void setNeighbors (int val)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						face_LBPHFaceRecognizer_setNeighbors_10 (nativeObj, val);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  double getThreshold()
				//
	
				//javadoc: LBPHFaceRecognizer::getThreshold()
				public  double getThreshold ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = face_LBPHFaceRecognizer_getThreshold_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}

				//
				// C++:  void setThreshold(double val)
				//
		
				//javadoc: LBPHFaceRecognizer::setThreshold(val)
				public  void setThreshold (double val)
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						face_LBPHFaceRecognizer_setThreshold_10 (nativeObj, val);
			
						return;
						#else
			return;
						#endif
				}
		
		
				//
				// C++:  vector_Mat getHistograms()
				//
		
				//javadoc: LBPHFaceRecognizer::getHistograms()
				public  List<Mat> getHistograms ()
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						List<Mat> retVal = new List<Mat> ();
						Mat retValMat = new Mat (face_LBPHFaceRecognizer_getHistograms_10 (nativeObj));
						Converters.Mat_to_vector_Mat (retValMat, retVal);
						return retVal;
						#else
			return null;
						#endif
				}
		
		
				//
				// C++:  Mat getLabels()
				//
		
				//javadoc: LBPHFaceRecognizer::getLabels()
				public  Mat getLabels ()
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						Mat retVal = new Mat (face_LBPHFaceRecognizer_getLabels_10 (nativeObj));
			
						return retVal;
						#else
			return null;
						#endif
				}
	
	

	
		#if UNITY_IOS && !UNITY_EDITOR

		
		// C++:  int getGridX()
		[DllImport("__Internal")]
		private static extern int face_LBPHFaceRecognizer_getGridX_10 (IntPtr nativeObj);
		
		// C++:  void setGridX(int val)
		[DllImport("__Internal")]
		private static extern void face_LBPHFaceRecognizer_setGridX_10 (IntPtr nativeObj, int val);
		
		// C++:  int getGridY()
		[DllImport("__Internal")]
		private static extern int face_LBPHFaceRecognizer_getGridY_10 (IntPtr nativeObj);
		
		// C++:  void setGridY(int val)
		[DllImport("__Internal")]
		private static extern void face_LBPHFaceRecognizer_setGridY_10 (IntPtr nativeObj, int val);
		
		// C++:  int getRadius()
		[DllImport("__Internal")]
		private static extern int face_LBPHFaceRecognizer_getRadius_10 (IntPtr nativeObj);
		
		// C++:  void setRadius(int val)
		[DllImport("__Internal")]
		private static extern void face_LBPHFaceRecognizer_setRadius_10 (IntPtr nativeObj, int val);
		
		// C++:  int getNeighbors()
		[DllImport("__Internal")]
		private static extern int face_LBPHFaceRecognizer_getNeighbors_10 (IntPtr nativeObj);
		
		// C++:  void setNeighbors(int val)
		[DllImport("__Internal")]
		private static extern void face_LBPHFaceRecognizer_setNeighbors_10 (IntPtr nativeObj, int val);
		
		// C++:  double getThreshold()
		[DllImport("__Internal")]
		private static extern double face_LBPHFaceRecognizer_getThreshold_10 (IntPtr nativeObj);

		// C++:  void setThreshold(double val)
		[DllImport("__Internal")]
		private static extern void face_LBPHFaceRecognizer_setThreshold_10 (IntPtr nativeObj, double val);
		
		// C++:  vector_Mat getHistograms()
		[DllImport("__Internal")]
		private static extern IntPtr face_LBPHFaceRecognizer_getHistograms_10 (IntPtr nativeObj);
		
		// C++:  Mat getLabels()
		[DllImport("__Internal")]
		private static extern IntPtr face_LBPHFaceRecognizer_getLabels_10 (IntPtr nativeObj);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void face_LBPHFaceRecognizer_delete (IntPtr nativeObj);
#else
	

	
				// C++:  int getGridX()
				[DllImport("opencvforunity")]
				private static extern int face_LBPHFaceRecognizer_getGridX_10 (IntPtr nativeObj);
	
				// C++:  void setGridX(int val)
				[DllImport("opencvforunity")]
				private static extern void face_LBPHFaceRecognizer_setGridX_10 (IntPtr nativeObj, int val);
	
				// C++:  int getGridY()
				[DllImport("opencvforunity")]
				private static extern int face_LBPHFaceRecognizer_getGridY_10 (IntPtr nativeObj);
	
				// C++:  void setGridY(int val)
				[DllImport("opencvforunity")]
				private static extern void face_LBPHFaceRecognizer_setGridY_10 (IntPtr nativeObj, int val);
	
				// C++:  int getRadius()
				[DllImport("opencvforunity")]
				private static extern int face_LBPHFaceRecognizer_getRadius_10 (IntPtr nativeObj);
	
				// C++:  void setRadius(int val)
				[DllImport("opencvforunity")]
				private static extern void face_LBPHFaceRecognizer_setRadius_10 (IntPtr nativeObj, int val);
	
				// C++:  int getNeighbors()
				[DllImport("opencvforunity")]
				private static extern int face_LBPHFaceRecognizer_getNeighbors_10 (IntPtr nativeObj);
	
				// C++:  void setNeighbors(int val)
				[DllImport("opencvforunity")]
				private static extern void face_LBPHFaceRecognizer_setNeighbors_10 (IntPtr nativeObj, int val);
	
				// C++:  double getThreshold()
				[DllImport("opencvforunity")]
				private static extern double face_LBPHFaceRecognizer_getThreshold_10 (IntPtr nativeObj);

				// C++:  void setThreshold(double val)
				[DllImport("opencvforunity")]
				private static extern void face_LBPHFaceRecognizer_setThreshold_10 (IntPtr nativeObj, double val);
		
				// C++:  vector_Mat getHistograms()
				[DllImport("opencvforunity")]
				private static extern IntPtr face_LBPHFaceRecognizer_getHistograms_10 (IntPtr nativeObj);
		
				// C++:  Mat getLabels()
				[DllImport("opencvforunity")]
				private static extern IntPtr face_LBPHFaceRecognizer_getLabels_10 (IntPtr nativeObj);
	
				// native support for java finalize()
				[DllImport("opencvforunity")]
				private static extern void face_LBPHFaceRecognizer_delete (IntPtr nativeObj);
#endif
	
		}
}
