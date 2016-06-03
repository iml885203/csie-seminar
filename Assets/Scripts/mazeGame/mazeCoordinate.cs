using UnityEngine;
using System.Collections;
using OpenCVForUnity;

public class mazeCoordinate : MonoBehaviour {
    //地圖資料
    public mapData _mapData;
    public Mat _mapMat;
    public Texture2D _tex;
    //地圖方向defind
    private const byte UP = 7;
    private const byte RIGHT = 11;
    private const byte DOWN = 13;
    private const byte LEFT = 14;
    //設定地圖長寬格數
    private const int ScreenWidthBlock = 16;
    private const int ScreenHeightBlock = 9;
    //設定地圖實際像素大小
    private float _mapWidth;
    private float _mapHeight;
    public mapBlock[,] StartBlock;
	// Use this for initialization
    void Start()
    {

        StartBlock = new mapBlock[9, 16];
        _mapWidth = transform.localScale.x;
        _mapHeight = transform.localScale.y;
        
        Init();
           

        _mapMat = new Mat((int)_mapHeight, (int)_mapWidth, CvType.CV_8UC3);
        _mapMat.setTo(new Scalar(255, 255, 255));
        _tex = new Texture2D((int)_mapWidth, (int)_mapHeight);

    }

    void Update()
    {
        CanGo(0, 0, 2);
        //顯示大小改變
        if (transform.localScale.x != _mapWidth || transform.localScale.y != _mapHeight)
        {
            //Debug.Log("update map coordinate");
            _mapWidth = transform.localScale.x;
            _mapHeight = transform.localScale.y;
            Debug.Log("update map" + _mapWidth + "x" + _mapHeight);
            Init();
        }
        DrawMap();
        Utils.matToTexture2D(_mapMat, _tex);
        gameObject.GetComponent<Renderer>().material.mainTexture = _tex;

    }
    public void CanGo(int x,int y,int times)//原始座標x,y剩餘次數
    {
        if (x < 0 || y < 0 || x > 16 || y > 9) return;
        if (times-- > 0)
        {
            if ((_mapData.getWall(x, y) | UP) == UP)
            {
                if (!_mapData.isExist(new Point(x, y - 1)))
                {
                    _mapData.setCanMoveArea(new Point(x, y - 1));
                    CanGo(x, y - 1, times);
                    //Debug.Log("GO X = " + x + "Y = " + (y - 1) + "times = " + times + " UP");
                }
            }
            if ((_mapData.getWall(x, y) | RIGHT) == RIGHT)
            {
                if (!_mapData.isExist(new Point(x + 1, y)))
                {
                    _mapData.setCanMoveArea(new Point(x + 1, y));
                    CanGo(x + 1, y, times);
                    //Debug.Log("GO X = " + (x + 1) + "Y = " + y + "times = " + times + " RIGHT");
                }
            }
            if ((_mapData.getWall(x, y) | DOWN) == DOWN)
            {
                if (!_mapData.isExist(new Point(x, y + 1)))
                {
                    _mapData.setCanMoveArea(new Point(x, y + 1));
                    CanGo(x, y + 1, times);
                    //Debug.Log("GO X = " + x + "Y = " + (y + 1) + "times = " + times + " DOWN");
                }
            }
            if ((_mapData.getWall(x, y) | LEFT) == LEFT)
            {
                if (!_mapData.isExist(new Point(x - 1, y)))
                {
                    _mapData.setCanMoveArea(new Point(x - 1, y));
                    CanGo(x - 1, y, times);
                    //Debug.Log("GO X = " + (x - 1) + "Y = " + y + "times = " + times + " LEFT");
                }
            }
        }
        return;
    }
    private Point[] PosToBlock(int x, int y)
    {
        Point[] P = new Point[2];
        P[0] = StartBlock[y, x].minPos;
        P[1] = StartBlock[y, x].maxPos;
        return P;
    }
    public void DrawMap()
    {
        for (int i = 0; i < ScreenHeightBlock; i++)
        {
            for (int j = 0; j < ScreenWidthBlock; j++)
            {
                DrawMazeBlock(j, i, _mapData.getWall(j, i));
            }
        }
    }
    public void DrawMazeBlock(int x,int y,byte Block)
    {
        Point[] P = PosToBlock(x, y);
        //Debug.Log("Draw x = " + x + "y = " + y + "Pos_X" + P[0].x+ "Pos_Y" + P[0].y);
        if ((_mapData.getWall(x, y) & 8) == 8)//UP
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[0].y), new Scalar(45, 45, 45));
        }
        if ((_mapData.getWall(x, y) & 4) == 4)//R
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[1].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), new Scalar(45, 45, 45));
        }
        if ((_mapData.getWall(x, y) & 2) == 2)//D
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[1].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), new Scalar(45, 45, 45));
        }
        if ((_mapData.getWall(x, y) & 1) == 1)//L
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[0].x, _mapHeight - P[1].y), new Scalar(45, 45, 45));
        }
    }
    private void Init()
    {
        //新增開始區塊範圍
        for (int i = 0; i < ScreenHeightBlock; i++)
        {
            for (int j = 0; j <ScreenWidthBlock ; j++)
            {
                StartBlock[i, j] = new mapBlock();
                StartBlock[i, j].minPos = new Point((double)(_mapWidth * (j / (double)ScreenWidthBlock)), (double)(_mapHeight * (i / (double)ScreenHeightBlock)));
                StartBlock[i, j].maxPos = new Point((double)(_mapWidth * ((j + 1) / (double)ScreenWidthBlock)), (double)(_mapHeight * ((i + 1) / (double)ScreenHeightBlock)));
            }
        }
    }

}
