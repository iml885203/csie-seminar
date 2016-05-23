
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class VideoCapture
//javadoc: VideoCapture
		public class VideoCapture : DisposableOpenCVObject
		{
	
				protected override void Dispose (bool disposing)
				{
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						try {
				
								if (disposing) {
								}
				
								if (IsEnabledDispose) {
										if (nativeObj != IntPtr.Zero)
												videoio_VideoCapture_delete (nativeObj);
										nativeObj = IntPtr.Zero;
								}
				
						} finally {
								base.Dispose (disposing);
						}
			
						#else
			return;
						#endif
				}
		
				protected VideoCapture (IntPtr addr) : base(addr)
				{
			
				}
	
	
				//
				// C++:   VideoCapture()
				//
	
				//javadoc: VideoCapture::VideoCapture()
				public   VideoCapture ()
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						nativeObj = videoio_VideoCapture_VideoCapture_10 ();
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:   VideoCapture(String filename)
				//
	
				//javadoc: VideoCapture::VideoCapture(filename)
				public   VideoCapture (string filename)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						nativeObj = videoio_VideoCapture_VideoCapture_11 (filename);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:   VideoCapture(int device)
				//
	
				//javadoc: VideoCapture::VideoCapture(device)
				//[Android]No support for Android.
				public   VideoCapture (int device)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						nativeObj = videoio_VideoCapture_VideoCapture_12 (device);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  bool open(String filename)
				//
	
				//javadoc: VideoCapture::open(filename)
				public  bool open (string filename)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = videoio_VideoCapture_open_10 (nativeObj, filename);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  bool open(int device)
				//
	
				//javadoc: VideoCapture::open(device)
				//[Android]No support for Android.
				public  bool open (int device)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = videoio_VideoCapture_open_11 (nativeObj, device);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  bool isOpened()
				//
	
				//javadoc: VideoCapture::isOpened()
				public  bool isOpened ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = videoio_VideoCapture_isOpened_10 (nativeObj);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  void release()
				//
	
				//javadoc: VideoCapture::release()
				public  void release ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						videoio_VideoCapture_release_10 (nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  bool grab()
				//
	
				//javadoc: VideoCapture::grab()
				public  bool grab ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = videoio_VideoCapture_grab_10 (nativeObj);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  bool retrieve(Mat& image, int flag = 0)
				//
	
				//javadoc: VideoCapture::retrieve(image, flag)
				public  bool retrieve (Mat image, int flag)
				{
						ThrowIfDisposed ();
						if (image != null)
								image.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = videoio_VideoCapture_retrieve_10 (nativeObj, image.nativeObj, flag);
		
						return retVal;
#else
return false;
#endif
				}
	
				//javadoc: VideoCapture::retrieve(image)
				public  bool retrieve (Mat image)
				{
						ThrowIfDisposed ();
						if (image != null)
								image.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = videoio_VideoCapture_retrieve_11 (nativeObj, image.nativeObj);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  bool read(Mat& image)
				//
	
				//javadoc: VideoCapture::read(image)
				public  bool read (Mat image)
				{
						ThrowIfDisposed ();
						if (image != null)
								image.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = videoio_VideoCapture_read_10 (nativeObj, image.nativeObj);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  bool set(int propId, double value)
				//
	
				//javadoc: VideoCapture::set(propId, value)
				public  bool set (int propId, double value)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bool retVal = videoio_VideoCapture_set_10 (nativeObj, propId, value);
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  double get(int propId)
				//
	
				//javadoc: VideoCapture::get(propId)
				public  double get (int propId)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						double retVal = videoio_VideoCapture_get_10 (nativeObj, propId);
		
						return retVal;
#else
return -1;
#endif
				}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:   VideoCapture()
		[DllImport("__Internal")]
		private static extern IntPtr videoio_VideoCapture_VideoCapture_10 ();
		
		// C++:   VideoCapture(String filename)
		[DllImport("__Internal")]
		private static extern IntPtr videoio_VideoCapture_VideoCapture_11 (string filename);
		
		// C++:   VideoCapture(int device)
		[DllImport("__Internal")]
		private static extern IntPtr videoio_VideoCapture_VideoCapture_12 (int device);
		
		// C++:  bool open(String filename)
		[DllImport("__Internal")]
		private static extern bool videoio_VideoCapture_open_10 (IntPtr nativeObj, string filename);
		
		// C++:  bool open(int device)
		[DllImport("__Internal")]
		private static extern bool videoio_VideoCapture_open_11 (IntPtr nativeObj, int device);
		
		// C++:  bool isOpened()
		[DllImport("__Internal")]
		private static extern bool videoio_VideoCapture_isOpened_10 (IntPtr nativeObj);
		
		// C++:  void release()
		[DllImport("__Internal")]
		private static extern void videoio_VideoCapture_release_10 (IntPtr nativeObj);
		
		// C++:  bool grab()
		[DllImport("__Internal")]
		private static extern bool videoio_VideoCapture_grab_10 (IntPtr nativeObj);
		
		// C++:  bool retrieve(Mat& image, int flag = 0)
		[DllImport("__Internal")]
		private static extern bool videoio_VideoCapture_retrieve_10 (IntPtr nativeObj, IntPtr image_nativeObj, int flag);
		
		[DllImport("__Internal")]
		private static extern bool videoio_VideoCapture_retrieve_11 (IntPtr nativeObj, IntPtr image_nativeObj);
		
		// C++:  bool read(Mat& image)
		[DllImport("__Internal")]
		private static extern bool videoio_VideoCapture_read_10 (IntPtr nativeObj, IntPtr image_nativeObj);
		
		// C++:  bool set(int propId, double value)
		[DllImport("__Internal")]
		private static extern bool videoio_VideoCapture_set_10 (IntPtr nativeObj, int propId, double value);
		
		// C++:  double get(int propId)
		[DllImport("__Internal")]
		private static extern double videoio_VideoCapture_get_10 (IntPtr nativeObj, int propId);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void videoio_VideoCapture_delete (IntPtr nativeObj);
#else
				// C++:   VideoCapture()
				[DllImport("opencvforunity")]
				private static extern IntPtr videoio_VideoCapture_VideoCapture_10 ();
	
				// C++:   VideoCapture(String filename)
				[DllImport("opencvforunity")]
				private static extern IntPtr videoio_VideoCapture_VideoCapture_11 (string filename);
	
				// C++:   VideoCapture(int device)
				[DllImport("opencvforunity")]
				private static extern IntPtr videoio_VideoCapture_VideoCapture_12 (int device);
	
				// C++:  bool open(String filename)
				[DllImport("opencvforunity")]
				private static extern bool videoio_VideoCapture_open_10 (IntPtr nativeObj, string filename);
	
				// C++:  bool open(int device)
				[DllImport("opencvforunity")]
				private static extern bool videoio_VideoCapture_open_11 (IntPtr nativeObj, int device);
	
				// C++:  bool isOpened()
				[DllImport("opencvforunity")]
				private static extern bool videoio_VideoCapture_isOpened_10 (IntPtr nativeObj);
	
				// C++:  void release()
				[DllImport("opencvforunity")]
				private static extern void videoio_VideoCapture_release_10 (IntPtr nativeObj);
	
				// C++:  bool grab()
				[DllImport("opencvforunity")]
				private static extern bool videoio_VideoCapture_grab_10 (IntPtr nativeObj);
	
				// C++:  bool retrieve(Mat& image, int flag = 0)
				[DllImport("opencvforunity")]
				private static extern bool videoio_VideoCapture_retrieve_10 (IntPtr nativeObj, IntPtr image_nativeObj, int flag);

				[DllImport("opencvforunity")]
				private static extern bool videoio_VideoCapture_retrieve_11 (IntPtr nativeObj, IntPtr image_nativeObj);
	
				// C++:  bool read(Mat& image)
				[DllImport("opencvforunity")]
				private static extern bool videoio_VideoCapture_read_10 (IntPtr nativeObj, IntPtr image_nativeObj);
	
				// C++:  bool set(int propId, double value)
				[DllImport("opencvforunity")]
				private static extern bool videoio_VideoCapture_set_10 (IntPtr nativeObj, int propId, double value);
	
				// C++:  double get(int propId)
				[DllImport("opencvforunity")]
				private static extern double videoio_VideoCapture_get_10 (IntPtr nativeObj, int propId);
	
				// native support for java finalize()
				[DllImport("opencvforunity")]
				private static extern void videoio_VideoCapture_delete (IntPtr nativeObj);
#endif
		}
}