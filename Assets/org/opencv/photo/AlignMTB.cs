
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class AlignMTB
//javadoc: AlignMTB
	public class AlignMTB : AlignExposures
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						photo_AlignMTB_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		public AlignMTB (IntPtr addr) : base(addr)
		{
		}
	
	
	
		//
		// C++:  void process(vector_Mat src, vector_Mat dst, Mat times, Mat response)
		//
	
		//javadoc: AlignMTB::process(src, dst, times, response)
		public override void process (List<Mat> src, List<Mat> dst, Mat times, Mat response)
		{
			ThrowIfDisposed ();
			if (times != null)
				times.ThrowIfDisposed ();
			if (response != null)
				response.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat src_mat = Converters.vector_Mat_to_Mat (src);
			Mat dst_mat = Converters.vector_Mat_to_Mat (dst);
			photo_AlignMTB_process_10 (nativeObj, src_mat.nativeObj, dst_mat.nativeObj, times.nativeObj, response.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void process(vector_Mat src, vector_Mat dst)
		//
	
		//javadoc: AlignMTB::process(src, dst)
		public  void process (List<Mat> src, List<Mat> dst)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat src_mat = Converters.vector_Mat_to_Mat (src);
			Mat dst_mat = Converters.vector_Mat_to_Mat (dst);
			photo_AlignMTB_process_11 (nativeObj, src_mat.nativeObj, dst_mat.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  Point calculateShift(Mat img0, Mat img1)
		//
	
		//javadoc: AlignMTB::calculateShift(img0, img1)
		public  Point calculateShift (Mat img0, Mat img1)
		{
			ThrowIfDisposed ();
			if (img0 != null)
				img0.ThrowIfDisposed ();
			if (img1 != null)
				img1.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double[] tmpArray = new double[2];
			
			photo_AlignMTB_calculateShift_10 (nativeObj, img0.nativeObj, img1.nativeObj, tmpArray);
			
			Point retVal = new Point (tmpArray);

			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  void shiftMat(Mat src, Mat& dst, Point shift)
		//
	
		//javadoc: AlignMTB::shiftMat(src, dst, shift)
		public  void shiftMat (Mat src, Mat dst, Point shift)
		{
			ThrowIfDisposed ();
			if (src != null)
				src.ThrowIfDisposed ();
			if (dst != null)
				dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_AlignMTB_shiftMat_10 (nativeObj, src.nativeObj, dst.nativeObj, shift.x, shift.y);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void computeBitmaps(Mat img, Mat& tb, Mat& eb)
		//
	
		//javadoc: AlignMTB::computeBitmaps(img, tb, eb)
		public  void computeBitmaps (Mat img, Mat tb, Mat eb)
		{
			ThrowIfDisposed ();
			if (img != null)
				img.ThrowIfDisposed ();
			if (tb != null)
				tb.ThrowIfDisposed ();
			if (eb != null)
				eb.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_AlignMTB_computeBitmaps_10 (nativeObj, img.nativeObj, tb.nativeObj, eb.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getMaxBits()
		//
	
		//javadoc: AlignMTB::getMaxBits()
		public  int getMaxBits ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = photo_AlignMTB_getMaxBits_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setMaxBits(int max_bits)
		//
	
		//javadoc: AlignMTB::setMaxBits(max_bits)
		public  void setMaxBits (int max_bits)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_AlignMTB_setMaxBits_10 (nativeObj, max_bits);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getExcludeRange()
		//
	
		//javadoc: AlignMTB::getExcludeRange()
		public  int getExcludeRange ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = photo_AlignMTB_getExcludeRange_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setExcludeRange(int exclude_range)
		//
	
		//javadoc: AlignMTB::setExcludeRange(exclude_range)
		public  void setExcludeRange (int exclude_range)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_AlignMTB_setExcludeRange_10 (nativeObj, exclude_range);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  bool getCut()
		//
	
		//javadoc: AlignMTB::getCut()
		public  bool getCut ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			bool retVal = photo_AlignMTB_getCut_10 (nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  void setCut(bool value)
		//
	
		//javadoc: AlignMTB::setCut(value)
		public  void setCut (bool value)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			photo_AlignMTB_setCut_10 (nativeObj, value);
		
			return;
#else
return;
#endif
		}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  void process(vector_Mat src, vector_Mat dst, Mat times, Mat response)
		[DllImport("__Internal")]
		private static extern void photo_AlignMTB_process_10 (IntPtr nativeObj, IntPtr src_mat_nativeObj, IntPtr dst_mat_nativeObj, IntPtr times_nativeObj, IntPtr response_nativeObj);
		
		// C++:  void process(vector_Mat src, vector_Mat dst)
		[DllImport("__Internal")]
		private static extern void photo_AlignMTB_process_11 (IntPtr nativeObj, IntPtr src_mat_nativeObj, IntPtr dst_mat_nativeObj);
		
		// C++:  Point calculateShift(Mat img0, Mat img1)
		[DllImport("__Internal")]
		private static extern void photo_AlignMTB_calculateShift_10 (IntPtr nativeObj, IntPtr img0_nativeObj, IntPtr img1_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);
		
		// C++:  void shiftMat(Mat src, Mat& dst, Point shift)
		[DllImport("__Internal")]
		private static extern void photo_AlignMTB_shiftMat_10 (IntPtr nativeObj, IntPtr src_nativeObj, IntPtr dst_nativeObj, double shift_x, double shift_y);
		
		// C++:  void computeBitmaps(Mat img, Mat& tb, Mat& eb)
		[DllImport("__Internal")]
		private static extern void photo_AlignMTB_computeBitmaps_10 (IntPtr nativeObj, IntPtr img_nativeObj, IntPtr tb_nativeObj, IntPtr eb_nativeObj);
		
		// C++:  int getMaxBits()
		[DllImport("__Internal")]
		private static extern int photo_AlignMTB_getMaxBits_10 (IntPtr nativeObj);
		
		// C++:  void setMaxBits(int max_bits)
		[DllImport("__Internal")]
		private static extern void photo_AlignMTB_setMaxBits_10 (IntPtr nativeObj, int max_bits);
		
		// C++:  int getExcludeRange()
		[DllImport("__Internal")]
		private static extern int photo_AlignMTB_getExcludeRange_10 (IntPtr nativeObj);
		
		// C++:  void setExcludeRange(int exclude_range)
		[DllImport("__Internal")]
		private static extern void photo_AlignMTB_setExcludeRange_10 (IntPtr nativeObj, int exclude_range);
		
		// C++:  bool getCut()
		[DllImport("__Internal")]
		private static extern bool photo_AlignMTB_getCut_10 (IntPtr nativeObj);
		
		// C++:  void setCut(bool value)
		[DllImport("__Internal")]
		private static extern void photo_AlignMTB_setCut_10 (IntPtr nativeObj, bool value);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void photo_AlignMTB_delete (IntPtr nativeObj);
#else
		// C++:  void process(vector_Mat src, vector_Mat dst, Mat times, Mat response)
		[DllImport("opencvforunity")]
		private static extern void photo_AlignMTB_process_10 (IntPtr nativeObj, IntPtr src_mat_nativeObj, IntPtr dst_mat_nativeObj, IntPtr times_nativeObj, IntPtr response_nativeObj);
	
		// C++:  void process(vector_Mat src, vector_Mat dst)
		[DllImport("opencvforunity")]
		private static extern void photo_AlignMTB_process_11 (IntPtr nativeObj, IntPtr src_mat_nativeObj, IntPtr dst_mat_nativeObj);
	
		// C++:  Point calculateShift(Mat img0, Mat img1)
		[DllImport("opencvforunity")]
		private static extern void photo_AlignMTB_calculateShift_10 (IntPtr nativeObj, IntPtr img0_nativeObj, IntPtr img1_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);
	
		// C++:  void shiftMat(Mat src, Mat& dst, Point shift)
		[DllImport("opencvforunity")]
		private static extern void photo_AlignMTB_shiftMat_10 (IntPtr nativeObj, IntPtr src_nativeObj, IntPtr dst_nativeObj, double shift_x, double shift_y);
	
		// C++:  void computeBitmaps(Mat img, Mat& tb, Mat& eb)
		[DllImport("opencvforunity")]
		private static extern void photo_AlignMTB_computeBitmaps_10 (IntPtr nativeObj, IntPtr img_nativeObj, IntPtr tb_nativeObj, IntPtr eb_nativeObj);
	
		// C++:  int getMaxBits()
		[DllImport("opencvforunity")]
		private static extern int photo_AlignMTB_getMaxBits_10 (IntPtr nativeObj);
	
		// C++:  void setMaxBits(int max_bits)
		[DllImport("opencvforunity")]
		private static extern void photo_AlignMTB_setMaxBits_10 (IntPtr nativeObj, int max_bits);
	
		// C++:  int getExcludeRange()
		[DllImport("opencvforunity")]
		private static extern int photo_AlignMTB_getExcludeRange_10 (IntPtr nativeObj);
	
		// C++:  void setExcludeRange(int exclude_range)
		[DllImport("opencvforunity")]
		private static extern void photo_AlignMTB_setExcludeRange_10 (IntPtr nativeObj, int exclude_range);
	
		// C++:  bool getCut()
		[DllImport("opencvforunity")]
		private static extern bool photo_AlignMTB_getCut_10 (IntPtr nativeObj);
	
		// C++:  void setCut(bool value)
		[DllImport("opencvforunity")]
		private static extern void photo_AlignMTB_setCut_10 (IntPtr nativeObj, bool value);
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void photo_AlignMTB_delete (IntPtr nativeObj);
#endif
	
	}
}
