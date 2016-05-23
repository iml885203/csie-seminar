
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class TransientAreasSegmentationModule
//javadoc: TransientAreasSegmentationModule
		public class TransientAreasSegmentationModule : Algorithm
		{

				protected override void Dispose (bool disposing)
				{
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
						try {
				
								if (disposing) {
								}
				
								if (IsEnabledDispose) {
										if (nativeObj != IntPtr.Zero)
												bioinspired_TransientAreasSegmentationModule_delete (nativeObj);
										nativeObj = IntPtr.Zero;
								}
				
						} finally {
								base.Dispose (disposing);
						}
			
						#else
			return;
						#endif
				}

				public TransientAreasSegmentationModule (IntPtr addr) : base(addr)
				{
				}
	
	
				//
				// C++:  void setup(String segmentationParameterFile = "", bool applyDefaultSetupOnFailure = true)
				//
	
				//javadoc: TransientAreasSegmentationModule::setup(segmentationParameterFile, applyDefaultSetupOnFailure)
				public  void setup (string segmentationParameterFile, bool applyDefaultSetupOnFailure)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bioinspired_TransientAreasSegmentationModule_setup_10 (nativeObj, segmentationParameterFile, applyDefaultSetupOnFailure);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: TransientAreasSegmentationModule::setup()
				public  void setup ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bioinspired_TransientAreasSegmentationModule_setup_11 (nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  String printSetup()
				//
	
				//javadoc: TransientAreasSegmentationModule::printSetup()
				public  string printSetup ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						string retVal = Marshal.PtrToStringAnsi (bioinspired_TransientAreasSegmentationModule_printSetup_10 (nativeObj));
		
						return retVal;
#else
return false;
#endif
				}
	
	
				//
				// C++:  void run(Mat inputToSegment, int channelIndex = 0)
				//
	
				//javadoc: TransientAreasSegmentationModule::run(inputToSegment, channelIndex)
				public  void run (Mat inputToSegment, int channelIndex)
				{
						ThrowIfDisposed ();
						if (inputToSegment != null)
								inputToSegment.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bioinspired_TransientAreasSegmentationModule_run_10 (nativeObj, inputToSegment.nativeObj, channelIndex);
		
						return;
#else
return;
#endif
				}
	
				//javadoc: TransientAreasSegmentationModule::run(inputToSegment)
				public  void run (Mat inputToSegment)
				{
						ThrowIfDisposed ();
						if (inputToSegment != null)
								inputToSegment.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bioinspired_TransientAreasSegmentationModule_run_11 (nativeObj, inputToSegment.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void write(String fs)
				//
	
				//javadoc: TransientAreasSegmentationModule::write(fs)
				public  void write (string fs)
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bioinspired_TransientAreasSegmentationModule_write_10 (nativeObj, fs);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void getSegmentationPicture(Mat& transientAreas)
				//
	
				//javadoc: TransientAreasSegmentationModule::getSegmentationPicture(transientAreas)
				public  void getSegmentationPicture (Mat transientAreas)
				{
						ThrowIfDisposed ();
						if (transientAreas != null)
								transientAreas.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bioinspired_TransientAreasSegmentationModule_getSegmentationPicture_10 (nativeObj, transientAreas.nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  void clearAllBuffers()
				//
	
				//javadoc: TransientAreasSegmentationModule::clearAllBuffers()
				public  void clearAllBuffers ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
						bioinspired_TransientAreasSegmentationModule_clearAllBuffers_10 (nativeObj);
		
						return;
#else
return;
#endif
				}
	
	
				//
				// C++:  Size getSize()
				//
	
				//javadoc: TransientAreasSegmentationModule::getSize()
				public  Size getSize ()
				{
						ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
						double[] tmpArray = new double[2];
						bioinspired_TransientAreasSegmentationModule_getSize_10 (nativeObj, tmpArray);
						Size retVal = new Size (tmpArray);
						
		
						return retVal;
#else
return false;
#endif
				}
	
	

	
	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  void setup(String segmentationParameterFile = "", bool applyDefaultSetupOnFailure = true)
		[DllImport("__Internal")]
		private static extern void bioinspired_TransientAreasSegmentationModule_setup_10 (IntPtr nativeObj, string segmentationParameterFile, bool applyDefaultSetupOnFailure);
		
		[DllImport("__Internal")]
		private static extern void bioinspired_TransientAreasSegmentationModule_setup_11 (IntPtr nativeObj);
		
		// C++:  String printSetup()
		[DllImport("__Internal")]
		private static extern IntPtr bioinspired_TransientAreasSegmentationModule_printSetup_10 (IntPtr nativeObj);
		
		// C++:  void run(Mat inputToSegment, int channelIndex = 0)
		[DllImport("__Internal")]
		private static extern void bioinspired_TransientAreasSegmentationModule_run_10 (IntPtr nativeObj, IntPtr inputToSegment_nativeObj, int channelIndex);
		
		[DllImport("__Internal")]
		private static extern void bioinspired_TransientAreasSegmentationModule_run_11 (IntPtr nativeObj, IntPtr inputToSegment_nativeObj);
		
		// C++:  void write(String fs)
		[DllImport("__Internal")]
		private static extern void bioinspired_TransientAreasSegmentationModule_write_10 (IntPtr nativeObj, string fs);
		
		// C++:  void getSegmentationPicture(Mat& transientAreas)
		[DllImport("__Internal")]
		private static extern void bioinspired_TransientAreasSegmentationModule_getSegmentationPicture_10 (IntPtr nativeObj, IntPtr transientAreas_nativeObj);
		
		// C++:  void clearAllBuffers()
		[DllImport("__Internal")]
		private static extern void bioinspired_TransientAreasSegmentationModule_clearAllBuffers_10 (IntPtr nativeObj);
		
		// C++:  Size getSize()
		[DllImport("__Internal")]
		private static extern void bioinspired_TransientAreasSegmentationModule_getSize_10 (IntPtr nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void bioinspired_TransientAreasSegmentationModule_delete (IntPtr nativeObj);
#else
				// C++:  void setup(String segmentationParameterFile = "", bool applyDefaultSetupOnFailure = true)
				[DllImport("opencvforunity")]
				private static extern void bioinspired_TransientAreasSegmentationModule_setup_10 (IntPtr nativeObj, string segmentationParameterFile, bool applyDefaultSetupOnFailure);

				[DllImport("opencvforunity")]
				private static extern void bioinspired_TransientAreasSegmentationModule_setup_11 (IntPtr nativeObj);
	
				// C++:  String printSetup()
				[DllImport("opencvforunity")]
				private static extern IntPtr bioinspired_TransientAreasSegmentationModule_printSetup_10 (IntPtr nativeObj);
	
				// C++:  void run(Mat inputToSegment, int channelIndex = 0)
				[DllImport("opencvforunity")]
				private static extern void bioinspired_TransientAreasSegmentationModule_run_10 (IntPtr nativeObj, IntPtr inputToSegment_nativeObj, int channelIndex);

				[DllImport("opencvforunity")]
				private static extern void bioinspired_TransientAreasSegmentationModule_run_11 (IntPtr nativeObj, IntPtr inputToSegment_nativeObj);
	
				// C++:  void write(String fs)
				[DllImport("opencvforunity")]
				private static extern void bioinspired_TransientAreasSegmentationModule_write_10 (IntPtr nativeObj, string fs);
	
				// C++:  void getSegmentationPicture(Mat& transientAreas)
				[DllImport("opencvforunity")]
				private static extern void bioinspired_TransientAreasSegmentationModule_getSegmentationPicture_10 (IntPtr nativeObj, IntPtr transientAreas_nativeObj);
	
				// C++:  void clearAllBuffers()
				[DllImport("opencvforunity")]
				private static extern void bioinspired_TransientAreasSegmentationModule_clearAllBuffers_10 (IntPtr nativeObj);
	
				// C++:  Size getSize()
				[DllImport("opencvforunity")]
				private static extern void bioinspired_TransientAreasSegmentationModule_getSize_10 (IntPtr nativeObj, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);
	
				// native support for java finalize()
				[DllImport("opencvforunity")]
				private static extern void bioinspired_TransientAreasSegmentationModule_delete (IntPtr nativeObj);
#endif
		}
}