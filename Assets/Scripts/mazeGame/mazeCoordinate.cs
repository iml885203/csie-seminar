using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class mazeCoordinate : MonoBehaviour {
    //地圖資料
    public mapData _mapData;                    //地圖全部資料
    public Mat _mapMat;                         //畫地圖的mat
    public Texture2D _tex;                      //顯示的結果texture2D
    //遊戲狀況文字顯示
    public Text _roundText;
    //地圖方向defind
    private const byte UP = 7;                  //上可走 0111
    private const byte RIGHT = 11;              //右可走1011
    private const byte DOWN = 13;               //下可走1101
    private const byte LEFT = 14;               //左可走1110
    //設定地圖長寬格數
    private const int ScreenWidthBlock = 16;    //寬的格數
    private const int ScreenHeightBlock = 9;    //高的格數
    //設定地圖實際像素大小
    private float _mapWidth;
    private float _mapHeight;

    //設定地圖方格陣列
    public mapBlock[,] StartBlock;
    //設定顏色
    private Scalar _treadsureColor = new Scalar(255, 255, 255);                     //寶藏迷霧
    private Scalar _FogOfWarColor = new Scalar(0, 0, 0);                     //戰爭迷霧
    private Scalar _mapWellColor = new Scalar(255, 250, 250);                   //迷宮的牆壁顏色
    private Scalar _canGoBlockColor = new Scalar(0, 0, 0);                       //可走的地區顏色
    private Scalar[] _playerColor = new Scalar[2] { new Scalar(0, 0, 255), new Scalar(255, 255, 255) }; //玩家顏色
    //線條粗細
    private int _mapWellThickness = 1;
    private int _mapBlockThickness = 1;
    //點擊功能class
    public raytoPosition _rayPosData;
    //遊戲狀態
    private int _winerFlag; //-1=>沒人贏 0=>ID 0玩家贏 1=>ID 1玩家贏
    private int _round;
    private int _whoRound;
    //觸發角色移動
    private bool _moved;
    private float _movedTimer;
    private float _movedTriggerTime;
    //角色outputView座標
    public matchPointToOutputView _matchPointToOutputView;
    private Point[] _pointPlayer;
    private int _pointRange;

    private bool isSave = new bool();

    // Use this for initialization
    void Start()
    {
        StartBlock = new mapBlock[ScreenHeightBlock, ScreenWidthBlock];           //設定初始地圖陣列大小
        isSave = false;
        _mapWidth = transform.localScale.x;
        _mapHeight = transform.localScale.y;
        
        Init();                                                                   //初始化地圖
       
        _mapMat = new Mat((int)_mapHeight, (int)_mapWidth, CvType.CV_8UC3);
        _mapMat.setTo(_FogOfWarColor);                                              //設定戰爭迷霧
        _tex = new Texture2D((int)_mapWidth, (int)_mapHeight);                      //設定結果圖片大小
        //設定玩家初始位置
        _mapData.setPlayerPos(new Point(0, 0));
        _mapData.setPlayerPos(new Point(4, 4));
        //設定寶藏初始位置
        _mapData.setTreadsurePos(new Point(1, 1));
        _mapData.setTreadsurePos(new Point(5, 5));
        //設定回合&誰先遊戲&還沒有人贏
        _winerFlag = -1;
        _round = 0;
        _whoRound = 0;
        //設定玩家顏色
        _playerColor[0] = new Scalar(255, 0, 0);
        _playerColor[1] = new Scalar(255, 0 ,0);
        //
        _moved = false;
        _movedTimer = 0f;
        _movedTriggerTime = 1;
        _pointRange = 5;
        //
        _pointPlayer = new Point[2];
        _pointPlayer[0] = new Point(0, 0);
        _pointPlayer[1] = new Point(0, 0);

    }

    public void Restart()
    {
        _rayPosData.Reset();
        _mapMat.setTo(_FogOfWarColor);
        _mapData.ClearPlayerPos();
        _mapData.ClearCanMoveArea();
        _mapData.ClearTreadsurePos();
        //設定玩家初始位置
        _mapData.setPlayerPos(new Point(0, 0));
        _mapData.setPlayerPos(new Point(4, 4));
        //設定寶藏初始位置
        _mapData.setTreadsurePos(new Point(1, 1));
        _mapData.setTreadsurePos(new Point(5, 5));
        //設定回合&誰先遊戲&還沒有人贏
        _winerFlag = -1;
        _round = 0;
        _whoRound = 0;
        this.DrawMap();
        this.DrawTreadsure();
        for (int ID = 0; ID < _mapData.getPlayerCount(); ID++)
            DrawPlayer(ID);
    }

    void Update()
    {
        if (_winerFlag < 0)
        {
            SetIsSave();
            _mapMat.setTo(_FogOfWarColor);
            //顯示大小改變
            if (transform.localScale.x != _mapWidth || transform.localScale.y != _mapHeight)
            {
                Debug.Log("update map" + transform.localScale.x + "x" + transform.localScale.y);
                Init();
            }

            // set Character Point and trigger
            Point[] characterPoint = _matchPointToOutputView.outputPoint.ToArray();

            if (characterPoint.Length != 0)
            {
                //Debug.Log("round: "+_whoRound);
                //Debug.Log(characterPoint[_whoRound]);
                //Debug.Log(_pointPlayer[_whoRound]);

                if (characterPoint[_whoRound].x < _pointPlayer[_whoRound].x + _pointRange && characterPoint[_whoRound].x > _pointPlayer[_whoRound].x - _pointRange &&
                   characterPoint[_whoRound].y < _pointPlayer[_whoRound].y + _pointRange && characterPoint[_whoRound].y > _pointPlayer[_whoRound].y - _pointRange)
                {
                    _movedTimer += Time.deltaTime;
                    if (_movedTimer > _movedTriggerTime)
                    {
                        _movedTimer = 0f;
                        _moved = true;
                        Debug.Log("round: " + _whoRound + " Point: " + (int)_pointPlayer[_whoRound].x + "," + (int)_pointPlayer[_whoRound].y);
                    }
                }
                else
                {
                    _movedTimer = 0f;
                    _pointPlayer[_whoRound] = characterPoint[_whoRound];
                }
            }
            //如果滑鼠點擊
            this.ClickMouseUpEvent();

            //搜尋兩個玩家可走區塊
            for (int ID = 0; ID < _mapData.getPlayerCount(); ID++)
                CanGo((int)(_mapData.getPlayerPos(ID).x), (int)(_mapData.getPlayerPos(ID).y), 3);

            for (int ID = 0; ID < _mapData.getPlayerCount(); ID++)
                if (this.GetTreadsureOrNot(ID))
                {
                    _winerFlag = ID;
                    _roundText.text = "Player " + ID + " win!!";
                    Debug.Log("ID = " + ID + ",X = " + _mapData.getPlayerPos(ID).x + ",Y = " + _mapData.getPlayerPos(ID).y + ", get the treadsure");
                }

            //畫地圖(外框、兩個玩家可走區塊),寶藏,玩家
            if (!isSave)
            {
                this.DrawMap();
                this.DrawTreadsure();
            }
            
            for (int ID = 0; ID < _mapData.getPlayerCount(); ID++)
                DrawPlayer(ID);

            //轉換地圖mat至顯示結果
            Utils.matToTexture2D(_mapMat, _tex);
            gameObject.GetComponent<Renderer>().material.mainTexture = _tex;
        }
    }

    //滑鼠點擊事件
    private void ClickMouseUpEvent()
    {
        if (_moved || Input.GetMouseButtonUp(0))
        {
            Point triggerPoint = new Point();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        if (StartBlock[i, j].Check(_rayPosData.getPos().x, _rayPosData.getPos().y))
                        {
                            //Debug.Log("PosX:" + j + "PosX:" + i);
                            triggerPoint.x = j;
                            triggerPoint.y = i;
                        }
                    }
                    else
                    {
                        if (StartBlock[i, j].Check(_pointPlayer[_whoRound].x, _pointPlayer[_whoRound].y))
                        {
                            //Debug.Log("PosX:" + j + "PosX:" + i);
                            triggerPoint.x = j;
                            triggerPoint.y = i;
                        }
                    }
                }
            }

            _whoRound = _round % 2;
            this.RefreshOneCanMoveArea(_whoRound);
            this._mapData.RemovePlayerArea();

            if (_mapData.getCanMoveArea().Exists(List => List.x == triggerPoint.x && List.y == triggerPoint.y) &&
                (_mapData.getPlayerPos(_whoRound).x == triggerPoint.x &&
                 _mapData.getPlayerPos(_whoRound).y == triggerPoint.y) ==false)
            {
                _mapData.setPlayerPos(_whoRound, new Point(triggerPoint.x, triggerPoint.y));
                _round++;
                _roundText.text = ((_round % 2 == 0) ? "(←) " : "(→) ") + ("Round：" + _round);
                this.RefreshCanMoveArea();
                Debug.Log("This point can be move!" + "X = " + triggerPoint.x + ",Y = " + triggerPoint.y);
            }
            else
            {
                Debug.Log("This point can't be move!" + "X = " + triggerPoint.x + ",Y = " + triggerPoint.y);
            }
            this.RefreshOneCanMoveArea(0);
            this.RefreshOneCanMoveArea(1);
            //Debug.Log("WR" + _whoRound + "R " + _round + "NUM " + _mapData.getPlayerCount());
            //Debug.Log("ID = 0" + "X = " + _mapData.getPlayerPos(0).x + "Y = " + _mapData.getPlayerPos(0).y);
            //Debug.Log("ID = 1" + "X = " + _mapData.getPlayerPos(1).x + "Y = " + _mapData.getPlayerPos(1).y);
            _moved = false;
        }
    }

    //刷新canMoveArea(包含清除及重新搜尋)
    public void RefreshCanMoveArea()
    {
        _mapData.ClearCanMoveArea();
        for (int ID = 0; ID < _mapData.getPlayerCount(); ID++)
            CanGo((int)(_mapData.getPlayerPos(ID).x), (int)(_mapData.getPlayerPos(ID).y), 3);
    }

    //刷新canMoveArea(包含清除及重新搜尋)
    public void RefreshOneCanMoveArea(int ID)
    {
        _mapData.ClearCanMoveArea();
        CanGo((int)(_mapData.getPlayerPos(ID).x), (int)(_mapData.getPlayerPos(ID).y), 3);
        CanGo((int)(_mapData.getPlayerPos(ID).x), (int)(_mapData.getPlayerPos(ID).y), 3);
    }
    //搜尋可以走的區塊並加入資料
    public void CanGo(int x,int y,int times)//原始座標x,y剩餘次數
    {
        //超出範圍
        if (x < 0 || y < 0 || x > 16 || y > 9) return;
        //剩餘步數大於0
        if (times-- > 0)
        {
            if ((_mapData.getWall(x, y) | UP) == UP)
            {
               // if (!_mapData.isExistCanMoveArea(new Point(x, y - 1)))
               // {
                    _mapData.setCanMoveArea(new Point(x, y - 1));
                    CanGo(x, y - 1, times);
                    //Debug.Log("GO X = " + x + "Y = " + (y - 1) + "times = " + times + " UP");
               // }
            }
            if ((_mapData.getWall(x, y) | RIGHT) == RIGHT)
            {
                //if (!_mapData.isExistCanMoveArea(new Point(x + 1, y)))
                //{
                    _mapData.setCanMoveArea(new Point(x + 1, y));
                    CanGo(x + 1, y, times);
                    //Debug.Log("GO X = " + (x + 1) + "Y = " + y + "times = " + times + " RIGHT");
                //}
            }
            if ((_mapData.getWall(x, y) | DOWN) == DOWN)
            {
               // if (!_mapData.isExistCanMoveArea(new Point(x, y + 1)))
                //{
                    _mapData.setCanMoveArea(new Point(x, y + 1));
                    CanGo(x, y + 1, times);
                    //Debug.Log("GO X = " + x + "Y = " + (y + 1) + "times = " + times + " DOWN");
                //}
            }
            if ((_mapData.getWall(x, y) | LEFT) == LEFT)
            {
                //if (!_mapData.isExistCanMoveArea(new Point(x - 1, y)))
                //{
                    _mapData.setCanMoveArea(new Point(x - 1, y));
                    CanGo(x - 1, y, times);
                    //Debug.Log("GO X = " + (x - 1) + "Y = " + y + "times = " + times + " LEFT");
                //}
            }
        }
        return;
    }
    private void DrawPlayer(int ID)
    {
        Point[] P = new Point[2];
        P = PosToBlock((int)(_mapData.getPlayerPos(ID).x), (int)(_mapData.getPlayerPos(ID).y));
        //Imgproc.rectangle(_mapMat, new Point(_mapWidth - P[0].x - _mapWellThickness, _mapHeight - P[0].y - _mapWellThickness), new Point(_mapWidth - P[1].x + _mapWellThickness, _mapHeight - P[1].y +  _mapWellThickness), _canGoBlockColor, -1);
        Imgproc.circle(_mapMat, new Point(_mapWidth - ((P[0].x + P[1].x) / 2), _mapHeight - ((P[0].y + P[1].y) / 2)), (int)((P[1].x - P[0].x) / 3), _playerColor[ID]);
    }

    //畫寶藏 永遠畫
    private void DrawTreadsure()
    {
        for(int treadsureIndex = 0;treadsureIndex < _mapData.getTreadsurePos().Count; treadsureIndex++)
        {
            Point[] treadsurePoint = new Point[2];
            treadsurePoint = PosToBlock((int)(_mapData.getTreadsurePos()[treadsureIndex].x), (int)(_mapData.getTreadsurePos()[treadsureIndex].y));
            Imgproc.circle(_mapMat, new Point(_mapWidth - ((treadsurePoint[0].x + treadsurePoint[1].x) / 2), _mapHeight - ((treadsurePoint[0].y + treadsurePoint[1].y) / 2)), (int)((treadsurePoint[1].x - treadsurePoint[0].x) / 3), _treadsureColor,-1);
        }
    }

    //回傳是否得到寶藏 得到->true 沒得到->false
    private bool GetTreadsureOrNot(int playerID)
    {
        if (_mapData.getTreadsurePos().Exists(Point =>Point.x == _mapData.getPlayerPos(playerID).x && Point.y == _mapData.getPlayerPos(playerID).y))
            return true;
        return false;
    }
    
    //傳換座標變成兩點
    private Point[] PosToBlock(int x, int y)
    {
        Point[] P = new Point[2];
        P[0] = StartBlock[y, x].minPos;
        P[1] = StartBlock[y, x].maxPos;
        return P;
    }
    public void DrawMap()
    {
        //劃出地圖邊界
        Imgproc.rectangle(_mapMat, new Point(0, 0), new Point(_mapMat.width()-1, _mapMat.height()-1), _mapWellColor);
        //跑全部地圖
        for (int i = 0; i < ScreenHeightBlock; i++)
        {
            for (int j = 0; j < ScreenWidthBlock; j++)
            {
                //如果可以走就畫出來
                if (_mapData.isExistCanMoveArea(new Point(j, i)))
                {
                    DrawMazeBlock(j, i, _mapData.getWall(j, i));
                }
            }
        }
    }
    //畫格子
    public void DrawMazeBlock(int x,int y,byte Block)
    {
        //取得方格對應的兩點座標
        Point[] P = PosToBlock(x, y);
        //畫格子與外框(-1是實心)
        Imgproc.rectangle(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), _canGoBlockColor,-1);
        Imgproc.rectangle(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), _FogOfWarColor, _mapBlockThickness);

        //Debug.Log("Draw x = " + x + "y = " + y + "Pos_X" + P[0].x+ "Pos_Y" + P[0].y);
        //畫牆壁
        if ((_mapData.getWall(x, y) & 8) == 8)//UP
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[0].y), _mapWellColor, _mapWellThickness);
        }
        if ((_mapData.getWall(x, y) & 4) == 4)//R
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[1].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), _mapWellColor, _mapWellThickness);
        }
        if ((_mapData.getWall(x, y) & 2) == 2)//D
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[1].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), _mapWellColor, _mapWellThickness);
        }
        if ((_mapData.getWall(x, y) & 1) == 1)//L
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[0].x, _mapHeight - P[1].y), _mapWellColor, _mapWellThickness);
        }
    }
    //初始化地圖方格座標
    private void Init()
    {
        _mapWidth = transform.localScale.x;
        _mapHeight = transform.localScale.y;
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
    public void SetIsSave()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            isSave = (isSave) ? false : true;
            Debug.Log((isSave) ? "isSave Set True" : "isSave Set false");
        }
    }
}
