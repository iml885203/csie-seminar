
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{
		public class Core
		{
	
				// these constants are wrapped inside functions to prevent inlining
				private static string getVersion ()
				{
						return "3.0.0";
				}

				private static string getNativeLibraryName ()
				{
						return "opencvforunity";
				}

				private static int getVersionMajor ()
				{
						return 3;
				}

				private static int getVersionMinor ()
				{
						return 0;
				}

				private static int getVersionRevision ()
				{
						return 0;
				}

				private static string getVersionStatus ()
				{
						return "";
				}
	
				public static readonly string VERSION = getVersion ();
				public static readonly string NATIVE_LIBRARY_NAME = getNativeLibraryName ();
				public static readonly int VERSION_MAJOR = getVersionMajor ();
				public static readonly int VERSION_MINOR = getVersionMinor ();
				public static readonly int VERSION_REVISION = getVersionRevision ();
				public static readonly string VERSION_STATUS = getVersionStatus ();
				private const int
						CV_8U = 0,
						CV_8S = 1,
						CV_16U = 2,
						CV_16S = 3,
						CV_32S = 4,
						CV_32F = 5,
						CV_64F = 6,
						CV_USRTYPE1 = 7;
				public const int
						SVD_MODIFY_A = 1,
						SVD_NO_UV = 2,
						SVD_FULL_UV = 4,
						FILLED = -1,
						REDUCE_SUM = 0,
						REDUCE_AVG = 1,
						REDUCE_MAX = 2,
						REDUCE_MIN = 3,
						StsOk = 0,
						StsBackTrace = -1,
						StsError = -2,
						StsInternal = -3,
						StsNoMem = -4,
						StsBadArg = -5,
						StsBadFunc = -6,
						StsNoConv = -7,
						StsAutoTrace = -8,
						HeaderIsNull = -9,
						BadImageSize = -10,
						BadOffset = -11,
						BadDataPtr = -12,
						BadStep = -13,
						BadModelOrChSeq = -14,
						BadNumChannels = -15,
						BadNumChannel1U = -16,
						BadDepth = -17,
						BadAlphaChannel = -18,
						BadOrder = -19,
						BadOrigin = -20,
						BadAlign = -21,
						BadCallBack = -22,
						BadTileSize = -23,
						BadCOI = -24,
						BadROISize = -25,
						MaskIsTiled = -26,
						StsNullPtr = -27,
						StsVecLengthErr = -28,
						StsFilterStructContentErr = -29,
						StsKernelStructContentErr = -30,
						StsFilterOffsetErr = -31,
						StsBadSize = -201,
						StsDivByZero = -202,
						StsInplaceNotSupported = -203,
						StsObjectNotFound = -204,
						StsUnmatchedFormats = -205,
						StsBadFlag = -206,
						StsBadPoint = -207,
						StsBadMask = -208,
						StsUnmatchedSizes = -209,
						StsUnsupportedFormat = -210,
						StsOutOfRange = -211,
						StsParseError = -212,
						StsNotImplemented = -213,
						StsBadMemBlock = -214,
						StsAssert = -215,
						GpuNotSupported = -216,
						GpuApiCallError = -217,
						OpenGlNotSupported = -218,
						OpenGlApiCallError = -219,
						OpenCLApiCallError = -220,
						OpenCLDoubleNotSupported = -221,
						OpenCLInitError = -222,
						OpenCLNoAMDBlasFft = -223,
						DECOMP_LU = 0,
						DECOMP_SVD = 1,
						DECOMP_EIG = 2,
						DECOMP_CHOLESKY = 3,
						DECOMP_QR = 4,
						DECOMP_NORMAL = 16,
						NORM_INF = 1,
						NORM_L1 = 2,
						NORM_L2 = 4,
						NORM_L2SQR = 5,
						NORM_HAMMING = 6,
						NORM_HAMMING2 = 7,
						NORM_TYPE_MASK = 7,
						NORM_RELATIVE = 8,
						NORM_MINMAX = 32,
						CMP_EQ = 0,
						CMP_GT = 1,
						CMP_GE = 2,
						CMP_LT = 3,
						CMP_LE = 4,
						CMP_NE = 5,
						GEMM_1_T = 1,
						GEMM_2_T = 2,
						GEMM_3_T = 4,
						DFT_INVERSE = 1,
						DFT_SCALE = 2,
						DFT_ROWS = 4,
						DFT_COMPLEX_OUTPUT = 16,
						DFT_REAL_OUTPUT = 32,
						DCT_INVERSE = DFT_INVERSE,
						DCT_ROWS = DFT_ROWS,
						BORDER_CONSTANT = 0,
						BORDER_REPLICATE = 1,
						BORDER_REFLECT = 2,
						BORDER_WRAP = 3,
						BORDER_REFLECT_101 = 4,
						BORDER_TRANSPARENT = 5,
						BORDER_REFLECT101 = BORDER_REFLECT_101,
						BORDER_DEFAULT = BORDER_REFLECT_101,
						BORDER_ISOLATED = 16,
						SORT_EVERY_ROW = 0,
						SORT_EVERY_COLUMN = 1,
						SORT_ASCENDING = 0,
						SORT_DESCENDING = 16,
						COVAR_SCRAMBLED = 0,
						COVAR_NORMAL = 1,
						COVAR_USE_AVG = 2,
						COVAR_SCALE = 4,
						COVAR_ROWS = 8,
						COVAR_COLS = 16,
						KMEANS_RANDOM_CENTERS = 0,
						KMEANS_PP_CENTERS = 2,
						KMEANS_USE_INITIAL_LABELS = 1,
						LINE_4 = 4,
						LINE_8 = 8,
						LINE_AA = 16,
						FONT_HERSHEY_SIMPLEX = 0,
						FONT_HERSHEY_PLAIN = 1,
						FONT_HERSHEY_DUPLEX = 2,
						FONT_HERSHEY_COMPLEX = 3,
						FONT_HERSHEY_TRIPLEX = 4,
						FONT_HERSHEY_COMPLEX_SMALL = 5,
						FONT_HERSHEY_SCRIPT_SIMPLEX = 6,
						FONT_HERSHEY_SCRIPT_COMPLEX = 7,
						FONT_ITALIC = 16,
						CPU_MMX = 1,
						CPU_SSE = 2,
						CPU_SSE2 = 3,
						CPU_SSE3 = 4,
						CPU_SSSE3 = 5,
						CPU_SSE4_1 = 6,
						CPU_SSE4_2 = 7,
						CPU_POPCNT = 8,
						CPU_AVX = 10,
						CPU_AVX2 = 11,
						CPU_FMA3 = 12,
						CPU_AVX_512F = 13,
						CPU_AVX_512BW = 14,
						CPU_AVX_512CD = 15,
						CPU_AVX_512DQ = 16,
						CPU_AVX_512ER = 17,
						CPU_AVX_512IFMA512 = 18,
						CPU_AVX_512PF = 19,
						CPU_AVX_512VBMI = 20,
						CPU_AVX_512VL = 21,
						CPU_NEON = 100;
	
	
				//
				// C++:  double PSNR(Mat src1, Mat src2)
				//
	
				//javadoc: PSNR(src1, src2)
				public static double PSNR (Mat src1, Mat src2)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_PSNR_10 (src1.nativeObj, src2.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void batchDistance(Mat src1, Mat src2, Mat& dist, int dtype, Mat& nidx, int normType = NORM_L2, int K = 0, Mat mask = Mat(), int update = 0, bool crosscheck = false)
				//
	
				//javadoc: batchDistance(src1, src2, dist, dtype, nidx, normType, K, mask, update, crosscheck)
				public static void batchDistance (Mat src1, Mat src2, Mat dist, int dtype, Mat nidx, int normType, int K, Mat mask, int update, bool crosscheck)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dist != null)
								dist.ThrowIfDisposed ();
						if (nidx != null)
								nidx.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_batchDistance_10 (src1.nativeObj, src2.nativeObj, dist.nativeObj, dtype, nidx.nativeObj, normType, K, mask.nativeObj, update, crosscheck);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: batchDistance(src1, src2, dist, dtype, nidx, normType, K)
				public static void batchDistance (Mat src1, Mat src2, Mat dist, int dtype, Mat nidx, int normType, int K)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dist != null)
								dist.ThrowIfDisposed ();
						if (nidx != null)
								nidx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_batchDistance_11 (src1.nativeObj, src2.nativeObj, dist.nativeObj, dtype, nidx.nativeObj, normType, K);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: batchDistance(src1, src2, dist, dtype, nidx)
				public static void batchDistance (Mat src1, Mat src2, Mat dist, int dtype, Mat nidx)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dist != null)
								dist.ThrowIfDisposed ();
						if (nidx != null)
								nidx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_batchDistance_12 (src1.nativeObj, src2.nativeObj, dist.nativeObj, dtype, nidx.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int64 getCPUTickCount()
				//
	
				//javadoc: getCPUTickCount()
				public static long getCPUTickCount ()
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						long retVal = core_Core_getCPUTickCount_10 ();
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  float cubeRoot(float val)
				//
	
				//javadoc: cubeRoot(val)
				public static float cubeRoot (float val)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						float retVal = core_Core_cubeRoot_10 (val);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  float fastAtan2(float y, float x)
				//
	
				//javadoc: fastAtan2(y, x)
				public static float fastAtan2 (float y, float x)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						float retVal = core_Core_fastAtan2_10 (y, x);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void insertChannel(Mat src, Mat& dst, int coi)
				//
	
				//javadoc: insertChannel(src, dst, coi)
				public static void insertChannel (Mat src, Mat dst, int coi)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_insertChannel_10 (src.nativeObj, dst.nativeObj, coi);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void flip(Mat src, Mat& dst, int flipCode)
				//
	
				//javadoc: flip(src, dst, flipCode)
				public static void flip (Mat src, Mat dst, int flipCode)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_flip_10 (src.nativeObj, dst.nativeObj, flipCode);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void repeat(Mat src, int ny, int nx, Mat& dst)
				//
	
				//javadoc: repeat(src, ny, nx, dst)
				public static void repeat (Mat src, int ny, int nx, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_repeat_10 (src.nativeObj, ny, nx, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void PCACompute(Mat data, Mat& mean, Mat& eigenvectors, double retainedVariance)
				//
	
				//javadoc: PCACompute(data, mean, eigenvectors, retainedVariance)
				public static void PCACompute (Mat data, Mat mean, Mat eigenvectors, double retainedVariance)
				{
						if (data != null)
								data.ThrowIfDisposed ();
						if (mean != null)
								mean.ThrowIfDisposed ();
						if (eigenvectors != null)
								eigenvectors.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_PCACompute_10 (data.nativeObj, mean.nativeObj, eigenvectors.nativeObj, retainedVariance);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void PCAProject(Mat data, Mat mean, Mat eigenvectors, Mat& result)
				//
	
				//javadoc: PCAProject(data, mean, eigenvectors, result)
				public static void PCAProject (Mat data, Mat mean, Mat eigenvectors, Mat result)
				{
						if (data != null)
								data.ThrowIfDisposed ();
						if (mean != null)
								mean.ThrowIfDisposed ();
						if (eigenvectors != null)
								eigenvectors.ThrowIfDisposed ();
						if (result != null)
								result.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_PCAProject_10 (data.nativeObj, mean.nativeObj, eigenvectors.nativeObj, result.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void PCABackProject(Mat data, Mat mean, Mat eigenvectors, Mat& result)
				//
	
				//javadoc: PCABackProject(data, mean, eigenvectors, result)
				public static void PCABackProject (Mat data, Mat mean, Mat eigenvectors, Mat result)
				{
						if (data != null)
								data.ThrowIfDisposed ();
						if (mean != null)
								mean.ThrowIfDisposed ();
						if (eigenvectors != null)
								eigenvectors.ThrowIfDisposed ();
						if (result != null)
								result.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_PCABackProject_10 (data.nativeObj, mean.nativeObj, eigenvectors.nativeObj, result.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void SVDecomp(Mat src, Mat& w, Mat& u, Mat& vt, int flags = 0)
				//
	
				//javadoc: SVDecomp(src, w, u, vt, flags)
				public static void SVDecomp (Mat src, Mat w, Mat u, Mat vt, int flags)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (w != null)
								w.ThrowIfDisposed ();
						if (u != null)
								u.ThrowIfDisposed ();
						if (vt != null)
								vt.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_SVDecomp_10 (src.nativeObj, w.nativeObj, u.nativeObj, vt.nativeObj, flags);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: SVDecomp(src, w, u, vt)
				public static void SVDecomp (Mat src, Mat w, Mat u, Mat vt)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (w != null)
								w.ThrowIfDisposed ();
						if (u != null)
								u.ThrowIfDisposed ();
						if (vt != null)
								vt.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_SVDecomp_11 (src.nativeObj, w.nativeObj, u.nativeObj, vt.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void SVBackSubst(Mat w, Mat u, Mat vt, Mat rhs, Mat& dst)
				//
	
				//javadoc: SVBackSubst(w, u, vt, rhs, dst)
				public static void SVBackSubst (Mat w, Mat u, Mat vt, Mat rhs, Mat dst)
				{
						if (w != null)
								w.ThrowIfDisposed ();
						if (u != null)
								u.ThrowIfDisposed ();
						if (vt != null)
								vt.ThrowIfDisposed ();
						if (rhs != null)
								rhs.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_SVBackSubst_10 (w.nativeObj, u.nativeObj, vt.nativeObj, rhs.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  double Mahalanobis(Mat v1, Mat v2, Mat icovar)
				//
	
				//javadoc: Mahalanobis(v1, v2, icovar)
				public static double Mahalanobis (Mat v1, Mat v2, Mat icovar)
				{
						if (v1 != null)
								v1.ThrowIfDisposed ();
						if (v2 != null)
								v2.ThrowIfDisposed ();
						if (icovar != null)
								icovar.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_Mahalanobis_10 (v1.nativeObj, v2.nativeObj, icovar.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void dft(Mat src, Mat& dst, int flags = 0, int nonzeroRows = 0)
				//
	
				//javadoc: dft(src, dst, flags, nonzeroRows)
				public static void dft (Mat src, Mat dst, int flags, int nonzeroRows)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_dft_10 (src.nativeObj, dst.nativeObj, flags, nonzeroRows);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: dft(src, dst)
				public static void dft (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_dft_11 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void idft(Mat src, Mat& dst, int flags = 0, int nonzeroRows = 0)
				//
	
				//javadoc: idft(src, dst, flags, nonzeroRows)
				public static void idft (Mat src, Mat dst, int flags, int nonzeroRows)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_idft_10 (src.nativeObj, dst.nativeObj, flags, nonzeroRows);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: idft(src, dst)
				public static void idft (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_idft_11 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void dct(Mat src, Mat& dst, int flags = 0)
				//
	
				//javadoc: dct(src, dst, flags)
				public static void dct (Mat src, Mat dst, int flags)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_dct_10 (src.nativeObj, dst.nativeObj, flags);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: dct(src, dst)
				public static void dct (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_dct_11 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void idct(Mat src, Mat& dst, int flags = 0)
				//
	
				//javadoc: idct(src, dst, flags)
				public static void idct (Mat src, Mat dst, int flags)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_idct_10 (src.nativeObj, dst.nativeObj, flags);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: idct(src, dst)
				public static void idct (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_idct_11 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void mulSpectrums(Mat a, Mat b, Mat& c, int flags, bool conjB = false)
				//
	
				//javadoc: mulSpectrums(a, b, c, flags, conjB)
				public static void mulSpectrums (Mat a, Mat b, Mat c, int flags, bool conjB)
				{
						if (a != null)
								a.ThrowIfDisposed ();
						if (b != null)
								b.ThrowIfDisposed ();
						if (c != null)
								c.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_mulSpectrums_10 (a.nativeObj, b.nativeObj, c.nativeObj, flags, conjB);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: mulSpectrums(a, b, c, flags)
				public static void mulSpectrums (Mat a, Mat b, Mat c, int flags)
				{
						if (a != null)
								a.ThrowIfDisposed ();
						if (b != null)
								b.ThrowIfDisposed ();
						if (c != null)
								c.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_mulSpectrums_11 (a.nativeObj, b.nativeObj, c.nativeObj, flags);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void max(Mat src1, Scalar src2, Mat& dst)
				//
	
				//javadoc: max(src1, src2, dst)
				public static void max (Mat src1, Scalar src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_max_10 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void min(Mat src1, Scalar src2, Mat& dst)
				//
	
				//javadoc: min(src1, src2, dst)
				public static void min (Mat src1, Scalar src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_min_10 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int borderInterpolate(int p, int len, int borderType)
				//
	
				//javadoc: borderInterpolate(p, len, borderType)
				public static int borderInterpolate (int p, int len, int borderType)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						int retVal = core_Core_borderInterpolate_10 (p, len, borderType);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void copyMakeBorder(Mat src, Mat& dst, int top, int bottom, int left, int right, int borderType, Scalar value = Scalar())
				//
	
				//javadoc: copyMakeBorder(src, dst, top, bottom, left, right, borderType, value)
				public static void copyMakeBorder (Mat src, Mat dst, int top, int bottom, int left, int right, int borderType, Scalar value)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_copyMakeBorder_10 (src.nativeObj, dst.nativeObj, top, bottom, left, right, borderType, value.val [0], value.val [1], value.val [2], value.val [3]);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: copyMakeBorder(src, dst, top, bottom, left, right, borderType)
				public static void copyMakeBorder (Mat src, Mat dst, int top, int bottom, int left, int right, int borderType)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_copyMakeBorder_11 (src.nativeObj, dst.nativeObj, top, bottom, left, right, borderType);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void add(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
				//
	
				//javadoc: add(src1, src2, dst, mask, dtype)
				public static void add (Mat src1, Mat src2, Mat dst, Mat mask, int dtype)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_add_10 (src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: add(src1, src2, dst, mask)
				public static void add (Mat src1, Mat src2, Mat dst, Mat mask)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_add_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: add(src1, src2, dst)
				public static void add (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_add_12 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void subtract(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
				//
	
				//javadoc: subtract(src1, src2, dst, mask, dtype)
				public static void subtract (Mat src1, Mat src2, Mat dst, Mat mask, int dtype)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_subtract_10 (src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: subtract(src1, src2, dst, mask)
				public static void subtract (Mat src1, Mat src2, Mat dst, Mat mask)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_subtract_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: subtract(src1, src2, dst)
				public static void subtract (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_subtract_12 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void multiply(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
				//
	
				//javadoc: multiply(src1, src2, dst, scale, dtype)
				public static void multiply (Mat src1, Mat src2, Mat dst, double scale, int dtype)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_multiply_10 (src1.nativeObj, src2.nativeObj, dst.nativeObj, scale, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: multiply(src1, src2, dst, scale)
				public static void multiply (Mat src1, Mat src2, Mat dst, double scale)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_multiply_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj, scale);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: multiply(src1, src2, dst)
				public static void multiply (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_multiply_12 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void divide(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
				//
	
				//javadoc: divide(src1, src2, dst, scale, dtype)
				public static void divide (Mat src1, Mat src2, Mat dst, double scale, int dtype)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_divide_10 (src1.nativeObj, src2.nativeObj, dst.nativeObj, scale, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: divide(src1, src2, dst, scale)
				public static void divide (Mat src1, Mat src2, Mat dst, double scale)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_divide_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj, scale);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: divide(src1, src2, dst)
				public static void divide (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_divide_12 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void exp(Mat src, Mat& dst)
				//
	
				//javadoc: exp(src, dst)
				public static void exp (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_exp_10 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void log(Mat src, Mat& dst)
				//
	
				//javadoc: log(src, dst)
				public static void log (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_log_10 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void polarToCart(Mat magnitude, Mat angle, Mat& x, Mat& y, bool angleInDegrees = false)
				//
	
				//javadoc: polarToCart(magnitude, angle, x, y, angleInDegrees)
				public static void polarToCart (Mat magnitude, Mat angle, Mat x, Mat y, bool angleInDegrees)
				{
						if (magnitude != null)
								magnitude.ThrowIfDisposed ();
						if (angle != null)
								angle.ThrowIfDisposed ();
						if (x != null)
								x.ThrowIfDisposed ();
						if (y != null)
								y.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_polarToCart_10 (magnitude.nativeObj, angle.nativeObj, x.nativeObj, y.nativeObj, angleInDegrees);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: polarToCart(magnitude, angle, x, y)
				public static void polarToCart (Mat magnitude, Mat angle, Mat x, Mat y)
				{
						if (magnitude != null)
								magnitude.ThrowIfDisposed ();
						if (angle != null)
								angle.ThrowIfDisposed ();
						if (x != null)
								x.ThrowIfDisposed ();
						if (y != null)
								y.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_polarToCart_11 (magnitude.nativeObj, angle.nativeObj, x.nativeObj, y.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void cartToPolar(Mat x, Mat y, Mat& magnitude, Mat& angle, bool angleInDegrees = false)
				//
	
				//javadoc: cartToPolar(x, y, magnitude, angle, angleInDegrees)
				public static void cartToPolar (Mat x, Mat y, Mat magnitude, Mat angle, bool angleInDegrees)
				{
						if (x != null)
								x.ThrowIfDisposed ();
						if (y != null)
								y.ThrowIfDisposed ();
						if (magnitude != null)
								magnitude.ThrowIfDisposed ();
						if (angle != null)
								angle.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_cartToPolar_10 (x.nativeObj, y.nativeObj, magnitude.nativeObj, angle.nativeObj, angleInDegrees);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: cartToPolar(x, y, magnitude, angle)
				public static void cartToPolar (Mat x, Mat y, Mat magnitude, Mat angle)
				{
						if (x != null)
								x.ThrowIfDisposed ();
						if (y != null)
								y.ThrowIfDisposed ();
						if (magnitude != null)
								magnitude.ThrowIfDisposed ();
						if (angle != null)
								angle.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_cartToPolar_11 (x.nativeObj, y.nativeObj, magnitude.nativeObj, angle.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void phase(Mat x, Mat y, Mat& angle, bool angleInDegrees = false)
				//
	
				//javadoc: phase(x, y, angle, angleInDegrees)
				public static void phase (Mat x, Mat y, Mat angle, bool angleInDegrees)
				{
						if (x != null)
								x.ThrowIfDisposed ();
						if (y != null)
								y.ThrowIfDisposed ();
						if (angle != null)
								angle.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_phase_10 (x.nativeObj, y.nativeObj, angle.nativeObj, angleInDegrees);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: phase(x, y, angle)
				public static void phase (Mat x, Mat y, Mat angle)
				{
						if (x != null)
								x.ThrowIfDisposed ();
						if (y != null)
								y.ThrowIfDisposed ();
						if (angle != null)
								angle.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_phase_11 (x.nativeObj, y.nativeObj, angle.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void magnitude(Mat x, Mat y, Mat& magnitude)
				//
	
				//javadoc: magnitude(x, y, magnitude)
				public static void magnitude (Mat x, Mat y, Mat magnitude)
				{
						if (x != null)
								x.ThrowIfDisposed ();
						if (y != null)
								y.ThrowIfDisposed ();
						if (magnitude != null)
								magnitude.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_magnitude_10 (x.nativeObj, y.nativeObj, magnitude.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  bool checkRange(Mat a, bool quiet = true,  _hidden_ * pos = 0, double minVal = -DBL_MAX, double maxVal = DBL_MAX)
				//
	
				//javadoc: checkRange(a, quiet, minVal, maxVal)
				public static bool checkRange (Mat a, bool quiet, double minVal, double maxVal)
				{
						if (a != null)
								a.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = core_Core_checkRange_10 (a.nativeObj, quiet, minVal, maxVal);
		
						return retVal;
#else
return false;
#endif
				}
	
				//javadoc: checkRange(a)
				public static bool checkRange (Mat a)
				{
						if (a != null)
								a.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = core_Core_checkRange_11 (a.nativeObj);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  void patchNaNs(Mat& a, double val = 0)
				//
	
				//javadoc: patchNaNs(a, val)
				public static void patchNaNs (Mat a, double val)
				{
						if (a != null)
								a.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_patchNaNs_10 (a.nativeObj, val);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: patchNaNs(a)
				public static void patchNaNs (Mat a)
				{
						if (a != null)
								a.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_patchNaNs_11 (a.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void gemm(Mat src1, Mat src2, double alpha, Mat src3, double beta, Mat& dst, int flags = 0)
				//
	
				//javadoc: gemm(src1, src2, alpha, src3, beta, dst, flags)
				public static void gemm (Mat src1, Mat src2, double alpha, Mat src3, double beta, Mat dst, int flags)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (src3 != null)
								src3.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_gemm_10 (src1.nativeObj, src2.nativeObj, alpha, src3.nativeObj, beta, dst.nativeObj, flags);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: gemm(src1, src2, alpha, src3, beta, dst)
				public static void gemm (Mat src1, Mat src2, double alpha, Mat src3, double beta, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (src3 != null)
								src3.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_gemm_11 (src1.nativeObj, src2.nativeObj, alpha, src3.nativeObj, beta, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void mulTransposed(Mat src, Mat& dst, bool aTa, Mat delta = Mat(), double scale = 1, int dtype = -1)
				//
	
				//javadoc: mulTransposed(src, dst, aTa, delta, scale, dtype)
				public static void mulTransposed (Mat src, Mat dst, bool aTa, Mat delta, double scale, int dtype)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (delta != null)
								delta.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_mulTransposed_10 (src.nativeObj, dst.nativeObj, aTa, delta.nativeObj, scale, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: mulTransposed(src, dst, aTa, delta, scale)
				public static void mulTransposed (Mat src, Mat dst, bool aTa, Mat delta, double scale)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (delta != null)
								delta.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_mulTransposed_11 (src.nativeObj, dst.nativeObj, aTa, delta.nativeObj, scale);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: mulTransposed(src, dst, aTa)
				public static void mulTransposed (Mat src, Mat dst, bool aTa)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_mulTransposed_12 (src.nativeObj, dst.nativeObj, aTa);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void transpose(Mat src, Mat& dst)
				//
	
				//javadoc: transpose(src, dst)
				public static void transpose (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_transpose_10 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void transform(Mat src, Mat& dst, Mat m)
				//
	
				//javadoc: transform(src, dst, m)
				public static void transform (Mat src, Mat dst, Mat m)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (m != null)
								m.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_transform_10 (src.nativeObj, dst.nativeObj, m.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void perspectiveTransform(Mat src, Mat& dst, Mat m)
				//
	
				//javadoc: perspectiveTransform(src, dst, m)
				public static void perspectiveTransform (Mat src, Mat dst, Mat m)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (m != null)
								m.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_perspectiveTransform_10 (src.nativeObj, dst.nativeObj, m.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void completeSymm(Mat& mtx, bool lowerToUpper = false)
				//
	
				//javadoc: completeSymm(mtx, lowerToUpper)
				public static void completeSymm (Mat mtx, bool lowerToUpper)
				{
						if (mtx != null)
								mtx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_completeSymm_10 (mtx.nativeObj, lowerToUpper);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: completeSymm(mtx)
				public static void completeSymm (Mat mtx)
				{
						if (mtx != null)
								mtx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_completeSymm_11 (mtx.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void setIdentity(Mat& mtx, Scalar s = Scalar(1))
				//
	
				//javadoc: setIdentity(mtx, s)
				public static void setIdentity (Mat mtx, Scalar s)
				{
						if (mtx != null)
								mtx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_setIdentity_10 (mtx.nativeObj, s.val [0], s.val [1], s.val [2], s.val [3]);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: setIdentity(mtx)
				public static void setIdentity (Mat mtx)
				{
						if (mtx != null)
								mtx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_setIdentity_11 (mtx.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  double determinant(Mat mtx)
				//
	
				//javadoc: determinant(mtx)
				public static double determinant (Mat mtx)
				{
						if (mtx != null)
								mtx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_determinant_10 (mtx.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  Scalar trace(Mat mtx)
				//
	
				//javadoc: trace(mtx)
				public static Scalar trace (Mat mtx)
				{
						if (mtx != null)
								mtx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double[] tmpArray = new double[4];
						core_Core_trace_10 (mtx.nativeObj, tmpArray);
						Scalar retVal = new Scalar (tmpArray);
		
						return retVal;
#else
return null;
#endif
				}
	
	
				//
				// C++:  double invert(Mat src, Mat& dst, int flags = DECOMP_LU)
				//
	
				//javadoc: invert(src, dst, flags)
				public static double invert (Mat src, Mat dst, int flags)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_invert_10 (src.nativeObj, dst.nativeObj, flags);
		
						return retVal;
#else
return -1;
#endif
				}
	
				//javadoc: invert(src, dst)
				public static double invert (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_invert_11 (src.nativeObj, dst.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  bool solve(Mat src1, Mat src2, Mat& dst, int flags = DECOMP_LU)
				//
	
				//javadoc: solve(src1, src2, dst, flags)
				public static bool solve (Mat src1, Mat src2, Mat dst, int flags)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = core_Core_solve_10 (src1.nativeObj, src2.nativeObj, dst.nativeObj, flags);
		
						return retVal;
#else
return false;
#endif
				}
	
				//javadoc: solve(src1, src2, dst)
				public static bool solve (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = core_Core_solve_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  void sort(Mat src, Mat& dst, int flags)
				//
	
				//javadoc: sort(src, dst, flags)
				public static void sort (Mat src, Mat dst, int flags)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_sort_10 (src.nativeObj, dst.nativeObj, flags);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void sortIdx(Mat src, Mat& dst, int flags)
				//
	
				//javadoc: sortIdx(src, dst, flags)
				public static void sortIdx (Mat src, Mat dst, int flags)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_sortIdx_10 (src.nativeObj, dst.nativeObj, flags);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int solveCubic(Mat coeffs, Mat& roots)
				//
	
				//javadoc: solveCubic(coeffs, roots)
				public static int solveCubic (Mat coeffs, Mat roots)
				{
						if (coeffs != null)
								coeffs.ThrowIfDisposed ();
						if (roots != null)
								roots.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						int retVal = core_Core_solveCubic_10 (coeffs.nativeObj, roots.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  double solvePoly(Mat coeffs, Mat& roots, int maxIters = 300)
				//
	
				//javadoc: solvePoly(coeffs, roots, maxIters)
				public static double solvePoly (Mat coeffs, Mat roots, int maxIters)
				{
						if (coeffs != null)
								coeffs.ThrowIfDisposed ();
						if (roots != null)
								roots.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_solvePoly_10 (coeffs.nativeObj, roots.nativeObj, maxIters);
		
						return retVal;
#else
return -1;
#endif
				}
	
				//javadoc: solvePoly(coeffs, roots)
				public static double solvePoly (Mat coeffs, Mat roots)
				{
						if (coeffs != null)
								coeffs.ThrowIfDisposed ();
						if (roots != null)
								roots.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_solvePoly_11 (coeffs.nativeObj, roots.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  bool eigen(Mat src, Mat& eigenvalues, Mat& eigenvectors = Mat())
				//
	
				//javadoc: eigen(src, eigenvalues, eigenvectors)
				public static bool eigen (Mat src, Mat eigenvalues, Mat eigenvectors)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (eigenvalues != null)
								eigenvalues.ThrowIfDisposed ();
						if (eigenvectors != null)
								eigenvectors.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = core_Core_eigen_10 (src.nativeObj, eigenvalues.nativeObj, eigenvectors.nativeObj);
		
						return retVal;
#else
return false;
#endif
				}
	
				//javadoc: eigen(src, eigenvalues)
				public static bool eigen (Mat src, Mat eigenvalues)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (eigenvalues != null)
								eigenvalues.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = core_Core_eigen_11 (src.nativeObj, eigenvalues.nativeObj);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  void calcCovarMatrix(Mat samples, Mat& covar, Mat& mean, int flags, int ctype = CV_64F)
				//
	
				//javadoc: calcCovarMatrix(samples, covar, mean, flags, ctype)
				public static void calcCovarMatrix (Mat samples, Mat covar, Mat mean, int flags, int ctype)
				{
						if (samples != null)
								samples.ThrowIfDisposed ();
						if (covar != null)
								covar.ThrowIfDisposed ();
						if (mean != null)
								mean.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_calcCovarMatrix_10 (samples.nativeObj, covar.nativeObj, mean.nativeObj, flags, ctype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: calcCovarMatrix(samples, covar, mean, flags)
				public static void calcCovarMatrix (Mat samples, Mat covar, Mat mean, int flags)
				{
						if (samples != null)
								samples.ThrowIfDisposed ();
						if (covar != null)
								covar.ThrowIfDisposed ();
						if (mean != null)
								mean.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_calcCovarMatrix_11 (samples.nativeObj, covar.nativeObj, mean.nativeObj, flags);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void PCACompute(Mat data, Mat& mean, Mat& eigenvectors, int maxComponents = 0)
				//
	
				//javadoc: PCACompute(data, mean, eigenvectors, maxComponents)
				public static void PCACompute (Mat data, Mat mean, Mat eigenvectors, int maxComponents)
				{
						if (data != null)
								data.ThrowIfDisposed ();
						if (mean != null)
								mean.ThrowIfDisposed ();
						if (eigenvectors != null)
								eigenvectors.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_PCACompute_11 (data.nativeObj, mean.nativeObj, eigenvectors.nativeObj, maxComponents);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: PCACompute(data, mean, eigenvectors)
				public static void PCACompute (Mat data, Mat mean, Mat eigenvectors)
				{
						if (data != null)
								data.ThrowIfDisposed ();
						if (mean != null)
								mean.ThrowIfDisposed ();
						if (eigenvectors != null)
								eigenvectors.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_PCACompute_12 (data.nativeObj, mean.nativeObj, eigenvectors.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int getOptimalDFTSize(int vecsize)
				//
	
				//javadoc: getOptimalDFTSize(vecsize)
				public static int getOptimalDFTSize (int vecsize)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						int retVal = core_Core_getOptimalDFTSize_10 (vecsize);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void randu(Mat& dst, double low, double high)
				//
	
				//javadoc: randu(dst, low, high)
				public static void randu (Mat dst, double low, double high)
				{
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_randu_10 (dst.nativeObj, low, high);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void randn(Mat& dst, double mean, double stddev)
				//
	
				//javadoc: randn(dst, mean, stddev)
				public static void randn (Mat dst, double mean, double stddev)
				{
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_randn_10 (dst.nativeObj, mean, stddev);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void randShuffle(Mat& dst, double iterFactor = 1., RNG* rng = 0)
				//
	
				//javadoc: randShuffle(dst, iterFactor)
				public static void randShuffle (Mat dst, double iterFactor)
				{
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_randShuffle_10 (dst.nativeObj, iterFactor);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: randShuffle(dst)
				public static void randShuffle (Mat dst)
				{
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_randShuffle_11 (dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  double kmeans(Mat data, int K, Mat& bestLabels, TermCriteria criteria, int attempts, int flags, Mat& centers = Mat())
				//
	
				//javadoc: kmeans(data, K, bestLabels, criteria, attempts, flags, centers)
				public static double kmeans (Mat data, int K, Mat bestLabels, TermCriteria criteria, int attempts, int flags, Mat centers)
				{
						if (data != null)
								data.ThrowIfDisposed ();
						if (bestLabels != null)
								bestLabels.ThrowIfDisposed ();
						if (centers != null)
								centers.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_kmeans_10 (data.nativeObj, K, bestLabels.nativeObj, criteria.type, criteria.maxCount, criteria.epsilon, attempts, flags, centers.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
				//javadoc: kmeans(data, K, bestLabels, criteria, attempts, flags)
				public static double kmeans (Mat data, int K, Mat bestLabels, TermCriteria criteria, int attempts, int flags)
				{
						if (data != null)
								data.ThrowIfDisposed ();
						if (bestLabels != null)
								bestLabels.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_kmeans_11 (data.nativeObj, K, bestLabels.nativeObj, criteria.type, criteria.maxCount, criteria.epsilon, attempts, flags);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void scaleAdd(Mat src1, double alpha, Mat src2, Mat& dst)
				//
	
				//javadoc: scaleAdd(src1, alpha, src2, dst)
				public static void scaleAdd (Mat src1, double alpha, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_scaleAdd_10 (src1.nativeObj, alpha, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void divide(double scale, Mat src2, Mat& dst, int dtype = -1)
				//
	
				//javadoc: divide(scale, src2, dst, dtype)
				public static void divide (double scale, Mat src2, Mat dst, int dtype)
				{
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_divide_13 (scale, src2.nativeObj, dst.nativeObj, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: divide(scale, src2, dst)
				public static void divide (double scale, Mat src2, Mat dst)
				{
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_divide_14 (scale, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void addWeighted(Mat src1, double alpha, Mat src2, double beta, double gamma, Mat& dst, int dtype = -1)
				//
	
				//javadoc: addWeighted(src1, alpha, src2, beta, gamma, dst, dtype)
				public static void addWeighted (Mat src1, double alpha, Mat src2, double beta, double gamma, Mat dst, int dtype)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_addWeighted_10 (src1.nativeObj, alpha, src2.nativeObj, beta, gamma, dst.nativeObj, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: addWeighted(src1, alpha, src2, beta, gamma, dst)
				public static void addWeighted (Mat src1, double alpha, Mat src2, double beta, double gamma, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_addWeighted_11 (src1.nativeObj, alpha, src2.nativeObj, beta, gamma, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void convertScaleAbs(Mat src, Mat& dst, double alpha = 1, double beta = 0)
				//
	
				//javadoc: convertScaleAbs(src, dst, alpha, beta)
				public static void convertScaleAbs (Mat src, Mat dst, double alpha, double beta)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_convertScaleAbs_10 (src.nativeObj, dst.nativeObj, alpha, beta);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: convertScaleAbs(src, dst)
				public static void convertScaleAbs (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_convertScaleAbs_11 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void LUT(Mat src, Mat lut, Mat& dst)
				//
	
				//javadoc: LUT(src, lut, dst)
				public static void LUT (Mat src, Mat lut, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (lut != null)
								lut.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_LUT_10 (src.nativeObj, lut.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  Scalar sum(Mat src)
				//
	
				//javadoc: sum(src)
				public static Scalar sumElems (Mat src)
				{
						if (src != null)
								src.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double[] tmpArray = new double[4];
						core_Core_sumElems_10 (src.nativeObj, tmpArray);
						Scalar retVal = new Scalar (tmpArray);
		
						return retVal;
#else
return null;
#endif
				}
	
	
				//
				// C++:  void findNonZero(Mat src, Mat& idx)
				//
	
				//javadoc: findNonZero(src, idx)
				public static void findNonZero (Mat src, Mat idx)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (idx != null)
								idx.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_findNonZero_10 (src.nativeObj, idx.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int countNonZero(Mat src)
				//
	
				//javadoc: countNonZero(src)
				public static int countNonZero (Mat src)
				{
						if (src != null)
								src.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						int retVal = core_Core_countNonZero_10 (src.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  Scalar mean(Mat src, Mat mask = Mat())
				//
	
				//javadoc: mean(src, mask)
				public static Scalar mean (Mat src, Mat mask)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double[] tmpArray = new double[4];
						core_Core_mean_10 (src.nativeObj, mask.nativeObj, tmpArray);
						Scalar retVal = new Scalar (tmpArray);
		
						return retVal;
#else
return null;
#endif
				}
	
				//javadoc: mean(src)
				public static Scalar mean (Mat src)
				{
						if (src != null)
								src.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double[] tmpArray = new double[4];
						core_Core_mean_11 (src.nativeObj, tmpArray);
						Scalar retVal = new Scalar (tmpArray);
		
						return retVal;
#else
return null;
#endif
				}
	
	
				//
				// C++:  void meanStdDev(Mat src, vector_double& mean, vector_double& stddev, Mat mask = Mat())
				//
	
				//javadoc: meanStdDev(src, mean, stddev, mask)
				public static void meanStdDev (Mat src, MatOfDouble mean, MatOfDouble stddev, Mat mask)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (mean != null)
								mean.ThrowIfDisposed ();
						if (stddev != null)
								stddev.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						Mat mean_mat = mean;
						Mat stddev_mat = stddev;
						core_Core_meanStdDev_10 (src.nativeObj, mean_mat.nativeObj, stddev_mat.nativeObj, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: meanStdDev(src, mean, stddev)
				public static void meanStdDev (Mat src, MatOfDouble mean, MatOfDouble stddev)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (mean != null)
								mean.ThrowIfDisposed ();
						if (stddev != null)
								stddev.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						Mat mean_mat = mean;
						Mat stddev_mat = stddev;
						core_Core_meanStdDev_11 (src.nativeObj, mean_mat.nativeObj, stddev_mat.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  double norm(Mat src1, int normType = NORM_L2, Mat mask = Mat())
				//
	
				//javadoc: norm(src1, normType, mask)
				public static double norm (Mat src1, int normType, Mat mask)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_norm_10 (src1.nativeObj, normType, mask.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
				//javadoc: norm(src1, normType)
				public static double norm (Mat src1, int normType)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_norm_11 (src1.nativeObj, normType);
		
						return retVal;
#else
return -1;
#endif
				}
	
				//javadoc: norm(src1)
				public static double norm (Mat src1)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_norm_12 (src1.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  double norm(Mat src1, Mat src2, int normType = NORM_L2, Mat mask = Mat())
				//
	
				//javadoc: norm(src1, src2, normType, mask)
				public static double norm (Mat src1, Mat src2, int normType, Mat mask)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_norm_13 (src1.nativeObj, src2.nativeObj, normType, mask.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
				//javadoc: norm(src1, src2, normType)
				public static double norm (Mat src1, Mat src2, int normType)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_norm_14 (src1.nativeObj, src2.nativeObj, normType);
		
						return retVal;
#else
return -1;
#endif
				}
	
				//javadoc: norm(src1, src2)
				public static double norm (Mat src1, Mat src2)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_norm_15 (src1.nativeObj, src2.nativeObj);
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void normalize(Mat src, Mat& dst, double alpha = 1, double beta = 0, int norm_type = NORM_L2, int dtype = -1, Mat mask = Mat())
				//
	
				//javadoc: normalize(src, dst, alpha, beta, norm_type, dtype, mask)
				public static void normalize (Mat src, Mat dst, double alpha, double beta, int norm_type, int dtype, Mat mask)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_normalize_10 (src.nativeObj, dst.nativeObj, alpha, beta, norm_type, dtype, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: normalize(src, dst, alpha, beta, norm_type, dtype)
				public static void normalize (Mat src, Mat dst, double alpha, double beta, int norm_type, int dtype)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_normalize_11 (src.nativeObj, dst.nativeObj, alpha, beta, norm_type, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: normalize(src, dst, alpha, beta, norm_type)
				public static void normalize (Mat src, Mat dst, double alpha, double beta, int norm_type)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_normalize_12 (src.nativeObj, dst.nativeObj, alpha, beta, norm_type);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: normalize(src, dst)
				public static void normalize (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_normalize_13 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void setErrorVerbosity(bool verbose)
				//
	
				//javadoc: setErrorVerbosity(verbose)
				public static void setErrorVerbosity (bool verbose)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_setErrorVerbosity_10 (verbose);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void reduce(Mat src, Mat& dst, int dim, int rtype, int dtype = -1)
				//
	
				//javadoc: reduce(src, dst, dim, rtype, dtype)
				public static void reduce (Mat src, Mat dst, int dim, int rtype, int dtype)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_reduce_10 (src.nativeObj, dst.nativeObj, dim, rtype, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: reduce(src, dst, dim, rtype)
				public static void reduce (Mat src, Mat dst, int dim, int rtype)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_reduce_11 (src.nativeObj, dst.nativeObj, dim, rtype);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void merge(vector_Mat mv, Mat& dst)
				//
	
				//javadoc: merge(mv, dst)
				public static void merge (List<Mat> mv, Mat dst)
				{
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						Mat mv_mat = Converters.vector_Mat_to_Mat (mv);
						core_Core_merge_10 (mv_mat.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void split(Mat m, vector_Mat& mv)
				//
	
				//javadoc: split(m, mv)
				public static void split (Mat m, List<Mat> mv)
				{
						if (m != null)
								m.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						Mat mv_mat = new Mat ();
						core_Core_split_10 (m.nativeObj, mv_mat.nativeObj);
						Converters.Mat_to_vector_Mat (mv_mat, mv);
						mv_mat.release ();
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void mixChannels(vector_Mat src, vector_Mat dst, vector_int fromTo)
				//
	
				//javadoc: mixChannels(src, dst, fromTo)
				public static void mixChannels (List<Mat> src, List<Mat> dst, MatOfInt fromTo)
				{
						if (fromTo != null)
								fromTo.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						Mat src_mat = Converters.vector_Mat_to_Mat (src);
						Mat dst_mat = Converters.vector_Mat_to_Mat (dst);
						Mat fromTo_mat = fromTo;
						core_Core_mixChannels_10 (src_mat.nativeObj, dst_mat.nativeObj, fromTo_mat.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void extractChannel(Mat src, Mat& dst, int coi)
				//
	
				//javadoc: extractChannel(src, dst, coi)
				public static void extractChannel (Mat src, Mat dst, int coi)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_extractChannel_10 (src.nativeObj, dst.nativeObj, coi);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void add(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
				//
	
				//javadoc: add(src1, src2, dst, mask, dtype)
				public static void add (Mat src1, Scalar src2, Mat dst, Mat mask, int dtype)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_add_13 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj, mask.nativeObj, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: add(src1, src2, dst, mask)
				public static void add (Mat src1, Scalar src2, Mat dst, Mat mask)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_add_14 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: add(src1, src2, dst)
				public static void add (Mat src1, Scalar src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_add_15 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  int getNumberOfCPUs()
				//
	
				//javadoc: getNumberOfCPUs()
				public static int getNumberOfCPUs ()
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						int retVal = core_Core_getNumberOfCPUs_10 ();
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void subtract(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
				//
	
				//javadoc: subtract(src1, src2, dst, mask, dtype)
				public static void subtract (Mat src1, Scalar src2, Mat dst, Mat mask, int dtype)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_subtract_13 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj, mask.nativeObj, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: subtract(src1, src2, dst, mask)
				public static void subtract (Mat src1, Scalar src2, Mat dst, Mat mask)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_subtract_14 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: subtract(src1, src2, dst)
				public static void subtract (Mat src1, Scalar src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_subtract_15 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void multiply(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
				//
	
				//javadoc: multiply(src1, src2, dst, scale, dtype)
				public static void multiply (Mat src1, Scalar src2, Mat dst, double scale, int dtype)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_multiply_13 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj, scale, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: multiply(src1, src2, dst, scale)
				public static void multiply (Mat src1, Scalar src2, Mat dst, double scale)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_multiply_14 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj, scale);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: multiply(src1, src2, dst)
				public static void multiply (Mat src1, Scalar src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_multiply_15 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void divide(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
				//
	
				//javadoc: divide(src1, src2, dst, scale, dtype)
				public static void divide (Mat src1, Scalar src2, Mat dst, double scale, int dtype)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_divide_15 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj, scale, dtype);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: divide(src1, src2, dst, scale)
				public static void divide (Mat src1, Scalar src2, Mat dst, double scale)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_divide_16 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj, scale);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: divide(src1, src2, dst)
				public static void divide (Mat src1, Scalar src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_divide_17 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void compare(Mat src1, Scalar src2, Mat& dst, int cmpop)
				//
	
				//javadoc: compare(src1, src2, dst, cmpop)
				public static void compare (Mat src1, Scalar src2, Mat dst, int cmpop)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_compare_10 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj, cmpop);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void absdiff(Mat src1, Scalar src2, Mat& dst)
				//
	
				//javadoc: absdiff(src1, src2, dst)
				public static void absdiff (Mat src1, Scalar src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_absdiff_10 (src1.nativeObj, src2.val [0], src2.val [1], src2.val [2], src2.val [3], dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  String getBuildInformation()
				//
	
				//javadoc: getBuildInformation()
				public static string getBuildInformation ()
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						string retVal = Marshal.PtrToStringAnsi (core_Core_getBuildInformation_10 ());
		
						return retVal;
#else
return null;
#endif
				}
	
	
				//
				// C++:  double getTickFrequency()
				//
	
				//javadoc: getTickFrequency()
				public static double getTickFrequency ()
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = core_Core_getTickFrequency_10 ();
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  int64 getTickCount()
				//
	
				//javadoc: getTickCount()
				public static long getTickCount ()
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						long retVal = core_Core_getTickCount_10 ();
		
						return retVal;
#else
return -1;
#endif
				}
	
	
				//
				// C++:  void hconcat(vector_Mat src, Mat& dst)
				//
	
				//javadoc: hconcat(src, dst)
				public static void hconcat (List<Mat> src, Mat dst)
				{
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						Mat src_mat = Converters.vector_Mat_to_Mat (src);
						core_Core_hconcat_10 (src_mat.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void vconcat(vector_Mat src, Mat& dst)
				//
	
				//javadoc: vconcat(src, dst)
				public static void vconcat (List<Mat> src, Mat dst)
				{
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						Mat src_mat = Converters.vector_Mat_to_Mat (src);
						core_Core_vconcat_10 (src_mat.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void bitwise_and(Mat src1, Mat src2, Mat& dst, Mat mask = Mat())
				//
	
				//javadoc: bitwise_and(src1, src2, dst, mask)
				public static void bitwise_and (Mat src1, Mat src2, Mat dst, Mat mask)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_bitwise_1and_10 (src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: bitwise_and(src1, src2, dst)
				public static void bitwise_and (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_bitwise_1and_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void bitwise_or(Mat src1, Mat src2, Mat& dst, Mat mask = Mat())
				//
	
				//javadoc: bitwise_or(src1, src2, dst, mask)
				public static void bitwise_or (Mat src1, Mat src2, Mat dst, Mat mask)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_bitwise_1or_10 (src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: bitwise_or(src1, src2, dst)
				public static void bitwise_or (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_bitwise_1or_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void bitwise_xor(Mat src1, Mat src2, Mat& dst, Mat mask = Mat())
				//
	
				//javadoc: bitwise_xor(src1, src2, dst, mask)
				public static void bitwise_xor (Mat src1, Mat src2, Mat dst, Mat mask)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_bitwise_1xor_10 (src1.nativeObj, src2.nativeObj, dst.nativeObj, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: bitwise_xor(src1, src2, dst)
				public static void bitwise_xor (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_bitwise_1xor_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void bitwise_not(Mat src, Mat& dst, Mat mask = Mat())
				//
	
				//javadoc: bitwise_not(src, dst, mask)
				public static void bitwise_not (Mat src, Mat dst, Mat mask)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_bitwise_1not_10 (src.nativeObj, dst.nativeObj, mask.nativeObj);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: bitwise_not(src, dst)
				public static void bitwise_not (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_bitwise_1not_11 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void absdiff(Mat src1, Mat src2, Mat& dst)
				//
	
				//javadoc: absdiff(src1, src2, dst)
				public static void absdiff (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_absdiff_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void inRange(Mat src, Scalar lowerb, Scalar upperb, Mat& dst)
				//
	
				//javadoc: inRange(src, lowerb, upperb, dst)
				public static void inRange (Mat src, Scalar lowerb, Scalar upperb, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_inRange_10 (src.nativeObj, lowerb.val [0], lowerb.val [1], lowerb.val [2], lowerb.val [3], upperb.val [0], upperb.val [1], upperb.val [2], upperb.val [3], dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void compare(Mat src1, Mat src2, Mat& dst, int cmpop)
				//
	
				//javadoc: compare(src1, src2, dst, cmpop)
				public static void compare (Mat src1, Mat src2, Mat dst, int cmpop)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_compare_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj, cmpop);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void min(Mat src1, Mat src2, Mat& dst)
				//
	
				//javadoc: min(src1, src2, dst)
				public static void min (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_min_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void max(Mat src1, Mat src2, Mat& dst)
				//
	
				//javadoc: max(src1, src2, dst)
				public static void max (Mat src1, Mat src2, Mat dst)
				{
						if (src1 != null)
								src1.ThrowIfDisposed ();
						if (src2 != null)
								src2.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_max_11 (src1.nativeObj, src2.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void sqrt(Mat src, Mat& dst)
				//
	
				//javadoc: sqrt(src, dst)
				public static void sqrt (Mat src, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_sqrt_10 (src.nativeObj, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void pow(Mat src, double power, Mat& dst)
				//
	
				//javadoc: pow(src, power, dst)
				public static void pow (Mat src, double power, Mat dst)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (dst != null)
								dst.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						core_Core_pow_10 (src.nativeObj, power, dst.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				// manual port
				public /*static*/ class MinMaxLocResult
				{
						public double minVal;
						public double maxVal;
						public Point minLoc;
						public Point maxLoc;
		
						public MinMaxLocResult ()
						{
								minVal = 0;
								maxVal = 0;
								minLoc = new Point ();
								maxLoc = new Point ();
						}
				}
	
				// C++: minMaxLoc(Mat src, double* minVal, double* maxVal=0, Point* minLoc=0, Point* maxLoc=0, InputArray mask=noArray())
	
				//javadoc: minMaxLoc(src, mask)
				public static MinMaxLocResult minMaxLoc (Mat src, Mat mask)
				{
						if (src != null)
								src.ThrowIfDisposed ();
						if (mask != null)
								mask.ThrowIfDisposed ();
			
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5			

						MinMaxLocResult res = new MinMaxLocResult ();
						IntPtr maskNativeObj = IntPtr.Zero;//TODO:@check
						if (mask != null) {
								maskNativeObj = mask.nativeObj;
						}
						double[] resarr = new double[6];
						core_Core_n_1minMaxLocManual (src.nativeObj, maskNativeObj, resarr);
						res.minVal = resarr [0];
						res.maxVal = resarr [1];
						res.minLoc.x = resarr [2];
						res.minLoc.y = resarr [3];
						res.maxLoc.x = resarr [4];
						res.maxLoc.y = resarr [5];
						return res;
						#else
			return null;
						#endif
				}
	
				//javadoc: minMaxLoc(src)
				public static MinMaxLocResult minMaxLoc (Mat src)
				{
						if (src != null)
								src.ThrowIfDisposed ();
			
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5			
						return minMaxLoc (src, null);
						#else
			return null;
						#endif
				}
	
	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  double PSNR(Mat src1, Mat src2)
		[DllImport("__Internal")]
		private static extern double core_Core_PSNR_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj);
		
		// C++:  void batchDistance(Mat src1, Mat src2, Mat& dist, int dtype, Mat& nidx, int normType = NORM_L2, int K = 0, Mat mask = Mat(), int update = 0, bool crosscheck = false)
		[DllImport("__Internal")]
		private static extern void core_Core_batchDistance_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dist_nativeObj, int dtype, IntPtr nidx_nativeObj, int normType, int K, IntPtr mask_nativeObj, int update, bool crosscheck);
		
		[DllImport("__Internal")]
		private static extern void core_Core_batchDistance_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dist_nativeObj, int dtype, IntPtr nidx_nativeObj, int normType, int K);
		
		[DllImport("__Internal")]
		private static extern void core_Core_batchDistance_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dist_nativeObj, int dtype, IntPtr nidx_nativeObj);
		
		// C++:  int64 getCPUTickCount()
		[DllImport("__Internal")]
		private static extern long core_Core_getCPUTickCount_10 ();
		
		// C++:  float cubeRoot(float val)
		[DllImport("__Internal")]
		private static extern float core_Core_cubeRoot_10 (float val);
		
		// C++:  float fastAtan2(float y, float x)
		[DllImport("__Internal")]
		private static extern float core_Core_fastAtan2_10 (float y, float x);
		
		// C++:  void insertChannel(Mat src, Mat& dst, int coi)
		[DllImport("__Internal")]
		private static extern void core_Core_insertChannel_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int coi);
		
		// C++:  void flip(Mat src, Mat& dst, int flipCode)
		[DllImport("__Internal")]
		private static extern void core_Core_flip_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flipCode);
		
		// C++:  void repeat(Mat src, int ny, int nx, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_repeat_10 (IntPtr src_nativeObj, int ny, int nx, IntPtr dst_nativeObj);
		
		// C++:  void PCACompute(Mat data, Mat& mean, Mat& eigenvectors, double retainedVariance)
		[DllImport("__Internal")]
		private static extern void core_Core_PCACompute_10 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj, double retainedVariance);
		
		// C++:  void PCAProject(Mat data, Mat mean, Mat eigenvectors, Mat& result)
		[DllImport("__Internal")]
		private static extern void core_Core_PCAProject_10 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj, IntPtr result_nativeObj);
		
		// C++:  void PCABackProject(Mat data, Mat mean, Mat eigenvectors, Mat& result)
		[DllImport("__Internal")]
		private static extern void core_Core_PCABackProject_10 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj, IntPtr result_nativeObj);
		
		// C++:  void SVDecomp(Mat src, Mat& w, Mat& u, Mat& vt, int flags = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_SVDecomp_10 (IntPtr src_nativeObj, IntPtr w_nativeObj, IntPtr u_nativeObj, IntPtr vt_nativeObj, int flags);
		
		[DllImport("__Internal")]
		private static extern void core_Core_SVDecomp_11 (IntPtr src_nativeObj, IntPtr w_nativeObj, IntPtr u_nativeObj, IntPtr vt_nativeObj);
		
		// C++:  void SVBackSubst(Mat w, Mat u, Mat vt, Mat rhs, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_SVBackSubst_10 (IntPtr w_nativeObj, IntPtr u_nativeObj, IntPtr vt_nativeObj, IntPtr rhs_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  double Mahalanobis(Mat v1, Mat v2, Mat icovar)
		[DllImport("__Internal")]
		private static extern double core_Core_Mahalanobis_10 (IntPtr v1_nativeObj, IntPtr v2_nativeObj, IntPtr icovar_nativeObj);
		
		// C++:  void dft(Mat src, Mat& dst, int flags = 0, int nonzeroRows = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_dft_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags, int nonzeroRows);
		
		[DllImport("__Internal")]
		private static extern void core_Core_dft_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void idft(Mat src, Mat& dst, int flags = 0, int nonzeroRows = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_idft_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags, int nonzeroRows);
		
		[DllImport("__Internal")]
		private static extern void core_Core_idft_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void dct(Mat src, Mat& dst, int flags = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_dct_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);
		
		[DllImport("__Internal")]
		private static extern void core_Core_dct_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void idct(Mat src, Mat& dst, int flags = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_idct_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);
		
		[DllImport("__Internal")]
		private static extern void core_Core_idct_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void mulSpectrums(Mat a, Mat b, Mat& c, int flags, bool conjB = false)
		[DllImport("__Internal")]
		private static extern void core_Core_mulSpectrums_10 (IntPtr a_nativeObj, IntPtr b_nativeObj, IntPtr c_nativeObj, int flags, bool conjB);
		
		[DllImport("__Internal")]
		private static extern void core_Core_mulSpectrums_11 (IntPtr a_nativeObj, IntPtr b_nativeObj, IntPtr c_nativeObj, int flags);
		
		// C++:  void max(Mat src1, Scalar src2, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_max_10 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
		
		// C++:  void min(Mat src1, Scalar src2, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_min_10 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
		
		// C++:  int borderInterpolate(int p, int len, int borderType)
		[DllImport("__Internal")]
		private static extern int core_Core_borderInterpolate_10 (int p, int len, int borderType);
		
		// C++:  void copyMakeBorder(Mat src, Mat& dst, int top, int bottom, int left, int right, int borderType, Scalar value = Scalar())
		[DllImport("__Internal")]
		private static extern void core_Core_copyMakeBorder_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int top, int bottom, int left, int right, int borderType, double value_val0, double value_val1, double value_val2, double value_val3);
		
		[DllImport("__Internal")]
		private static extern void core_Core_copyMakeBorder_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int top, int bottom, int left, int right, int borderType);
		
		// C++:  void add(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_add_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_add_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_add_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void subtract(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_subtract_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_subtract_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_subtract_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void multiply(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_multiply_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_multiply_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale);
		
		[DllImport("__Internal")]
		private static extern void core_Core_multiply_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void divide(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_divide_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_divide_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale);
		
		[DllImport("__Internal")]
		private static extern void core_Core_divide_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void exp(Mat src, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_exp_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void log(Mat src, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_log_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void polarToCart(Mat magnitude, Mat angle, Mat& x, Mat& y, bool angleInDegrees = false)
		[DllImport("__Internal")]
		private static extern void core_Core_polarToCart_10 (IntPtr magnitude_nativeObj, IntPtr angle_nativeObj, IntPtr x_nativeObj, IntPtr y_nativeObj, bool angleInDegrees);
		
		[DllImport("__Internal")]
		private static extern void core_Core_polarToCart_11 (IntPtr magnitude_nativeObj, IntPtr angle_nativeObj, IntPtr x_nativeObj, IntPtr y_nativeObj);
		
		// C++:  void cartToPolar(Mat x, Mat y, Mat& magnitude, Mat& angle, bool angleInDegrees = false)
		[DllImport("__Internal")]
		private static extern void core_Core_cartToPolar_10 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr magnitude_nativeObj, IntPtr angle_nativeObj, bool angleInDegrees);
		
		[DllImport("__Internal")]
		private static extern void core_Core_cartToPolar_11 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr magnitude_nativeObj, IntPtr angle_nativeObj);
		
		// C++:  void phase(Mat x, Mat y, Mat& angle, bool angleInDegrees = false)
		[DllImport("__Internal")]
		private static extern void core_Core_phase_10 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr angle_nativeObj, bool angleInDegrees);
		
		[DllImport("__Internal")]
		private static extern void core_Core_phase_11 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr angle_nativeObj);
		
		// C++:  void magnitude(Mat x, Mat y, Mat& magnitude)
		[DllImport("__Internal")]
		private static extern void core_Core_magnitude_10 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr magnitude_nativeObj);
		
		// C++:  bool checkRange(Mat a, bool quiet = true,  _hidden_ * pos = 0, double minVal = -DBL_MAX, double maxVal = DBL_MAX)
		[DllImport("__Internal")]
		private static extern bool core_Core_checkRange_10 (IntPtr a_nativeObj, bool quiet, double minVal, double maxVal);
		
		[DllImport("__Internal")]
		private static extern bool core_Core_checkRange_11 (IntPtr a_nativeObj);
		
		// C++:  void patchNaNs(Mat& a, double val = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_patchNaNs_10 (IntPtr a_nativeObj, double val);
		
		[DllImport("__Internal")]
		private static extern void core_Core_patchNaNs_11 (IntPtr a_nativeObj);
		
		// C++:  void gemm(Mat src1, Mat src2, double alpha, Mat src3, double beta, Mat& dst, int flags = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_gemm_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, double alpha, IntPtr src3_nativeObj, double beta, IntPtr dst_nativeObj, int flags);
		
		[DllImport("__Internal")]
		private static extern void core_Core_gemm_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, double alpha, IntPtr src3_nativeObj, double beta, IntPtr dst_nativeObj);
		
		// C++:  void mulTransposed(Mat src, Mat& dst, bool aTa, Mat delta = Mat(), double scale = 1, int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_mulTransposed_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, bool aTa, IntPtr delta_nativeObj, double scale, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_mulTransposed_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, bool aTa, IntPtr delta_nativeObj, double scale);
		
		[DllImport("__Internal")]
		private static extern void core_Core_mulTransposed_12 (IntPtr src_nativeObj, IntPtr dst_nativeObj, bool aTa);
		
		// C++:  void transpose(Mat src, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_transpose_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void transform(Mat src, Mat& dst, Mat m)
		[DllImport("__Internal")]
		private static extern void core_Core_transform_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, IntPtr m_nativeObj);
		
		// C++:  void perspectiveTransform(Mat src, Mat& dst, Mat m)
		[DllImport("__Internal")]
		private static extern void core_Core_perspectiveTransform_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, IntPtr m_nativeObj);
		
		// C++:  void completeSymm(Mat& mtx, bool lowerToUpper = false)
		[DllImport("__Internal")]
		private static extern void core_Core_completeSymm_10 (IntPtr mtx_nativeObj, bool lowerToUpper);
		
		[DllImport("__Internal")]
		private static extern void core_Core_completeSymm_11 (IntPtr mtx_nativeObj);
		
		// C++:  void setIdentity(Mat& mtx, Scalar s = Scalar(1))
		[DllImport("__Internal")]
		private static extern void core_Core_setIdentity_10 (IntPtr mtx_nativeObj, double s_val0, double s_val1, double s_val2, double s_val3);
		
		[DllImport("__Internal")]
		private static extern void core_Core_setIdentity_11 (IntPtr mtx_nativeObj);
		
		// C++:  double determinant(Mat mtx)
		[DllImport("__Internal")]
		private static extern double core_Core_determinant_10 (IntPtr mtx_nativeObj);
		
		// C++:  Scalar trace(Mat mtx)
		[DllImport("__Internal")]
		private static extern void core_Core_trace_10 (IntPtr mtx_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] double[] vals);
		
		// C++:  double invert(Mat src, Mat& dst, int flags = DECOMP_LU)
		[DllImport("__Internal")]
		private static extern double core_Core_invert_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);
		
		[DllImport("__Internal")]
		private static extern double core_Core_invert_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  bool solve(Mat src1, Mat src2, Mat& dst, int flags = DECOMP_LU)
		[DllImport("__Internal")]
		private static extern bool core_Core_solve_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, int flags);
		
		[DllImport("__Internal")]
		private static extern bool core_Core_solve_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void sort(Mat src, Mat& dst, int flags)
		[DllImport("__Internal")]
		private static extern void core_Core_sort_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);
		
		// C++:  void sortIdx(Mat src, Mat& dst, int flags)
		[DllImport("__Internal")]
		private static extern void core_Core_sortIdx_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);
		
		// C++:  int solveCubic(Mat coeffs, Mat& roots)
		[DllImport("__Internal")]
		private static extern int core_Core_solveCubic_10 (IntPtr coeffs_nativeObj, IntPtr roots_nativeObj);
		
		// C++:  double solvePoly(Mat coeffs, Mat& roots, int maxIters = 300)
		[DllImport("__Internal")]
		private static extern double core_Core_solvePoly_10 (IntPtr coeffs_nativeObj, IntPtr roots_nativeObj, int maxIters);
		
		[DllImport("__Internal")]
		private static extern double core_Core_solvePoly_11 (IntPtr coeffs_nativeObj, IntPtr roots_nativeObj);
		
		// C++:  bool eigen(Mat src, Mat& eigenvalues, Mat& eigenvectors = Mat())
		[DllImport("__Internal")]
		private static extern bool core_Core_eigen_10 (IntPtr src_nativeObj, IntPtr eigenvalues_nativeObj, IntPtr eigenvectors_nativeObj);
		
		[DllImport("__Internal")]
		private static extern bool core_Core_eigen_11 (IntPtr src_nativeObj, IntPtr eigenvalues_nativeObj);
		
		// C++:  void calcCovarMatrix(Mat samples, Mat& covar, Mat& mean, int flags, int ctype = CV_64F)
		[DllImport("__Internal")]
		private static extern void core_Core_calcCovarMatrix_10 (IntPtr samples_nativeObj, IntPtr covar_nativeObj, IntPtr mean_nativeObj, int flags, int ctype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_calcCovarMatrix_11 (IntPtr samples_nativeObj, IntPtr covar_nativeObj, IntPtr mean_nativeObj, int flags);
		
		// C++:  void PCACompute(Mat data, Mat& mean, Mat& eigenvectors, int maxComponents = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_PCACompute_11 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj, int maxComponents);
		
		[DllImport("__Internal")]
		private static extern void core_Core_PCACompute_12 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj);
		
		// C++:  int getOptimalDFTSize(int vecsize)
		[DllImport("__Internal")]
		private static extern int core_Core_getOptimalDFTSize_10 (int vecsize);
		
		// C++:  void randu(Mat& dst, double low, double high)
		[DllImport("__Internal")]
		private static extern void core_Core_randu_10 (IntPtr dst_nativeObj, double low, double high);
		
		// C++:  void randn(Mat& dst, double mean, double stddev)
		[DllImport("__Internal")]
		private static extern void core_Core_randn_10 (IntPtr dst_nativeObj, double mean, double stddev);
		
		// C++:  void randShuffle(Mat& dst, double iterFactor = 1., RNG* rng = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_randShuffle_10 (IntPtr dst_nativeObj, double iterFactor);
		
		[DllImport("__Internal")]
		private static extern void core_Core_randShuffle_11 (IntPtr dst_nativeObj);
		
		// C++:  double kmeans(Mat data, int K, Mat& bestLabels, TermCriteria criteria, int attempts, int flags, Mat& centers = Mat())
		[DllImport("__Internal")]
		private static extern double core_Core_kmeans_10 (IntPtr data_nativeObj, int K, IntPtr bestLabels_nativeObj, int criteria_type, int criteria_maxCount, double criteria_epsilon, int attempts, int flags, IntPtr centers_nativeObj);
		
		[DllImport("__Internal")]
		private static extern double core_Core_kmeans_11 (IntPtr data_nativeObj, int K, IntPtr bestLabels_nativeObj, int criteria_type, int criteria_maxCount, double criteria_epsilon, int attempts, int flags);
		
		// C++:  void scaleAdd(Mat src1, double alpha, Mat src2, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_scaleAdd_10 (IntPtr src1_nativeObj, double alpha, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void divide(double scale, Mat src2, Mat& dst, int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_divide_13 (double scale, IntPtr src2_nativeObj, IntPtr dst_nativeObj, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_divide_14 (double scale, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void addWeighted(Mat src1, double alpha, Mat src2, double beta, double gamma, Mat& dst, int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_addWeighted_10 (IntPtr src1_nativeObj, double alpha, IntPtr src2_nativeObj, double beta, double gamma, IntPtr dst_nativeObj, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_addWeighted_11 (IntPtr src1_nativeObj, double alpha, IntPtr src2_nativeObj, double beta, double gamma, IntPtr dst_nativeObj);
		
		// C++:  void convertScaleAbs(Mat src, Mat& dst, double alpha = 1, double beta = 0)
		[DllImport("__Internal")]
		private static extern void core_Core_convertScaleAbs_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta);
		
		[DllImport("__Internal")]
		private static extern void core_Core_convertScaleAbs_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void LUT(Mat src, Mat lut, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_LUT_10 (IntPtr src_nativeObj, IntPtr lut_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  Scalar sum(Mat src)
		[DllImport("__Internal")]
		private static extern void core_Core_sumElems_10 (IntPtr src_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] double[] vals);
		
		// C++:  void findNonZero(Mat src, Mat& idx)
		[DllImport("__Internal")]
		private static extern void core_Core_findNonZero_10 (IntPtr src_nativeObj, IntPtr idx_nativeObj);
		
		// C++:  int countNonZero(Mat src)
		[DllImport("__Internal")]
		private static extern int core_Core_countNonZero_10 (IntPtr src_nativeObj);
		
		// C++:  Scalar mean(Mat src, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern void core_Core_mean_10 (IntPtr src_nativeObj, IntPtr mask_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] double[] vals);
		
		[DllImport("__Internal")]
		private static extern void core_Core_mean_11 (IntPtr src_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] double[] vals);
		
		// C++:  void meanStdDev(Mat src, vector_double& mean, vector_double& stddev, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern void core_Core_meanStdDev_10 (IntPtr src_nativeObj, IntPtr mean_mat_nativeObj, IntPtr stddev_mat_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_meanStdDev_11 (IntPtr src_nativeObj, IntPtr mean_mat_nativeObj, IntPtr stddev_mat_nativeObj);
		
		// C++:  double norm(Mat src1, int normType = NORM_L2, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern double core_Core_norm_10 (IntPtr src1_nativeObj, int normType, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern double core_Core_norm_11 (IntPtr src1_nativeObj, int normType);
		
		[DllImport("__Internal")]
		private static extern double core_Core_norm_12 (IntPtr src1_nativeObj);
		
		// C++:  double norm(Mat src1, Mat src2, int normType = NORM_L2, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern double core_Core_norm_13 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, int normType, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern double core_Core_norm_14 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, int normType);
		
		[DllImport("__Internal")]
		private static extern double core_Core_norm_15 (IntPtr src1_nativeObj, IntPtr src2_nativeObj);
		
		// C++:  void normalize(Mat src, Mat& dst, double alpha = 1, double beta = 0, int norm_type = NORM_L2, int dtype = -1, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern void core_Core_normalize_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta, int norm_type, int dtype, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_normalize_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta, int norm_type, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_normalize_12 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta, int norm_type);
		
		[DllImport("__Internal")]
		private static extern void core_Core_normalize_13 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void setErrorVerbosity(bool verbose)
		[DllImport("__Internal")]
		private static extern void core_Core_setErrorVerbosity_10 (bool verbose);
		
		// C++:  void reduce(Mat src, Mat& dst, int dim, int rtype, int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_reduce_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int dim, int rtype, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_reduce_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int dim, int rtype);
		
		// C++:  void merge(vector_Mat mv, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_merge_10 (IntPtr mv_mat_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void split(Mat m, vector_Mat& mv)
		[DllImport("__Internal")]
		private static extern void core_Core_split_10 (IntPtr m_nativeObj, IntPtr mv_mat_nativeObj);
		
		// C++:  void mixChannels(vector_Mat src, vector_Mat dst, vector_int fromTo)
		[DllImport("__Internal")]
		private static extern void core_Core_mixChannels_10 (IntPtr src_mat_nativeObj, IntPtr dst_mat_nativeObj, IntPtr fromTo_mat_nativeObj);
		
		// C++:  void extractChannel(Mat src, Mat& dst, int coi)
		[DllImport("__Internal")]
		private static extern void core_Core_extractChannel_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int coi);
		
		// C++:  void add(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_add_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_add_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_add_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
		
		// C++:  int getNumberOfCPUs()
		[DllImport("__Internal")]
		private static extern int core_Core_getNumberOfCPUs_10 ();
		
		// C++:  void subtract(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_subtract_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_subtract_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_subtract_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
		
		// C++:  void multiply(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_multiply_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_multiply_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale);
		
		[DllImport("__Internal")]
		private static extern void core_Core_multiply_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
		
		// C++:  void divide(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
		[DllImport("__Internal")]
		private static extern void core_Core_divide_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale, int dtype);
		
		[DllImport("__Internal")]
		private static extern void core_Core_divide_16 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale);
		
		[DllImport("__Internal")]
		private static extern void core_Core_divide_17 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
		
		// C++:  void compare(Mat src1, Scalar src2, Mat& dst, int cmpop)
		[DllImport("__Internal")]
		private static extern void core_Core_compare_10 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, int cmpop);
		
		// C++:  void absdiff(Mat src1, Scalar src2, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_absdiff_10 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
		
		// C++:  String getBuildInformation()
		[DllImport("__Internal")]
		private static extern IntPtr core_Core_getBuildInformation_10 ();
		
		// C++:  double getTickFrequency()
		[DllImport("__Internal")]
		private static extern double core_Core_getTickFrequency_10 ();
		
		// C++:  int64 getTickCount()
		[DllImport("__Internal")]
		private static extern long core_Core_getTickCount_10 ();
		
		// C++:  void hconcat(vector_Mat src, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_hconcat_10 (IntPtr src_mat_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void vconcat(vector_Mat src, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_vconcat_10 (IntPtr src_mat_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void bitwise_and(Mat src1, Mat src2, Mat& dst, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern void core_Core_bitwise_1and_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_bitwise_1and_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void bitwise_or(Mat src1, Mat src2, Mat& dst, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern void core_Core_bitwise_1or_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_bitwise_1or_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void bitwise_xor(Mat src1, Mat src2, Mat& dst, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern void core_Core_bitwise_1xor_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_bitwise_1xor_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void bitwise_not(Mat src, Mat& dst, Mat mask = Mat())
		[DllImport("__Internal")]
		private static extern void core_Core_bitwise_1not_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_bitwise_1not_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void absdiff(Mat src1, Mat src2, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_absdiff_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void inRange(Mat src, Scalar lowerb, Scalar upperb, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_inRange_10 (IntPtr src_nativeObj, double lowerb_val0, double lowerb_val1, double lowerb_val2, double lowerb_val3, double upperb_val0, double upperb_val1, double upperb_val2, double upperb_val3, IntPtr dst_nativeObj);
		
		// C++:  void compare(Mat src1, Mat src2, Mat& dst, int cmpop)
		[DllImport("__Internal")]
		private static extern void core_Core_compare_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, int cmpop);
		
		// C++:  void min(Mat src1, Mat src2, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_min_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void max(Mat src1, Mat src2, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_max_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void sqrt(Mat src, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_sqrt_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
		
		// C++:  void pow(Mat src, double power, Mat& dst)
		[DllImport("__Internal")]
		private static extern void core_Core_pow_10 (IntPtr src_nativeObj, double power, IntPtr dst_nativeObj);
		
		[DllImport("__Internal")]
		private static extern void core_Core_n_1minMaxLocManual (IntPtr src_nativeObj, IntPtr mask_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 6)] double[] vals);
#else
				// C++:  double PSNR(Mat src1, Mat src2)
				[DllImport("opencvforunity")]
				private static extern double core_Core_PSNR_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj);
	
				// C++:  void batchDistance(Mat src1, Mat src2, Mat& dist, int dtype, Mat& nidx, int normType = NORM_L2, int K = 0, Mat mask = Mat(), int update = 0, bool crosscheck = false)
				[DllImport("opencvforunity")]
				private static extern void core_Core_batchDistance_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dist_nativeObj, int dtype, IntPtr nidx_nativeObj, int normType, int K, IntPtr mask_nativeObj, int update, bool crosscheck);

				[DllImport("opencvforunity")]
				private static extern void core_Core_batchDistance_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dist_nativeObj, int dtype, IntPtr nidx_nativeObj, int normType, int K);

				[DllImport("opencvforunity")]
				private static extern void core_Core_batchDistance_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dist_nativeObj, int dtype, IntPtr nidx_nativeObj);
	
				// C++:  int64 getCPUTickCount()
				[DllImport("opencvforunity")]
				private static extern long core_Core_getCPUTickCount_10 ();
	
				// C++:  float cubeRoot(float val)
				[DllImport("opencvforunity")]
				private static extern float core_Core_cubeRoot_10 (float val);
	
				// C++:  float fastAtan2(float y, float x)
				[DllImport("opencvforunity")]
				private static extern float core_Core_fastAtan2_10 (float y, float x);
	
				// C++:  void insertChannel(Mat src, Mat& dst, int coi)
				[DllImport("opencvforunity")]
				private static extern void core_Core_insertChannel_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int coi);
	
				// C++:  void flip(Mat src, Mat& dst, int flipCode)
				[DllImport("opencvforunity")]
				private static extern void core_Core_flip_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flipCode);
	
				// C++:  void repeat(Mat src, int ny, int nx, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_repeat_10 (IntPtr src_nativeObj, int ny, int nx, IntPtr dst_nativeObj);
	
				// C++:  void PCACompute(Mat data, Mat& mean, Mat& eigenvectors, double retainedVariance)
				[DllImport("opencvforunity")]
				private static extern void core_Core_PCACompute_10 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj, double retainedVariance);
	
				// C++:  void PCAProject(Mat data, Mat mean, Mat eigenvectors, Mat& result)
				[DllImport("opencvforunity")]
				private static extern void core_Core_PCAProject_10 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj, IntPtr result_nativeObj);
	
				// C++:  void PCABackProject(Mat data, Mat mean, Mat eigenvectors, Mat& result)
				[DllImport("opencvforunity")]
				private static extern void core_Core_PCABackProject_10 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj, IntPtr result_nativeObj);
	
				// C++:  void SVDecomp(Mat src, Mat& w, Mat& u, Mat& vt, int flags = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_SVDecomp_10 (IntPtr src_nativeObj, IntPtr w_nativeObj, IntPtr u_nativeObj, IntPtr vt_nativeObj, int flags);

				[DllImport("opencvforunity")]
				private static extern void core_Core_SVDecomp_11 (IntPtr src_nativeObj, IntPtr w_nativeObj, IntPtr u_nativeObj, IntPtr vt_nativeObj);
	
				// C++:  void SVBackSubst(Mat w, Mat u, Mat vt, Mat rhs, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_SVBackSubst_10 (IntPtr w_nativeObj, IntPtr u_nativeObj, IntPtr vt_nativeObj, IntPtr rhs_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  double Mahalanobis(Mat v1, Mat v2, Mat icovar)
				[DllImport("opencvforunity")]
				private static extern double core_Core_Mahalanobis_10 (IntPtr v1_nativeObj, IntPtr v2_nativeObj, IntPtr icovar_nativeObj);
	
				// C++:  void dft(Mat src, Mat& dst, int flags = 0, int nonzeroRows = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_dft_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags, int nonzeroRows);

				[DllImport("opencvforunity")]
				private static extern void core_Core_dft_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void idft(Mat src, Mat& dst, int flags = 0, int nonzeroRows = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_idft_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags, int nonzeroRows);

				[DllImport("opencvforunity")]
				private static extern void core_Core_idft_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void dct(Mat src, Mat& dst, int flags = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_dct_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);

				[DllImport("opencvforunity")]
				private static extern void core_Core_dct_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void idct(Mat src, Mat& dst, int flags = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_idct_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);

				[DllImport("opencvforunity")]
				private static extern void core_Core_idct_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void mulSpectrums(Mat a, Mat b, Mat& c, int flags, bool conjB = false)
				[DllImport("opencvforunity")]
				private static extern void core_Core_mulSpectrums_10 (IntPtr a_nativeObj, IntPtr b_nativeObj, IntPtr c_nativeObj, int flags, bool conjB);

				[DllImport("opencvforunity")]
				private static extern void core_Core_mulSpectrums_11 (IntPtr a_nativeObj, IntPtr b_nativeObj, IntPtr c_nativeObj, int flags);
	
				// C++:  void max(Mat src1, Scalar src2, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_max_10 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
	
				// C++:  void min(Mat src1, Scalar src2, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_min_10 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
	
				// C++:  int borderInterpolate(int p, int len, int borderType)
				[DllImport("opencvforunity")]
				private static extern int core_Core_borderInterpolate_10 (int p, int len, int borderType);
	
				// C++:  void copyMakeBorder(Mat src, Mat& dst, int top, int bottom, int left, int right, int borderType, Scalar value = Scalar())
				[DllImport("opencvforunity")]
				private static extern void core_Core_copyMakeBorder_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int top, int bottom, int left, int right, int borderType, double value_val0, double value_val1, double value_val2, double value_val3);

				[DllImport("opencvforunity")]
				private static extern void core_Core_copyMakeBorder_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int top, int bottom, int left, int right, int borderType);
	
				// C++:  void add(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_add_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_add_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_add_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void subtract(Mat src1, Mat src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_subtract_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_subtract_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_subtract_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void multiply(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_multiply_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_multiply_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale);

				[DllImport("opencvforunity")]
				private static extern void core_Core_multiply_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void divide(Mat src1, Mat src2, Mat& dst, double scale = 1, int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_divide_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_divide_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, double scale);

				[DllImport("opencvforunity")]
				private static extern void core_Core_divide_12 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void exp(Mat src, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_exp_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void log(Mat src, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_log_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void polarToCart(Mat magnitude, Mat angle, Mat& x, Mat& y, bool angleInDegrees = false)
				[DllImport("opencvforunity")]
				private static extern void core_Core_polarToCart_10 (IntPtr magnitude_nativeObj, IntPtr angle_nativeObj, IntPtr x_nativeObj, IntPtr y_nativeObj, bool angleInDegrees);

				[DllImport("opencvforunity")]
				private static extern void core_Core_polarToCart_11 (IntPtr magnitude_nativeObj, IntPtr angle_nativeObj, IntPtr x_nativeObj, IntPtr y_nativeObj);
	
				// C++:  void cartToPolar(Mat x, Mat y, Mat& magnitude, Mat& angle, bool angleInDegrees = false)
				[DllImport("opencvforunity")]
				private static extern void core_Core_cartToPolar_10 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr magnitude_nativeObj, IntPtr angle_nativeObj, bool angleInDegrees);

				[DllImport("opencvforunity")]
				private static extern void core_Core_cartToPolar_11 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr magnitude_nativeObj, IntPtr angle_nativeObj);
	
				// C++:  void phase(Mat x, Mat y, Mat& angle, bool angleInDegrees = false)
				[DllImport("opencvforunity")]
				private static extern void core_Core_phase_10 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr angle_nativeObj, bool angleInDegrees);

				[DllImport("opencvforunity")]
				private static extern void core_Core_phase_11 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr angle_nativeObj);
	
				// C++:  void magnitude(Mat x, Mat y, Mat& magnitude)
				[DllImport("opencvforunity")]
				private static extern void core_Core_magnitude_10 (IntPtr x_nativeObj, IntPtr y_nativeObj, IntPtr magnitude_nativeObj);
	
				// C++:  bool checkRange(Mat a, bool quiet = true,  _hidden_ * pos = 0, double minVal = -DBL_MAX, double maxVal = DBL_MAX)
				[DllImport("opencvforunity")]
				private static extern bool core_Core_checkRange_10 (IntPtr a_nativeObj, bool quiet, double minVal, double maxVal);

				[DllImport("opencvforunity")]
				private static extern bool core_Core_checkRange_11 (IntPtr a_nativeObj);
	
				// C++:  void patchNaNs(Mat& a, double val = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_patchNaNs_10 (IntPtr a_nativeObj, double val);

				[DllImport("opencvforunity")]
				private static extern void core_Core_patchNaNs_11 (IntPtr a_nativeObj);
	
				// C++:  void gemm(Mat src1, Mat src2, double alpha, Mat src3, double beta, Mat& dst, int flags = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_gemm_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, double alpha, IntPtr src3_nativeObj, double beta, IntPtr dst_nativeObj, int flags);

				[DllImport("opencvforunity")]
				private static extern void core_Core_gemm_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, double alpha, IntPtr src3_nativeObj, double beta, IntPtr dst_nativeObj);
	
				// C++:  void mulTransposed(Mat src, Mat& dst, bool aTa, Mat delta = Mat(), double scale = 1, int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_mulTransposed_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, bool aTa, IntPtr delta_nativeObj, double scale, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_mulTransposed_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, bool aTa, IntPtr delta_nativeObj, double scale);

				[DllImport("opencvforunity")]
				private static extern void core_Core_mulTransposed_12 (IntPtr src_nativeObj, IntPtr dst_nativeObj, bool aTa);
	
				// C++:  void transpose(Mat src, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_transpose_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void transform(Mat src, Mat& dst, Mat m)
				[DllImport("opencvforunity")]
				private static extern void core_Core_transform_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, IntPtr m_nativeObj);
	
				// C++:  void perspectiveTransform(Mat src, Mat& dst, Mat m)
				[DllImport("opencvforunity")]
				private static extern void core_Core_perspectiveTransform_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, IntPtr m_nativeObj);
	
				// C++:  void completeSymm(Mat& mtx, bool lowerToUpper = false)
				[DllImport("opencvforunity")]
				private static extern void core_Core_completeSymm_10 (IntPtr mtx_nativeObj, bool lowerToUpper);

				[DllImport("opencvforunity")]
				private static extern void core_Core_completeSymm_11 (IntPtr mtx_nativeObj);
	
				// C++:  void setIdentity(Mat& mtx, Scalar s = Scalar(1))
				[DllImport("opencvforunity")]
				private static extern void core_Core_setIdentity_10 (IntPtr mtx_nativeObj, double s_val0, double s_val1, double s_val2, double s_val3);

				[DllImport("opencvforunity")]
				private static extern void core_Core_setIdentity_11 (IntPtr mtx_nativeObj);
	
				// C++:  double determinant(Mat mtx)
				[DllImport("opencvforunity")]
				private static extern double core_Core_determinant_10 (IntPtr mtx_nativeObj);
	
				// C++:  Scalar trace(Mat mtx)
				[DllImport("opencvforunity")]
				private static extern void core_Core_trace_10 (IntPtr mtx_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] double[] vals);
	
				// C++:  double invert(Mat src, Mat& dst, int flags = DECOMP_LU)
				[DllImport("opencvforunity")]
				private static extern double core_Core_invert_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);

				[DllImport("opencvforunity")]
				private static extern double core_Core_invert_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  bool solve(Mat src1, Mat src2, Mat& dst, int flags = DECOMP_LU)
				[DllImport("opencvforunity")]
				private static extern bool core_Core_solve_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, int flags);

				[DllImport("opencvforunity")]
				private static extern bool core_Core_solve_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void sort(Mat src, Mat& dst, int flags)
				[DllImport("opencvforunity")]
				private static extern void core_Core_sort_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);
	
				// C++:  void sortIdx(Mat src, Mat& dst, int flags)
				[DllImport("opencvforunity")]
				private static extern void core_Core_sortIdx_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int flags);
	
				// C++:  int solveCubic(Mat coeffs, Mat& roots)
				[DllImport("opencvforunity")]
				private static extern int core_Core_solveCubic_10 (IntPtr coeffs_nativeObj, IntPtr roots_nativeObj);
	
				// C++:  double solvePoly(Mat coeffs, Mat& roots, int maxIters = 300)
				[DllImport("opencvforunity")]
				private static extern double core_Core_solvePoly_10 (IntPtr coeffs_nativeObj, IntPtr roots_nativeObj, int maxIters);

				[DllImport("opencvforunity")]
				private static extern double core_Core_solvePoly_11 (IntPtr coeffs_nativeObj, IntPtr roots_nativeObj);
	
				// C++:  bool eigen(Mat src, Mat& eigenvalues, Mat& eigenvectors = Mat())
				[DllImport("opencvforunity")]
				private static extern bool core_Core_eigen_10 (IntPtr src_nativeObj, IntPtr eigenvalues_nativeObj, IntPtr eigenvectors_nativeObj);

				[DllImport("opencvforunity")]
				private static extern bool core_Core_eigen_11 (IntPtr src_nativeObj, IntPtr eigenvalues_nativeObj);
	
				// C++:  void calcCovarMatrix(Mat samples, Mat& covar, Mat& mean, int flags, int ctype = CV_64F)
				[DllImport("opencvforunity")]
				private static extern void core_Core_calcCovarMatrix_10 (IntPtr samples_nativeObj, IntPtr covar_nativeObj, IntPtr mean_nativeObj, int flags, int ctype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_calcCovarMatrix_11 (IntPtr samples_nativeObj, IntPtr covar_nativeObj, IntPtr mean_nativeObj, int flags);
	
				// C++:  void PCACompute(Mat data, Mat& mean, Mat& eigenvectors, int maxComponents = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_PCACompute_11 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj, int maxComponents);

				[DllImport("opencvforunity")]
				private static extern void core_Core_PCACompute_12 (IntPtr data_nativeObj, IntPtr mean_nativeObj, IntPtr eigenvectors_nativeObj);
	
				// C++:  int getOptimalDFTSize(int vecsize)
				[DllImport("opencvforunity")]
				private static extern int core_Core_getOptimalDFTSize_10 (int vecsize);
	
				// C++:  void randu(Mat& dst, double low, double high)
				[DllImport("opencvforunity")]
				private static extern void core_Core_randu_10 (IntPtr dst_nativeObj, double low, double high);
	
				// C++:  void randn(Mat& dst, double mean, double stddev)
				[DllImport("opencvforunity")]
				private static extern void core_Core_randn_10 (IntPtr dst_nativeObj, double mean, double stddev);
	
				// C++:  void randShuffle(Mat& dst, double iterFactor = 1., RNG* rng = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_randShuffle_10 (IntPtr dst_nativeObj, double iterFactor);

				[DllImport("opencvforunity")]
				private static extern void core_Core_randShuffle_11 (IntPtr dst_nativeObj);
	
				// C++:  double kmeans(Mat data, int K, Mat& bestLabels, TermCriteria criteria, int attempts, int flags, Mat& centers = Mat())
				[DllImport("opencvforunity")]
				private static extern double core_Core_kmeans_10 (IntPtr data_nativeObj, int K, IntPtr bestLabels_nativeObj, int criteria_type, int criteria_maxCount, double criteria_epsilon, int attempts, int flags, IntPtr centers_nativeObj);

				[DllImport("opencvforunity")]
				private static extern double core_Core_kmeans_11 (IntPtr data_nativeObj, int K, IntPtr bestLabels_nativeObj, int criteria_type, int criteria_maxCount, double criteria_epsilon, int attempts, int flags);
	
				// C++:  void scaleAdd(Mat src1, double alpha, Mat src2, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_scaleAdd_10 (IntPtr src1_nativeObj, double alpha, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void divide(double scale, Mat src2, Mat& dst, int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_divide_13 (double scale, IntPtr src2_nativeObj, IntPtr dst_nativeObj, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_divide_14 (double scale, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void addWeighted(Mat src1, double alpha, Mat src2, double beta, double gamma, Mat& dst, int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_addWeighted_10 (IntPtr src1_nativeObj, double alpha, IntPtr src2_nativeObj, double beta, double gamma, IntPtr dst_nativeObj, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_addWeighted_11 (IntPtr src1_nativeObj, double alpha, IntPtr src2_nativeObj, double beta, double gamma, IntPtr dst_nativeObj);
	
				// C++:  void convertScaleAbs(Mat src, Mat& dst, double alpha = 1, double beta = 0)
				[DllImport("opencvforunity")]
				private static extern void core_Core_convertScaleAbs_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta);

				[DllImport("opencvforunity")]
				private static extern void core_Core_convertScaleAbs_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void LUT(Mat src, Mat lut, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_LUT_10 (IntPtr src_nativeObj, IntPtr lut_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  Scalar sum(Mat src)
				[DllImport("opencvforunity")]
				private static extern void core_Core_sumElems_10 (IntPtr src_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] double[] vals);
	
				// C++:  void findNonZero(Mat src, Mat& idx)
				[DllImport("opencvforunity")]
				private static extern void core_Core_findNonZero_10 (IntPtr src_nativeObj, IntPtr idx_nativeObj);
	
				// C++:  int countNonZero(Mat src)
				[DllImport("opencvforunity")]
				private static extern int core_Core_countNonZero_10 (IntPtr src_nativeObj);
	
				// C++:  Scalar mean(Mat src, Mat mask = Mat())
				[DllImport("opencvforunity")]
				private static extern void core_Core_mean_10 (IntPtr src_nativeObj, IntPtr mask_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] double[] vals);

				[DllImport("opencvforunity")]
				private static extern void core_Core_mean_11 (IntPtr src_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] double[] vals);
	
				// C++:  void meanStdDev(Mat src, vector_double& mean, vector_double& stddev, Mat mask = Mat())
				[DllImport("opencvforunity")]
				private static extern void core_Core_meanStdDev_10 (IntPtr src_nativeObj, IntPtr mean_mat_nativeObj, IntPtr stddev_mat_nativeObj, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_meanStdDev_11 (IntPtr src_nativeObj, IntPtr mean_mat_nativeObj, IntPtr stddev_mat_nativeObj);
	
				// C++:  double norm(Mat src1, int normType = NORM_L2, Mat mask = Mat())
				[DllImport("opencvforunity")]
				private static extern double core_Core_norm_10 (IntPtr src1_nativeObj, int normType, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern double core_Core_norm_11 (IntPtr src1_nativeObj, int normType);

				[DllImport("opencvforunity")]
				private static extern double core_Core_norm_12 (IntPtr src1_nativeObj);
	
				// C++:  double norm(Mat src1, Mat src2, int normType = NORM_L2, Mat mask = Mat())
				[DllImport("opencvforunity")]
				private static extern double core_Core_norm_13 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, int normType, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern double core_Core_norm_14 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, int normType);

				[DllImport("opencvforunity")]
				private static extern double core_Core_norm_15 (IntPtr src1_nativeObj, IntPtr src2_nativeObj);
	
				// C++:  void normalize(Mat src, Mat& dst, double alpha = 1, double beta = 0, int norm_type = NORM_L2, int dtype = -1, Mat mask = Mat())
				[DllImport("opencvforunity")]
				private static extern void core_Core_normalize_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta, int norm_type, int dtype, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_normalize_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta, int norm_type, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_normalize_12 (IntPtr src_nativeObj, IntPtr dst_nativeObj, double alpha, double beta, int norm_type);

				[DllImport("opencvforunity")]
				private static extern void core_Core_normalize_13 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void setErrorVerbosity(bool verbose)
				[DllImport("opencvforunity")]
				private static extern void core_Core_setErrorVerbosity_10 (bool verbose);
	
				// C++:  void reduce(Mat src, Mat& dst, int dim, int rtype, int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_reduce_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int dim, int rtype, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_reduce_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int dim, int rtype);
	
				// C++:  void merge(vector_Mat mv, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_merge_10 (IntPtr mv_mat_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void split(Mat m, vector_Mat& mv)
				[DllImport("opencvforunity")]
				private static extern void core_Core_split_10 (IntPtr m_nativeObj, IntPtr mv_mat_nativeObj);
	
				// C++:  void mixChannels(vector_Mat src, vector_Mat dst, vector_int fromTo)
				[DllImport("opencvforunity")]
				private static extern void core_Core_mixChannels_10 (IntPtr src_mat_nativeObj, IntPtr dst_mat_nativeObj, IntPtr fromTo_mat_nativeObj);
	
				// C++:  void extractChannel(Mat src, Mat& dst, int coi)
				[DllImport("opencvforunity")]
				private static extern void core_Core_extractChannel_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, int coi);
	
				// C++:  void add(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_add_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_add_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_add_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
	
				// C++:  int getNumberOfCPUs()
				[DllImport("opencvforunity")]
				private static extern int core_Core_getNumberOfCPUs_10 ();
	
				// C++:  void subtract(Mat src1, Scalar src2, Mat& dst, Mat mask = Mat(), int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_subtract_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_subtract_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_subtract_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
	
				// C++:  void multiply(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_multiply_13 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_multiply_14 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale);

				[DllImport("opencvforunity")]
				private static extern void core_Core_multiply_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
	
				// C++:  void divide(Mat src1, Scalar src2, Mat& dst, double scale = 1, int dtype = -1)
				[DllImport("opencvforunity")]
				private static extern void core_Core_divide_15 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale, int dtype);

				[DllImport("opencvforunity")]
				private static extern void core_Core_divide_16 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, double scale);

				[DllImport("opencvforunity")]
				private static extern void core_Core_divide_17 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
	
				// C++:  void compare(Mat src1, Scalar src2, Mat& dst, int cmpop)
				[DllImport("opencvforunity")]
				private static extern void core_Core_compare_10 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj, int cmpop);
	
				// C++:  void absdiff(Mat src1, Scalar src2, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_absdiff_10 (IntPtr src1_nativeObj, double src2_val0, double src2_val1, double src2_val2, double src2_val3, IntPtr dst_nativeObj);
	
				// C++:  String getBuildInformation()
				[DllImport("opencvforunity")]
				private static extern IntPtr core_Core_getBuildInformation_10 ();
	
				// C++:  double getTickFrequency()
				[DllImport("opencvforunity")]
				private static extern double core_Core_getTickFrequency_10 ();
	
				// C++:  int64 getTickCount()
				[DllImport("opencvforunity")]
				private static extern long core_Core_getTickCount_10 ();
	
				// C++:  void hconcat(vector_Mat src, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_hconcat_10 (IntPtr src_mat_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void vconcat(vector_Mat src, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_vconcat_10 (IntPtr src_mat_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void bitwise_and(Mat src1, Mat src2, Mat& dst, Mat mask = Mat())
				[DllImport("opencvforunity")]
				private static extern void core_Core_bitwise_1and_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_bitwise_1and_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void bitwise_or(Mat src1, Mat src2, Mat& dst, Mat mask = Mat())
				[DllImport("opencvforunity")]
				private static extern void core_Core_bitwise_1or_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_bitwise_1or_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void bitwise_xor(Mat src1, Mat src2, Mat& dst, Mat mask = Mat())
				[DllImport("opencvforunity")]
				private static extern void core_Core_bitwise_1xor_10 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_bitwise_1xor_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void bitwise_not(Mat src, Mat& dst, Mat mask = Mat())
				[DllImport("opencvforunity")]
				private static extern void core_Core_bitwise_1not_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj, IntPtr mask_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_bitwise_1not_11 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void absdiff(Mat src1, Mat src2, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_absdiff_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void inRange(Mat src, Scalar lowerb, Scalar upperb, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_inRange_10 (IntPtr src_nativeObj, double lowerb_val0, double lowerb_val1, double lowerb_val2, double lowerb_val3, double upperb_val0, double upperb_val1, double upperb_val2, double upperb_val3, IntPtr dst_nativeObj);
	
				// C++:  void compare(Mat src1, Mat src2, Mat& dst, int cmpop)
				[DllImport("opencvforunity")]
				private static extern void core_Core_compare_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj, int cmpop);
	
				// C++:  void min(Mat src1, Mat src2, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_min_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void max(Mat src1, Mat src2, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_max_11 (IntPtr src1_nativeObj, IntPtr src2_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void sqrt(Mat src, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_sqrt_10 (IntPtr src_nativeObj, IntPtr dst_nativeObj);
	
				// C++:  void pow(Mat src, double power, Mat& dst)
				[DllImport("opencvforunity")]
				private static extern void core_Core_pow_10 (IntPtr src_nativeObj, double power, IntPtr dst_nativeObj);

				[DllImport("opencvforunity")]
				private static extern void core_Core_n_1minMaxLocManual (IntPtr src_nativeObj, IntPtr mask_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 6)] double[] vals);
#endif
		}
}