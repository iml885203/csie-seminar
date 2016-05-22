
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{



// C++: class CalibrateDebevec
//javadoc: CalibrateDebevec
	public class CalibrateDebevec : CalibrateCRF
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						photo_CalibrateDebevec_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		public CalibrateDebevec (IntPtr addr) : base(addr)
		{
		}
	
	
		//
		// C++:  float getLambda()
		//
	
		//javadoc: CalibrateDebevec::getLambda()
		public  float getLambda ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = photo_CalibrateDebevec_getLambda_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setLambda(float lambda)
		//
	
		//javadoc: CalibrateDebevec::setLambda(lambda)
		public  void setLambda (float lambda)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_CalibrateDebevec_setLambda_10 (nativeObj, lambda);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getSamples()
		//
	
		//javadoc: CalibrateDebevec::getSamples()
		public  int getSamples ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = photo_CalibrateDebevec_getSamples_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setSamples(int samples)
		//
	
		//javadoc: CalibrateDebevec::setSamples(samples)
		public  void setSamples (int samples)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_CalibrateDebevec_setSamples_10 (nativeObj, samples);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  bool getRandom()
		//
	
		//javadoc: CalibrateDebevec::getRandom()
		public  bool getRandom ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			bool retVal = photo_CalibrateDebevec_getRandom_10 (nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  void setRandom(bool random)
		//
	
		//javadoc: CalibrateDebevec::setRandom(random)
		public  void setRandom (bool random)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_CalibrateDebevec_setRandom_10 (nativeObj, random);
		
			return;
#else
return;
#endif
		}
	
	

	
	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  float getLambda()
		[DllImport("__Internal")]
		private static extern float photo_CalibrateDebevec_getLambda_10 (IntPtr nativeObj);
		
		// C++:  void setLambda(float lambda)
		[DllImport("__Internal")]
		private static extern void photo_CalibrateDebevec_setLambda_10 (IntPtr nativeObj, float lambda);
		
		// C++:  int getSamples()
		[DllImport("__Internal")]
		private static extern int photo_CalibrateDebevec_getSamples_10 (IntPtr nativeObj);
		
		// C++:  void setSamples(int samples)
		[DllImport("__Internal")]
		private static extern void photo_CalibrateDebevec_setSamples_10 (IntPtr nativeObj, int samples);
		
		// C++:  bool getRandom()
		[DllImport("__Internal")]
		private static extern bool photo_CalibrateDebevec_getRandom_10 (IntPtr nativeObj);
		
		// C++:  void setRandom(bool random)
		[DllImport("__Internal")]
		private static extern void photo_CalibrateDebevec_setRandom_10 (IntPtr nativeObj, bool random);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void photo_CalibrateDebevec_delete (IntPtr nativeObj);
#else
		// C++:  float getLambda()
		[DllImport("opencvforunity")]
		private static extern float photo_CalibrateDebevec_getLambda_10 (IntPtr nativeObj);
	
		// C++:  void setLambda(float lambda)
		[DllImport("opencvforunity")]
		private static extern void photo_CalibrateDebevec_setLambda_10 (IntPtr nativeObj, float lambda);
	
		// C++:  int getSamples()
		[DllImport("opencvforunity")]
		private static extern int photo_CalibrateDebevec_getSamples_10 (IntPtr nativeObj);
	
		// C++:  void setSamples(int samples)
		[DllImport("opencvforunity")]
		private static extern void photo_CalibrateDebevec_setSamples_10 (IntPtr nativeObj, int samples);
	
		// C++:  bool getRandom()
		[DllImport("opencvforunity")]
		private static extern bool photo_CalibrateDebevec_getRandom_10 (IntPtr nativeObj);
	
		// C++:  void setRandom(bool random)
		[DllImport("opencvforunity")]
		private static extern void photo_CalibrateDebevec_setRandom_10 (IntPtr nativeObj, bool random);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void photo_CalibrateDebevec_delete (IntPtr nativeObj);
#endif
	
	}
}
