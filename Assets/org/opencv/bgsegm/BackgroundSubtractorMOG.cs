
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{



// C++: class BackgroundSubtractorMOG
//javadoc: BackgroundSubtractorMOG
		public class BackgroundSubtractorMOG : BackgroundSubtractor
		{

				protected override void Dispose (bool disposing)
				{
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
			
						try {
				
								if (disposing) {
								}
				
								if (IsEnabledDispose) {
										if (nativeObj != IntPtr.Zero)
												bgsegm_BackgroundSubtractorMOG_delete (nativeObj);
										nativeObj = IntPtr.Zero;
								}
				
						} finally {
								base.Dispose (disposing);
						}
			
						#else
			return;
						#endif
				}

				public BackgroundSubtractorMOG (IntPtr addr) : base(addr)
				{
				}
	
	
				//
				// C++:  int getNMixtures()
				//
	
				//javadoc: BackgroundSubtractorMOG::getNMixtures()
				public  int getNMixtures ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						int retVal = bgsegm_BackgroundSubtractorMOG_getNMixtures_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void setNMixtures(int nmix)
				//
	
				//javadoc: BackgroundSubtractorMOG::setNMixtures(nmix)
				public  void setNMixtures (int nmix)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						bgsegm_BackgroundSubtractorMOG_setNMixtures_10 (nativeObj, nmix);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  double getBackgroundRatio()
				//
	
				//javadoc: BackgroundSubtractorMOG::getBackgroundRatio()
				public  double getBackgroundRatio ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						double retVal = bgsegm_BackgroundSubtractorMOG_getBackgroundRatio_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void setBackgroundRatio(double backgroundRatio)
				//
	
				//javadoc: BackgroundSubtractorMOG::setBackgroundRatio(backgroundRatio)
				public  void setBackgroundRatio (double backgroundRatio)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						bgsegm_BackgroundSubtractorMOG_setBackgroundRatio_10 (nativeObj, backgroundRatio);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  double getNoiseSigma()
				//
	
				//javadoc: BackgroundSubtractorMOG::getNoiseSigma()
				public  double getNoiseSigma ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						double retVal = bgsegm_BackgroundSubtractorMOG_getNoiseSigma_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void setNoiseSigma(double noiseSigma)
				//
	
				//javadoc: BackgroundSubtractorMOG::setNoiseSigma(noiseSigma)
				public  void setNoiseSigma (double noiseSigma)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						bgsegm_BackgroundSubtractorMOG_setNoiseSigma_10 (nativeObj, noiseSigma);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void setHistory(int nframes)
				//
	
				//javadoc: BackgroundSubtractorMOG::setHistory(nframes)
				public  void setHistory (int nframes)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						bgsegm_BackgroundSubtractorMOG_setHistory_10 (nativeObj, nframes);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int getHistory()
				//
	
				//javadoc: BackgroundSubtractorMOG::getHistory()
				public  int getHistory ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						int retVal = bgsegm_BackgroundSubtractorMOG_getHistory_10 (nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  int getNMixtures()
		[DllImport("__Internal")]
		private static extern int bgsegm_BackgroundSubtractorMOG_getNMixtures_10 (IntPtr nativeObj);
		
		// C++:  void setNMixtures(int nmix)
		[DllImport("__Internal")]
		private static extern void bgsegm_BackgroundSubtractorMOG_setNMixtures_10 (IntPtr nativeObj, int nmix);
		
		// C++:  double getBackgroundRatio()
		[DllImport("__Internal")]
		private static extern double bgsegm_BackgroundSubtractorMOG_getBackgroundRatio_10 (IntPtr nativeObj);
		
		// C++:  void setBackgroundRatio(double backgroundRatio)
		[DllImport("__Internal")]
		private static extern void bgsegm_BackgroundSubtractorMOG_setBackgroundRatio_10 (IntPtr nativeObj, double backgroundRatio);
		
		// C++:  double getNoiseSigma()
		[DllImport("__Internal")]
		private static extern double bgsegm_BackgroundSubtractorMOG_getNoiseSigma_10 (IntPtr nativeObj);
		
		// C++:  void setNoiseSigma(double noiseSigma)
		[DllImport("__Internal")]
		private static extern void bgsegm_BackgroundSubtractorMOG_setNoiseSigma_10 (IntPtr nativeObj, double noiseSigma);
		
		// C++:  void setHistory(int nframes)
		[DllImport("__Internal")]
		private static extern void bgsegm_BackgroundSubtractorMOG_setHistory_10 (IntPtr nativeObj, int nframes);
		
		// C++:  int getHistory()
		[DllImport("__Internal")]
		private static extern int bgsegm_BackgroundSubtractorMOG_getHistory_10 (IntPtr nativeObj);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void bgsegm_BackgroundSubtractorMOG_delete (IntPtr nativeObj);
#else
				// C++:  int getNMixtures()
				[DllImport("opencvforunity")]
				private static extern int bgsegm_BackgroundSubtractorMOG_getNMixtures_10 (IntPtr nativeObj);
	
				// C++:  void setNMixtures(int nmix)
				[DllImport("opencvforunity")]
				private static extern void bgsegm_BackgroundSubtractorMOG_setNMixtures_10 (IntPtr nativeObj, int nmix);
	
				// C++:  double getBackgroundRatio()
				[DllImport("opencvforunity")]
				private static extern double bgsegm_BackgroundSubtractorMOG_getBackgroundRatio_10 (IntPtr nativeObj);
	
				// C++:  void setBackgroundRatio(double backgroundRatio)
				[DllImport("opencvforunity")]
				private static extern void bgsegm_BackgroundSubtractorMOG_setBackgroundRatio_10 (IntPtr nativeObj, double backgroundRatio);
	
				// C++:  double getNoiseSigma()
				[DllImport("opencvforunity")]
				private static extern double bgsegm_BackgroundSubtractorMOG_getNoiseSigma_10 (IntPtr nativeObj);
	
				// C++:  void setNoiseSigma(double noiseSigma)
				[DllImport("opencvforunity")]
				private static extern void bgsegm_BackgroundSubtractorMOG_setNoiseSigma_10 (IntPtr nativeObj, double noiseSigma);
	
				// C++:  void setHistory(int nframes)
				[DllImport("opencvforunity")]
				private static extern void bgsegm_BackgroundSubtractorMOG_setHistory_10 (IntPtr nativeObj, int nframes);
	
				// C++:  int getHistory()
				[DllImport("opencvforunity")]
				private static extern int bgsegm_BackgroundSubtractorMOG_getHistory_10 (IntPtr nativeObj);
	
				// native support for java finalize()
				[DllImport("opencvforunity")]
				private static extern void bgsegm_BackgroundSubtractorMOG_delete (IntPtr nativeObj);
#endif
		}
}
