
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class CLAHE
//javadoc: CLAHE
	public class CLAHE : Algorithm
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						imgproc_CLAHE_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		public CLAHE (IntPtr addr) : base(addr)
		{
		}
	
	

	
	
		//
		// C++:  void apply(Mat src, Mat& dst)
		//
	
		//javadoc: CLAHE::apply(src, dst)
		public  void apply (Mat src, Mat dst)
		{
			ThrowIfDisposed ();
			if (src != null)
				src.ThrowIfDisposed ();
			if (dst != null)
				dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			imgproc_CLAHE_apply_10 (nativeObj, src.nativeObj, dst.nativeObj);
		
			return;
#else
return;
#endif
		}

		//
		// C++:  void setClipLimit(double clipLimit)
		//
		
		//javadoc: CLAHE::setClipLimit(clipLimit)
		public  void setClipLimit (double clipLimit)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			imgproc_CLAHE_setClipLimit_10 (nativeObj, clipLimit);
			
			return;
			#else
			return;
			#endif
		}
	
	

	
	
		//
		// C++:  void setTilesGridSize(Size tileGridSize)
		//
	
		//javadoc: CLAHE::setTilesGridSize(tileGridSize)
		public  void setTilesGridSize (Size tileGridSize)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			imgproc_CLAHE_setTilesGridSize_10 (nativeObj, tileGridSize.width, tileGridSize.height);
		
			return;
#else
return;
#endif
		}

		//
		// C++:  double getClipLimit()
		//
		
		//javadoc: CLAHE::getClipLimit()
		public  double getClipLimit ()
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			double retVal = imgproc_CLAHE_getClipLimit_10 (nativeObj);
			
			return retVal;
			#else
			return -1;
			#endif
		}
	
	
		//
		// C++:  void collectGarbage()
		//
	
		//javadoc: CLAHE::collectGarbage()
		public  void collectGarbage ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			imgproc_CLAHE_collectGarbage_10 (nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  Size getTilesGridSize()
		//
	
		//javadoc: CLAHE::getTilesGridSize()
		public  Size getTilesGridSize ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double[] tmpArray = new double[2];
			imgproc_CLAHE_getTilesGridSize_10 (nativeObj, tmpArray);
			Size retVal = new Size (tmpArray);
		
			return retVal;
#else
return null;
#endif
		}
	
	

	
		#if UNITY_IOS && !UNITY_EDITOR

		// C++:  void apply(Mat src, Mat& dst)
		[DllImport("__Internal")]
		private static extern void imgproc_CLAHE_apply_10 (IntPtr nativeObj, IntPtr src_nativeObj, IntPtr dst_nativeObj);

		// C++:  void setClipLimit(double clipLimit)
		[DllImport("__Internal")]
		private static extern void imgproc_CLAHE_setClipLimit_10 (IntPtr nativeObj, double clipLimit);



		// C++:  void setTilesGridSize(Size tileGridSize)
		[DllImport("__Internal")]
		private static extern void imgproc_CLAHE_setTilesGridSize_10 (IntPtr nativeObj, double tileGridSize_width, double tileGridSize_height);

		// C++:  double getClipLimit()
		[DllImport("__Internal")]
		private static extern double imgproc_CLAHE_getClipLimit_10 (IntPtr nativeObj);


		// C++:  void collectGarbage()
		[DllImport("__Internal")]
		private static extern void imgproc_CLAHE_collectGarbage_10 (IntPtr nativeObj);
		
		// C++:  Size getTilesGridSize()
		[DllImport("__Internal")]
		private static extern void imgproc_CLAHE_getTilesGridSize_10 (IntPtr nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void imgproc_CLAHE_delete (IntPtr nativeObj);
#else
	

		// C++:  void apply(Mat src, Mat& dst)
		[DllImport("opencvforunity")]
		private static extern void imgproc_CLAHE_apply_10 (IntPtr nativeObj, IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
		// C++:  void setClipLimit(double clipLimit)
		[DllImport("opencvforunity")]
		private static extern void imgproc_CLAHE_setClipLimit_10 (IntPtr nativeObj, double clipLimit);



		// C++:  void setTilesGridSize(Size tileGridSize)
		[DllImport("opencvforunity")]
		private static extern void imgproc_CLAHE_setTilesGridSize_10 (IntPtr nativeObj, double tileGridSize_width, double tileGridSize_height);
	
		// C++:  double getClipLimit()
		[DllImport("opencvforunity")]
		private static extern double imgproc_CLAHE_getClipLimit_10 (IntPtr nativeObj);


		// C++:  void collectGarbage()
		[DllImport("opencvforunity")]
		private static extern void imgproc_CLAHE_collectGarbage_10 (IntPtr nativeObj);
	
		// C++:  Size getTilesGridSize()
		[DllImport("opencvforunity")]
		private static extern void imgproc_CLAHE_getTilesGridSize_10 (IntPtr nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void imgproc_CLAHE_delete (IntPtr nativeObj);
#endif
	
	}
}
