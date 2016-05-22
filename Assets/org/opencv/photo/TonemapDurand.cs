
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{



// C++: class TonemapDurand
//javadoc: TonemapDurand
	public class TonemapDurand : Tonemap
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						photo_TonemapDurand_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		public TonemapDurand (IntPtr addr) : base(addr)
		{
		}
	
	
	
		//
		// C++:  float getSaturation()
		//
	
		//javadoc: TonemapDurand::getSaturation()
		public  float getSaturation ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = photo_TonemapDurand_getSaturation_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setSaturation(float saturation)
		//
	
		//javadoc: TonemapDurand::setSaturation(saturation)
		public  void setSaturation (float saturation)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_TonemapDurand_setSaturation_10 (nativeObj, saturation);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  float getContrast()
		//
	
		//javadoc: TonemapDurand::getContrast()
		public  float getContrast ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = photo_TonemapDurand_getContrast_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setContrast(float contrast)
		//
	
		//javadoc: TonemapDurand::setContrast(contrast)
		public  void setContrast (float contrast)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_TonemapDurand_setContrast_10 (nativeObj, contrast);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  float getSigmaSpace()
		//
	
		//javadoc: TonemapDurand::getSigmaSpace()
		public  float getSigmaSpace ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = photo_TonemapDurand_getSigmaSpace_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setSigmaSpace(float sigma_space)
		//
	
		//javadoc: TonemapDurand::setSigmaSpace(sigma_space)
		public  void setSigmaSpace (float sigma_space)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_TonemapDurand_setSigmaSpace_10 (nativeObj, sigma_space);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  float getSigmaColor()
		//
	
		//javadoc: TonemapDurand::getSigmaColor()
		public  float getSigmaColor ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			float retVal = photo_TonemapDurand_getSigmaColor_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setSigmaColor(float sigma_color)
		//
	
		//javadoc: TonemapDurand::setSigmaColor(sigma_color)
		public  void setSigmaColor (float sigma_color)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_TonemapDurand_setSigmaColor_10 (nativeObj, sigma_color);
		
			return;
#else
return;
#endif
		}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  float getSaturation()
		[DllImport("__Internal")]
		private static extern float photo_TonemapDurand_getSaturation_10 (IntPtr nativeObj);
		
		// C++:  void setSaturation(float saturation)
		[DllImport("__Internal")]
		private static extern void photo_TonemapDurand_setSaturation_10 (IntPtr nativeObj, float saturation);
		
		// C++:  float getContrast()
		[DllImport("__Internal")]
		private static extern float photo_TonemapDurand_getContrast_10 (IntPtr nativeObj);
		
		// C++:  void setContrast(float contrast)
		[DllImport("__Internal")]
		private static extern void photo_TonemapDurand_setContrast_10 (IntPtr nativeObj, float contrast);
		
		// C++:  float getSigmaSpace()
		[DllImport("__Internal")]
		private static extern float photo_TonemapDurand_getSigmaSpace_10 (IntPtr nativeObj);
		
		// C++:  void setSigmaSpace(float sigma_space)
		[DllImport("__Internal")]
		private static extern void photo_TonemapDurand_setSigmaSpace_10 (IntPtr nativeObj, float sigma_space);
		
		// C++:  float getSigmaColor()
		[DllImport("__Internal")]
		private static extern float photo_TonemapDurand_getSigmaColor_10 (IntPtr nativeObj);
		
		// C++:  void setSigmaColor(float sigma_color)
		[DllImport("__Internal")]
		private static extern void photo_TonemapDurand_setSigmaColor_10 (IntPtr nativeObj, float sigma_color);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void photo_TonemapDurand_delete (IntPtr nativeObj);
#else
		// C++:  float getSaturation()
		[DllImport("opencvforunity")]
		private static extern float photo_TonemapDurand_getSaturation_10 (IntPtr nativeObj);
	
		// C++:  void setSaturation(float saturation)
		[DllImport("opencvforunity")]
		private static extern void photo_TonemapDurand_setSaturation_10 (IntPtr nativeObj, float saturation);
	
		// C++:  float getContrast()
		[DllImport("opencvforunity")]
		private static extern float photo_TonemapDurand_getContrast_10 (IntPtr nativeObj);
	
		// C++:  void setContrast(float contrast)
		[DllImport("opencvforunity")]
		private static extern void photo_TonemapDurand_setContrast_10 (IntPtr nativeObj, float contrast);
	
		// C++:  float getSigmaSpace()
		[DllImport("opencvforunity")]
		private static extern float photo_TonemapDurand_getSigmaSpace_10 (IntPtr nativeObj);
	
		// C++:  void setSigmaSpace(float sigma_space)
		[DllImport("opencvforunity")]
		private static extern void photo_TonemapDurand_setSigmaSpace_10 (IntPtr nativeObj, float sigma_space);
	
		// C++:  float getSigmaColor()
		[DllImport("opencvforunity")]
		private static extern float photo_TonemapDurand_getSigmaColor_10 (IntPtr nativeObj);
	
		// C++:  void setSigmaColor(float sigma_color)
		[DllImport("opencvforunity")]
		private static extern void photo_TonemapDurand_setSigmaColor_10 (IntPtr nativeObj, float sigma_color);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void photo_TonemapDurand_delete (IntPtr nativeObj);
#endif
	
	}
}
