
//
// This file is auto-generated. Please don't modify it!
//
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenCVForUnity
{

// C++: class Subdiv2D
//javadoc: Subdiv2D
		public class Subdiv2D : DisposableOpenCVObject
		{

				protected override void Dispose (bool disposing)
				{
						#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR) || UNITY_5
			
			try {
				
				if (disposing) {
				}
				
				if (IsEnabledDispose) {
					if (nativeObj != IntPtr.Zero)
						imgproc_Subdiv2D_delete (nativeObj);
					nativeObj = IntPtr.Zero;
				}
				
			} finally {
				base.Dispose (disposing);
			}
			
						#else
						return;
						#endif
				}
		
				protected Subdiv2D (IntPtr addr) : base(addr)
				{
			
				}

				public const int
						PTLOC_ERROR = -2,
						PTLOC_OUTSIDE_RECT = -1,
						PTLOC_INSIDE = 0,
						PTLOC_VERTEX = 1,
						PTLOC_ON_EDGE = 2,
						NEXT_AROUND_ORG = 0x00,
						NEXT_AROUND_DST = 0x22,
						PREV_AROUND_ORG = 0x11,
						PREV_AROUND_DST = 0x33,
						NEXT_AROUND_LEFT = 0x13,
						NEXT_AROUND_RIGHT = 0x31,
						PREV_AROUND_LEFT = 0x20,
						PREV_AROUND_RIGHT = 0x02;


				//
				// C++:   Subdiv2D(Rect rect)
				//

				//javadoc: Subdiv2D::Subdiv2D(rect)
				public   Subdiv2D (Rect rect)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						nativeObj = imgproc_Subdiv2D_Subdiv2D_10 (rect.x, rect.y, rect.width, rect.height);
        
						return;
#else
						return;
#endif
				}


				//
				// C++:   Subdiv2D()
				//

				//javadoc: Subdiv2D::Subdiv2D()
				public   Subdiv2D ()
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						nativeObj = imgproc_Subdiv2D_Subdiv2D_11 ();
        
						return;
#else
						return;
#endif
				}


				//
				// C++:  Point2f getVertex(int vertex, int* firstEdge = 0)
				//

				//javadoc: Subdiv2D::getVertex(vertex, firstEdge)
				public  Point getVertex (int vertex, int[] firstEdge)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
						double[] firstEdge_out = new double[1];
						double[] tmpArray = new double[2];
			
						imgproc_Subdiv2D_getVertex_10 (nativeObj, vertex, firstEdge_out, tmpArray);
			
						Point retVal = new Point (tmpArray);
						if (firstEdge != null)
								firstEdge [0] = (int)firstEdge_out [0];
						return retVal;
#else
						return null;
#endif
				}

				//javadoc: Subdiv2D::getVertex(vertex)
				public  Point getVertex (int vertex)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						double[] tmpArray = new double[2];
			
						imgproc_Subdiv2D_getVertex_11 (nativeObj, vertex, tmpArray);
			
						Point retVal = new Point (tmpArray);
			
						return retVal;
#else
						return null;
#endif
				}


				//
				// C++:  int getEdge(int edge, int nextEdgeType)
				//

				//javadoc: Subdiv2D::getEdge(edge, nextEdgeType)
				public  int getEdge (int edge, int nextEdgeType)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						int retVal = imgproc_Subdiv2D_getEdge_10 (nativeObj, edge, nextEdgeType);
        
						return retVal;
#else
						return -1;
#endif
				}


				//
				// C++:  int nextEdge(int edge)
				//

				//javadoc: Subdiv2D::nextEdge(edge)
				public  int nextEdge (int edge)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						int retVal = imgproc_Subdiv2D_nextEdge_10 (nativeObj, edge);
        
						return retVal;
#else
						return -1;
#endif
				}


				//
				// C++:  int rotateEdge(int edge, int rotate)
				//

				//javadoc: Subdiv2D::rotateEdge(edge, rotate)
				public  int rotateEdge (int edge, int rotate)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						int retVal = imgproc_Subdiv2D_rotateEdge_10 (nativeObj, edge, rotate);
        
						return retVal;
#else
						return -1;
#endif
				}


				//
				// C++:  int symEdge(int edge)
				//

				//javadoc: Subdiv2D::symEdge(edge)
				public  int symEdge (int edge)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						int retVal = imgproc_Subdiv2D_symEdge_10 (nativeObj, edge);
        
						return retVal;
#else
						return -1;
#endif
				}


				//
				// C++:  int edgeOrg(int edge, Point2f* orgpt = 0)
				//

				//javadoc: Subdiv2D::edgeOrg(edge, orgpt)
				public  int edgeOrg (int edge, Point orgpt)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
						double[] orgpt_out = new double[2];
						int retVal = imgproc_Subdiv2D_edgeOrg_10 (nativeObj, edge, orgpt_out);
						if (orgpt != null) {
								orgpt.x = orgpt_out [0];
								orgpt.y = orgpt_out [1];
						} 
						return retVal;
#else
						return -1;
#endif
				}

				//javadoc: Subdiv2D::edgeOrg(edge)
				public  int edgeOrg (int edge)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						int retVal = imgproc_Subdiv2D_edgeOrg_11 (nativeObj, edge);
        
						return retVal;
#else
						return -1;
#endif
				}


				//
				// C++:  int edgeDst(int edge, Point2f* dstpt = 0)
				//

				//javadoc: Subdiv2D::edgeDst(edge, dstpt)
				public  int edgeDst (int edge, Point dstpt)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
						double[] dstpt_out = new double[2];
						int retVal = imgproc_Subdiv2D_edgeDst_10 (nativeObj, edge, dstpt_out);
						if (dstpt != null) {
								dstpt.x = dstpt_out [0];
								dstpt.y = dstpt_out [1];
						} 
						return retVal;
#else
						return -1;
#endif
				}

				//javadoc: Subdiv2D::edgeDst(edge)
				public  int edgeDst (int edge)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						int retVal = imgproc_Subdiv2D_edgeDst_11 (nativeObj, edge);
        
						return retVal;
#else
						return -1;
#endif
				}


				//
				// C++:  void getVoronoiFacetList(vector_int idx, vector_vector_Point2f& facetList, vector_Point2f& facetCenters)
				//

				//javadoc: Subdiv2D::getVoronoiFacetList(idx, facetList, facetCenters)
				public  void getVoronoiFacetList (MatOfInt idx, List<MatOfPoint2f> facetList, MatOfPoint2f facetCenters)
				{
						if (idx != null)
								idx.ThrowIfDisposed ();
						if (facetCenters != null)
								facetCenters.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
						Mat idx_mat = idx;
						Mat facetList_mat = new Mat ();
						Mat facetCenters_mat = facetCenters;
						imgproc_Subdiv2D_getVoronoiFacetList_10 (nativeObj, idx_mat.nativeObj, facetList_mat.nativeObj, facetCenters_mat.nativeObj);
						Converters.Mat_to_vector_vector_Point2f (facetList_mat, facetList);
						facetList_mat.release ();
						return;
#else
						return;
#endif
				}


				//
				// C++:  void insert(vector_Point2f ptvec)
				//

				//javadoc: Subdiv2D::insert(ptvec)
				public  void insert (MatOfPoint2f ptvec)
				{
						if (ptvec != null)
								ptvec.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
						Mat ptvec_mat = ptvec;
						imgproc_Subdiv2D_insert_10 (nativeObj, ptvec_mat.nativeObj);
        
						return;
#else
						return;
#endif
				}


				//
				// C++:  int insert(Point2f pt)
				//

				//javadoc: Subdiv2D::insert(pt)
				public  int insert (Point pt)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						int retVal = imgproc_Subdiv2D_insert_11 (nativeObj, pt.x, pt.y);
        
						return retVal;
#else
						return -1;
#endif
				}


				//
				// C++:  void initDelaunay(Rect rect)
				//

				//javadoc: Subdiv2D::initDelaunay(rect)
				public  void initDelaunay (Rect rect)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						imgproc_Subdiv2D_initDelaunay_10 (nativeObj, rect.x, rect.y, rect.width, rect.height);
        
						return;
#else
						return;
#endif
				}


				//
				// C++:  int findNearest(Point2f pt, Point2f* nearestPt = 0)
				//

				//javadoc: Subdiv2D::findNearest(pt, nearestPt)
				public  int findNearest (Point pt, Point nearestPt)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
						double[] nearestPt_out = new double[2];
						int retVal = imgproc_Subdiv2D_findNearest_10 (nativeObj, pt.x, pt.y, nearestPt_out);
						if (nearestPt != null) {
								nearestPt.x = nearestPt_out [0];
								nearestPt.y = nearestPt_out [1];
						} 
						return retVal;
#else
						return -1;
#endif
				}

				//javadoc: Subdiv2D::findNearest(pt)
				public  int findNearest (Point pt)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
        
						int retVal = imgproc_Subdiv2D_findNearest_11 (nativeObj, pt.x, pt.y);
        
						return retVal;
#else
						return -1;
#endif
				}


				//
				// C++:  int locate(Point2f pt, int& edge, int& vertex)
				//

				//javadoc: Subdiv2D::locate(pt, edge, vertex)
				public  int locate (Point pt, int[] edge, int[] vertex)
				{
#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
						double[] edge_out = new double[1];
						double[] vertex_out = new double[1];
						int retVal = imgproc_Subdiv2D_locate_10 (nativeObj, pt.x, pt.y, edge_out, vertex_out);
						if (edge != null)
								edge [0] = (int)edge_out [0];
						if (vertex != null)
								vertex [0] = (int)vertex_out [0];
						return retVal;
#else
						return -1;
#endif
				}


				//
				// C++:  void getEdgeList(vector_Vec4f& edgeList)
				//

				//javadoc: Subdiv2D::getEdgeList(edgeList)
				public  void getEdgeList (MatOfFloat4 edgeList)
				{
						if (edgeList != null)
								edgeList.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
						Mat edgeList_mat = edgeList;
						imgproc_Subdiv2D_getEdgeList_10 (nativeObj, edgeList_mat.nativeObj);
        
						return;
#else
						return;
#endif
				}


				//
				// C++:  void getTriangleList(vector_Vec6f& triangleList)
				//

				//javadoc: Subdiv2D::getTriangleList(triangleList)
				public  void getTriangleList (MatOfFloat6 triangleList)
				{
						if (triangleList != null)
								triangleList.ThrowIfDisposed ();

#if UNITY_PRO_LICENSE || ((UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR) || UNITY_5
						Mat triangleList_mat = triangleList;
						imgproc_Subdiv2D_getTriangleList_10 (nativeObj, triangleList_mat.nativeObj);
        
						return;
#else
						return;
#endif
				}




		#if UNITY_IOS && !UNITY_EDITOR
		// C++:   Subdiv2D(Rect rect)
		[DllImport("__Internal")]
		private static extern IntPtr imgproc_Subdiv2D_Subdiv2D_10 (int rect_x, int rect_y, int rect_width, int rect_height);
		
		// C++:   Subdiv2D()
		[DllImport("__Internal")]
		private static extern IntPtr imgproc_Subdiv2D_Subdiv2D_11 ();
		
		// C++:  Point2f getVertex(int vertex, int* firstEdge = 0)
		[DllImport("__Internal")]
		private static extern void imgproc_Subdiv2D_getVertex_10 (IntPtr nativeObj, int vertex, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] firstEdge_out, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);
		
		[DllImport("__Internal")]
		private static extern void imgproc_Subdiv2D_getVertex_11 (IntPtr nativeObj, int vertex, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);
		
		// C++:  int getEdge(int edge, int nextEdgeType)
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_getEdge_10 (IntPtr nativeObj, int edge, int nextEdgeType);
		
		// C++:  int nextEdge(int edge)
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_nextEdge_10 (IntPtr nativeObj, int edge);
		
		// C++:  int rotateEdge(int edge, int rotate)
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_rotateEdge_10 (IntPtr nativeObj, int edge, int rotate);
		
		// C++:  int symEdge(int edge)
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_symEdge_10 (IntPtr nativeObj, int edge);
		
		// C++:  int edgeOrg(int edge, Point2f* orgpt = 0)
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_edgeOrg_10 (IntPtr nativeObj, int edge, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] orgpt_out);
		
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_edgeOrg_11 (IntPtr nativeObj, int edge);
		
		// C++:  int edgeDst(int edge, Point2f* dstpt = 0)
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_edgeDst_10 (IntPtr nativeObj, int edge, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] dstpt_out);
		
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_edgeDst_11 (IntPtr nativeObj, int edge);
		
		// C++:  void getVoronoiFacetList(vector_int idx, vector_vector_Point2f& facetList, vector_Point2f& facetCenters)
		[DllImport("__Internal")]
		private static extern void imgproc_Subdiv2D_getVoronoiFacetList_10 (IntPtr nativeObj, IntPtr idx_mat_nativeObj, IntPtr facetList_mat_nativeObj, IntPtr facetCenters_mat_nativeObj);
		
		// C++:  void insert(vector_Point2f ptvec)
		[DllImport("__Internal")]
		private static extern void imgproc_Subdiv2D_insert_10 (IntPtr nativeObj, IntPtr ptvec_mat_nativeObj);
		
		// C++:  int insert(Point2f pt)
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_insert_11 (IntPtr nativeObj, double pt_x, double pt_y);
		
		// C++:  void initDelaunay(Rect rect)
		[DllImport("__Internal")]
		private static extern void imgproc_Subdiv2D_initDelaunay_10 (IntPtr nativeObj, int rect_x, int rect_y, int rect_width, int rect_height);
		
		// C++:  int findNearest(Point2f pt, Point2f* nearestPt = 0)
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_findNearest_10 (IntPtr nativeObj, double pt_x, double pt_y, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] nearestPt_out);
		
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_findNearest_11 (IntPtr nativeObj, double pt_x, double pt_y);
		
		// C++:  int locate(Point2f pt, int& edge, int& vertex)
		[DllImport("__Internal")]
		private static extern int imgproc_Subdiv2D_locate_10 (IntPtr nativeObj, double pt_x, double pt_y, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] double[] edge_out, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] double[] vertex_out);
		
		// C++:  void getEdgeList(vector_Vec4f& edgeList)
		[DllImport("__Internal")]
		private static extern void imgproc_Subdiv2D_getEdgeList_10 (IntPtr nativeObj, IntPtr edgeList_mat_nativeObj);
		
		// C++:  void getTriangleList(vector_Vec6f& triangleList)
		[DllImport("__Internal")]
		private static extern void imgproc_Subdiv2D_getTriangleList_10 (IntPtr nativeObj, IntPtr triangleList_mat_nativeObj);
		
		// native support for java finalize()
		[DllImport("__Internal")]
		private static extern void imgproc_Subdiv2D_delete (IntPtr nativeObj);
		#else

				// C++:   Subdiv2D(Rect rect)
				[DllImport("opencvforunity")]
				private static extern IntPtr imgproc_Subdiv2D_Subdiv2D_10 (int rect_x, int rect_y, int rect_width, int rect_height);

				// C++:   Subdiv2D()
				[DllImport("opencvforunity")]
				private static extern IntPtr imgproc_Subdiv2D_Subdiv2D_11 ();

				// C++:  Point2f getVertex(int vertex, int* firstEdge = 0)
				[DllImport("opencvforunity")]
				private static extern void imgproc_Subdiv2D_getVertex_10 (IntPtr nativeObj, int vertex, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] firstEdge_out, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);

				[DllImport("opencvforunity")]
				private static extern void imgproc_Subdiv2D_getVertex_11 (IntPtr nativeObj, int vertex, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] vals);

				// C++:  int getEdge(int edge, int nextEdgeType)
				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_getEdge_10 (IntPtr nativeObj, int edge, int nextEdgeType);

				// C++:  int nextEdge(int edge)
				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_nextEdge_10 (IntPtr nativeObj, int edge);

				// C++:  int rotateEdge(int edge, int rotate)
				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_rotateEdge_10 (IntPtr nativeObj, int edge, int rotate);

				// C++:  int symEdge(int edge)
				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_symEdge_10 (IntPtr nativeObj, int edge);

				// C++:  int edgeOrg(int edge, Point2f* orgpt = 0)
				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_edgeOrg_10 (IntPtr nativeObj, int edge, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] orgpt_out);

				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_edgeOrg_11 (IntPtr nativeObj, int edge);

				// C++:  int edgeDst(int edge, Point2f* dstpt = 0)
				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_edgeDst_10 (IntPtr nativeObj, int edge, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] dstpt_out);

				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_edgeDst_11 (IntPtr nativeObj, int edge);

				// C++:  void getVoronoiFacetList(vector_int idx, vector_vector_Point2f& facetList, vector_Point2f& facetCenters)
				[DllImport("opencvforunity")]
				private static extern void imgproc_Subdiv2D_getVoronoiFacetList_10 (IntPtr nativeObj, IntPtr idx_mat_nativeObj, IntPtr facetList_mat_nativeObj, IntPtr facetCenters_mat_nativeObj);

				// C++:  void insert(vector_Point2f ptvec)
				[DllImport("opencvforunity")]
				private static extern void imgproc_Subdiv2D_insert_10 (IntPtr nativeObj, IntPtr ptvec_mat_nativeObj);

				// C++:  int insert(Point2f pt)
				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_insert_11 (IntPtr nativeObj, double pt_x, double pt_y);

				// C++:  void initDelaunay(Rect rect)
				[DllImport("opencvforunity")]
				private static extern void imgproc_Subdiv2D_initDelaunay_10 (IntPtr nativeObj, int rect_x, int rect_y, int rect_width, int rect_height);

				// C++:  int findNearest(Point2f pt, Point2f* nearestPt = 0)
				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_findNearest_10 (IntPtr nativeObj, double pt_x, double pt_y, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] double[] nearestPt_out);

				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_findNearest_11 (IntPtr nativeObj, double pt_x, double pt_y);

				// C++:  int locate(Point2f pt, int& edge, int& vertex)
				[DllImport("opencvforunity")]
				private static extern int imgproc_Subdiv2D_locate_10 (IntPtr nativeObj, double pt_x, double pt_y, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] double[] edge_out, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] double[] vertex_out);

				// C++:  void getEdgeList(vector_Vec4f& edgeList)
				[DllImport("opencvforunity")]
				private static extern void imgproc_Subdiv2D_getEdgeList_10 (IntPtr nativeObj, IntPtr edgeList_mat_nativeObj);

				// C++:  void getTriangleList(vector_Vec6f& triangleList)
				[DllImport("opencvforunity")]
				private static extern void imgproc_Subdiv2D_getTriangleList_10 (IntPtr nativeObj, IntPtr triangleList_mat_nativeObj);

				// native support for java finalize()
				[DllImport("opencvforunity")]
				private static extern void imgproc_Subdiv2D_delete (IntPtr nativeObj);

#endif
		}
}
