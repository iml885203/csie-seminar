
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class SVM
//javadoc: SVM
	public class SVM : StatModel
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						ml_SVM_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		protected SVM (IntPtr addr) : base(addr)
		{
		}
	
		public const int
			C_SVC = 100,
			NU_SVC = 101,
			ONE_CLASS = 102,
			EPS_SVR = 103,
			NU_SVR = 104,
			CUSTOM = -1,
			LINEAR = 0,
			POLY = 1,
			RBF = 2,
			SIGMOID = 3,
			CHI2 = 4,
			INTER = 5,
			C = 0,
			GAMMA = 1,
			P = 2,
			NU = 3,
			COEF = 4,
			DEGREE = 5;
	
	
		//
		// C++:  int getType()
		//
	
		//javadoc: SVM::getType()
		public  int getType ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_SVM_getType_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setType(int val)
		//
	
		//javadoc: SVM::setType(val)
		public  void setType (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setType_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getGamma()
		//
	
		//javadoc: SVM::getGamma()
		public  double getGamma ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = ml_SVM_getGamma_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setGamma(double val)
		//
	
		//javadoc: SVM::setGamma(val)
		public  void setGamma (double val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setGamma_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getCoef0()
		//
	
		//javadoc: SVM::getCoef0()
		public  double getCoef0 ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = ml_SVM_getCoef0_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setCoef0(double val)
		//
	
		//javadoc: SVM::setCoef0(val)
		public  void setCoef0 (double val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setCoef0_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getDegree()
		//
	
		//javadoc: SVM::getDegree()
		public  double getDegree ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = ml_SVM_getDegree_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setDegree(double val)
		//
	
		//javadoc: SVM::setDegree(val)
		public  void setDegree (double val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setDegree_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getC()
		//
	
		//javadoc: SVM::getC()
		public  double getC ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = ml_SVM_getC_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setC(double val)
		//
	
		//javadoc: SVM::setC(val)
		public  void setC (double val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setC_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getNu()
		//
	
		//javadoc: SVM::getNu()
		public  double getNu ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = ml_SVM_getNu_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setNu(double val)
		//
	
		//javadoc: SVM::setNu(val)
		public  void setNu (double val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setNu_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getP()
		//
	
		//javadoc: SVM::getP()
		public  double getP ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = ml_SVM_getP_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setP(double val)
		//
	
		//javadoc: SVM::setP(val)
		public  void setP (double val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setP_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  Mat getClassWeights()
		//
	
		//javadoc: SVM::getClassWeights()
		public  Mat getClassWeights ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_SVM_getClassWeights_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  void setClassWeights(Mat val)
		//
	
		//javadoc: SVM::setClassWeights(val)
		public  void setClassWeights (Mat val)
		{
			ThrowIfDisposed ();
			if (val != null)
				val.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setClassWeights_10 (nativeObj, val.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  TermCriteria getTermCriteria()
		//
	
		//javadoc: SVM::getTermCriteria()
		public  TermCriteria getTermCriteria ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double[] tmpArray = new double[3];
			ml_SVM_getTermCriteria_10 (nativeObj, tmpArray);
			TermCriteria retVal = new TermCriteria (tmpArray);
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  void setTermCriteria(TermCriteria val)
		//
	
		//javadoc: SVM::setTermCriteria(val)
		public  void setTermCriteria (TermCriteria val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setTermCriteria_10 (nativeObj, val.type, val.maxCount, val.epsilon);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getKernelType()
		//
	
		//javadoc: SVM::getKernelType()
		public  int getKernelType ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_SVM_getKernelType_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setKernel(int kernelType)
		//
	
		//javadoc: SVM::setKernel(kernelType)
		public  void setKernel (int kernelType)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_SVM_setKernel_10 (nativeObj, kernelType);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  Mat getSupportVectors()
		//
	
		//javadoc: SVM::getSupportVectors()
		public  Mat getSupportVectors ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Mat retVal = new Mat (ml_SVM_getSupportVectors_10 (nativeObj));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  double getDecisionFunction(int i, Mat& alpha, Mat& svidx)
		//
	
		//javadoc: SVM::getDecisionFunction(i, alpha, svidx)
		public  double getDecisionFunction (int i, Mat alpha, Mat svidx)
		{
			ThrowIfDisposed ();
			if (alpha != null)
				alpha.ThrowIfDisposed ();
			if (svidx != null)
				svidx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = ml_SVM_getDecisionFunction_10 (nativeObj, i, alpha.nativeObj, svidx.nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++: static Ptr_SVM create()
		//
	
		//javadoc: SVM::create()
		public static SVM create ()
		{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			SVM retVal = new SVM (ml_SVM_create_10 ());
		
			return retVal;
#else
return null;
#endif
		}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  int getType()
		[DllImport("__Internal")]
		private static extern int ml_SVM_getType_10 (IntPtr nativeObj);
		
		// C++:  void setType(int val)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setType_10 (IntPtr nativeObj, int val);
		
		// C++:  double getGamma()
		[DllImport("__Internal")]
		private static extern double ml_SVM_getGamma_10 (IntPtr nativeObj);
		
		// C++:  void setGamma(double val)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setGamma_10 (IntPtr nativeObj, double val);
		
		// C++:  double getCoef0()
		[DllImport("__Internal")]
		private static extern double ml_SVM_getCoef0_10 (IntPtr nativeObj);
		
		// C++:  void setCoef0(double val)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setCoef0_10 (IntPtr nativeObj, double val);
		
		// C++:  double getDegree()
		[DllImport("__Internal")]
		private static extern double ml_SVM_getDegree_10 (IntPtr nativeObj);
		
		// C++:  void setDegree(double val)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setDegree_10 (IntPtr nativeObj, double val);
		
		// C++:  double getC()
		[DllImport("__Internal")]
		private static extern double ml_SVM_getC_10 (IntPtr nativeObj);
		
		// C++:  void setC(double val)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setC_10 (IntPtr nativeObj, double val);
		
		// C++:  double getNu()
		[DllImport("__Internal")]
		private static extern double ml_SVM_getNu_10 (IntPtr nativeObj);
		
		// C++:  void setNu(double val)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setNu_10 (IntPtr nativeObj, double val);
		
		// C++:  double getP()
		[DllImport("__Internal")]
		private static extern double ml_SVM_getP_10 (IntPtr nativeObj);
		
		// C++:  void setP(double val)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setP_10 (IntPtr nativeObj, double val);
		
		// C++:  Mat getClassWeights()
		[DllImport("__Internal")]
		private static extern IntPtr ml_SVM_getClassWeights_10 (IntPtr nativeObj);
		
		// C++:  void setClassWeights(Mat val)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setClassWeights_10 (IntPtr nativeObj, IntPtr val_nativeObj);
		
		// C++:  TermCriteria getTermCriteria()
		[DllImport("__Internal")]
		private static extern void ml_SVM_getTermCriteria_10 (IntPtr nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] double[] vals);
		
		// C++:  void setTermCriteria(TermCriteria val)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setTermCriteria_10 (IntPtr nativeObj, int val_type, int val_maxCount, double val_epsilon);
		
		// C++:  int getKernelType()
		[DllImport("__Internal")]
		private static extern int ml_SVM_getKernelType_10 (IntPtr nativeObj);
		
		// C++:  void setKernel(int kernelType)
		[DllImport("__Internal")]
		private static extern void ml_SVM_setKernel_10 (IntPtr nativeObj, int kernelType);
		
		// C++:  Mat getSupportVectors()
		[DllImport("__Internal")]
		private static extern IntPtr ml_SVM_getSupportVectors_10 (IntPtr nativeObj);
		
		// C++:  double getDecisionFunction(int i, Mat& alpha, Mat& svidx)
		[DllImport("__Internal")]
		private static extern double ml_SVM_getDecisionFunction_10 (IntPtr nativeObj, int i, IntPtr alpha_nativeObj, IntPtr svidx_nativeObj);
		
		// C++: static Ptr_SVM create()
		[DllImport("__Internal")]
		private static extern IntPtr ml_SVM_create_10 ();
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void ml_SVM_delete (IntPtr nativeObj);
#else
	
		// C++:  int getType()
		[DllImport("opencvforunity")]
		private static extern int ml_SVM_getType_10 (IntPtr nativeObj);
	
		// C++:  void setType(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setType_10 (IntPtr nativeObj, int val);
	
		// C++:  double getGamma()
		[DllImport("opencvforunity")]
		private static extern double ml_SVM_getGamma_10 (IntPtr nativeObj);
	
		// C++:  void setGamma(double val)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setGamma_10 (IntPtr nativeObj, double val);
	
		// C++:  double getCoef0()
		[DllImport("opencvforunity")]
		private static extern double ml_SVM_getCoef0_10 (IntPtr nativeObj);
	
		// C++:  void setCoef0(double val)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setCoef0_10 (IntPtr nativeObj, double val);
	
		// C++:  double getDegree()
		[DllImport("opencvforunity")]
		private static extern double ml_SVM_getDegree_10 (IntPtr nativeObj);
	
		// C++:  void setDegree(double val)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setDegree_10 (IntPtr nativeObj, double val);
	
		// C++:  double getC()
		[DllImport("opencvforunity")]
		private static extern double ml_SVM_getC_10 (IntPtr nativeObj);
	
		// C++:  void setC(double val)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setC_10 (IntPtr nativeObj, double val);
	
		// C++:  double getNu()
		[DllImport("opencvforunity")]
		private static extern double ml_SVM_getNu_10 (IntPtr nativeObj);
	
		// C++:  void setNu(double val)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setNu_10 (IntPtr nativeObj, double val);
	
		// C++:  double getP()
		[DllImport("opencvforunity")]
		private static extern double ml_SVM_getP_10 (IntPtr nativeObj);
	
		// C++:  void setP(double val)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setP_10 (IntPtr nativeObj, double val);
	
		// C++:  Mat getClassWeights()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_SVM_getClassWeights_10 (IntPtr nativeObj);
	
		// C++:  void setClassWeights(Mat val)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setClassWeights_10 (IntPtr nativeObj, IntPtr val_nativeObj);
	
		// C++:  TermCriteria getTermCriteria()
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_getTermCriteria_10 (IntPtr nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] double[] vals);
	
		// C++:  void setTermCriteria(TermCriteria val)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setTermCriteria_10 (IntPtr nativeObj, int val_type, int val_maxCount, double val_epsilon);
	
		// C++:  int getKernelType()
		[DllImport("opencvforunity")]
		private static extern int ml_SVM_getKernelType_10 (IntPtr nativeObj);
	
		// C++:  void setKernel(int kernelType)
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_setKernel_10 (IntPtr nativeObj, int kernelType);
	
		// C++:  Mat getSupportVectors()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_SVM_getSupportVectors_10 (IntPtr nativeObj);
	
		// C++:  double getDecisionFunction(int i, Mat& alpha, Mat& svidx)
		[DllImport("opencvforunity")]
		private static extern double ml_SVM_getDecisionFunction_10 (IntPtr nativeObj, int i, IntPtr alpha_nativeObj, IntPtr svidx_nativeObj);
	
		// C++: static Ptr_SVM create()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_SVM_create_10 ();
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void ml_SVM_delete (IntPtr nativeObj);
#endif
	
	}
}