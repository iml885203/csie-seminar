
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class TrainData
//javadoc: TrainData
	public class TrainData  : DisposableOpenCVObject
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						ml_TrainData_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		protected TrainData (IntPtr addr) : base(addr)
		{
		
		}

	
	
		//
		// C++:  int getLayout()
		//
	
		//javadoc: TrainData::getLayout()
		public  int getLayout ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_TrainData_getLayout_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  int getNSamples()
		//
	
		//javadoc: TrainData::getNSamples()
		public  int getNSamples ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_TrainData_getNSamples_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  int getNTestSamples()
		//
	
		//javadoc: TrainData::getNTestSamples()
		public  int getNTestSamples ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_TrainData_getNTestSamples_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  int getNTrainSamples()
		//
	
		//javadoc: TrainData::getNTrainSamples()
		public  int getNTrainSamples ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_TrainData_getNTrainSamples_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  int getNVars()
		//
	
		//javadoc: TrainData::getNVars()
		public  int getNVars ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_TrainData_getNVars_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  int getNAllVars()
		//
	
		//javadoc: TrainData::getNAllVars()
		public  int getNAllVars ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_TrainData_getNAllVars_10 (nativeObj);
		
			return retVal;
#else
			return -1;
#endif
		}
	
	
		//
		// C++:  void getSample(Mat varIdx, int sidx, float* buf)
		//
	
		//javadoc: TrainData::getSample(varIdx, sidx, buf)
		public  void getSample (Mat varIdx, int sidx, float buf)
		{
			ThrowIfDisposed ();
			if (varIdx != null)
				varIdx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_TrainData_getSample_10 (nativeObj, varIdx.nativeObj, sidx, buf);
		
			return;
#else
return;
#endif
		}

		//
		// C++:  Mat getSamples()
		//
		
		//javadoc: TrainData::getSamples()
		public  Mat getSamples ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			Mat retVal = new Mat (ml_TrainData_getSamples_10 (nativeObj));
			
			return retVal;
			#else
			return null;
			#endif
		}
	
	
		//
		// C++:  Mat getMissing()
		//
	
		//javadoc: TrainData::getMissing()
		public  Mat getMissing ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getMissing_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getTrainSamples(int layout = ROW_SAMPLE, bool compressSamples = true, bool compressVars = true)
		//
	
		//javadoc: TrainData::getTrainSamples(layout, compressSamples, compressVars)
		public  Mat getTrainSamples (int layout, bool compressSamples, bool compressVars)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTrainSamples_10 (nativeObj, layout, compressSamples, compressVars));
		
			return retVal;
#else
return null;
#endif
		}
	
		//javadoc: TrainData::getTrainSamples()
		public  Mat getTrainSamples ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTrainSamples_11 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getTrainResponses()
		//
	
		//javadoc: TrainData::getTrainResponses()
		public  Mat getTrainResponses ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTrainResponses_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getTrainNormCatResponses()
		//
	
		//javadoc: TrainData::getTrainNormCatResponses()
		public  Mat getTrainNormCatResponses ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTrainNormCatResponses_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getTestResponses()
		//
	
		//javadoc: TrainData::getTestResponses()
		public  Mat getTestResponses ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTestResponses_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getTestNormCatResponses()
		//
	
		//javadoc: TrainData::getTestNormCatResponses()
		public  Mat getTestNormCatResponses ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTestNormCatResponses_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getResponses()
		//
	
		//javadoc: TrainData::getResponses()
		public  Mat getResponses ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getResponses_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getNormCatResponses()
		//
	
		//javadoc: TrainData::getNormCatResponses()
		public  Mat getNormCatResponses ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getNormCatResponses_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	

	
	
		//
		// C++:  Mat getSampleWeights()
		//
	
		//javadoc: TrainData::getSampleWeights()
		public  Mat getSampleWeights ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getSampleWeights_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getTrainSampleWeights()
		//
	
		//javadoc: TrainData::getTrainSampleWeights()
		public  Mat getTrainSampleWeights ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTrainSampleWeights_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getTestSampleWeights()
		//
	
		//javadoc: TrainData::getTestSampleWeights()
		public  Mat getTestSampleWeights ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTestSampleWeights_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getVarIdx()
		//
	
		//javadoc: TrainData::getVarIdx()
		public  Mat getVarIdx ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getVarIdx_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getVarType()
		//
	
		//javadoc: TrainData::getVarType()
		public  Mat getVarType ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getVarType_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  int getResponseType()
		//
	
		//javadoc: TrainData::getResponseType()
		public  int getResponseType ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_TrainData_getResponseType_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  Mat getTrainSampleIdx()
		//
	
		//javadoc: TrainData::getTrainSampleIdx()
		public  Mat getTrainSampleIdx ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTrainSampleIdx_10 (nativeObj));
		
			return retVal;
#else
			return null;
#endif
		}
	
	
		//
		// C++:  Mat getTestSampleIdx()
		//
	
		//javadoc: TrainData::getTestSampleIdx()
		public  Mat getTestSampleIdx ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getTestSampleIdx_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  void getValues(int vi, Mat sidx, float* values)
		//
	
		//javadoc: TrainData::getValues(vi, sidx, values)
		public  void getValues (int vi, Mat sidx, float values)
		{
			ThrowIfDisposed ();
			if (sidx != null)
				sidx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_TrainData_getValues_10 (nativeObj, vi, sidx.nativeObj, values);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  Mat getDefaultSubstValues()
		//
	
		//javadoc: TrainData::getDefaultSubstValues()
		public  Mat getDefaultSubstValues ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getDefaultSubstValues_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  int getCatCount(int vi)
		//
	
		//javadoc: TrainData::getCatCount(vi)
		public  int getCatCount (int vi)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_TrainData_getCatCount_10 (nativeObj, vi);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  Mat getClassLabels()
		//
	
		//javadoc: TrainData::getClassLabels()
		public  Mat getClassLabels ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getClassLabels_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getCatOfs()
		//
	
		//javadoc: TrainData::getCatOfs()
		public  Mat getCatOfs ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getCatOfs_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  Mat getCatMap()
		//
	
		//javadoc: TrainData::getCatMap()
		public  Mat getCatMap ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getCatMap_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  void setTrainTestSplit(int count, bool shuffle = true)
		//
	
		//javadoc: TrainData::setTrainTestSplit(count, shuffle)
		public  void setTrainTestSplit (int count, bool shuffle)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_TrainData_setTrainTestSplit_10 (nativeObj, count, shuffle);
		
			return;
#else
return;
#endif
		}
	
		//javadoc: TrainData::setTrainTestSplit(count)
		public  void setTrainTestSplit (int count)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_TrainData_setTrainTestSplit_11 (nativeObj, count);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void setTrainTestSplitRatio(double ratio, bool shuffle = true)
		//
	
		//javadoc: TrainData::setTrainTestSplitRatio(ratio, shuffle)
		public  void setTrainTestSplitRatio (double ratio, bool shuffle)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_TrainData_setTrainTestSplitRatio_10 (nativeObj, ratio, shuffle);
		
			return;
#else
return;
#endif
		}
	
		//javadoc: TrainData::setTrainTestSplitRatio(ratio)
		public  void setTrainTestSplitRatio (double ratio)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_TrainData_setTrainTestSplitRatio_11 (nativeObj, ratio);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void shuffleTrainTest()
		//
	
		//javadoc: TrainData::shuffleTrainTest()
		public  void shuffleTrainTest ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_TrainData_shuffleTrainTest_10 (nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: static Mat getSubVector(Mat vec, Mat idx)
		//
	
		//javadoc: TrainData::getSubVector(vec, idx)
		public static Mat getSubVector (Mat vec, Mat idx)
		{
			if (vec != null)
				vec.ThrowIfDisposed ();
			if (idx != null)
				idx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_TrainData_getSubVector_10 (vec.nativeObj, idx.nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: static Ptr_TrainData create(Mat samples, int layout, Mat responses, Mat varIdx = Mat(), Mat sampleIdx = Mat(), Mat sampleWeights = Mat(), Mat varType = Mat())
		//
	
		// Return type 'Ptr_TrainData' is not supported, skipping the function
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  int getLayout()
		[DllImport("__Internal")]
		private static extern int ml_TrainData_getLayout_10 (IntPtr nativeObj);
		
		// C++:  int getNSamples()
		[DllImport("__Internal")]
		private static extern int ml_TrainData_getNSamples_10 (IntPtr nativeObj);
		
		// C++:  int getNTestSamples()
		[DllImport("__Internal")]
		private static extern int ml_TrainData_getNTestSamples_10 (IntPtr nativeObj);
		
		// C++:  int getNTrainSamples()
		[DllImport("__Internal")]
		private static extern int ml_TrainData_getNTrainSamples_10 (IntPtr nativeObj);
		
		// C++:  int getNVars()
		[DllImport("__Internal")]
		private static extern int ml_TrainData_getNVars_10 (IntPtr nativeObj);
		
		// C++:  int getNAllVars()
		[DllImport("__Internal")]
		private static extern int ml_TrainData_getNAllVars_10 (IntPtr nativeObj);
		
		// C++:  void getSample(Mat varIdx, int sidx, float* buf)
		[DllImport("__Internal")]
		private static extern void ml_TrainData_getSample_10 (IntPtr nativeObj, IntPtr varIdx_nativeObj, int sidx, float buf);

		// C++:  Mat getSamples()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getSamples_10 (IntPtr nativeObj);

		// C++:  Mat getMissing()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getMissing_10 (IntPtr nativeObj);
		
		// C++:  Mat getTrainSamples(int layout = ROW_SAMPLE, bool compressSamples = true, bool compressVars = true)
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTrainSamples_10 (IntPtr nativeObj, int layout, bool compressSamples, bool compressVars);
		
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTrainSamples_11 (IntPtr nativeObj);
		
		// C++:  Mat getTrainResponses()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTrainResponses_10 (IntPtr nativeObj);
		
		// C++:  Mat getTrainNormCatResponses()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTrainNormCatResponses_10 (IntPtr nativeObj);
		
		// C++:  Mat getTestResponses()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTestResponses_10 (IntPtr nativeObj);
		
		// C++:  Mat getTestNormCatResponses()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTestNormCatResponses_10 (IntPtr nativeObj);
		
		// C++:  Mat getResponses()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getResponses_10 (IntPtr nativeObj);
		
		// C++:  Mat getNormCatResponses()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getNormCatResponses_10 (IntPtr nativeObj);
		

		
		// C++:  Mat getSampleWeights()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getSampleWeights_10 (IntPtr nativeObj);
		
		// C++:  Mat getTrainSampleWeights()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTrainSampleWeights_10 (IntPtr nativeObj);
		
		// C++:  Mat getTestSampleWeights()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTestSampleWeights_10 (IntPtr nativeObj);
		
		// C++:  Mat getVarIdx()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getVarIdx_10 (IntPtr nativeObj);
		
		// C++:  Mat getVarType()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getVarType_10 (IntPtr nativeObj);
		
		// C++:  int getResponseType()
		[DllImport("__Internal")]
		private static extern int ml_TrainData_getResponseType_10 (IntPtr nativeObj);
		
		// C++:  Mat getTrainSampleIdx()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTrainSampleIdx_10 (IntPtr nativeObj);
		
		// C++:  Mat getTestSampleIdx()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getTestSampleIdx_10 (IntPtr nativeObj);
		
		// C++:  void getValues(int vi, Mat sidx, float* values)
		[DllImport("__Internal")]
		private static extern void ml_TrainData_getValues_10 (IntPtr nativeObj, int vi, IntPtr sidx_nativeObj, float values);
		
		// C++:  Mat getDefaultSubstValues()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getDefaultSubstValues_10 (IntPtr nativeObj);
		
		// C++:  int getCatCount(int vi)
		[DllImport("__Internal")]
		private static extern int ml_TrainData_getCatCount_10 (IntPtr nativeObj, int vi);
		
		// C++:  Mat getClassLabels()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getClassLabels_10 (IntPtr nativeObj);
		
		// C++:  Mat getCatOfs()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getCatOfs_10 (IntPtr nativeObj);
		
		// C++:  Mat getCatMap()
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getCatMap_10 (IntPtr nativeObj);
		
		// C++:  void setTrainTestSplit(int count, bool shuffle = true)
		[DllImport("__Internal")]
		private static extern void ml_TrainData_setTrainTestSplit_10 (IntPtr nativeObj, int count, bool shuffle);
		
		[DllImport("__Internal")]
		private static extern void ml_TrainData_setTrainTestSplit_11 (IntPtr nativeObj, int count);
		
		// C++:  void setTrainTestSplitRatio(double ratio, bool shuffle = true)
		[DllImport("__Internal")]
		private static extern void ml_TrainData_setTrainTestSplitRatio_10 (IntPtr nativeObj, double ratio, bool shuffle);
		
		[DllImport("__Internal")]
		private static extern void ml_TrainData_setTrainTestSplitRatio_11 (IntPtr nativeObj, double ratio);
		
		// C++:  void shuffleTrainTest()
		[DllImport("__Internal")]
		private static extern void ml_TrainData_shuffleTrainTest_10 (IntPtr nativeObj);
		
		// C++: static Mat getSubVector(Mat vec, Mat idx)
		[DllImport("__Internal")]
		private static extern IntPtr ml_TrainData_getSubVector_10 (IntPtr vec_nativeObj, IntPtr idx_nativeObj);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void ml_TrainData_delete (IntPtr nativeObj);
#else
	
		// C++:  int getLayout()
		[DllImport("opencvforunity")]
		private static extern int ml_TrainData_getLayout_10 (IntPtr nativeObj);
	
		// C++:  int getNSamples()
		[DllImport("opencvforunity")]
		private static extern int ml_TrainData_getNSamples_10 (IntPtr nativeObj);
	
		// C++:  int getNTestSamples()
		[DllImport("opencvforunity")]
		private static extern int ml_TrainData_getNTestSamples_10 (IntPtr nativeObj);
	
		// C++:  int getNTrainSamples()
		[DllImport("opencvforunity")]
		private static extern int ml_TrainData_getNTrainSamples_10 (IntPtr nativeObj);
	
		// C++:  int getNVars()
		[DllImport("opencvforunity")]
		private static extern int ml_TrainData_getNVars_10 (IntPtr nativeObj);
	
		// C++:  int getNAllVars()
		[DllImport("opencvforunity")]
		private static extern int ml_TrainData_getNAllVars_10 (IntPtr nativeObj);
	
		// C++:  void getSample(Mat varIdx, int sidx, float* buf)
		[DllImport("opencvforunity")]
		private static extern void ml_TrainData_getSample_10 (IntPtr nativeObj, IntPtr varIdx_nativeObj, int sidx, float buf);
	
		// C++:  Mat getSamples()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getSamples_10 (IntPtr nativeObj);

		// C++:  Mat getMissing()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getMissing_10 (IntPtr nativeObj);
	
		// C++:  Mat getTrainSamples(int layout = ROW_SAMPLE, bool compressSamples = true, bool compressVars = true)
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTrainSamples_10 (IntPtr nativeObj, int layout, bool compressSamples, bool compressVars);

		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTrainSamples_11 (IntPtr nativeObj);
	
		// C++:  Mat getTrainResponses()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTrainResponses_10 (IntPtr nativeObj);
	
		// C++:  Mat getTrainNormCatResponses()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTrainNormCatResponses_10 (IntPtr nativeObj);
	
		// C++:  Mat getTestResponses()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTestResponses_10 (IntPtr nativeObj);
	
		// C++:  Mat getTestNormCatResponses()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTestNormCatResponses_10 (IntPtr nativeObj);
	
		// C++:  Mat getResponses()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getResponses_10 (IntPtr nativeObj);
	
		// C++:  Mat getNormCatResponses()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getNormCatResponses_10 (IntPtr nativeObj);
	

	
		// C++:  Mat getSampleWeights()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getSampleWeights_10 (IntPtr nativeObj);
	
		// C++:  Mat getTrainSampleWeights()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTrainSampleWeights_10 (IntPtr nativeObj);
	
		// C++:  Mat getTestSampleWeights()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTestSampleWeights_10 (IntPtr nativeObj);
	
		// C++:  Mat getVarIdx()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getVarIdx_10 (IntPtr nativeObj);
	
		// C++:  Mat getVarType()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getVarType_10 (IntPtr nativeObj);
	
		// C++:  int getResponseType()
		[DllImport("opencvforunity")]
		private static extern int ml_TrainData_getResponseType_10 (IntPtr nativeObj);
	
		// C++:  Mat getTrainSampleIdx()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTrainSampleIdx_10 (IntPtr nativeObj);
	
		// C++:  Mat getTestSampleIdx()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getTestSampleIdx_10 (IntPtr nativeObj);
	
		// C++:  void getValues(int vi, Mat sidx, float* values)
		[DllImport("opencvforunity")]
		private static extern void ml_TrainData_getValues_10 (IntPtr nativeObj, int vi, IntPtr sidx_nativeObj, float values);
	
		// C++:  Mat getDefaultSubstValues()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getDefaultSubstValues_10 (IntPtr nativeObj);
	
		// C++:  int getCatCount(int vi)
		[DllImport("opencvforunity")]
		private static extern int ml_TrainData_getCatCount_10 (IntPtr nativeObj, int vi);
	
		// C++:  Mat getClassLabels()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getClassLabels_10 (IntPtr nativeObj);
	
		// C++:  Mat getCatOfs()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getCatOfs_10 (IntPtr nativeObj);
	
		// C++:  Mat getCatMap()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getCatMap_10 (IntPtr nativeObj);
	
		// C++:  void setTrainTestSplit(int count, bool shuffle = true)
		[DllImport("opencvforunity")]
		private static extern void ml_TrainData_setTrainTestSplit_10 (IntPtr nativeObj, int count, bool shuffle);

		[DllImport("opencvforunity")]
		private static extern void ml_TrainData_setTrainTestSplit_11 (IntPtr nativeObj, int count);
	
		// C++:  void setTrainTestSplitRatio(double ratio, bool shuffle = true)
		[DllImport("opencvforunity")]
		private static extern void ml_TrainData_setTrainTestSplitRatio_10 (IntPtr nativeObj, double ratio, bool shuffle);

		[DllImport("opencvforunity")]
		private static extern void ml_TrainData_setTrainTestSplitRatio_11 (IntPtr nativeObj, double ratio);
	
		// C++:  void shuffleTrainTest()
		[DllImport("opencvforunity")]
		private static extern void ml_TrainData_shuffleTrainTest_10 (IntPtr nativeObj);
	
		// C++: static Mat getSubVector(Mat vec, Mat idx)
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_TrainData_getSubVector_10 (IntPtr vec_nativeObj, IntPtr idx_nativeObj);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void ml_TrainData_delete (IntPtr nativeObj);
#endif
	
	}
}
