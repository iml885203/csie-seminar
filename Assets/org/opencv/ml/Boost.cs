
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{



// C++: class Boost
//javadoc: Boost
	public class Boost : DTrees
	{

		protected override void Dispose (bool disposing)
		{
			#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						ml_Boost_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
			#else
			return;
			#endif
		}
		
		protected Boost (IntPtr addr) : base(addr)
		{
		}
	
		public const int
			DISCRETE = 0,
			REAL = 1,
			LOGIT = 2,
			GENTLE = 3;
	
	
		//
		// C++:  int getBoostType()
		//
	
		//javadoc: Boost::getBoostType()
		public  int getBoostType ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_Boost_getBoostType_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setBoostType(int val)
		//
	
		//javadoc: Boost::setBoostType(val)
		public  void setBoostType (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_Boost_setBoostType_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  int getWeakCount()
		//
	
		//javadoc: Boost::getWeakCount()
		public  int getWeakCount ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			int retVal = ml_Boost_getWeakCount_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setWeakCount(int val)
		//
	
		//javadoc: Boost::setWeakCount(val)
		public  void setWeakCount (int val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_Boost_setWeakCount_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++:  double getWeightTrimRate()
		//
	
		//javadoc: Boost::getWeightTrimRate()
		public  double getWeightTrimRate ()
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			double retVal = ml_Boost_getWeightTrimRate_10 (nativeObj);
		
			return retVal;
#else
return -1;
#endif
		}
	
	
		//
		// C++:  void setWeightTrimRate(double val)
		//
	
		//javadoc: Boost::setWeightTrimRate(val)
		public  void setWeightTrimRate (double val)
		{
			ThrowIfDisposed ();
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			ml_Boost_setWeightTrimRate_10 (nativeObj, val);
		
			return;
#else
return;
#endif
		}
	
	
		//
		// C++: static Ptr_Boost create()
		//
	
		//javadoc: Boost::create()
		#pragma warning disable 0108
		public static Boost create ()
		{
		#pragma warning restore 0067

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
		
			Boost retVal = new Boost (ml_Boost_create_10 ());
		
			return retVal;
#else
return null;
#endif
		}
	
	

	
		#if UNITY_IOS && !UNITY_EDITOR
		// C++:  int getBoostType()
		[DllImport("__Internal")]
		private static extern int ml_Boost_getBoostType_10 (IntPtr nativeObj);
		
		// C++:  void setBoostType(int val)
		[DllImport("__Internal")]
		private static extern void ml_Boost_setBoostType_10 (IntPtr nativeObj, int val);
		
		// C++:  int getWeakCount()
		[DllImport("__Internal")]
		private static extern int ml_Boost_getWeakCount_10 (IntPtr nativeObj);
		
		// C++:  void setWeakCount(int val)
		[DllImport("__Internal")]
		private static extern void ml_Boost_setWeakCount_10 (IntPtr nativeObj, int val);
		
		// C++:  double getWeightTrimRate()
		[DllImport("__Internal")]
		private static extern double ml_Boost_getWeightTrimRate_10 (IntPtr nativeObj);
		
		// C++:  void setWeightTrimRate(double val)
		[DllImport("__Internal")]
		private static extern void ml_Boost_setWeightTrimRate_10 (IntPtr nativeObj, double val);
		
		// C++: static Ptr_Boost create()
		[DllImport("__Internal")]
		private static extern IntPtr ml_Boost_create_10 ();
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void ml_Boost_delete (IntPtr nativeObj);
#else
	
		// C++:  int getBoostType()
		[DllImport("opencvforunity")]
		private static extern int ml_Boost_getBoostType_10 (IntPtr nativeObj);
	
		// C++:  void setBoostType(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_Boost_setBoostType_10 (IntPtr nativeObj, int val);
	
		// C++:  int getWeakCount()
		[DllImport("opencvforunity")]
		private static extern int ml_Boost_getWeakCount_10 (IntPtr nativeObj);
	
		// C++:  void setWeakCount(int val)
		[DllImport("opencvforunity")]
		private static extern void ml_Boost_setWeakCount_10 (IntPtr nativeObj, int val);
	
		// C++:  double getWeightTrimRate()
		[DllImport("opencvforunity")]
		private static extern double ml_Boost_getWeightTrimRate_10 (IntPtr nativeObj);
	
		// C++:  void setWeightTrimRate(double val)
		[DllImport("opencvforunity")]
		private static extern void ml_Boost_setWeightTrimRate_10 (IntPtr nativeObj, double val);
	
		// C++: static Ptr_Boost create()
		[DllImport("opencvforunity")]
		private static extern IntPtr ml_Boost_create_10 ();
	
		// native support for java finalize()
		[DllImport("opencvforunity")]
		private static extern void ml_Boost_delete (IntPtr nativeObj);
#endif
	
	}
}
