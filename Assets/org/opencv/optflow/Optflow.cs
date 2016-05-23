
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{
	public class Optflow
	{
	
		//
		// C++:  void calcOpticalFlowSF(Mat from, Mat to, Mat& flow, int layers, int averaging_block_size, int max_flow, double sigma_dist, double sigma_color, int postprocess_window, double sigma_dist_fix, double sigma_color_fix, double occ_thr, int upscale_averaging_radius, double upscale_sigma_dist, double upscale_sigma_color, double speed_up_thr)
		//
	
		//javadoc: calcOpticalFlowSF(from, to, flow, layers, averaging_block_size, max_flow, sigma_dist, sigma_color, postprocess_window, sigma_dist_fix, sigma_color_fix, occ_thr, upscale_averaging_radius, upscale_sigma_dist, upscale_sigma_color, speed_up_thr)
		public static void calcOpticalFlowSF (Mat from, Mat to, Mat flow, int layers, int averaging_block_size, int max_flow, double sigma_dist, double sigma_color, int postprocess_window, double sigma_dist_fix, double sigma_color_fix, double occ_thr, int upscale_averaging_radius, double upscale_sigma_dist, double upscale_sigma_color, double speed_up_thr)
		{
			if (from != null)
				from.ThrowIfDisposed ();
			if (to != null)
				to.ThrowIfDisposed ();
			if (flow != null)
				flow.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
			optflow_Optflow_calcOpticalFlowSF_10 (from.nativeObj, to.nativeObj, flow.nativeObj, layers, averaging_block_size, max_flow, sigma_dist, sigma_color, postprocess_window, sigma_dist_fix, sigma_color_fix, occ_thr, upscale_averaging_radius, upscale_sigma_dist, upscale_sigma_color, speed_up_thr);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void calcOpticalFlowSF(Mat from, Mat to, Mat& flow, int layers, int averaging_block_size, int max_flow)
		//
	
		//javadoc: calcOpticalFlowSF(from, to, flow, layers, averaging_block_size, max_flow)
		public static void calcOpticalFlowSF (Mat from, Mat to, Mat flow, int layers, int averaging_block_size, int max_flow)
		{
			if (from != null)
				from.ThrowIfDisposed ();
			if (to != null)
				to.ThrowIfDisposed ();
			if (flow != null)
				flow.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
			optflow_Optflow_calcOpticalFlowSF_11 (from.nativeObj, to.nativeObj, flow.nativeObj, layers, averaging_block_size, max_flow);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  Mat readOpticalFlow(String path)
		//
	
		//javadoc: readOpticalFlow(path)
		public static Mat readOpticalFlow (string path)
		{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
			Mat retVal = new Mat (optflow_Optflow_readOpticalFlow_10 (path));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  bool writeOpticalFlow(String path, Mat flow)
		//
	
		//javadoc: writeOpticalFlow(path, flow)
		public static bool writeOpticalFlow (string path, Mat flow)
		{
			if (flow != null)
				flow.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
			bool retVal = optflow_Optflow_writeOpticalFlow_10 (path, flow.nativeObj);
		
			return retVal;
#else
return false;
#endif
		}
	
	
		//
		// C++:  Ptr_DenseOpticalFlow createOptFlow_DeepFlow()
		//
	
		// Return type 'Ptr_DenseOpticalFlow' is not supported, skipping the function
	
	
		//
		// C++:  Ptr_DenseOpticalFlow createOptFlow_SimpleFlow()
		//
	
		// Return type 'Ptr_DenseOpticalFlow' is not supported, skipping the function
	
	
		//
		// C++:  Ptr_DenseOpticalFlow createOptFlow_Farneback()
		//
	
		// Return type 'Ptr_DenseOpticalFlow' is not supported, skipping the function
	
	
		//
		// C++:  void calcMotionGradient(Mat mhi, Mat& mask, Mat& orientation, double delta1, double delta2, int apertureSize = 3)
		//
	
		//javadoc: calcMotionGradient(mhi, mask, orientation, delta1, delta2, apertureSize)
		public static void calcMotionGradient (Mat mhi, Mat mask, Mat orientation, double delta1, double delta2, int apertureSize)
		{
			if (mhi != null)
				mhi.ThrowIfDisposed ();
			if (mask != null)
				mask.ThrowIfDisposed ();
			if (orientation != null)
				orientation.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
			optflow_Optflow_calcMotionGradient_10 (mhi.nativeObj, mask.nativeObj, orientation.nativeObj, delta1, delta2, apertureSize);
		
			return;
#else
return;
#endif
		}
	
		//javadoc: calcMotionGradient(mhi, mask, orientation, delta1, delta2)
		public static void calcMotionGradient (Mat mhi, Mat mask, Mat orientation, double delta1, double delta2)
		{
			if (mhi != null)
				mhi.ThrowIfDisposed ();
			if (mask != null)
				mask.ThrowIfDisposed ();
			if (orientation != null)
				orientation.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
			optflow_Optflow_calcMotionGradient_11 (mhi.nativeObj, mask.nativeObj, orientation.nativeObj, delta1, delta2);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void updateMotionHistory(Mat silhouette, Mat& mhi, double timestamp, double duration)
		//
	
		//javadoc: updateMotionHistory(silhouette, mhi, timestamp, duration)
		public static void updateMotionHistory (Mat silhouette, Mat mhi, double timestamp, double duration)
		{
			if (silhouette != null)
				silhouette.ThrowIfDisposed ();
			if (mhi != null)
				mhi.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
			optflow_Optflow_updateMotionHistory_10 (silhouette.nativeObj, mhi.nativeObj, timestamp, duration);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double calcGlobalOrientation(Mat orientation, Mat mask, Mat mhi, double timestamp, double duration)
		//
	
		//javadoc: calcGlobalOrientation(orientation, mask, mhi, timestamp, duration)
		public static double calcGlobalOrientation (Mat orientation, Mat mask, Mat mhi, double timestamp, double duration)
		{
			if (orientation != null)
				orientation.ThrowIfDisposed ();
			if (mask != null)
				mask.ThrowIfDisposed ();
			if (mhi != null)
				mhi.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
		
			double retVal = optflow_Optflow_calcGlobalOrientation_10 (orientation.nativeObj, mask.nativeObj, mhi.nativeObj, timestamp, duration);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void segmentMotion(Mat mhi, Mat& segmask, vector_Rect& boundingRects, double timestamp, double segThresh)
		//
	
		//javadoc: segmentMotion(mhi, segmask, boundingRects, timestamp, segThresh)
		public static void segmentMotion (Mat mhi, Mat segmask, MatOfRect boundingRects, double timestamp, double segThresh)
		{
			if (mhi != null)
				mhi.ThrowIfDisposed ();
			if (segmask != null)
				segmask.ThrowIfDisposed ();
			if (boundingRects != null)
				boundingRects.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5 && !(UNITY_WSA && !UNITY_EDITOR)
			Mat boundingRects_mat = boundingRects;
			optflow_Optflow_segmentMotion_10 (mhi.nativeObj, segmask.nativeObj, boundingRects_mat.nativeObj, timestamp, segThresh);
		
			return;
#else
return;
#endif
		}
	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  void calcOpticalFlowSF(Mat from, Mat to, Mat& flow, int layers, int averaging_block_size, int max_flow, double sigma_dist, double sigma_color, int postprocess_window, double sigma_dist_fix, double sigma_color_fix, double occ_thr, int upscale_averaging_radius, double upscale_sigma_dist, double upscale_sigma_color, double speed_up_thr)
		[DllImport("__Internal")]
		private static extern void optflow_Optflow_calcOpticalFlowSF_10 (IntPtr from_nativeObj, IntPtr to_nativeObj, IntPtr flow_nativeObj, int layers, int averaging_block_size, int max_flow, double sigma_dist, double sigma_color, int postprocess_window, double sigma_dist_fix, double sigma_color_fix, double occ_thr, int upscale_averaging_radius, double upscale_sigma_dist, double upscale_sigma_color, double speed_up_thr);
		
		// C++:  void calcOpticalFlowSF(Mat from, Mat to, Mat& flow, int layers, int averaging_block_size, int max_flow)
		[DllImport("__Internal")]
		private static extern void optflow_Optflow_calcOpticalFlowSF_11 (IntPtr from_nativeObj, IntPtr to_nativeObj, IntPtr flow_nativeObj, int layers, int averaging_block_size, int max_flow);
		
		// C++:  Mat readOpticalFlow(String path)
		[DllImport("__Internal")]
		private static extern IntPtr optflow_Optflow_readOpticalFlow_10 (string path);
		
		// C++:  bool writeOpticalFlow(String path, Mat flow)
		[DllImport("__Internal")]
		private static extern bool optflow_Optflow_writeOpticalFlow_10 (string path, IntPtr flow_nativeObj);
		
		// C++:  void calcMotionGradient(Mat mhi, Mat& mask, Mat& orientation, double delta1, double delta2, int apertureSize = 3)
		[DllImport("__Internal")]
		private static extern void optflow_Optflow_calcMotionGradient_10 (IntPtr mhi_nativeObj, IntPtr mask_nativeObj, IntPtr orientation_nativeObj, double delta1, double delta2, int apertureSize);
		
		[DllImport("__Internal")]
		private static extern void optflow_Optflow_calcMotionGradient_11 (IntPtr mhi_nativeObj, IntPtr mask_nativeObj, IntPtr orientation_nativeObj, double delta1, double delta2);
		
		// C++:  void updateMotionHistory(Mat silhouette, Mat& mhi, double timestamp, double duration)
		[DllImport("__Internal")]
		private static extern void optflow_Optflow_updateMotionHistory_10 (IntPtr silhouette_nativeObj, IntPtr mhi_nativeObj, double timestamp, double duration);
		
		// C++:  double calcGlobalOrientation(Mat orientation, Mat mask, Mat mhi, double timestamp, double duration)
		[DllImport("__Internal")]
		private static extern double optflow_Optflow_calcGlobalOrientation_10 (IntPtr orientation_nativeObj, IntPtr mask_nativeObj, IntPtr mhi_nativeObj, double timestamp, double duration);
		
		// C++:  void segmentMotion(Mat mhi, Mat& segmask, vector_Rect& boundingRects, double timestamp, double segThresh)
		[DllImport("__Internal")]
		private static extern void optflow_Optflow_segmentMotion_10 (IntPtr mhi_nativeObj, IntPtr segmask_nativeObj, IntPtr boundingRects_mat_nativeObj, double timestamp, double segThresh);
		#else
	
		// C++:  void calcOpticalFlowSF(Mat from, Mat to, Mat& flow, int layers, int averaging_block_size, int max_flow, double sigma_dist, double sigma_color, int postprocess_window, double sigma_dist_fix, double sigma_color_fix, double occ_thr, int upscale_averaging_radius, double upscale_sigma_dist, double upscale_sigma_color, double speed_up_thr)
		[DllImport("opencvforunity")]
		private static extern void optflow_Optflow_calcOpticalFlowSF_10 (IntPtr from_nativeObj, IntPtr to_nativeObj, IntPtr flow_nativeObj, int layers, int averaging_block_size, int max_flow, double sigma_dist, double sigma_color, int postprocess_window, double sigma_dist_fix, double sigma_color_fix, double occ_thr, int upscale_averaging_radius, double upscale_sigma_dist, double upscale_sigma_color, double speed_up_thr);
	
		// C++:  void calcOpticalFlowSF(Mat from, Mat to, Mat& flow, int layers, int averaging_block_size, int max_flow)
		[DllImport("opencvforunity")]
		private static extern void optflow_Optflow_calcOpticalFlowSF_11 (IntPtr from_nativeObj, IntPtr to_nativeObj, IntPtr flow_nativeObj, int layers, int averaging_block_size, int max_flow);
	
		// C++:  Mat readOpticalFlow(String path)
		[DllImport("opencvforunity")]
		private static extern IntPtr optflow_Optflow_readOpticalFlow_10 (string path);
	
		// C++:  bool writeOpticalFlow(String path, Mat flow)
		[DllImport("opencvforunity")]
		private static extern bool optflow_Optflow_writeOpticalFlow_10 (string path, IntPtr flow_nativeObj);
	
		// C++:  void calcMotionGradient(Mat mhi, Mat& mask, Mat& orientation, double delta1, double delta2, int apertureSize = 3)
		[DllImport("opencvforunity")]
		private static extern void optflow_Optflow_calcMotionGradient_10 (IntPtr mhi_nativeObj, IntPtr mask_nativeObj, IntPtr orientation_nativeObj, double delta1, double delta2, int apertureSize);

		[DllImport("opencvforunity")]
		private static extern void optflow_Optflow_calcMotionGradient_11 (IntPtr mhi_nativeObj, IntPtr mask_nativeObj, IntPtr orientation_nativeObj, double delta1, double delta2);
	
		// C++:  void updateMotionHistory(Mat silhouette, Mat& mhi, double timestamp, double duration)
		[DllImport("opencvforunity")]
		private static extern void optflow_Optflow_updateMotionHistory_10 (IntPtr silhouette_nativeObj, IntPtr mhi_nativeObj, double timestamp, double duration);
	
		// C++:  double calcGlobalOrientation(Mat orientation, Mat mask, Mat mhi, double timestamp, double duration)
		[DllImport("opencvforunity")]
		private static extern double optflow_Optflow_calcGlobalOrientation_10 (IntPtr orientation_nativeObj, IntPtr mask_nativeObj, IntPtr mhi_nativeObj, double timestamp, double duration);
	
		// C++:  void segmentMotion(Mat mhi, Mat& segmask, vector_Rect& boundingRects, double timestamp, double segThresh)
		[DllImport("opencvforunity")]
		private static extern void optflow_Optflow_segmentMotion_10 (IntPtr mhi_nativeObj, IntPtr segmask_nativeObj, IntPtr boundingRects_mat_nativeObj, double timestamp, double segThresh);
		#endif
	}
}
