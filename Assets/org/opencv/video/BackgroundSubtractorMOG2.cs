
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{



// C++: class BackgroundSubtractorMOG2
//javadoc: BackgroundSubtractorMOG2
	public class BackgroundSubtractorMOG2 : BackgroundSubtractor
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						video_BackgroundSubtractorMOG2_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		public BackgroundSubtractorMOG2 (IntPtr addr) : base(addr)
		{
		}
	
	
	

	
	

	
	
		//
		// C++:  void setComplexityReductionThreshold(double ct)
		//
	
		//javadoc: BackgroundSubtractorMOG2::setComplexityReductionThreshold(ct)
		public  void setComplexityReductionThreshold (double ct)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_BackgroundSubtractorMOG2_setComplexityReductionThreshold_10 (nativeObj, ct);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  bool getDetectShadows()
		//
	
		//javadoc: BackgroundSubtractorMOG2::getDetectShadows()
		public  bool getDetectShadows ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			bool retVal = video_BackgroundSubtractorMOG2_getDetectShadows_10 (nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  void setDetectShadows(bool detectShadows)
		//
	
		//javadoc: BackgroundSubtractorMOG2::setDetectShadows(detectShadows)
		public  void setDetectShadows (bool detectShadows)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_BackgroundSubtractorMOG2_setDetectShadows_10 (nativeObj, detectShadows);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getShadowValue()
		//
	
		//javadoc: BackgroundSubtractorMOG2::getShadowValue()
		public  int getShadowValue ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = video_BackgroundSubtractorMOG2_getShadowValue_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setShadowValue(int value)
		//
	
		//javadoc: BackgroundSubtractorMOG2::setShadowValue(value)
		public  void setShadowValue (int value)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_BackgroundSubtractorMOG2_setShadowValue_10 (nativeObj, value);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getShadowThreshold()
		//
	
		//javadoc: BackgroundSubtractorMOG2::getShadowThreshold()
		public  double getShadowThreshold ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = video_BackgroundSubtractorMOG2_getShadowThreshold_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setShadowThreshold(double threshold)
		//
	
		//javadoc: BackgroundSubtractorMOG2::setShadowThreshold(threshold)
		public  void setShadowThreshold (double threshold)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_BackgroundSubtractorMOG2_setShadowThreshold_10 (nativeObj, threshold);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getHistory()
		//
	
		//javadoc: BackgroundSubtractorMOG2::getHistory()
		public  int getHistory ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = video_BackgroundSubtractorMOG2_getHistory_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setHistory(int history)
		//
	
		//javadoc: BackgroundSubtractorMOG2::setHistory(history)
		public  void setHistory (int history)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_BackgroundSubtractorMOG2_setHistory_10 (nativeObj, history);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getNMixtures()
		//
	
		//javadoc: BackgroundSubtractorMOG2::getNMixtures()
		public  int getNMixtures ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = video_BackgroundSubtractorMOG2_getNMixtures_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setNMixtures(int nmixtures)
		//
	
		//javadoc: BackgroundSubtractorMOG2::setNMixtures(nmixtures)
		public  void setNMixtures (int nmixtures)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_BackgroundSubtractorMOG2_setNMixtures_10 (nativeObj, nmixtures);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getBackgroundRatio()
		//
	
		//javadoc: BackgroundSubtractorMOG2::getBackgroundRatio()
		public  double getBackgroundRatio ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = video_BackgroundSubtractorMOG2_getBackgroundRatio_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setBackgroundRatio(double ratio)
		//
	
		//javadoc: BackgroundSubtractorMOG2::setBackgroundRatio(ratio)
		public  void setBackgroundRatio (double ratio)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_BackgroundSubtractorMOG2_setBackgroundRatio_10 (nativeObj, ratio);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getVarThreshold()
		//
	
		//javadoc: BackgroundSubtractorMOG2::getVarThreshold()
		public  double getVarThreshold ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = video_BackgroundSubtractorMOG2_getVarThreshold_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setVarThreshold(double varThreshold)
		//
	
		//javadoc: BackgroundSubtractorMOG2::setVarThreshold(varThreshold)
		public  void setVarThreshold (double varThreshold)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_BackgroundSubtractorMOG2_setVarThreshold_10 (nativeObj, varThreshold);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getVarThresholdGen()
		//
	
		//javadoc: BackgroundSubtractorMOG2::getVarThresholdGen()
		public  double getVarThresholdGen ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = video_BackgroundSubtractorMOG2_getVarThresholdGen_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setVarThresholdGen(double varThresholdGen)
		//
	
		//javadoc: BackgroundSubtractorMOG2::setVarThresholdGen(varThresholdGen)
		public  void setVarThresholdGen (double varThresholdGen)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			video_BackgroundSubtractorMOG2_setVarThresholdGen_10 (nativeObj, varThresholdGen);
		
			return;
#else
return;
#endif
		}


	
	
		//
		// C++:  double getVarInit()
		//
	
		//javadoc: BackgroundSubtractorMOG2::getVarInit()
		public  double getVarInit ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = video_BackgroundSubtractorMOG2_getVarInit_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}

		//
		// C++:  void setVarInit(double varInit)
		//
		
		//javadoc: BackgroundSubtractorMOG2::setVarInit(varInit)
		public  void setVarInit (double varInit)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			video_BackgroundSubtractorMOG2_setVarInit_10 (nativeObj, varInit);
			
			return;
			#else
			return;
			#endif
		}
		
		
		//
		// C++:  double getVarMin()
		//
		
		//javadoc: BackgroundSubtractorMOG2::getVarMin()
		public  double getVarMin ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			double retVal = video_BackgroundSubtractorMOG2_getVarMin_10 (nativeObj);
			
			return retVal;
			#else
			return -1;
			#endif
		}
		
		
		//
		// C++:  void setVarMin(double varMin)
		//
		
		//javadoc: BackgroundSubtractorMOG2::setVarMin(varMin)
		public  void setVarMin (double varMin)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			video_BackgroundSubtractorMOG2_setVarMin_10 (nativeObj, varMin);
			
			return;
			#else
			return;
			#endif
		}
		
		
		//
		// C++:  double getVarMax()
		//
		
		//javadoc: BackgroundSubtractorMOG2::getVarMax()
		public  double getVarMax ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			double retVal = video_BackgroundSubtractorMOG2_getVarMax_10 (nativeObj);
			
			return retVal;
			#else
			return -1;
			#endif
		}
		
		
		//
		// C++:  void setVarMax(double varMax)
		//
		
		//javadoc: BackgroundSubtractorMOG2::setVarMax(varMax)
		public  void setVarMax (double varMax)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			video_BackgroundSubtractorMOG2_setVarMax_10 (nativeObj, varMax);
			
			return;
			#else
			return;
			#endif
		}
		
		//
		// C++:  double getComplexityReductionThreshold()
		//
		
		//javadoc: BackgroundSubtractorMOG2::getComplexityReductionThreshold()
		public  double getComplexityReductionThreshold ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			double retVal = video_BackgroundSubtractorMOG2_getComplexityReductionThreshold_10 (nativeObj);
			
			return retVal;
			#else
			return -1;
			#endif
		}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR


		// C++:  void setComplexityReductionThreshold(double ct)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setComplexityReductionThreshold_10 (IntPtr nativeObj, double ct);
		
		// C++:  bool getDetectShadows()
		[DllImport("__Internal")]
		private static extern bool video_BackgroundSubtractorMOG2_getDetectShadows_10 (IntPtr nativeObj);
		
		// C++:  void setDetectShadows(bool detectShadows)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setDetectShadows_10 (IntPtr nativeObj, bool detectShadows);
		
		// C++:  int getShadowValue()
		[DllImport("__Internal")]
		private static extern int video_BackgroundSubtractorMOG2_getShadowValue_10 (IntPtr nativeObj);
		
		// C++:  void setShadowValue(int value)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setShadowValue_10 (IntPtr nativeObj, int value);
		
		// C++:  double getShadowThreshold()
		[DllImport("__Internal")]
		private static extern double video_BackgroundSubtractorMOG2_getShadowThreshold_10 (IntPtr nativeObj);
		
		// C++:  void setShadowThreshold(double threshold)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setShadowThreshold_10 (IntPtr nativeObj, double threshold);
		
		// C++:  int getHistory()
		[DllImport("__Internal")]
		private static extern int video_BackgroundSubtractorMOG2_getHistory_10 (IntPtr nativeObj);
		
		// C++:  void setHistory(int history)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setHistory_10 (IntPtr nativeObj, int history);
		
		// C++:  int getNMixtures()
		[DllImport("__Internal")]
		private static extern int video_BackgroundSubtractorMOG2_getNMixtures_10 (IntPtr nativeObj);
		
		// C++:  void setNMixtures(int nmixtures)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setNMixtures_10 (IntPtr nativeObj, int nmixtures);
		
		// C++:  double getBackgroundRatio()
		[DllImport("__Internal")]
		private static extern double video_BackgroundSubtractorMOG2_getBackgroundRatio_10 (IntPtr nativeObj);
		
		// C++:  void setBackgroundRatio(double ratio)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setBackgroundRatio_10 (IntPtr nativeObj, double ratio);
		
		// C++:  double getVarThreshold()
		[DllImport("__Internal")]
		private static extern double video_BackgroundSubtractorMOG2_getVarThreshold_10 (IntPtr nativeObj);
		
		// C++:  void setVarThreshold(double varThreshold)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setVarThreshold_10 (IntPtr nativeObj, double varThreshold);
		
		// C++:  double getVarThresholdGen()
		[DllImport("__Internal")]
		private static extern double video_BackgroundSubtractorMOG2_getVarThresholdGen_10 (IntPtr nativeObj);
		
		// C++:  void setVarThresholdGen(double varThresholdGen)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setVarThresholdGen_10 (IntPtr nativeObj, double varThresholdGen);
		
		// C++:  double getVarInit()
		[DllImport("__Internal")]
		private static extern double video_BackgroundSubtractorMOG2_getVarInit_10 (IntPtr nativeObj);

		// C++:  void setVarInit(double varInit)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setVarInit_10 (IntPtr nativeObj, double varInit);
		
		// C++:  double getVarMin()
		[DllImport("__Internal")]
		private static extern double video_BackgroundSubtractorMOG2_getVarMin_10 (IntPtr nativeObj);
		
		// C++:  void setVarMin(double varMin)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setVarMin_10 (IntPtr nativeObj, double varMin);
		
		// C++:  double getVarMax()
		[DllImport("__Internal")]
		private static extern double video_BackgroundSubtractorMOG2_getVarMax_10 (IntPtr nativeObj);
		
		// C++:  void setVarMax(double varMax)
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_setVarMax_10 (IntPtr nativeObj, double varMax);

		// C++:  double getComplexityReductionThreshold()
		[DllImport("__Internal")]
		private static extern double video_BackgroundSubtractorMOG2_getComplexityReductionThreshold_10 (IntPtr nativeObj);

		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void video_BackgroundSubtractorMOG2_delete (IntPtr nativeObj);
#else


		// C++:  void setComplexityReductionThreshold(double ct)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setComplexityReductionThreshold_10 (IntPtr nativeObj, double ct);
	
		// C++:  bool getDetectShadows()
		[DllImport("opencvforunity")]
		private static extern bool video_BackgroundSubtractorMOG2_getDetectShadows_10 (IntPtr nativeObj);
	
		// C++:  void setDetectShadows(bool detectShadows)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setDetectShadows_10 (IntPtr nativeObj, bool detectShadows);
	
		// C++:  int getShadowValue()
		[DllImport("opencvforunity")]
		private static extern int video_BackgroundSubtractorMOG2_getShadowValue_10 (IntPtr nativeObj);
	
		// C++:  void setShadowValue(int value)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setShadowValue_10 (IntPtr nativeObj, int value);
	
		// C++:  double getShadowThreshold()
		[DllImport("opencvforunity")]
		private static extern double video_BackgroundSubtractorMOG2_getShadowThreshold_10 (IntPtr nativeObj);
	
		// C++:  void setShadowThreshold(double threshold)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setShadowThreshold_10 (IntPtr nativeObj, double threshold);
	
		// C++:  int getHistory()
		[DllImport("opencvforunity")]
		private static extern int video_BackgroundSubtractorMOG2_getHistory_10 (IntPtr nativeObj);
	
		// C++:  void setHistory(int history)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setHistory_10 (IntPtr nativeObj, int history);
	
		// C++:  int getNMixtures()
		[DllImport("opencvforunity")]
		private static extern int video_BackgroundSubtractorMOG2_getNMixtures_10 (IntPtr nativeObj);
	
		// C++:  void setNMixtures(int nmixtures)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setNMixtures_10 (IntPtr nativeObj, int nmixtures);
	
		// C++:  double getBackgroundRatio()
		[DllImport("opencvforunity")]
		private static extern double video_BackgroundSubtractorMOG2_getBackgroundRatio_10 (IntPtr nativeObj);
	
		// C++:  void setBackgroundRatio(double ratio)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setBackgroundRatio_10 (IntPtr nativeObj, double ratio);
	
		// C++:  double getVarThreshold()
		[DllImport("opencvforunity")]
		private static extern double video_BackgroundSubtractorMOG2_getVarThreshold_10 (IntPtr nativeObj);
	
		// C++:  void setVarThreshold(double varThreshold)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setVarThreshold_10 (IntPtr nativeObj, double varThreshold);
	
		// C++:  double getVarThresholdGen()
		[DllImport("opencvforunity")]
		private static extern double video_BackgroundSubtractorMOG2_getVarThresholdGen_10 (IntPtr nativeObj);
	
		// C++:  void setVarThresholdGen(double varThresholdGen)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setVarThresholdGen_10 (IntPtr nativeObj, double varThresholdGen);
	
		// C++:  double getVarInit()
		[DllImport("opencvforunity")]
		private static extern double video_BackgroundSubtractorMOG2_getVarInit_10 (IntPtr nativeObj);

		// C++:  void setVarInit(double varInit)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setVarInit_10 (IntPtr nativeObj, double varInit);
		
		// C++:  double getVarMin()
		[DllImport("opencvforunity")]
		private static extern double video_BackgroundSubtractorMOG2_getVarMin_10 (IntPtr nativeObj);
		
		// C++:  void setVarMin(double varMin)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setVarMin_10 (IntPtr nativeObj, double varMin);
		
		// C++:  double getVarMax()
		[DllImport("opencvforunity")]
		private static extern double video_BackgroundSubtractorMOG2_getVarMax_10 (IntPtr nativeObj);
		
		// C++:  void setVarMax(double varMax)
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_setVarMax_10 (IntPtr nativeObj, double varMax);

		// C++:  double getComplexityReductionThreshold()
		[DllImport("opencvforunity")]
		private static extern double video_BackgroundSubtractorMOG2_getComplexityReductionThreshold_10 (IntPtr nativeObj);

	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void video_BackgroundSubtractorMOG2_delete (IntPtr nativeObj);
#endif
	
	}
}