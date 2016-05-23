
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class BasicFaceRecognizer
//javadoc: BasicFaceRecognizer
		public class BasicFaceRecognizer : FaceRecognizer
		{

				protected override void Dispose (bool disposing)
				{
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						try {
				
								if (disposing) {
								}
				
								if (IsEnabledDispose) {
										if (nativeObj != IntPtr.Zero)
												face_BasicFaceRecognizer_delete (nativeObj);
										nativeObj = IntPtr.Zero;
								}
				
						} finally {
								base.Dispose (disposing);
						}
			
						#else
			return;
						#endif
				}
		
				public BasicFaceRecognizer (IntPtr addr) : base(addr)
				{
				}
	
	
				//
				// C++:  int getNumComponents()
				//
		
				//javadoc: BasicFaceRecognizer::getNumComponents()
				public  int getNumComponents ()
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						int retVal = face_BasicFaceRecognizer_getNumComponents_10 (nativeObj);
			
						return retVal;
						#else
			return -1;
						#endif
				}


				//
				// C++:  void setNumComponents(int val)
				//
		
				//javadoc: BasicFaceRecognizer::setNumComponents(val)
				public  void setNumComponents (int val)
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						face_BasicFaceRecognizer_setNumComponents_10 (nativeObj, val);
			
						return;
						#else
			return;
						#endif
				}
		
		
		
		
		
				//
				// C++:  Mat getLabels()
				//
		
				//javadoc: BasicFaceRecognizer::getLabels()
				public  Mat getLabels ()
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						Mat retVal = new Mat (face_BasicFaceRecognizer_getLabels_10 (nativeObj));
			
						return retVal;
						#else
			return null;
						#endif
				}
		
		
				//
				// C++:  Mat getEigenValues()
				//
		
				//javadoc: BasicFaceRecognizer::getEigenValues()
				public  Mat getEigenValues ()
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						Mat retVal = new Mat (face_BasicFaceRecognizer_getEigenValues_10 (nativeObj));
			
						return retVal;
						#else
			return null;
						#endif
				}
		
		
				//
				// C++:  Mat getEigenVectors()
				//
		
				//javadoc: BasicFaceRecognizer::getEigenVectors()
				public  Mat getEigenVectors ()
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						Mat retVal = new Mat (face_BasicFaceRecognizer_getEigenVectors_10 (nativeObj));
			
						return retVal;
						#else
			return null;
						#endif
				}
		
		
				//
				// C++:  Mat getMean()
				//
		
				//javadoc: BasicFaceRecognizer::getMean()
				public  Mat getMean ()
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						Mat retVal = new Mat (face_BasicFaceRecognizer_getMean_10 (nativeObj));
			
						return retVal;
						#else
			return null;
						#endif
				}

	

	
	
				//
				// C++:  double getThreshold()
				//
	
				//javadoc: BasicFaceRecognizer::getThreshold()
				public  double getThreshold ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = face_BasicFaceRecognizer_getThreshold_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void setThreshold(double val)
				//
	
				//javadoc: BasicFaceRecognizer::setThreshold(val)
				public  void setThreshold (double val)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						face_BasicFaceRecognizer_setThreshold_10 (nativeObj, val);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  vector_Mat getProjections()
				//
		
				//javadoc: BasicFaceRecognizer::getProjections()
				public  List<Mat> getProjections ()
				{
						ThrowIfDisposed ();
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						List<Mat> retVal = new List<Mat> ();
						Mat retValMat = new Mat (face_BasicFaceRecognizer_getProjections_10 (nativeObj));
						Converters.Mat_to_vector_Mat (retValMat, retVal);
						return retVal;
						#else
			return null;
						#endif
				}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  int getNumComponents()
		[DllImport("__Internal")]
		private static extern int face_BasicFaceRecognizer_getNumComponents_10 (IntPtr nativeObj);

		// C++:  void setNumComponents(int val)
		[DllImport("__Internal")]
		private static extern void face_BasicFaceRecognizer_setNumComponents_10 (IntPtr nativeObj, int val);
		
		
		
		// C++:  Mat getLabels()
		[DllImport("__Internal")]
		private static extern IntPtr face_BasicFaceRecognizer_getLabels_10 (IntPtr nativeObj);
		
		// C++:  Mat getEigenValues()
		[DllImport("__Internal")]
		private static extern IntPtr face_BasicFaceRecognizer_getEigenValues_10 (IntPtr nativeObj);
		
		// C++:  Mat getEigenVectors()
		[DllImport("__Internal")]
		private static extern IntPtr face_BasicFaceRecognizer_getEigenVectors_10 (IntPtr nativeObj);
		
		// C++:  Mat getMean()
		[DllImport("__Internal")]
		private static extern IntPtr face_BasicFaceRecognizer_getMean_10 (IntPtr nativeObj);


		
		// C++:  double getThreshold()
		[DllImport("__Internal")]
		private static extern double face_BasicFaceRecognizer_getThreshold_10 (IntPtr nativeObj);
		
		// C++:  void setThreshold(double val)
		[DllImport("__Internal")]
		private static extern void face_BasicFaceRecognizer_setThreshold_10 (IntPtr nativeObj, double val);
		
		// C++:  vector_Mat getProjections()
		[DllImport("__Internal")]
		private static extern IntPtr face_BasicFaceRecognizer_getProjections_10 (IntPtr nativeObj);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void face_BasicFaceRecognizer_delete (IntPtr nativeObj);
#else
				// C++:  int getNumComponents()
				[DllImport("opencvforunity")]
				private static extern int face_BasicFaceRecognizer_getNumComponents_10 (IntPtr nativeObj);

				// C++:  void setNumComponents(int val)
				[DllImport("opencvforunity")]
				private static extern void face_BasicFaceRecognizer_setNumComponents_10 (IntPtr nativeObj, int val);
		
		
		
				// C++:  Mat getLabels()
				[DllImport("opencvforunity")]
				private static extern IntPtr face_BasicFaceRecognizer_getLabels_10 (IntPtr nativeObj);
		
				// C++:  Mat getEigenValues()
				[DllImport("opencvforunity")]
				private static extern IntPtr face_BasicFaceRecognizer_getEigenValues_10 (IntPtr nativeObj);
		
				// C++:  Mat getEigenVectors()
				[DllImport("opencvforunity")]
				private static extern IntPtr face_BasicFaceRecognizer_getEigenVectors_10 (IntPtr nativeObj);
		
				// C++:  Mat getMean()
				[DllImport("opencvforunity")]
				private static extern IntPtr face_BasicFaceRecognizer_getMean_10 (IntPtr nativeObj);


	
				// C++:  double getThreshold()
				[DllImport("opencvforunity")]
				private static extern double face_BasicFaceRecognizer_getThreshold_10 (IntPtr nativeObj);
	
				// C++:  void setThreshold(double val)
				[DllImport("opencvforunity")]
				private static extern void face_BasicFaceRecognizer_setThreshold_10 (IntPtr nativeObj, double val);
	
				// C++:  vector_Mat getProjections()
				[DllImport("opencvforunity")]
				private static extern IntPtr face_BasicFaceRecognizer_getProjections_10 (IntPtr nativeObj);
	
				// native support for java finalize()
				[DllImport("opencvforunity")]
				private static extern void face_BasicFaceRecognizer_delete (IntPtr nativeObj);
#endif
	
		}
}

