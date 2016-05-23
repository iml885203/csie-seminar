
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class LogisticRegression
//javadoc: LogisticRegression
	public class LogisticRegression : StatModel
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						ml_LogisticRegression_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		protected LogisticRegression (IntPtr addr) : base(addr)
		{
		}
	
		public const int
			REG_DISABLE = -1,
			REG_L1 = 0,
			REG_L2 = 1,
			BATCH = 0,
			MINI_BATCH = 1;
	
	
		//
		// C++:  double getLearningRate()
		//
	
		//javadoc: LogisticRegression::getLearningRate()
		public  double getLearningRate ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = ml_LogisticRegression_getLearningRate_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setLearningRate(double val)
		//
	
		//javadoc: LogisticRegression::setLearningRate(val)
		public  void setLearningRate (double val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_LogisticRegression_setLearningRate_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getIterations()
		//
	
		//javadoc: LogisticRegression::getIterations()
		public  int getIterations ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_LogisticRegression_getIterations_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setIterations(int val)
		//
	
		//javadoc: LogisticRegression::setIterations(val)
		public  void setIterations (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_LogisticRegression_setIterations_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getRegularization()
		//
	
		//javadoc: LogisticRegression::getRegularization()
		public  int getRegularization ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_LogisticRegression_getRegularization_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setRegularization(int val)
		//
	
		//javadoc: LogisticRegression::setRegularization(val)
		public  void setRegularization (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_LogisticRegression_setRegularization_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getTrainMethod()
		//
	
		//javadoc: LogisticRegression::getTrainMethod()
		public  int getTrainMethod ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_LogisticRegression_getTrainMethod_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setTrainMethod(int val)
		//
	
		//javadoc: LogisticRegression::setTrainMethod(val)
		public  void setTrainMethod (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_LogisticRegression_setTrainMethod_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getMiniBatchSize()
		//
	
		//javadoc: LogisticRegression::getMiniBatchSize()
		public  int getMiniBatchSize ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_LogisticRegression_getMiniBatchSize_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setMiniBatchSize(int val)
		//
	
		//javadoc: LogisticRegression::setMiniBatchSize(val)
		public  void setMiniBatchSize (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_LogisticRegression_setMiniBatchSize_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  TermCriteria getTermCriteria()
		//
	
		//javadoc: LogisticRegression::getTermCriteria()
		public  TermCriteria getTermCriteria ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double[] tmpArray = new double[3];
			ml_LogisticRegression_getTermCriteria_10 (nativeObj, tmpArray);
			TermCriteria retVal = new TermCriteria (tmpArray);
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  void setTermCriteria(TermCriteria val)
		//
	
		//javadoc: LogisticRegression::setTermCriteria(val)
		public  void setTermCriteria (TermCriteria val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_LogisticRegression_setTermCriteria_10 (nativeObj, val.type, val.maxCount, val.epsilon);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  float predict(Mat samples, Mat& results = Mat(), int flags = 0)
		//
	
		//javadoc: LogisticRegression::predict(samples, results, flags)
		public override float predict (Mat samples, Mat results, int flags)
		{
			ThrowIfDisposed ();
			if (samples != null)
				samples.ThrowIfDisposed ();
			if (results != null)
				results.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = ml_LogisticRegression_predict_10 (nativeObj, samples.nativeObj, results.nativeObj, flags);
		
			return retVal;
#else
return -1;
#endif
		}
	
		//javadoc: LogisticRegression::predict(samples)
		public override float predict (Mat samples)
		{
			ThrowIfDisposed ();
			if (samples != null)
				samples.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = ml_LogisticRegression_predict_11 (nativeObj, samples.nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  Mat get_learnt_thetas()
		//
	
		//javadoc: LogisticRegression::get_learnt_thetas()
		public  Mat get_learnt_thetas ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_LogisticRegression_get_1learnt_1thetas_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++: static Ptr_LogisticRegression create()
		//
	
		//javadoc: LogisticRegression::create()
		public static LogisticRegression create ()
		{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			LogisticRegression retVal = new LogisticRegression (ml_LogisticRegression_create_10 ());
		
			return retVal;
#else
return null;
#endif
		}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  double getLearningRate()
		[DllImport("__Internal")]
		private static extern double ml_LogisticRegression_getLearningRate_10 (IntPtr nativeObj);
		
		// C++:  void setLearningRate(double val)
		[DllImport("__Internal")]
		private static extern void ml_LogisticRegression_setLearningRate_10 (IntPtr nativeObj, double val);
		
		// C++:  int getIterations()
		[DllImport("__Internal")]
		private static extern int ml_LogisticRegression_getIterations_10 (IntPtr nativeObj);
		
		// C++:  void setIterations(int val)
		[DllImport("__Internal")]
		private static extern void ml_LogisticRegression_setIterations_10 (IntPtr nativeObj, int val);
		
		// C++:  int getRegularization()
		[DllImport("__Internal")]
		private static extern int ml_LogisticRegression_getRegularization_10 (IntPtr nativeObj);
		
		// C++:  void setRegularization(int val)
		[DllImport("__Internal")]
		private static extern void ml_LogisticRegression_setRegularization_10 (IntPtr nativeObj, int val);
		
		// C++:  int getTrainMethod()
		[DllImport("__Internal")]
		private static extern int ml_LogisticRegression_getTrainMethod_10 (IntPtr nativeObj);
		
		// C++:  void setTrainMethod(int val)
		[DllImport("__Internal")]
		private static extern void ml_LogisticRegression_setTrainMethod_10 (IntPtr nativeObj, int val);
		
		// C++:  int getMiniBatchSize()
		[DllImport("__Internal")]
		private static extern int ml_LogisticRegression_getMiniBatchSize_10 (IntPtr nativeObj);
		
		// C++:  void setMiniBatchSize(int val)
		[DllImport("__Internal")]
		private static extern void ml_LogisticRegression_setMiniBatchSize_10 (IntPtr nativeObj, int val);
		
		// C++:  TermCriteria getTermCriteria()
		[DllImport("__Internal")]
		private static extern void ml_LogisticRegression_getTermCriteria_10 (IntPtr nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] double[] vals);
		
		// C++:  void setTermCriteria(TermCriteria val)
		[DllImport("__Internal")]
		private static extern void ml_LogisticRegression_setTermCriteria_10 (IntPtr nativeObj, int val_type, int val_maxCount, double val_epsilon);
		
		// C++:  float predict(Mat samples, Mat& results = Mat(), int flags = 0)
		[DllImport("__Internal")]
		private static extern float ml_LogisticRegression_predict_10 (IntPtr nativeObj, IntPtr samples_nativeObj, IntPtr results_nativeObj, int flags);
		
		[DllImport("__Internal")]
		private static extern float ml_LogisticRegression_predict_11 (IntPtr nativeObj, IntPtr samples_nativeObj);
		
		// C++:  Mat get_learnt_thetas()
		[DllImport("__Internal")]
		private static extern IntPtr ml_LogisticRegression_get_1learnt_1thetas_10 (IntPtr nativeObj);
		
		// C++: static Ptr_LogisticRegression create()
		[DllImport("__Internal")]
		private static extern IntPtr ml_LogisticRegression_create_10 ();
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void ml_LogisticRegression_delete (IntPtr nativeObj);
#else
		// C++:  double getLearningRate()
		[DllImport("opencvforunity")]
		private static extern double ml_LogisticRegression_getLearningRate_10 (IntPtr nativeObj);
	
		// C++:  void setLearningRate(double val)
		[DllImport("opencvforunity")]
		private static extern void ml_LogisticRegression_setLearningRate_10 (IntPtr nativeObj, double val);
	
		// C++:  int getIterations()
		[DllImport("opencvforunity")]
		private static extern int ml_LogisticRegression_getIterations_10 (IntPtr nativeObj);
	
		// C++:  void setIterations(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_LogisticRegression_setIterations_10 (IntPtr nativeObj, int val);
	
		// C++:  int getRegularization()
		[DllImport("opencvforunity")]
		private static extern int ml_LogisticRegression_getRegularization_10 (IntPtr nativeObj);
	
		// C++:  void setRegularization(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_LogisticRegression_setRegularization_10 (IntPtr nativeObj, int val);
	
		// C++:  int getTrainMethod()
		[DllImport("opencvforunity")]
		private static extern int ml_LogisticRegression_getTrainMethod_10 (IntPtr nativeObj);
	
		// C++:  void setTrainMethod(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_LogisticRegression_setTrainMethod_10 (IntPtr nativeObj, int val);
	
		// C++:  int getMiniBatchSize()
		[DllImport("opencvforunity")]
		private static extern int ml_LogisticRegression_getMiniBatchSize_10 (IntPtr nativeObj);
	
		// C++:  void setMiniBatchSize(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_LogisticRegression_setMiniBatchSize_10 (IntPtr nativeObj, int val);
	
		// C++:  TermCriteria getTermCriteria()
		[DllImport("opencvforunity")]
		private static extern void ml_LogisticRegression_getTermCriteria_10 (IntPtr nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] double[] vals);
	
		// C++:  void setTermCriteria(TermCriteria val)
		[DllImport("opencvforunity")]
		private static extern void ml_LogisticRegression_setTermCriteria_10 (IntPtr nativeObj, int val_type, int val_maxCount, double val_epsilon);
	
		// C++:  float predict(Mat samples, Mat& results = Mat(), int flags = 0)
		[DllImport("opencvforunity")]
		private static extern float ml_LogisticRegression_predict_10 (IntPtr nativeObj, IntPtr samples_nativeObj, IntPtr results_nativeObj, int flags);

		[DllImport("opencvforunity")]
		private static extern float ml_LogisticRegression_predict_11 (IntPtr nativeObj, IntPtr samples_nativeObj);
	
		// C++:  Mat get_learnt_thetas()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_LogisticRegression_get_1learnt_1thetas_10 (IntPtr nativeObj);
	
		// C++: static Ptr_LogisticRegression create()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_LogisticRegression_create_10 ();
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void ml_LogisticRegression_delete (IntPtr nativeObj);
#endif
	
	}
}
