using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using System;

public class GHSMapData : MonoBehaviour {

    private const int _screenWidthBlock = 16;
    private const int _screenHeightBlock = 8;

    public GameObject _reflectionObject;
    public GameObject _refractionObject;
    public GameObject _windObject;
    public GameObject _targetObject;
    public GameObject _laserBall;

    private byte[,] _mapCoordinateByte;
    private UnityEngine.Random rnd = new UnityEngine.Random();
    private int dir = -1;
    private List<Point> _canMoveArea = new List<Point>();
    private List<Point> _playerPos = new List<Point>();
    private List<Point> _treadsurePos = new List<Point>();
    private List<Point> _sightPos = new List<Point>();
    private List<Point> _bombPos = new List<Point>();
    private List<Point> _flashLight = new List<Point>();

    private int[] dCol = { 0, 1, 0, -1 };
    private int[] dRow = { -1, 0, 1, 0 };
    private int[,] used;
    //dir=0 ->dCol=0,dRow=-1  dir=1 ->dCol=1,dRow=0   dir=2 ->dCol=0,dRow=1  dir=3 ->dCol=-1,dRow=0
    public GHSMapData()
    {
        _mapCoordinateByte = new byte[_screenHeightBlock, _screenWidthBlock]{//Height,Width
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
        used = new int[_screenHeightBlock, _screenWidthBlock];
        List<Point> _canMoveArea = new List<Point>();
        List<Point> _playerPos = new List<Point>();
        List<Point> _treadsurePos = new List<Point>();
        List<Point> _sightPos = new List<Point>();
        
        System.IO.StreamReader fileData = new System.IO.StreamReader("objectData.txt", System.Text.Encoding.Default);

        int kindAndNumber = Convert.ToInt16(fileData.ReadLine());
        Debug.Log("kindAndNumber = " + kindAndNumber);
        fileData.ReadLine();

        int kindIndex = (kindAndNumber & 224) / 32;
        Debug.Log("kindIndex = " + kindIndex);

        GameObject productGameObject = new GameObject();
        this.SwitchGameObject(kindIndex, ref productGameObject);
        Debug.Log("productGameObject.name = " + productGameObject.name);

        

        int numberIndex = kindAndNumber & 15;
        Debug.Log("numberIndex = " + numberIndex);
        for (int index = 0; index < numberIndex; index++)
        {
            int dir = Convert.ToInt16(fileData.ReadLine());
            int position = Convert.ToInt16(fileData.ReadLine());

            float realDirection = this.TransferDirection(dir);
            Debug.Log("realDirection = " + realDirection);

            int widthBlock = (position & 240) / 16;
            int heightBlock = (position & 15);
            Debug.Log("widthBlock = " + widthBlock);
            Debug.Log("heightBlock = " + heightBlock);

            GameObject cloneObject = (GameObject)Instantiate(productGameObject,
                this.transform.FindChild("ReflectionObjects").position + new Vector3(Convert.ToSingle(fileData.ReadLine()), Convert.ToSingle(fileData.ReadLine()), Convert.ToSingle(fileData.ReadLine())),
                new Quaternion(0, 0, realDirection, 0)
                );
            cloneObject.transform.SetParent(this.transform.FindChild("ReflectionObjects"));
                
            fileData.ReadLine();
        }

        fileData.Close();
    }

    private float TransferDirection(int dir)
    {
        return (dir & 7) * (float)45.0;
    }

    public void CreateNewMap()
    {
        for (int i = 0; i < _screenHeightBlock; i++)
            for (int j = 0; j < _screenWidthBlock; j++)
                used[i, j] = 0;

        _mapCoordinateByte = new byte[_screenHeightBlock, _screenWidthBlock];

        dfs(0, 0, -1, -1);

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
            dir = UnityEngine.Random.Range(0, 4);//上dir=0 ->dCol=0,dRow=-1  右dir=1 ->dCol=1,dRow=0   下dir=2 ->dCol=0,dRow=1  左dir=3 ->dCol=-1,dRow=0

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
        int testNumber = UnityEngine.Random.Range(1, 6);
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
    public void RemovePlayerAreaByIndex(int ID)
    {
        _canMoveArea.Remove(_playerPos[ID]);
        //_canMoveArea.Remove(_playerPos[1]);
        //_canMoveArea.Remove(_playerPos[2]);
        //_canMoveArea.Remove(_playerPos[3]);
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

    public int ScreenWidthBlock
    {
        get
        {
            return _screenWidthBlock;
        }
    }

    public int ScreenHeightBlock
    {
        get
        {
            return _screenHeightBlock;
        }
    }

    private void SwitchGameObject(int gameObjectNumber, ref GameObject productGameObject)
    {
        switch (gameObjectNumber)
        {
            case 0:
                {
                    Debug.Log("gameObject = reflectionObject");
                    productGameObject = _reflectionObject;
                    break;
                }
            case 1:
                {
                    productGameObject = _refractionObject;
                    break;
                }
            case 2:
                {
                    productGameObject = _windObject;
                    break;
                }
            case 3:
                {
                    productGameObject = _targetObject;
                    break;
                }
            case 4:
                {
                    productGameObject = _laserBall;
                    break;
                }
            default:
                break;
        }
    }
}


