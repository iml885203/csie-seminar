
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class KNearest
//javadoc: KNearest
	public class KNearest : StatModel
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						ml_KNearest_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		protected KNearest (IntPtr addr) : base(addr)
		{
		}
	
		public const int
			BRUTE_FORCE = 1,
			KDTREE = 2;
	
	
		//
		// C++:  int getDefaultK()
		//
	
		//javadoc: KNearest::getDefaultK()
		public  int getDefaultK ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_KNearest_getDefaultK_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setDefaultK(int val)
		//
	
		//javadoc: KNearest::setDefaultK(val)
		public  void setDefaultK (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_KNearest_setDefaultK_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  bool getIsClassifier()
		//
	
		//javadoc: KNearest::getIsClassifier()
		public  bool getIsClassifier ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			bool retVal = ml_KNearest_getIsClassifier_10 (nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  void setIsClassifier(bool val)
		//
	
		//javadoc: KNearest::setIsClassifier(val)
		public  void setIsClassifier (bool val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_KNearest_setIsClassifier_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getEmax()
		//
	
		//javadoc: KNearest::getEmax()
		public  int getEmax ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_KNearest_getEmax_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setEmax(int val)
		//
	
		//javadoc: KNearest::setEmax(val)
		public  void setEmax (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_KNearest_setEmax_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getAlgorithmType()
		//
	
		//javadoc: KNearest::getAlgorithmType()
		public  int getAlgorithmType ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_KNearest_getAlgorithmType_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setAlgorithmType(int val)
		//
	
		//javadoc: KNearest::setAlgorithmType(val)
		public  void setAlgorithmType (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_KNearest_setAlgorithmType_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  float findNearest(Mat samples, int k, Mat& results, Mat& neighborResponses = Mat(), Mat& dist = Mat())
		//
	
		//javadoc: KNearest::findNearest(samples, k, results, neighborResponses, dist)
		public  float findNearest (Mat samples, int k, Mat results, Mat neighborResponses, Mat dist)
		{
			ThrowIfDisposed ();
			if (samples != null)
				samples.ThrowIfDisposed ();
			if (results != null)
				results.ThrowIfDisposed ();
			if (neighborResponses != null)
				neighborResponses.ThrowIfDisposed ();
			if (dist != null)
				dist.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = ml_KNearest_findNearest_10 (nativeObj, samples.nativeObj, k, results.nativeObj, neighborResponses.nativeObj, dist.nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
		//javadoc: KNearest::findNearest(samples, k, results)
		public  float findNearest (Mat samples, int k, Mat results)
		{
			ThrowIfDisposed ();
			if (samples != null)
				samples.ThrowIfDisposed ();
			if (results != null)
				results.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = ml_KNearest_findNearest_11 (nativeObj, samples.nativeObj, k, results.nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++: static Ptr_KNearest create()
		//
	
		//javadoc: KNearest::create()
		public static KNearest create ()
		{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			KNearest retVal = new KNearest (ml_KNearest_create_10 ());
		
			return retVal;
#else
return null;
#endif
		}
	
	

	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  int getDefaultK()
		[DllImport("__Internal")]
		private static extern int ml_KNearest_getDefaultK_10 (IntPtr nativeObj);
		
		// C++:  void setDefaultK(int val)
		[DllImport("__Internal")]
		private static extern void ml_KNearest_setDefaultK_10 (IntPtr nativeObj, int val);
		
		// C++:  bool getIsClassifier()
		[DllImport("__Internal")]
		private static extern bool ml_KNearest_getIsClassifier_10 (IntPtr nativeObj);
		
		// C++:  void setIsClassifier(bool val)
		[DllImport("__Internal")]
		private static extern void ml_KNearest_setIsClassifier_10 (IntPtr nativeObj, bool val);
		
		// C++:  int getEmax()
		[DllImport("__Internal")]
		private static extern int ml_KNearest_getEmax_10 (IntPtr nativeObj);
		
		// C++:  void setEmax(int val)
		[DllImport("__Internal")]
		private static extern void ml_KNearest_setEmax_10 (IntPtr nativeObj, int val);
		
		// C++:  int getAlgorithmType()
		[DllImport("__Internal")]
		private static extern int ml_KNearest_getAlgorithmType_10 (IntPtr nativeObj);
		
		// C++:  void setAlgorithmType(int val)
		[DllImport("__Internal")]
		private static extern void ml_KNearest_setAlgorithmType_10 (IntPtr nativeObj, int val);
		
		// C++:  float findNearest(Mat samples, int k, Mat& results, Mat& neighborResponses = Mat(), Mat& dist = Mat())
		[DllImport("__Internal")]
		private static extern float ml_KNearest_findNearest_10 (IntPtr nativeObj, IntPtr samples_nativeObj, int k, IntPtr results_nativeObj, IntPtr neighborResponses_nativeObj, IntPtr dist_nativeObj);
		
		[DllImport("__Internal")]
		private static extern float ml_KNearest_findNearest_11 (IntPtr nativeObj, IntPtr samples_nativeObj, int k, IntPtr results_nativeObj);
		
		// C++: static Ptr_KNearest create()
		[DllImport("__Internal")]
		private static extern IntPtr ml_KNearest_create_10 ();
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void ml_KNearest_delete (IntPtr nativeObj);
#else
	
		// C++:  int getDefaultK()
		[DllImport("opencvforunity")]
		private static extern int ml_KNearest_getDefaultK_10 (IntPtr nativeObj);
	
		// C++:  void setDefaultK(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_KNearest_setDefaultK_10 (IntPtr nativeObj, int val);
	
		// C++:  bool getIsClassifier()
		[DllImport("opencvforunity")]
		private static extern bool ml_KNearest_getIsClassifier_10 (IntPtr nativeObj);
	
		// C++:  void setIsClassifier(bool val)
		[DllImport("opencvforunity")]
		private static extern void ml_KNearest_setIsClassifier_10 (IntPtr nativeObj, bool val);
	
		// C++:  int getEmax()
		[DllImport("opencvforunity")]
		private static extern int ml_KNearest_getEmax_10 (IntPtr nativeObj);
	
		// C++:  void setEmax(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_KNearest_setEmax_10 (IntPtr nativeObj, int val);
	
		// C++:  int getAlgorithmType()
		[DllImport("opencvforunity")]
		private static extern int ml_KNearest_getAlgorithmType_10 (IntPtr nativeObj);
	
		// C++:  void setAlgorithmType(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_KNearest_setAlgorithmType_10 (IntPtr nativeObj, int val);
	
		// C++:  float findNearest(Mat samples, int k, Mat& results, Mat& neighborResponses = Mat(), Mat& dist = Mat())
		[DllImport("opencvforunity")]
		private static extern float ml_KNearest_findNearest_10 (IntPtr nativeObj, IntPtr samples_nativeObj, int k, IntPtr results_nativeObj, IntPtr neighborResponses_nativeObj, IntPtr dist_nativeObj);

		[DllImport("opencvforunity")]
		private static extern float ml_KNearest_findNearest_11 (IntPtr nativeObj, IntPtr samples_nativeObj, int k, IntPtr results_nativeObj);
	
		// C++: static Ptr_KNearest create()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_KNearest_create_10 ();
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void ml_KNearest_delete (IntPtr nativeObj);
#endif
	
	}
}

