
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{



// C++: class TonemapMantiuk
//javadoc: TonemapMantiuk
	public class TonemapMantiuk : Tonemap
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						photo_TonemapMantiuk_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		public TonemapMantiuk (IntPtr addr) : base(addr)
		{
		}
	
	
	
		//
		// C++:  float getScale()
		//
	
		//javadoc: TonemapMantiuk::getScale()
		public  float getScale ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = photo_TonemapMantiuk_getScale_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setScale(float scale)
		//
	
		//javadoc: TonemapMantiuk::setScale(scale)
		public  void setScale (float scale)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_TonemapMantiuk_setScale_10 (nativeObj, scale);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  float getSaturation()
		//
	
		//javadoc: TonemapMantiuk::getSaturation()
		public  float getSaturation ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = photo_TonemapMantiuk_getSaturation_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setSaturation(float saturation)
		//
	
		//javadoc: TonemapMantiuk::setSaturation(saturation)
		public  void setSaturation (float saturation)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_TonemapMantiuk_setSaturation_10 (nativeObj, saturation);
		
			return;
#else
return;
#endif
		}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  float getScale()
		[DllImport("__Internal")]
		private static extern float photo_TonemapMantiuk_getScale_10 (IntPtr nativeObj);
		
		// C++:  void setScale(float scale)
		[DllImport("__Internal")]
		private static extern void photo_TonemapMantiuk_setScale_10 (IntPtr nativeObj, float scale);
		
		// C++:  float getSaturation()
		[DllImport("__Internal")]
		private static extern float photo_TonemapMantiuk_getSaturation_10 (IntPtr nativeObj);
		
		// C++:  void setSaturation(float saturation)
		[DllImport("__Internal")]
		private static extern void photo_TonemapMantiuk_setSaturation_10 (IntPtr nativeObj, float saturation);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void photo_TonemapMantiuk_delete (IntPtr nativeObj);
#else
		// C++:  float getScale()
		[DllImport("opencvforunity")]
		private static extern float photo_TonemapMantiuk_getScale_10 (IntPtr nativeObj);
	
		// C++:  void setScale(float scale)
		[DllImport("opencvforunity")]
		private static extern void photo_TonemapMantiuk_setScale_10 (IntPtr nativeObj, float scale);
	
		// C++:  float getSaturation()
		[DllImport("opencvforunity")]
		private static extern float photo_TonemapMantiuk_getSaturation_10 (IntPtr nativeObj);
	
		// C++:  void setSaturation(float saturation)
		[DllImport("opencvforunity")]
		private static extern void photo_TonemapMantiuk_setSaturation_10 (IntPtr nativeObj, float saturation);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void photo_TonemapMantiuk_delete (IntPtr nativeObj);
#endif
	
	}
}
