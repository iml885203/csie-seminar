
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{


// C++: class FaceRecognizer
//javadoc: FaceRecognizer
	public class FaceRecognizer : Algorithm
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						face_FaceRecognizer_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		protected FaceRecognizer (IntPtr addr) : base(addr)
		{
		}
	
	
		//
		// C++:  void train(vector_Mat src, Mat labels)
		//
	
		//javadoc: FaceRecognizer::train(src, labels)
		public  void train (List<Mat> src, Mat labels)
		{
			ThrowIfDisposed ();
			if (labels != null)
				labels.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat src_mat = Converters.vector_Mat_to_Mat (src);
			face_FaceRecognizer_train_10 (nativeObj, src_mat.nativeObj, labels.nativeObj);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void update(vector_Mat src, Mat labels)
		//
	
		//javadoc: FaceRecognizer::update(src, labels)
		public  void update (List<Mat> src, Mat labels)
		{
			ThrowIfDisposed ();
			if (labels != null)
				labels.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			Mat src_mat = Converters.vector_Mat_to_Mat (src);
			face_FaceRecognizer_update_10 (nativeObj, src_mat.nativeObj, labels.nativeObj);
		
			return;
#else
return;
#endif
		}

		//
		// C++:  void predict(Mat src, int& label, double& confidence)
		//
		
		//javadoc: FaceRecognizer::predict(src, label, confidence)
		public  void predict (Mat src, int[] label, double[] confidence)
		{
			ThrowIfDisposed ();
			if (src != null)
				src.ThrowIfDisposed ();
			
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			double[] label_out = new double[1];
			double[] confidence_out = new double[1];
			face_FaceRecognizer_predict_10 (nativeObj, src.nativeObj, label_out, confidence_out);
			if (label != null)
				label [0] = (int)label_out [0];
			if (confidence != null)
				confidence [0] = (double)confidence_out [0];
			return;
			#else
			return;
			#endif
		}
		
		
		//
		// C++:  void save(String filename)
		//
		
		//javadoc: FaceRecognizer::save(filename)
		public override void save (string filename)
		{
			ThrowIfDisposed ();
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			face_FaceRecognizer_save_10 (nativeObj, filename);
			
			return;
			#else
			return;
			#endif
		}

	
	
		//
		// C++:  void load(String filename)
		//
	
		//javadoc: FaceRecognizer::load(filename)
		public  void load (string filename)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			face_FaceRecognizer_load_10 (nativeObj, filename);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  void setLabelInfo(int label, String strInfo)
		//
	
		//javadoc: FaceRecognizer::setLabelInfo(label, strInfo)
		public  void setLabelInfo (int label, string strInfo)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			face_FaceRecognizer_setLabelInfo_10 (nativeObj, label, strInfo);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  String getLabelInfo(int label)
		//
	
		//javadoc: FaceRecognizer::getLabelInfo(label)
		public  string getLabelInfo (int label)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			string retVal = Marshal.PtrToStringAnsi (face_FaceRecognizer_getLabelInfo_10 (nativeObj, label));
		
			return retVal;
#else
return null;
#endif
		}
	
	
		//
		// C++:  vector_int getLabelsByString(String str)
		//
	
		//javadoc: FaceRecognizer::getLabelsByString(str)
		public  MatOfInt getLabelsByString (string str)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			MatOfInt retVal = MatOfInt.fromNativeAddr (face_FaceRecognizer_getLabelsByString_10 (nativeObj, str));
		
			return retVal;
#else
return null;
#endif
		}
	
	

	

	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  void train(vector_Mat src, Mat labels)
		[DllImport("__Internal")]
		private static extern void face_FaceRecognizer_train_10 (IntPtr nativeObj, IntPtr src_mat_nativeObj, IntPtr labels_nativeObj);
		
		// C++:  void update(vector_Mat src, Mat labels)
		[DllImport("__Internal")]
		private static extern void face_FaceRecognizer_update_10 (IntPtr nativeObj, IntPtr src_mat_nativeObj, IntPtr labels_nativeObj);

		// C++:  void predict(Mat src, int& label, double& confidence)
		[DllImport("__Internal")]
		private static extern void face_FaceRecognizer_predict_10 (IntPtr nativeObj, IntPtr src_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] double[] label_out, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] double[] confidence_out);
		
		// C++:  void save(String filename)
		[DllImport("__Internal")]
		private static extern void face_FaceRecognizer_save_10 (IntPtr nativeObj, string filename);

		// C++:  void load(String filename)
		[DllImport("__Internal")]
		private static extern void face_FaceRecognizer_load_10 (IntPtr nativeObj, string filename);
		
		// C++:  void setLabelInfo(int label, String strInfo)
		[DllImport("__Internal")]
		private static extern void face_FaceRecognizer_setLabelInfo_10 (IntPtr nativeObj, int label, string strInfo);
		
		// C++:  String getLabelInfo(int label)
		[DllImport("__Internal")]
		private static extern IntPtr face_FaceRecognizer_getLabelInfo_10 (IntPtr nativeObj, int label);
		
		// C++:  vector_int getLabelsByString(String str)
		[DllImport("__Internal")]
		private static extern IntPtr face_FaceRecognizer_getLabelsByString_10 (IntPtr nativeObj, string str);
		

		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void face_FaceRecognizer_delete (IntPtr nativeObj);
#else
	
		// C++:  void train(vector_Mat src, Mat labels)
		[DllImport("opencvforunity")]
		private static extern void face_FaceRecognizer_train_10 (IntPtr nativeObj, IntPtr src_mat_nativeObj, IntPtr labels_nativeObj);
	
		// C++:  void update(vector_Mat src, Mat labels)
		[DllImport("opencvforunity")]
		private static extern void face_FaceRecognizer_update_10 (IntPtr nativeObj, IntPtr src_mat_nativeObj, IntPtr labels_nativeObj);
	
		// C++:  void predict(Mat src, int& label, double& confidence)
		[DllImport("opencvforunity")]
		private static extern void face_FaceRecognizer_predict_10 (IntPtr nativeObj, IntPtr src_nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] double[] label_out, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] double[] confidence_out);
		
		// C++:  void save(String filename)
		[DllImport("opencvforunity")]
		private static extern void face_FaceRecognizer_save_10 (IntPtr nativeObj, string filename);

		// C++:  void load(String filename)
		[DllImport("opencvforunity")]
		private static extern void face_FaceRecognizer_load_10 (IntPtr nativeObj, string filename);
	
		// C++:  void setLabelInfo(int label, String strInfo)
		[DllImport("opencvforunity")]
		private static extern void face_FaceRecognizer_setLabelInfo_10 (IntPtr nativeObj, int label, string strInfo);
	
		// C++:  String getLabelInfo(int label)
		[DllImport("opencvforunity")]
		private static extern IntPtr face_FaceRecognizer_getLabelInfo_10 (IntPtr nativeObj, int label);
	
		// C++:  vector_int getLabelsByString(String str)
		[DllImport("opencvforunity")]
		private static extern IntPtr face_FaceRecognizer_getLabelsByString_10 (IntPtr nativeObj, string str);
	

	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void face_FaceRecognizer_delete (IntPtr nativeObj);
#endif
	
	}
}
