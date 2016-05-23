
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{
		public class Xphoto
		{
	
				public const int
						INPAINT_SHIFTMAP = 0,
						WHITE_BALANCE_SIMPLE = 0,
						WHITE_BALANCE_GRAYWORLD = 1;
	
	
				//
				// C++:  void dctDenoising(Mat src, Mat dst, double sigma, int psize = 16)
				//
	
				//javadoc: dctDenoising(src, dst, sigma, psize)
				public static void dctDenoising (Mat src, Mat dst, double sigma, int psize)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						xphoto_Xphoto_dctDenoising_10 (src.nativeObj, dst.nativeObj, sigma, psize);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: dctDenoising(src, dst, sigma)
				public static void dctDenoising (Mat src, Mat dst, double sigma)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						xphoto_Xphoto_dctDenoising_11 (src.nativeObj, dst.nativeObj, sigma);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void balanceWhite(Mat src, Mat dst, int algorithmType, float inputMin = 0.0f, float inputMax = 255.0f, float outputMin = 0.0f, float outputMax = 255.0f)
				//
	
				//javadoc: balanceWhite(src, dst, algorithmType, inputMin, inputMax, outputMin, outputMax)
				public static void balanceWhite (Mat src, Mat dst, int algorithmType, float inputMin, float inputMax, float outputMin, float outputMax)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						xphoto_Xphoto_balanceWhite_10 (src.nativeObj, dst.nativeObj, algorithmType, inputMin, inputMax, outputMin, outputMax);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: balanceWhite(src, dst, algorithmType)
				public static void balanceWhite (Mat src, Mat dst, int algorithmType)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						xphoto_Xphoto_balanceWhite_11 (src.nativeObj, dst.nativeObj, algorithmType);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void inpaint(Mat src, Mat mask, Mat dst, int algorithmType)
				//
	
				//javadoc: inpaint(src, mask, dst, algorithmType)
				public static void inpaint (Mat src, Mat mask, Mat dst, int algorithmType)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
						xphoto_Xphoto_inpaint_10 (src.nativeObj, mask.nativeObj, dst.nativeObj, algorithmType);
		
						return;
#else
return;
#endif
				}
	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  void dctDenoising(Mat src, Mat dst, double sigma, int psize = 16)
		[DllImport("__Internal")]
		private static extern void xphoto_Xphoto_dctDenoising_10(IntPtr src_nativeObj, IntPtr dst_nativeObj, double sigma, int psize);
		[DllImport("__Internal")]
		private static extern void xphoto_Xphoto_dctDenoising_11(IntPtr src_nativeObj, IntPtr dst_nativeObj, double sigma);
		
		// C++:  void balanceWhite(Mat src, Mat dst, int algorithmType, float inputMin = 0.0f, float inputMax = 255.0f, float outputMin = 0.0f, float outputMax = 255.0f)
		[DllImport("__Internal")]
		private static extern void xphoto_Xphoto_balanceWhite_10(IntPtr src_nativeObj, IntPtr dst_nativeObj, int algorithmType, float inputMin, float inputMax, float outputMin, float outputMax);
		[DllImport("__Internal")]
		private static extern void xphoto_Xphoto_balanceWhite_11(IntPtr src_nativeObj, IntPtr dst_nativeObj, int algorithmType);
		
		// C++:  void inpaint(Mat src, Mat mask, Mat dst, int algorithmType)
		[DllImport("__Internal")]
		private static extern void xphoto_Xphoto_inpaint_10(IntPtr src_nativeObj, IntPtr mask_nativeObj, IntPtr dst_nativeObj, int algorithmType);
		#else
	
				// C++:  void dctDenoising(Mat src, Mat dst, double sigma, int psize = 16)
				[DllImport("opencvforunity")]
				private static extern void xphoto_Xphoto_dctDenoising_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double sigma, int psize);

				[DllImport("opencvforunity")]
				private static extern void xphoto_Xphoto_dctDenoising_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double sigma);
	
				// C++:  void balanceWhite(Mat src, Mat dst, int algorithmType, float inputMin = 0.0f, float inputMax = 255.0f, float outputMin = 0.0f, float outputMax = 255.0f)
				[DllImport("opencvforunity")]
				private static extern void xphoto_Xphoto_balanceWhite_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int algorithmType, float inputMin, float inputMax, float outputMin, float outputMax);

				[DllImport("opencvforunity")]
				private static extern void xphoto_Xphoto_balanceWhite_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int algorithmType);
	
				// C++:  void inpaint(Mat src, Mat mask, Mat dst, int algorithmType)
				[DllImport("opencvforunity")]
				private static extern void xphoto_Xphoto_inpaint_10 (IntPtr src_nativeObj, IntPtr mask_nativeObj, IntPtr dst_nativeObj, int algorithmType);
		#endif
		}
}
