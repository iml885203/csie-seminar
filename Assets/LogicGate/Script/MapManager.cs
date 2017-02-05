using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;

public class MapManager : MonoBehaviour {

    private byte[,] _mapCoordinateByte;

    //地圖方格數
    public const int BlockWidth = 16;
    public const int BlockHeight = 9;
    //角色可以移動的區塊
    private List<Point> _canMoveArea = new List<Point>();
    private List<Point> _playerPos = new List<Point>();
    private Random rnd = new Random();
    private int dir = -1;

    private int[] dCol = { 0, 1, 0, -1 };
    private int[] dRow = { -1, 0, 1, 0 };
    private int[,] used = new int[BlockHeight, BlockWidth];

    //地圖方向defind
    private const byte UP = 7;                  //上可走0111
    private const byte RIGHT = 11;              //右可走1011
    private const byte DOWN = 13;               //下可走1101
    private const byte LEFT = 14;               //左可走1110

    public int GetBlockWidth { get { return BlockWidth; } }
    public int GetBlockHeight { get { return BlockHeight; } }

    public MapManager()
    {
        //地圖預設資料
        _mapCoordinateByte = new byte[BlockHeight, BlockWidth]{//Height,Width
        {9,12,9,10,12,9,10,14,9,10,12,13,13,13,11,12},
        {5,1,2,12,3,6,9,10,0,12,3,6,5,3,12,5},
        {7,1,12,5,13,9,6,11,4,3,10,8,6,11,2,4},
        {11,4,7,1,6,5,9,14,5,9,10,2,12,9,8,4},
        {9,2,12,3,10,2,6,9,4,7,13,13,7,5,5,7},
        {7,9,6,9,14,9,10,6,3,14,1,0,10,4,1,10},
        {9,2,8,4,9,4,9,14,9,10,6,5,13,7,3,12},
        {5,9,6,7,5,5,5,9,0,10,10,2,6,9,12,5},
        {7,3,10,14,7,3,2,6,3,14,11,10,10,6,3,6}};

        _canMoveArea = new List<Point>();
        _playerPos = new List<Point>();
    }

    //創建隨機地圖
    public void CreateNewMap()
    {
        for (int i = 0; i < BlockHeight; i++)
            for (int j = 0; j < BlockWidth; j++)
                used[i, j] = 0;
        _mapCoordinateByte = new byte[BlockHeight, BlockWidth];

        for (int i = 0; i < BlockHeight; i++)
            for (int j = 0; j < BlockWidth; j++)
                _mapCoordinateByte[i, j] = 15;

        dfs(0, 0, -1, -1);

        for (int i = 0; i < BlockHeight; i++)
            for (int j = 0; j < BlockWidth; j++)
                Debug.Log(_mapCoordinateByte[i, j]);
        List<Point> _canMoveArea = new List<Point>();
        List<Point> _playerPos = new List<Point>();
        List<Point> _treadsurePos = new List<Point>();
    }

    //深度
    private void dfs(int col, int row, int pcol, int prow)
    {
        if ((col < 0 || row < 0) || (col >= BlockWidth || row >= BlockHeight))//col=16 row=9
            return;
        if (used[row, col] == 1)
            return;
        used[row, col] = 1;
        int cnt = 0, dir = 0;
        if (col == BlockWidth - 1 && row == BlockHeight - 1)
            return;
        while (cnt < 10)
        {
            dir = Random.Range(0, 4);//上dir=0 ->dCol=0,dRow=-1  右dir=1 ->dCol=1,dRow=0   下dir=2 ->dCol=0,dRow=1  左dir=3 ->dCol=-1,dRow=0

            if ((col + dCol[dir]) < BlockWidth && (row + dRow[dir]) < BlockHeight && (col + dCol[dir] >= 0 && row + dRow[dir] >= 0) && used[row + dRow[dir], col + dCol[dir]] != 1)
            {
                dfs(col + dCol[dir], row + dRow[dir], col, row);
                //Debug.Log("col = " + col + ",row=" + row);
                this.DeleteNearWall(row, col, dir);
                this.DeleteLocalWall(row, col, dir);
            }
            cnt++;
        }
    }

    private void DeleteLocalWall(int row, int col, int wallIndex)
    {
        switch (wallIndex)
        {
            case 0://刪除上方
                _mapCoordinateByte[row, col] -= 8;
                //_mapCoordinateByte[row, col] &= 7;
                break;
            case 1://刪除右方
                _mapCoordinateByte[row, col] -= 4;
                //_mapCoordinateByte[row, col] &= 11;
                break;
            case 2://刪除下方
                _mapCoordinateByte[row, col] -= 2;
                //_mapCoordinateByte[row, col] &= 13;
                break;
            case 3://刪除左方
                _mapCoordinateByte[row, col] -= 1;
                //_mapCoordinateByte[row, col] &= 14;
                break;
        }
    }

    private void DeleteNearWall(int row, int col, int wallIndex)
    {
        switch (wallIndex)
        {
            case 0://刪除下方
                _mapCoordinateByte[row - 1, col] -= 2;
                //_mapCoordinateByte[row - 1, col] &= 13;
                break;
            case 1://刪除左方
                _mapCoordinateByte[row, col + 1] -= 1;
                //_mapCoordinateByte[row, col + 1] &= 14;
                break;
            case 2://刪除上方
                _mapCoordinateByte[row + 1, col] -= 8;
                //_mapCoordinateByte[row + 1, col] &= 7;
                break;
            case 3://刪除右方
                _mapCoordinateByte[row, col - 1] -= 4;
                //_mapCoordinateByte[row, col - 1] &= 11;
                break;
        }
    }

    private bool RandomTF()
    {
        bool response;
        int testNumber = Random.Range(1, 6);
        if (testNumber == 1)
            response = true;
        else
            response = false;
        return response;
    }

    //計算可走區塊
    //搜尋可以走的區塊並加入資料
    public void CanGo(int x, int y, int times)//原始座標x,y剩餘次數
    {
        //超出範圍
        if (x < 0 || y < 0 || x > BlockWidth || y > BlockHeight) return;
        //剩餘步數大於0
        if (times-- > 0)
        {
            if ((getWall(x, y) | UP) == UP)
            {
                // if (!_mapData.isExistCanMoveArea(new Point(x, y - 1)))
                // {
                setCanMoveArea(new Point(x, y - 1));
                CanGo(x, y - 1, times);
                //Debug.Log("GO X = " + x + "Y = " + (y - 1) + "times = " + times + " UP");
                // }
            }
            if ((getWall(x, y) | RIGHT) == RIGHT)
            {
                //if (!_mapData.isExistCanMoveArea(new Point(x + 1, y)))
                //{
                setCanMoveArea(new Point(x + 1, y));
                CanGo(x + 1, y, times);
                //Debug.Log("GO X = " + (x + 1) + "Y = " + y + "times = " + times + " RIGHT");
                //}
            }
            if ((getWall(x, y) | DOWN) == DOWN)
            {
                // if (!_mapData.isExistCanMoveArea(new Point(x, y + 1)))
                //{
                setCanMoveArea(new Point(x, y + 1));
                CanGo(x, y + 1, times);
                //Debug.Log("GO X = " + x + "Y = " + (y + 1) + "times = " + times + " DOWN");
                //}
            }
            if ((getWall(x, y) | LEFT) == LEFT)
            {
                //if (!_mapData.isExistCanMoveArea(new Point(x - 1, y)))
                //{
                setCanMoveArea(new Point(x - 1, y));
                CanGo(x - 1, y, times);
                //Debug.Log("GO X = " + (x - 1) + "Y = " + y + "times = " + times + " LEFT");
                //}
            }
        }
        return;
    }

    //可走區塊相關功能
    public List<Point> getCanMoveArea()
    {
        return _canMoveArea;
    }

    public void setCanMoveArea(Point P)
    {
        _canMoveArea.Add(P);
    }

    public bool isExistCanMoveArea(Point P)
    {
        return _canMoveArea.Exists(List => List.x == P.x && List.y == P.y);
    }

    public void ClearPlayerPos()
    {
        _playerPos.Clear();
    }

    public void ClearCanMoveArea()
    {
        _canMoveArea.Clear();
    }

    //清空角色可走
    public void RemovePlayerArea()
    {
        for (int index = 0; index < _playerPos.Count; index++)
            _canMoveArea.Remove(_playerPos[index]);
    }
    //玩家位置相關功能
    public Point getPlayerPos(int ID)
    {
        return _playerPos[ID];
    }

    public void setPlayerPos(Point P)
    {
        _playerPos.Add(P);
    }

    public void setPlayerPos(int ID, Point P)
    {
        _playerPos[ID] = P;
    }

    public int getPlayerCount()
    {
        return _playerPos.Count;
    }

    public bool isExistPlayerPos(Point P)
    {
        return _playerPos.Exists(List => List.x == P.x && List.y == P.y);
    }

    //取得牆壁資訊
    public byte getWall(int x, int y)
    {
        return _mapCoordinateByte[y, x];
    }
}
