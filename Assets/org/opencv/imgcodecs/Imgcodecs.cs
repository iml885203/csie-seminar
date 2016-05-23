
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{
	public class Imgcodecs
	{
	
		public const int
			CV_LOAD_IMAGE_UNCHANGED = -1,
			CV_LOAD_IMAGE_GRAYSCALE = 0,
			CV_LOAD_IMAGE_COLOR = 1,
			CV_LOAD_IMAGE_ANYDEPTH = 2,
			CV_LOAD_IMAGE_ANYCOLOR = 4,
			CV_IMWRITE_JPEG_QUALITY = 1,
			CV_IMWRITE_JPEG_PROGRESSIVE = 2,
			CV_IMWRITE_JPEG_OPTIMIZE = 3,
			CV_IMWRITE_JPEG_RST_INTERVAL = 4,
			CV_IMWRITE_JPEG_LUMA_QUALITY = 5,
			CV_IMWRITE_JPEG_CHROMA_QUALITY = 6,
			CV_IMWRITE_PNG_COMPRESSION = 16,
			CV_IMWRITE_PNG_STRATEGY = 17,
			CV_IMWRITE_PNG_BILEVEL = 18,
			CV_IMWRITE_PNG_STRATEGY_DEFAULT = 0,
			CV_IMWRITE_PNG_STRATEGY_FILTERED = 1,
			CV_IMWRITE_PNG_STRATEGY_HUFFMAN_ONLY = 2,
			CV_IMWRITE_PNG_STRATEGY_RLE = 3,
			CV_IMWRITE_PNG_STRATEGY_FIXED = 4,
			CV_IMWRITE_PXM_BINARY = 32,
			CV_IMWRITE_WEBP_QUALITY = 64,
			CV_CVTIMG_FLIP = 1,
			CV_CVTIMG_SWAP_RB = 2,
			IMREAD_UNCHANGED = -1,
			IMREAD_GRAYSCALE = 0,
			IMREAD_COLOR = 1,
			IMREAD_ANYDEPTH = 2,
			IMREAD_ANYCOLOR = 4,
			IMREAD_LOAD_GDAL = 8,
			IMWRITE_JPEG_QUALITY = 1,
			IMWRITE_JPEG_PROGRESSIVE = 2,
			IMWRITE_JPEG_OPTIMIZE = 3,
			IMWRITE_JPEG_RST_INTERVAL = 4,
			IMWRITE_JPEG_LUMA_QUALITY = 5,
			IMWRITE_JPEG_CHROMA_QUALITY = 6,
			IMWRITE_PNG_COMPRESSION = 16,
			IMWRITE_PNG_STRATEGY = 17,
			IMWRITE_PNG_BILEVEL = 18,
			IMWRITE_PXM_BINARY = 32,
			IMWRITE_WEBP_QUALITY = 64,
			IMWRITE_PNG_STRATEGY_DEFAULT = 0,
			IMWRITE_PNG_STRATEGY_FILTERED = 1,
			IMWRITE_PNG_STRATEGY_HUFFMAN_ONLY = 2,
			IMWRITE_PNG_STRATEGY_RLE = 3,
			IMWRITE_PNG_STRATEGY_FIXED = 4;
	
	
		//
		// C++:  Mat imread(string filename, int flags = IMREAD_COLOR)
		//
	
		//javadoc: imread(filename, flags)
		public static Mat imread (string filename, int flags)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat retVal = new Mat (imgcodecs_Imgcodecs_imread_10 (filename, flags));
		
			return retVal;
#else
return null;
#endif
		}
	
		//javadoc: imread(filename)
		public static Mat imread (string filename)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat retVal = new Mat (imgcodecs_Imgcodecs_imread_11 (filename));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  bool imreadmulti(string filename, vector_Mat mats, int flags = IMREAD_ANYCOLOR)
		//
	
		//javadoc: imreadmulti(filename, mats, flags)
		public static bool imreadmulti (string filename, List<Mat> mats, int flags)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat mats_mat = Converters.vector_Mat_to_Mat (mats);
			bool retVal = imgcodecs_Imgcodecs_imreadmulti_10 (filename, mats_mat.nativeObj, flags);
		
			return retVal;
#else
return false;
#endif
		}
	
		//javadoc: imreadmulti(filename, mats)
		public static bool imreadmulti (string filename, List<Mat> mats)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat mats_mat = Converters.vector_Mat_to_Mat (mats);
			bool retVal = imgcodecs_Imgcodecs_imreadmulti_11 (filename, mats_mat.nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  bool imwrite(string filename, Mat img, vector_int params = std::vector<int>())
		//
	
		//javadoc: imwrite(filename, img, params)
		public static bool imwrite (string filename, Mat img, MatOfInt _params)
		{
			if (img != null)
				img.ThrowIfDisposed ();
			if (_params != null)
				_params.ThrowIfDisposed ();

			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat params_mat = _params;
			bool retVal = imgcodecs_Imgcodecs_imwrite_10 (filename, img.nativeObj, params_mat.nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
		//javadoc: imwrite(filename, img)
		public static bool imwrite (string filename, Mat img)
		{
			if (img != null)
				img.ThrowIfDisposed ();

			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			bool retVal = imgcodecs_Imgcodecs_imwrite_11 (filename, img.nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  Mat imdecode(Mat buf, int flags)
		//
	
		//javadoc: imdecode(buf, flags)
		public static Mat imdecode (Mat buf, int flags)
		{
			if (buf != null)
				buf.ThrowIfDisposed ();

			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat retVal = new Mat (imgcodecs_Imgcodecs_imdecode_10 (buf.nativeObj, flags));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  bool imencode(string ext, Mat img, vector_uchar& buf, vector_int params = std::vector<int>())
		//
	
		//javadoc: imencode(ext, img, buf, params)
		public static bool imencode (string ext, Mat img, MatOfByte buf, MatOfInt _params)
		{
			if (img != null)
				img.ThrowIfDisposed ();
			if (buf != null)
				buf.ThrowIfDisposed ();
			if (_params != null)
				_params.ThrowIfDisposed ();

			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat buf_mat = buf;
			Mat params_mat = _params;
			bool retVal = imgcodecs_Imgcodecs_imencode_10 (ext, img.nativeObj, buf_mat.nativeObj, params_mat.nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
		//javadoc: imencode(ext, img, buf)
		public static bool imencode (string ext, Mat img, MatOfByte buf)
		{
			if (img != null)
				img.ThrowIfDisposed ();
			if (buf != null)
				buf.ThrowIfDisposed ();

			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat buf_mat = buf;
			bool retVal = imgcodecs_Imgcodecs_imencode_11 (ext, img.nativeObj, buf_mat.nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  Mat imread(string filename, int flags = IMREAD_COLOR)
		[DllImport("__Internal")]
		private static extern IntPtr imgcodecs_Imgcodecs_imread_10 (string filename, int flags);
		
		[DllImport("__Internal")]
		private static extern IntPtr imgcodecs_Imgcodecs_imread_11 (string filename);
		
		// C++:  bool imreadmulti(string filename, vector_Mat mats, int flags = IMREAD_ANYCOLOR)
		[DllImport("__Internal")]
		private static extern bool imgcodecs_Imgcodecs_imreadmulti_10 (string filename, IntPtr mats_mat_nativeObj, int flags);
		
		[DllImport("__Internal")]
		private static extern bool imgcodecs_Imgcodecs_imreadmulti_11 (string filename, IntPtr mats_mat_nativeObj);
		
		// C++:  bool imwrite(string filename, Mat img, vector_int params = std::vector<int>())
		[DllImport("__Internal")]
		private static extern bool imgcodecs_Imgcodecs_imwrite_10 (string filename, IntPtr img_nativeObj, IntPtr params_mat_nativeObj);
		
		[DllImport("__Internal")]
		private static extern bool imgcodecs_Imgcodecs_imwrite_11 (string filename, IntPtr img_nativeObj);
		
		// C++:  Mat imdecode(Mat buf, int flags)
		[DllImport("__Internal")]
		private static extern IntPtr imgcodecs_Imgcodecs_imdecode_10 (IntPtr buf_nativeObj, int flags);
		
		// C++:  bool imencode(string ext, Mat img, vector_uchar& buf, vector_int params = std::vector<int>())
		[DllImport("__Internal")]
		private static extern bool imgcodecs_Imgcodecs_imencode_10 (string ext, IntPtr img_nativeObj, IntPtr buf_mat_nativeObj, IntPtr params_mat_nativeObj);
		
		[DllImport("__Internal")]
		private static extern bool imgcodecs_Imgcodecs_imencode_11 (string ext, IntPtr img_nativeObj, IntPtr buf_mat_nativeObj);
#else
	
		// C++:  Mat imread(string filename, int flags = IMREAD_COLOR)
		[DllImport("opencvforunity")]
		private static extern IntPtr imgcodecs_Imgcodecs_imread_10 (string filename, int flags);

		[DllImport("opencvforunity")]
		private static extern IntPtr imgcodecs_Imgcodecs_imread_11 (string filename);
	
		// C++:  bool imreadmulti(string filename, vector_Mat mats, int flags = IMREAD_ANYCOLOR)
		[DllImport("opencvforunity")]
		private static extern bool imgcodecs_Imgcodecs_imreadmulti_10 (string filename, IntPtr mats_mat_nativeObj, int flags);

		[DllImport("opencvforunity")]
		private static extern bool imgcodecs_Imgcodecs_imreadmulti_11 (string filename, IntPtr mats_mat_nativeObj);
	
		// C++:  bool imwrite(string filename, Mat img, vector_int params = std::vector<int>())
		[DllImport("opencvforunity")]
		private static extern bool imgcodecs_Imgcodecs_imwrite_10 (string filename, IntPtr img_nativeObj, IntPtr params_mat_nativeObj);

		[DllImport("opencvforunity")]
		private static extern bool imgcodecs_Imgcodecs_imwrite_11 (string filename, IntPtr img_nativeObj);
	
		// C++:  Mat imdecode(Mat buf, int flags)
		[DllImport("opencvforunity")]
		private static extern IntPtr imgcodecs_Imgcodecs_imdecode_10 (IntPtr buf_nativeObj, int flags);
	
		// C++:  bool imencode(string ext, Mat img, vector_uchar& buf, vector_int params = std::vector<int>())
		[DllImport("opencvforunity")]
		private static extern bool imgcodecs_Imgcodecs_imencode_10 (string ext, IntPtr img_nativeObj, IntPtr buf_mat_nativeObj, IntPtr params_mat_nativeObj);

		[DllImport("opencvforunity")]
		private static extern bool imgcodecs_Imgcodecs_imencode_11 (string ext, IntPtr img_nativeObj, IntPtr buf_mat_nativeObj);

#endif
	
	}
}