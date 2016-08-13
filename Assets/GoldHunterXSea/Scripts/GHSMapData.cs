using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;

public class GHSMapData : MonoBehaviour {

    private byte[,] _mapCoordinateByte = new byte[9, 16]{//Height,Width
        {9,12,9,10,12,9,10,14,9,10,12,13,13,13,11,12},
        {5,1,2,12,3,6,9,10,0,12,3,6,5,3,12,5},
        {7,1,12,5,13,9,6,11,4,3,10,8,6,11,2,4},
        {11,4,7,1,6,5,9,14,5,9,10,2,12,9,8,4},
        {9,2,12,3,10,2,6,9,4,7,13,13,7,5,5,7},
        {7,9,6,9,14,9,10,6,3,14,1,0,10,4,1,10},
        {9,2,8,4,9,4,9,14,9,10,6,5,13,7,3,12},
        {5,9,6,7,5,5,5,9,0,10,10,2,6,9,12,5},
        {7,3,10,14,7,3,2,6,3,14,11,10,10,6,3,6}};
    private Random rnd = new Random();
    private int dir = -1;
    private List<Point> _canMoveArea = new List<Point>();
    private List<Point> _playerPos = new List<Point>();
    private List<Point> _treadsurePos = new List<Point>();
    private List<Point> _sightPos = new List<Point>();
    private List<Point> _bombPos = new List<Point>();
    private List<Point> _flashLight = new List<Point>();

    private int[] dCol = { 0, 1, 0, -1 };
    private int[] dRow = { -1, 0, 1, 0 };
    private int[,] used = new int[9, 16];
    //dir=0 ->dCol=0,dRow=-1  dir=1 ->dCol=1,dRow=0   dir=2 ->dCol=0,dRow=1  dir=3 ->dCol=-1,dRow=0
    public GHSMapData()
    {
        _mapCoordinateByte = new byte[9, 16]{
        {9,12,9,10,12,9,10,14,9,10,12,13,13,13,11,12},
        {5,1,2,12,3,6,9,10,0,12,3,6,5,3,12,5},
        {7,1,12,5,13,9,6,11,4,3,10,8,6,11,2,4},
        {11,4,7,1,6,5,9,14,5,9,10,2,12,9,8,4},
        {9,2,12,3,10,2,6,9,4,7,13,13,7,5,5,7},
        {7,9,6,9,14,9,10,6,3,14,1,0,10,4,1,10},
        {9,2,8,4,9,4,9,14,9,10,6,5,13,7,3,12},
        {5,9,6,7,5,5,5,9,0,10,10,2,6,9,12,5},
        {7,3,10,14,7,3,2,6,3,14,11,10,10,6,3,6}};
        List<Point> _canMoveArea = new List<Point>();
        List<Point> _playerPos = new List<Point>();
        List<Point> _treadsurePos = new List<Point>();
        List<Point> _sightPos = new List<Point>();

    }
    public void CreateNewMap()
    {
        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 16; j++)
                used[i, j] = 0;
        _mapCoordinateByte = new byte[9, 16];

        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 16; j++)
                _mapCoordinateByte[i, j] = 15;

        dfs(0, 0, -1, -1);

        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 16; j++)
                Debug.Log(_mapCoordinateByte[i, j]);
        List<Point> _canMoveArea = new List<Point>();
        List<Point> _playerPos = new List<Point>();
        List<Point> _treadsurePos = new List<Point>();
    }

    private void dfs(int col, int row, int pcol, int prow)
    {
        if ((col < 0 || row < 0) || (col >= 16 || row >= 9))//col=16 row=9
            return;
        if (used[row, col] == 1)
            return;
        used[row, col] = 1;
        int cnt = 0, dir = 0;
        if (col == 16 - 1 && row == 9 - 1)
            return;
        while (cnt < 10)
        {
            dir = Random.Range(0, 4);//上dir=0 ->dCol=0,dRow=-1  右dir=1 ->dCol=1,dRow=0   下dir=2 ->dCol=0,dRow=1  左dir=3 ->dCol=-1,dRow=0

            if ((col + dCol[dir]) < 16 && (row + dRow[dir]) < 9 && (col + dCol[dir] >= 0 && row + dRow[dir] >= 0) && used[row + dRow[dir], col + dCol[dir]] != 1)
            {
                dfs(col + dCol[dir], row + dRow[dir], col, row);
                //Debug.Log("col = " + col + ",row=" + row);
                this.DeleteNearWall(row, col, dir);
                this.DeleteLocalWall(row, col, dir);
            }
            cnt++;
        }
    }

    //填補牆壁
    /*private void FillWall(int row, int col, int wallIndex)
    {
        switch (wallIndex)
        {
            case 0://填補下方
                _mapCoordinateByte[row - 1, col] += 2;
                break;
            case 1://填補左方
                _mapCoordinateByte[row, col + 1] += 1;
                break;
            case 2://填補上方
                _mapCoordinateByte[row + 1, col] += 8;
                break;
            case 3://填補右方
                _mapCoordinateByte[row, col - 1] += 4;
                break;
        }
    }*/

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

    //回傳可走區塊相關功能
    public List<Point> getCanMoveArea()
    {
        return _canMoveArea;
    }

    //設定可走區域
    public void setCanMoveArea(Point P)
    {
        _canMoveArea.Add(P);
    }

    //回傳是否有可走區域
    public bool isExistCanMoveArea(Point P)
    {
        return _canMoveArea.Exists(List => List.x == P.x && List.y == P.y);
    }

    //清除玩家位置
    public void ClearPlayerPos()
    {
        _playerPos.Clear();
    }

    //清除寶藏位置
    public void ClearTreadsurePos()
    {
        _treadsurePos.Clear();
    }

    //清除可走區域
    public void ClearCanMoveArea()
    {
        _canMoveArea.Clear();
    }

    //清除兩玩家可走區域
    public void RemovePlayerArea()
    {
        _canMoveArea.Remove(_playerPos[0]);
        _canMoveArea.Remove(_playerPos[1]);
        _canMoveArea.Remove(_playerPos[2]);
        _canMoveArea.Remove(_playerPos[3]);
    }

    //回傳玩家位置相關功能
    public Point getPlayerPos(int ID)
    {
        return _playerPos[ID];
    }

    //設定玩家座標
    public void setPlayerPos(Point P)
    {
        _playerPos.Add(P);
    }

    //設定特定玩家座標
    public void setPlayerPos(int ID, Point P)
    {
        _playerPos[ID] = P;
    }

    //回傳玩家數量
    public int getPlayerCount()
    {
        return _playerPos.Count;
    }

    //回傳指定座標是否有玩家
    public bool isExistPlayerPos(Point P)
    {
        return _playerPos.Exists(List => List.x == P.x && List.y == P.y);
    }

    //回傳牆壁資訊
    public byte getWall(int x, int y)
    {
        return _mapCoordinateByte[y, x];
    }

    //回傳寶藏座標
    public List<Point> getTreadsurePos()
    {
        return _treadsurePos;
    }

    //回傳指定寶藏座標
    public Point getTreadsurePos(int ID)
    {
        return _treadsurePos[ID];
    }

    //設定寶藏座標
    public void setTreadsurePos(Point Point)
    {
        _treadsurePos.Add(Point);
    }

    //回傳視野晶球座標List
    public List<Point> getSightPos()
    {
        return _sightPos;
    }

    //回傳指定視野晶球座標
    public Point getSightPos(int ID)
    {
        return _sightPos[ID];
    }

    //設定視野晶球座標
    public void setSightPos(Point Point)
    {
        _sightPos.Add(Point);
    }

    //移除指定晶球座標
    public void removeSight(int ID)
    {
        _sightPos.RemoveAt(ID);
    }

    //移除所有晶球座標
    public void ClearSightPos()
    {
        _sightPos.Clear();
    }

    //回傳炸彈List
    public List<Point> getBombPos()
    {
        return _bombPos;
    }

    //回傳指定炸彈座標
    public Point getBombPos(int ID)
    {
        return _bombPos[ID];
    }

    //設定炸彈座標
    public void setBombPos(Point Point)
    {
        _bombPos.Add(Point);
    }

    //移除指定炸彈
    public void removeBomb(int ID)
    {
        _bombPos.RemoveAt(ID);
    }

    //清除所有炸彈
    public void ClearBombPos()
    {
        _bombPos.Clear();
    }

    public Point getFlashLightPos(int ID)
    {
        return _flashLight[ID];
    }

    public List<Point> getFlashLightPos()
    {
        return _flashLight;
    }

    public void setFlashLightPos(Point Point)
    {
        _flashLight.Add(Point);
    }

    public void removeFlashLight(int ID)
    {
        _flashLight.RemoveAt(ID);
    }

    public void clearFlashLight()
    {
        _flashLight.Clear();
    }
}


