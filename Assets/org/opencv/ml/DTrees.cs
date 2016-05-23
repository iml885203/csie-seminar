
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class DTrees
//javadoc: DTrees
	public class DTrees : StatModel
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						ml_DTrees_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		protected DTrees (IntPtr addr) : base(addr)
		{
		}
	
		public const int
			PREDICT_AUTO = 0,
			PREDICT_SUM = (1 << 8),
			PREDICT_MAX_VOTE = (2 << 8),
			PREDICT_MASK = (3 << 8);
	
	
		//
		// C++:  int getMaxCategories()
		//
	
		//javadoc: DTrees::getMaxCategories()
		public  int getMaxCategories ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_DTrees_getMaxCategories_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setMaxCategories(int val)
		//
	
		//javadoc: DTrees::setMaxCategories(val)
		public  void setMaxCategories (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_DTrees_setMaxCategories_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getMaxDepth()
		//
	
		//javadoc: DTrees::getMaxDepth()
		public  int getMaxDepth ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_DTrees_getMaxDepth_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setMaxDepth(int val)
		//
	
		//javadoc: DTrees::setMaxDepth(val)
		public  void setMaxDepth (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_DTrees_setMaxDepth_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getMinSampleCount()
		//
	
		//javadoc: DTrees::getMinSampleCount()
		public  int getMinSampleCount ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_DTrees_getMinSampleCount_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setMinSampleCount(int val)
		//
	
		//javadoc: DTrees::setMinSampleCount(val)
		public  void setMinSampleCount (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_DTrees_setMinSampleCount_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getCVFolds()
		//
	
		//javadoc: DTrees::getCVFolds()
		public  int getCVFolds ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_DTrees_getCVFolds_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setCVFolds(int val)
		//
	
		//javadoc: DTrees::setCVFolds(val)
		public  void setCVFolds (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_DTrees_setCVFolds_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  bool getUseSurrogates()
		//
	
		//javadoc: DTrees::getUseSurrogates()
		public  bool getUseSurrogates ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			bool retVal = ml_DTrees_getUseSurrogates_10 (nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  void setUseSurrogates(bool val)
		//
	
		//javadoc: DTrees::setUseSurrogates(val)
		public  void setUseSurrogates (bool val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_DTrees_setUseSurrogates_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  bool getUse1SERule()
		//
	
		//javadoc: DTrees::getUse1SERule()
		public  bool getUse1SERule ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			bool retVal = ml_DTrees_getUse1SERule_10 (nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  void setUse1SERule(bool val)
		//
	
		//javadoc: DTrees::setUse1SERule(val)
		public  void setUse1SERule (bool val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_DTrees_setUse1SERule_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  bool getTruncatePrunedTree()
		//
	
		//javadoc: DTrees::getTruncatePrunedTree()
		public  bool getTruncatePrunedTree ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			bool retVal = ml_DTrees_getTruncatePrunedTree_10 (nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  void setTruncatePrunedTree(bool val)
		//
	
		//javadoc: DTrees::setTruncatePrunedTree(val)
		public  void setTruncatePrunedTree (bool val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_DTrees_setTruncatePrunedTree_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  float getRegressionAccuracy()
		//
	
		//javadoc: DTrees::getRegressionAccuracy()
		public  float getRegressionAccuracy ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = ml_DTrees_getRegressionAccuracy_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setRegressionAccuracy(float val)
		//
	
		//javadoc: DTrees::setRegressionAccuracy(val)
		public  void setRegressionAccuracy (float val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_DTrees_setRegressionAccuracy_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  Mat getPriors()
		//
	
		//javadoc: DTrees::getPriors()
		public  Mat getPriors ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_DTrees_getPriors_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  void setPriors(Mat val)
		//
	
		//javadoc: DTrees::setPriors(val)
		public  void setPriors (Mat val)
		{
			ThrowIfDisposed ();
			if (val != null)
				val.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_DTrees_setPriors_10 (nativeObj, val.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: static Ptr_DTrees create()
		//
	
		//javadoc: DTrees::create()
		public static DTrees create ()
		{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			DTrees retVal = new DTrees (ml_DTrees_create_10 ());
		
			return retVal;
#else
return null;
#endif
		}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  int getMaxCategories()
		[DllImport("__Internal")]
		private static extern int ml_DTrees_getMaxCategories_10 (IntPtr nativeObj);
		
		// C++:  void setMaxCategories(int val)
		[DllImport("__Internal")]
		private static extern void ml_DTrees_setMaxCategories_10 (IntPtr nativeObj, int val);
		
		// C++:  int getMaxDepth()
		[DllImport("__Internal")]
		private static extern int ml_DTrees_getMaxDepth_10 (IntPtr nativeObj);
		
		// C++:  void setMaxDepth(int val)
		[DllImport("__Internal")]
		private static extern void ml_DTrees_setMaxDepth_10 (IntPtr nativeObj, int val);
		
		// C++:  int getMinSampleCount()
		[DllImport("__Internal")]
		private static extern int ml_DTrees_getMinSampleCount_10 (IntPtr nativeObj);
		
		// C++:  void setMinSampleCount(int val)
		[DllImport("__Internal")]
		private static extern void ml_DTrees_setMinSampleCount_10 (IntPtr nativeObj, int val);
		
		// C++:  int getCVFolds()
		[DllImport("__Internal")]
		private static extern int ml_DTrees_getCVFolds_10 (IntPtr nativeObj);
		
		// C++:  void setCVFolds(int val)
		[DllImport("__Internal")]
		private static extern void ml_DTrees_setCVFolds_10 (IntPtr nativeObj, int val);
		
		// C++:  bool getUseSurrogates()
		[DllImport("__Internal")]
		private static extern bool ml_DTrees_getUseSurrogates_10 (IntPtr nativeObj);
		
		// C++:  void setUseSurrogates(bool val)
		[DllImport("__Internal")]
		private static extern void ml_DTrees_setUseSurrogates_10 (IntPtr nativeObj, bool val);
		
		// C++:  bool getUse1SERule()
		[DllImport("__Internal")]
		private static extern bool ml_DTrees_getUse1SERule_10 (IntPtr nativeObj);
		
		// C++:  void setUse1SERule(bool val)
		[DllImport("__Internal")]
		private static extern void ml_DTrees_setUse1SERule_10 (IntPtr nativeObj, bool val);
		
		// C++:  bool getTruncatePrunedTree()
		[DllImport("__Internal")]
		private static extern bool ml_DTrees_getTruncatePrunedTree_10 (IntPtr nativeObj);
		
		// C++:  void setTruncatePrunedTree(bool val)
		[DllImport("__Internal")]
		private static extern void ml_DTrees_setTruncatePrunedTree_10 (IntPtr nativeObj, bool val);
		
		// C++:  float getRegressionAccuracy()
		[DllImport("__Internal")]
		private static extern float ml_DTrees_getRegressionAccuracy_10 (IntPtr nativeObj);
		
		// C++:  void setRegressionAccuracy(float val)
		[DllImport("__Internal")]
		private static extern void ml_DTrees_setRegressionAccuracy_10 (IntPtr nativeObj, float val);
		
		// C++:  Mat getPriors()
		[DllImport("__Internal")]
		private static extern IntPtr ml_DTrees_getPriors_10 (IntPtr nativeObj);
		
		// C++:  void setPriors(Mat val)
		[DllImport("__Internal")]
		private static extern void ml_DTrees_setPriors_10 (IntPtr nativeObj, IntPtr val_nativeObj);
		
		// C++: static Ptr_DTrees create()
		[DllImport("__Internal")]
		private static extern IntPtr ml_DTrees_create_10 ();
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void ml_DTrees_delete (IntPtr nativeObj);
#else
		// C++:  int getMaxCategories()
		[DllImport("opencvforunity")]
		private static extern int ml_DTrees_getMaxCategories_10 (IntPtr nativeObj);
	
		// C++:  void setMaxCategories(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_setMaxCategories_10 (IntPtr nativeObj, int val);
	
		// C++:  int getMaxDepth()
		[DllImport("opencvforunity")]
		private static extern int ml_DTrees_getMaxDepth_10 (IntPtr nativeObj);
	
		// C++:  void setMaxDepth(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_setMaxDepth_10 (IntPtr nativeObj, int val);
	
		// C++:  int getMinSampleCount()
		[DllImport("opencvforunity")]
		private static extern int ml_DTrees_getMinSampleCount_10 (IntPtr nativeObj);
	
		// C++:  void setMinSampleCount(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_setMinSampleCount_10 (IntPtr nativeObj, int val);
	
		// C++:  int getCVFolds()
		[DllImport("opencvforunity")]
		private static extern int ml_DTrees_getCVFolds_10 (IntPtr nativeObj);
	
		// C++:  void setCVFolds(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_setCVFolds_10 (IntPtr nativeObj, int val);
	
		// C++:  bool getUseSurrogates()
		[DllImport("opencvforunity")]
		private static extern bool ml_DTrees_getUseSurrogates_10 (IntPtr nativeObj);
	
		// C++:  void setUseSurrogates(bool val)
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_setUseSurrogates_10 (IntPtr nativeObj, bool val);
	
		// C++:  bool getUse1SERule()
		[DllImport("opencvforunity")]
		private static extern bool ml_DTrees_getUse1SERule_10 (IntPtr nativeObj);
	
		// C++:  void setUse1SERule(bool val)
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_setUse1SERule_10 (IntPtr nativeObj, bool val);
	
		// C++:  bool getTruncatePrunedTree()
		[DllImport("opencvforunity")]
		private static extern bool ml_DTrees_getTruncatePrunedTree_10 (IntPtr nativeObj);
	
		// C++:  void setTruncatePrunedTree(bool val)
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_setTruncatePrunedTree_10 (IntPtr nativeObj, bool val);
	
		// C++:  float getRegressionAccuracy()
		[DllImport("opencvforunity")]
		private static extern float ml_DTrees_getRegressionAccuracy_10 (IntPtr nativeObj);
	
		// C++:  void setRegressionAccuracy(float val)
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_setRegressionAccuracy_10 (IntPtr nativeObj, float val);
	
		// C++:  Mat getPriors()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_DTrees_getPriors_10 (IntPtr nativeObj);
	
		// C++:  void setPriors(Mat val)
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_setPriors_10 (IntPtr nativeObj, IntPtr val_nativeObj);
	
		// C++: static Ptr_DTrees create()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_DTrees_create_10 ();
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void ml_DTrees_delete (IntPtr nativeObj);
#endif
	
	}
}
