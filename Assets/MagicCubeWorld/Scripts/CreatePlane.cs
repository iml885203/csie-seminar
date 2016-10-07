using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using System.Collections.Generic;

public class CreatePlane : MonoBehaviour
{
    //載入輸入深度資訊
    public DrawBlock _drawBlock;
    public Match _matchManage;
    public int lengthY; //網格的長
    public int lengthX; //寬
    public Material mat; //貼圖材質
    private Vector3[] matrix; //把網格中各點的座標存下來
    public Mesh mesh; //把建立的Mesh留下參照
    public float levelYPosition = 0; //網格的Y軸位置
    private GameObject newMesh;
    //轉換座標使用
    private clickPositionTrans _posTrans;

    void Start()
    {
        Create();
    }
    void Update()
    {
        //取得深度資料變動區塊資訊
        Mat _DepthMat = new Mat();
        if(_drawBlock.GetBlockDepthMat() != null)
        {
            _drawBlock.GetBlockDepthMat().copyTo(_DepthMat);
        }
        else
        {
            Debug.Log("Is null");
            return;
        }

        List<OpenCVForUnity.Rect> changeRectList = _matchManage._changeRectList;
        //轉換座標用
        _posTrans = new clickPositionTrans(_DepthMat.width(), _DepthMat.height(), lengthX, lengthY);
        //當發生變動更新Mesh
        if (_drawBlock._DepthImageChangeFlag)
        {
            UpdateMesh(changeRectList, _DepthMat);
            _drawBlock._DepthImageChangeFlag = false;
        }
    }
    void Create()
    {
        //建立網格點座標陣列
        matrix = new Vector3[lengthX * lengthY];
        for (int y = 0; y < lengthY; ++y)
        {
            for (int x = 0; x < lengthX; ++x)
            {
                matrix[y * lengthX + x] = new Vector3(((float)x) / 10, levelYPosition, ((float)y) / 10);
            }
        }

        //建立[vert][Normals][UVs]
        Vector3[] vertices = new Vector3[lengthX * lengthY];
        Vector3[] norms = new Vector3[lengthX * lengthY];
        Vector2[] UVs = new Vector2[lengthX * lengthY];

        for (int y = 0; y < lengthY; ++y)
        {
            for (int x = 0; x < lengthX; ++x)
            {
                vertices[y * lengthX + x] = matrix[y * lengthX + x];
                norms[y * lengthX + x] = Vector3.up;
                UVs[y * lengthX + x] = new Vector2((1 / (float)(lengthX - 1)) * x, (1 / (float)(lengthY - 1)) * y);
            }
        }

        //建立[Triangle]
        int[] triangles = new int[(lengthX - 1) * (lengthY - 1) * 6];
        int ind = 0;
        for (int y = 0; y < lengthY - 1; ++y)
        {
            for (int x = 0; x < lengthX - 1; ++x)
            {
                triangles[ind++] = y * lengthX + x;
                triangles[ind++] = (y + 1) * lengthX + (x + 1);
                triangles[ind++] = y * lengthX + (x + 1);
                triangles[ind++] = y * lengthX + x;
                triangles[ind++] = (y + 1) * lengthX + x;
                triangles[ind++] = (y + 1) * lengthX + (x + 1);
            }
        }

        //建立新的MeshRenderer並設定好材質
        newMesh = new GameObject();
        MeshRenderer mr = newMesh.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        mr.material = mat;

        MeshFilter mf = newMesh.AddComponent(typeof(MeshFilter)) as MeshFilter;
        mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.normals = norms;
        mesh.triangles = triangles;
        mesh.uv = UVs;
        mf.mesh = mesh;

        //把這個Mesh掛在當前物件底下
        newMesh.name = "DepthMesh";
        newMesh.transform.parent = this.transform;
        newMesh.transform.position = this.transform.position;
        newMesh.transform.rotation = this.transform.rotation;
        MeshCollider ms = newMesh.AddComponent(typeof(MeshCollider)) as MeshCollider;
    }
    void UpdateMesh(List<OpenCVForUnity.Rect> changeRectList, Mat srcMat)
    {
        matrix = new Vector3[lengthX * lengthY];
        for (int y = 0; y < lengthY; ++y)
        {
            for (int x = 0; x < lengthX; ++x)
            {
                matrix[y * lengthX + x] = new Vector3(((float)x) / 10, 0, ((float)y) / 10);
            }
        }

        for (int i = 0; i < changeRectList.Count; i++)
        {
            int minX = changeRectList[i].x;
            int minY = changeRectList[i].y;
            int maxX = changeRectList[i].x + changeRectList[i].width;
            int maxY = changeRectList[i].y + changeRectList[i].height;
            Vector2 pMin = _posTrans.TransToScreen2Pos(new Vector2(minX, minY));
            Vector2 pMax = _posTrans.TransToScreen2Pos(new Vector2(maxX, maxY));
            for (int y = (int)pMin.y; y < pMax.y; ++y)
            {
                for (int x = (int)pMin.x; x < pMax.x; ++x)
                {
                    //Vector2 nowPoint = _posTrans.TransToScreen1Pos(new Vector2(x, y));
                   // double[] Color = srcMat.get((int)nowPoint.x, (int)nowPoint.y);
                    //座標還有點問題 先開啟正方形 拿掉true就變成像素決定深度
                    if (true)//Color[0] > 0 ||true)
                    {
                        matrix[y * lengthX + x] = new Vector3(((float)x) / 10, 1, ((float)y) / 10);
                    }
                }
            }
        }


        //建立[vert][Normals][UVs]
        Vector3[] vertices = new Vector3[lengthX * lengthY];
        Vector3[] norms = new Vector3[lengthX * lengthY];
        Vector2[] UVs = new Vector2[lengthX * lengthY];

        for (int y = 0; y < lengthY; ++y)
        {
            for (int x = 0; x < lengthX; ++x)
            {
                vertices[y * lengthX + x] = matrix[y * lengthX + x];
                norms[y * lengthX + x] = Vector3.up;
                UVs[y * lengthX + x] = new Vector2((1 / (float)(lengthX - 1)) * x, (1 / (float)(lengthY - 1)) * y);
            }
        }

        //建立[Triangle]
        int[] triangles = new int[(lengthX - 1) * (lengthY - 1) * 6];
        int ind = 0;
        for (int y = 0; y < lengthY - 1; ++y)
        {
            for (int x = 0; x < lengthX - 1; ++x)
            {
                triangles[ind++] = y * lengthX + x;
                triangles[ind++] = (y + 1) * lengthX + (x + 1);
                triangles[ind++] = y * lengthX + (x + 1);
                triangles[ind++] = y * lengthX + x;
                triangles[ind++] = (y + 1) * lengthX + x;
                triangles[ind++] = (y + 1) * lengthX + (x + 1);
            }
        }
        mesh.vertices = vertices;
        mesh.normals = norms;
        mesh.triangles = triangles;
        mesh.uv = UVs;
        //奇怪的地方 一定要從從新開一次才有效
        newMesh.GetComponent<MeshCollider>().enabled = false;
        newMesh.GetComponent<MeshCollider>().enabled = true;
    }
}