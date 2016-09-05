using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class GHSMain : MonoBehaviour {
    //遊戲開始
    public bool GameStart = false;
    //音樂資料
    public GHSEffectSoundControl _effectSoundControl;

    //地圖資料
    public GHSMapData _mapData;                  //地圖全部資料
    public Mat _mapMat;                         //畫地圖的mat
    private Texture2D _tex;                      //顯示的結果texture2D
    //遊戲狀況文字顯示
    public Text _roundText;
    public Text[] _coordinatePlayer;
    public Text _moveState;
    public RawImage _boomTip;
    public RawImage _winTip;
    //寶藏、旗標、視野道具、炸彈物件
    public GameObject _treasure;
    public GameObject _flages;
    public GameObject [] _flashLights;
    public GameObject [] _sight;
    public GameObject [] _bomb;
    //地圖方向defind
    private const byte UP = 7;                  //上可走0111
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
    private Scalar _FogOfWarColor = new Scalar(0, 0, 0);                      //戰爭迷霧
    private Scalar _mapWellColor = new Scalar(255, 250, 250);                 //迷宮的牆壁顏色
    private Scalar _canGoBlockColor = new Scalar(20, 20, 20);                    //可走的地區顏色
    private Scalar _blockLineColor = new Scalar(20, 20, 20);                       //方格顯示的線
    private Scalar[] _playerColor = new Scalar[4] { new Scalar(0, 0, 255), new Scalar(0, 0, 255), new Scalar(0, 255, 0), new Scalar(255, 255, 255) }; //玩家顏色
    //線條粗細
    private int _mapWellThickness = 1;
    private int _mapBlockThickness = 1;
    private int _playerThickness = 1;
    //點擊功能class
    public raytoPosition _rayPosData;
    //遊戲狀態
    private int _winerFlag; //-1=>沒人贏 0=>ID 1玩家贏 1=>ID 2玩家贏
    private int _round;
    private int _whoRound;
    //角色啟用
    public GHSPlayerState _playerState = new GHSPlayerState();
    //觸發角色移動
    private bool _moved;
    private float _movedTimer;
    private float _movedTriggerTime;
    //角色outputView座標 玩家數量
    int _playerCount = 0;
    public matchPointToOutputView _matchPointToOutputView;
    private Point[] _pointPlayer;
    private int _pointRange;
    //玩家視野
    private int[] _playerCanSee = new int[4];
    //設定功能旗標
    private bool _isDraw = new bool();
    private bool _isDebug = new bool();
    private bool _isCheatMode = new bool();
    private bool _isReSet = new bool();
    private bool _isNextLevel = new bool();
    //設定按鍵(畫圖、角色、全地圖)
    private KeyCode _saveKey = KeyCode.Y;
    private KeyCode _debugKey = KeyCode.H;
    private KeyCode _fullMapKey = KeyCode.J;
    private KeyCode _reSetKey = KeyCode.K;
    private KeyCode _nextLevel = KeyCode.L;
    //觸發炸彈時間
    private float _boomTimer;
    private float _boomTriggerTime;
    //觸發閃爍時間
    private bool _flicker;
    private float _flickerTimer;
    private float _flickerTriggerTime;
    //勝利顯示圖片計時器
    private float _winRect = 0;

    //初始化
    void Start()
    {
        _playerState.SetPlayerEnableOrNotByIndex(0, true);
        _playerState.SetPlayerEnableOrNotByIndex(1, true);
        _playerState.SetPlayerEnableOrNotByIndex(2, false);
        _playerState.SetPlayerEnableOrNotByIndex(3, true);
        _playerState.InitializeRealPlayer();
        StartBlock = new mapBlock[ScreenHeightBlock, ScreenWidthBlock];           //設定初始地圖陣列大小
        //初始旗標狀態
        _isDraw = true;
        _isDebug = true;
        _isCheatMode = true;
        _isReSet = false;
        //設定地圖像素大小
        _mapWidth = transform.localScale.x;
        _mapHeight = transform.localScale.y;

        //初始化棋盤格子
        for (int i = 0; i < ScreenHeightBlock; i++)
        {
            for (int j = 0; j < ScreenWidthBlock; j++)
            {
                StartBlock[i, j] = new mapBlock();
            }
        }
        InitBlock();                                                                   //初始化地圖
        _mapMat = new Mat((int)_mapHeight, (int)_mapWidth, CvType.CV_8UC3);
        _mapMat.setTo(_FogOfWarColor);                                              //設定戰爭迷霧
        _tex = new Texture2D((int)_mapWidth, (int)_mapHeight);                      //設定結果圖片大小

        //玩家位置創建空間
        _pointPlayer = new Point[4];
        _pointPlayer[0] = new Point(0, 0);
        _pointPlayer[1] = new Point(ScreenWidthBlock - 1, 0);
        _pointPlayer[2] = new Point(ScreenWidthBlock - 1, ScreenHeightBlock - 1);
        _pointPlayer[3] = new Point(0, ScreenHeightBlock - 1);

        //設定玩家初始位置
        for(int ID = 0; ID < 4; ID++)
        {
            _mapData.setPlayerPos(_pointPlayer[ID]);
        }

        //設定寶藏初始位置
        _mapData.setTreadsurePos(new Point(5, 5));
        //設定視野道具初始位置
        _mapData.setSightPos(new Point(1, 1));
        _mapData.setSightPos(new Point(6, 6));
        //設定炸彈位置
        _mapData.setBombPos(new Point(1, 2));
        _mapData.setBombPos(new Point(10, 6));
        //設定照明彈位置
        _mapData.setFlashLightPos(new Point(1, 0));
        //設定回合&誰先遊戲&還沒有人贏
        _winerFlag = -1;
        _round = 0;
        _whoRound = _playerState.GetRealPlayerCornerByIndex(_round % _playerState.GetEnablePlayerCount());
        this.FlageMove();
        //設定玩家顏色
        _playerColor[0] = new Scalar(255, 0, 0);
        _playerColor[1] = new Scalar(0, 0, 255);
        _playerColor[2] = new Scalar(0, 255, 0);
        _playerColor[3] = new Scalar(255, 255, 255);
        //設定移動資訊
        _moved = false;
        _movedTimer = 0f;
        _movedTriggerTime = 1;
        _pointRange = 5;
        //設定玩家視野
        for (int enablePlayer = 0; enablePlayer < 4; enablePlayer++)
        {
            if (_playerState.GetIsPlayerEnableOrNotByIndex(enablePlayer))
                _playerCanSee[enablePlayer] = 2;
        }
        //創造寶藏
        Point PBlock = new Point(_mapData.getTreadsurePos(0).x, _mapData.getTreadsurePos(0).y);
        Point[] PT = PosToBlock((int)PBlock.x, (int)PBlock.y);
        //設定寶藏位置(說明：　原始座標是0,0在中心點 先減掉0.5倍的原始物件 再加上位置座標)
        _treasure.transform.localPosition = new Vector3((float)-0.5 + ((float)(PT[0].x + PT[1].x) / 2 / _mapWidth), (float)0.5 - ((float)(PT[0].y + PT[1].y) / 2 / _mapHeight),-1);
        SightPosInit();
        BoomPosInit();
        //設定炸彈計時
        _boomTimer = 0f;
        _boomTriggerTime = 1;
        //設定閃爍時間
         _flicker = true;
         _flickerTimer = 0f;
         _flickerTriggerTime = 1;
        //UI初始化
        _moveState.text = "";

        this.RefreshOneCanMoveArea(_whoRound);
    }

    //重啟遊戲
    public void Restart()
    {
        //
        //舊的 尚未更改
        //
        _rayPosData.Reset();
        _mapMat.setTo(_FogOfWarColor);
        //清除資訊
        _mapData.ClearPlayerPos();
        _mapData.ClearCanMoveArea();
        _mapData.ClearTreadsurePos();
        _mapData.ClearBombPos();
        _mapData.ClearSightPos();
        //設定玩家初始位置
        _mapData.setPlayerPos(new Point(0, 4));
        _mapData.setPlayerPos(new Point(15, 3));
        //設定寶藏初始位置
        _mapData.setTreadsurePos(new Point(5, Random.Range(0,8)));
        //設定視野道具初始位置
        _mapData.setSightPos(new Point(Random.Range(0, 8), Random.Range(0, 8)));
        _mapData.setSightPos(new Point(Random.Range(8, 15), Random.Range(0, 8)));
        //設定炸彈位置
        _mapData.setBombPos(new Point(Random.Range(0, 15), Random.Range(0, 8)));
        _mapData.setBombPos(new Point(Random.Range(0, 15), Random.Range(0, 8)));
        //設定照明彈位置
        _mapData.setFlashLightPos(new Point(Random.Range(0, 1), Random.Range(1, 8)));
        SightPosInit();
        BoomPosInit();
        //設定回合&誰先遊戲&還沒有人贏
        _winerFlag = -1;
        _round = 0;
        _whoRound = 0;
        _isReSet = false;
    }

    //換關初始化
    public void NextLevel()
    {
        Restart();
        _mapData.CreateNewMap();
        _isNextLevel = false;
    }

    //炸彈座標初始化
    void BoomPosInit()
    {
        //設定炸彈道具
        for (int ID = 0; ID < _mapData.getBombPos().Count; ID++)
        {
            //創造炸彈道具座標點
            Point PBlock = new Point(_mapData.getBombPos(ID).x, _mapData.getBombPos(ID).y);
            Point [] PT = PosToBlock((int)PBlock.x, (int)PBlock.y);
            //設定炸彈道具位置
            _bomb[ID].transform.localPosition = new Vector3((float)-0.5 + ((float)(PT[0].x + PT[1].x) / 2 / _mapWidth), (float)0.5 - ((float)(PT[0].y + PT[1].y) / 2 / _mapHeight), -1);
        }
    }

    //晶球座標初始化
    void SightPosInit()
    {
        //設定視野道具
        for (int ID = 0; ID < _mapData.getSightPos().Count; ID++)
        {
            //創造視野道具座標點
            Point  PBlock = new Point(_mapData.getSightPos(ID).x, _mapData.getSightPos(ID).y);
            Point[] PT = PosToBlock((int)PBlock.x, (int)PBlock.y);
            //設定視野道具位置
            _sight[ID].transform.localPosition = new Vector3((float)-0.5 + ((float)(PT[0].x + PT[1].x) / 2 / _mapWidth), (float)0.5 - ((float)(PT[0].y + PT[1].y) / 2 / _mapHeight), -1);
        }
    }

    //照明燈座標初始化
    void FlashLightPosInit()
    {
        //設定視野道具
        for (int ID = 0; ID < _mapData.getFlashLightPos().Count; ID++)
        {
            //創造視野道具座標點
            Point PBlock = new Point(_mapData.getFlashLightPos(ID).x, _mapData.getFlashLightPos(ID).y);
            Point[] PT = PosToBlock((int)PBlock.x, (int)PBlock.y);
            //設定視野道具位置
            _flashLights[ID].transform.localPosition = new Vector3((float)-0.5 + ((float)(PT[0].x + PT[1].x) / 2 / _mapWidth), (float)0.5 - ((float)(PT[0].y + PT[1].y) / 2 / _mapHeight), -1);
        }
    }

    //Update
    void Update()
    {
        if (!GameStart)
        {
            DrawReadyGame();
            return;
        }

        this.SetIsSaveAndisDebug();
        //重制按鈕
        if (_isReSet)
        {
            this.Restart();
        }
        //換關按鈕
        if (_isNextLevel)
        {
            this.NextLevel();
        }
        //當沒有贏家的時候
        if (_winerFlag < 0)
        {
            _mapMat.setTo(_FogOfWarColor);
            //顯示大小改變
            if (transform.localScale.x != _mapWidth || transform.localScale.y != _mapHeight)
            {
                Debug.Log("update map" + transform.localScale.x + "x" + transform.localScale.y);
                InitBlock();
            }

            //設定角色座標和trigger
            Point[] characterPoint = _matchPointToOutputView.outputPoint.ToArray();

            if (characterPoint.Length != 0)
            {
                //Debug.Log("round: "+_whoRound);
                //Debug.Log(characterPoint[_whoRound]);
                //Debug.Log(_pointPlayer[_whoRound]);
                //判斷在玩家可走範圍內
                if (characterPoint[_whoRound].x < _pointPlayer[_whoRound].x + _pointRange && characterPoint[_whoRound].x > _pointPlayer[_whoRound].x - _pointRange &&
                   characterPoint[_whoRound].y < _pointPlayer[_whoRound].y + _pointRange && characterPoint[_whoRound].y > _pointPlayer[_whoRound].y - _pointRange)
                {
                    //累積移動時間增加
                    _movedTimer += Time.deltaTime;
                    //累積移動時間大於_movedTriggerTime,就移動玩家座標
                    if (_movedTimer > _movedTriggerTime)
                    {
                        _movedTimer = 0f;
                        _moved = true;
                        Debug.Log("round: " + _whoRound + " Point: " + (int)_pointPlayer[_whoRound].x + "," + (int)_pointPlayer[_whoRound].y);
                    }
                }
                else
                {
                    //累積移動時間歸零,玩家維持原座標
                    _movedTimer = 0f;
                    _pointPlayer[_whoRound] = characterPoint[_whoRound];
                }
            }

            //顯示玩家目前座標 2人
            for(int enablePlayer = 0; enablePlayer < 4; enablePlayer++)
            {
                if (_playerState.GetIsPlayerEnableOrNotByIndex(enablePlayer))
                {
                    _coordinatePlayer[enablePlayer].text = "X：" + _mapData.getPlayerPos(enablePlayer).x.ToString() + "Y：" + _mapData.getPlayerPos(enablePlayer).y.ToString();
                }
            }
            
            //如果滑鼠點擊
            this.ClickMouseUpEvent();

            //讓道具閃爍
            this.Flicker();
            
            //搜尋兩個玩家可走區塊
            //for (int ID = 0; ID < 4; ID++)
            //{
            //    if (_playerState.GetIsPlayerEnableOrNotByIndex(ID))
            //    {
            //        CanGo((int)(_mapData.getPlayerPos(ID).x), (int)(_mapData.getPlayerPos(ID).y), _playerCanSee[ID]);
            //    }
            //}

            //確認有沒有玩家碰到道具
            for (int ID = 0; ID < 4; ID++)
            {
                if (_playerState.GetIsPlayerEnableOrNotByIndex(ID))
                {
                    if (this.GetTreadsureOrNot(ID))
                    {
                        //寶藏
                        _winerFlag = ID;
                        _roundText.text = "Player " + (ID + 1) + " win!!";
                        _winTip.transform.localPosition = new Vector3(292, -120, -1);
                        Debug.Log("ID = " + ID + ",X = " + _mapData.getPlayerPos(ID).x + ",Y = " + _mapData.getPlayerPos(ID).y + ", get the treadsure");
                    }
                    if (this.GetSightOrNot(ID))
                    {
                        //視野        
                        _playerCanSee[ID]++;
                        _moveState.text = "Get Sight";
                        _effectSoundControl.PlayEffectSound("GetItem");
                    }
                    if (this.GetBombOrNot(ID))
                    {
                        //爆炸
                        if (ID == 0) _mapData.setPlayerPos(ID, new Point(0, 0));
                        if (ID == 1) _mapData.setPlayerPos(ID, new Point(ScreenWidthBlock - 1, 0));
                        if (ID == 2) _mapData.setPlayerPos(ID, new Point(ScreenWidthBlock - 1, ScreenHeightBlock - 1));
                        if (ID == 3) _mapData.setPlayerPos(ID, new Point(0, ScreenHeightBlock - 1));
                    }
                }
            }

            //畫地圖(外框、兩個玩家可走區塊),寶藏
            if (_isDraw)
            {
                this.DrawMap();
               // this.DrawTreadsure();
            }

            //畫寶藏
            for (int i = 0; i < _mapData.getTreadsurePos().Count; i++)
            {
                _treasure.SetActive(_isDraw && _mapData.isExistCanMoveArea(_mapData.getTreadsurePos(i)) || _isCheatMode);
            }

            //畫眼睛道具
            for (int i = 0; i < _mapData.getSightPos().Count; i++)
            {
                _sight[i].SetActive(_isDraw && _mapData.isExistCanMoveArea(_mapData.getSightPos(i)) || _isCheatMode);
            }
                
            //畫炸彈(理應只有作弊模式)
            for (int i = 0; i < _mapData.getBombPos().Count; i++)
            {
               // _bomb[i].SetActive(_isDraw && _mapData.isExistCanMoveArea(_mapData.getBombPos(i)) ||_isCheatMode);
                if (_isCheatMode)_bomb[i].SetActive(true);
            }

            //畫玩家
            if (_isDebug)
            {
                for (int ID = 0; ID < 4; ID++)
                {
                    if (_playerState.GetIsPlayerEnableOrNotByIndex(ID))
                    {
                        DrawPlayer(ID);
                    }
                }
            }

            //轉換地圖mat至顯示結果
            Utils.matToTexture2D(_mapMat, _tex);
            gameObject.GetComponent<Renderer>().material.mainTexture = _tex;
        }
        else
        {
            //有贏家的時候
            if (_winRect < 0.5f) _winRect += Time.deltaTime;
            this.BlowUp(_winTip, _winRect);
        }
    }

    //滑鼠點擊事件
    private void ClickMouseUpEvent()
    {
        if (_moved || Input.GetMouseButtonUp(0) && _rayPosData.IsClickToSomethimg)
        {
            Point triggerPoint = new Point();
            for (int i = 0; i < ScreenHeightBlock; i++)
            {
                for (int j = 0; j < ScreenWidthBlock; j++)
                {
                    //trigger到指定格子
                    if (StartBlock[i, j].Check(_rayPosData.getPos().x, _rayPosData.getPos().y))
                    {
                        //Debug.Log("PosX:" + j + "PosX:" + i);
                        triggerPoint.x = j;
                        triggerPoint.y = i;
                    }
                }
            }

            //Debug.Log("triggerPoint.x = " + triggerPoint.x + ", triggerPoint.y = " + triggerPoint.y);

            //判斷是否為可走區域以及是否沒有玩家在該格子上
            if (_mapData.getCanMoveArea().Exists(List => List.x == triggerPoint.x && List.y == triggerPoint.y) &&
                _mapData.isExistPlayerPos(new Point(triggerPoint.x, triggerPoint.y))==false)
            {
                //可以的話,設定玩家到新座標
                _mapData.setPlayerPos(_whoRound, new Point(triggerPoint.x, triggerPoint.y));

                _round++;
                _whoRound = _playerState.GetRealPlayerCornerByIndex(_round % _playerState.GetEnablePlayerCount());
                _roundText.text = "Round：" + _round;

                Debug.Log("_whoRound = " + _whoRound);
                this.FlageMove();
                _moveState.text = "";
                //Debug.Log("This point can be move!" + "X = " + triggerPoint.x + ",Y = " + triggerPoint.y);
            }
            else
            {
                _moveState.text = "無法移動到此座標(" + triggerPoint.x + ", " + triggerPoint.y + ")";
                Point[] mistakeBlock = this.PosToBlock((int)triggerPoint.x,(int)triggerPoint.y);
                Imgproc.line(_mapMat, new Point(_mapWidth - mistakeBlock[0].x, _mapHeight - mistakeBlock[0].y), new Point(_mapWidth - mistakeBlock[1].x, _mapHeight - mistakeBlock[1].y), new Scalar(255, 0, 0));
                Imgproc.line(_mapMat, new Point(_mapWidth - mistakeBlock[1].x, _mapHeight - mistakeBlock[0].y), new Point(_mapWidth - mistakeBlock[0].x, _mapHeight - mistakeBlock[1].y), new Scalar(255, 0, 0));
                Debug.Log("This point can't be move!" + "X = " + triggerPoint.x + ",Y = " + triggerPoint.y);
            }

            //重新跑過各玩家可以走的地方
            this.RefreshOneCanMoveArea(_whoRound);

            //Debug.Log("WR" + _whoRound + "R " + _round + "NUM " + _mapData.getPlayerCount());
            //Debug.Log("ID = 0" + "X = " + _mapData.getPlayerPos(0).x + "Y = " + _mapData.getPlayerPos(0).y);
            //Debug.Log("ID = 1" + "X = " + _mapData.getPlayerPos(1).x + "Y = " + _mapData.getPlayerPos(1).y);
            _moved = false;
        }
    }

    //刷新canMoveArea(包含清除及重新搜尋)
    public void RefreshOneCanMoveArea(int ID)
    {
        _mapData.ClearCanMoveArea();
        //CanGo((int)(_mapData.getPlayerPos(ID).x), (int)(_mapData.getPlayerPos(ID).y), _playerCanSee[ID]);
        GHS_CanGo((int)(_mapData.getPlayerPos(ID).x), (int)(_mapData.getPlayerPos(ID).y));
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
                _mapData.setCanMoveArea(new Point(x, y - 1));
                CanGo(x, y - 1, times);
                //Debug.Log("GO X = " + x + "Y = " + (y - 1) + "times = " + times + " UP");
            }
            if ((_mapData.getWall(x, y) | RIGHT) == RIGHT)
            {
                _mapData.setCanMoveArea(new Point(x + 1, y));
                CanGo(x + 1, y, times);
                //Debug.Log("GO X = " + (x + 1) + "Y = " + y + "times = " + times + " RIGHT");
            }
            if ((_mapData.getWall(x, y) | DOWN) == DOWN)
            {
                _mapData.setCanMoveArea(new Point(x, y + 1));
                CanGo(x, y + 1, times);
                //Debug.Log("GO X = " + x + "Y = " + (y + 1) + "times = " + times + " DOWN");
            }
            if ((_mapData.getWall(x, y) | LEFT) == LEFT)
            {
                _mapData.setCanMoveArea(new Point(x - 1, y));
                CanGo(x - 1, y, times);
                //Debug.Log("GO X = " + (x - 1) + "Y = " + y + "times = " + times + " LEFT");
            }
        }
        return;
    }

    //搜尋可以走的區塊並加入資料
    public void GHS_CanGo(int x, int y)//原始座標x,y剩餘次數
    {
        CanGoDirection(x, y, 0); //上
        CanGoDirection(x, y, 1); //右
        CanGoDirection(x, y, 2); //下
        CanGoDirection(x, y, 3); //左
    }

    //直線方向判斷可走區域
    private void CanGoDirection(int x, int y, int dir)// dir : 0=上 1=右 2=下 3=左
    {
        int goSteps = 0;
        while (true)
        {
            goSteps++;
            int goX = x, goY = y;
            if (dir == 0)
                goY -= goSteps;
            else if (dir == 1)
                goX += goSteps;
            else if (dir == 2)
                goY += goSteps;
            else if (dir == 3)
                goX -= goSteps;

            int isRrdieect = CheckRedirectCanGo(goX, goY);
            if (isRrdieect != -1)
            {
                _mapData.setCanMoveArea(new Point(goX, goY));
                this.CanGoDirection(goX, goY, isRrdieect);
                break;
            }
            if (CheckBlockCanGo(goX, goY))
            {
                _mapData.setCanMoveArea(new Point(goX, goY));
                continue;
            }
            break;
        }
    }

    // 判斷CanGo障礙物
    private bool CheckBlockCanGo(int x, int y)
    {
        //在地圖範圍外
        if (x < 0 || y < 0 || x > ScreenWidthBlock - 1 || y > ScreenHeightBlock - 1)
            return false;
        //碰到玩家
        for (int enablePlayer = 0; enablePlayer < 4; enablePlayer++)
        {
            if (_playerState.GetIsPlayerEnableOrNotByIndex(enablePlayer))
            {
                Point playerPos = this._mapData.getPlayerPos(enablePlayer);
                if (playerPos.x == x && playerPos.y == y)
                    return false;
            }
        }

        return true;
    }

    // 判斷CanGo洋流
    private int CheckRedirectCanGo(int x, int y)
    {
        //碰到玩家
        for (int enablePlayer = 0; enablePlayer < 4; enablePlayer++)
        {
            if (_playerState.GetIsPlayerEnableOrNotByIndex(enablePlayer))
            {
                Point playerPos = this._mapData.getPlayerPos(enablePlayer);
                if (playerPos.x == x && playerPos.y == y)
                    return 0;
            }
        }

        return -1;
    }

    //畫玩家的圓形
    private void DrawPlayer(int ID)
    {
        Point[] P = new Point[2];
        P = PosToBlock((int)(_mapData.getPlayerPos(ID).x), (int)(_mapData.getPlayerPos(ID).y));
        Imgproc.circle(_mapMat, new Point(_mapWidth - ((P[0].x + P[1].x) / 2), _mapHeight - ((P[0].y + P[1].y) / 2)), (int)((P[1].x - P[0].x) / 3), _playerColor[ID], _playerThickness);
    }

    //回傳是否得到寶藏 得到->true 沒得到->false
    private bool GetTreadsureOrNot(int playerID)
    {
        if (_mapData.getTreadsurePos().Exists(Point =>Point.x == _mapData.getPlayerPos(playerID).x && Point.y == _mapData.getPlayerPos(playerID).y))
            return true;
        return false;
    }

    //回傳是否得到晶球 得到->true 沒得到->false
    private bool GetSightOrNot(int playerID)
    {
        if (_mapData.getSightPos().Exists(Point => Point.x == _mapData.getPlayerPos(playerID).x && Point.y == _mapData.getPlayerPos(playerID).y))
        {
            int SightID =  _mapData.getSightPos().FindIndex(Point => Point.x == _mapData.getPlayerPos(playerID).x && Point.y == _mapData.getPlayerPos(playerID).y);
            _mapData.removeSight(SightID);
            _sight[SightID].SetActive(false);
            SightPosInit();
            return true;
        }       
        return false;
    }

    //回傳是否得到炸彈 得到->true 沒得到->false
    private bool GetBombOrNot(int playerID)
    {
        if (_mapData.getBombPos().Exists(Point => Point.x == _mapData.getPlayerPos(playerID).x && Point.y == _mapData.getPlayerPos(playerID).y))
        {
            int BombID = _mapData.getBombPos().FindIndex(Point => Point.x == _mapData.getPlayerPos(playerID).x && Point.y == _mapData.getPlayerPos(playerID).y);
            _boomTimer += Time.deltaTime;
            _moveState.text = "Boom";
            _bomb[BombID].SetActive(true);
            _boomTip.transform.localPosition = new Vector3(292, -120, -1);
            this.BlowUp(_boomTip, _boomTimer);
            if (_boomTimer > _boomTriggerTime)
            {
                _boomTimer = 0f;
                _mapData.removeBomb(BombID);
                _bomb[BombID].transform.Translate(0, 0, 2);
                _bomb[BombID].SetActive(false);
                BoomPosInit();
                _boomTip.transform.localPosition = new Vector3(500, -500, 10);
                return true;
            }        
        }
        return false;
    }

    //回傳是否得到照明燈 得到->true 沒得到->false
    private bool GetFlashLightOrNot(int playerID)
    {
        if (_mapData.getFlashLightPos().Exists(Point => Point.x == _mapData.getPlayerPos(playerID).x && Point.y == _mapData.getPlayerPos(playerID).y))
        {
            int FlashLightID = _mapData.getFlashLightPos().FindIndex(Point => Point.x == _mapData.getPlayerPos(playerID).x && Point.y == _mapData.getPlayerPos(playerID).y);
            _mapData.removeFlashLight(FlashLightID);
            _flashLights[FlashLightID].SetActive(false);
            BoomPosInit();
            return true;
        }
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

    //畫地圖
    public void DrawMap()
    {
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
                else if (_isCheatMode)
                {
                    DrawMazeBlock(j, i, _mapData.getWall(j, i));
                }
            }
        }
        //劃出地圖邊界
        Imgproc.rectangle(_mapMat, new Point(0, 0), new Point(_mapMat.width() - 1, _mapMat.height() - 1), _mapWellColor, _mapWellThickness);
    }

    //畫格子,DrawMap子function
    public void DrawMazeBlock(int x,int y,byte Block)
    {
        //取得方格對應的兩點座標
        Point[] P = PosToBlock(x, y);
        //畫格子與外框(-1是實心)
        Imgproc.rectangle(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), _canGoBlockColor,-1);
        Imgproc.rectangle(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), _blockLineColor, _mapBlockThickness);

        //Debug.Log("Draw x = " + x + "y = " + y + "Pos_X" + P[0].x+ "Pos_Y" + P[0].y);
        //畫牆壁
        if ((_mapData.getWall(x, y) & 8) == 8 || true)//UP
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[0].y), _mapWellColor, _mapWellThickness);
        }
        if ((_mapData.getWall(x, y) & 4) == 4 || true)//R
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[1].x, _mapHeight - P[0].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), _mapWellColor, _mapWellThickness);
        }
        if ((_mapData.getWall(x, y) & 2) == 2 || true)//D
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[1].y), new Point(_mapWidth - P[1].x, _mapHeight - P[1].y), _mapWellColor, _mapWellThickness);
        }
        if ((_mapData.getWall(x, y) & 1) == 1 || true)//L
        {
            Imgproc.line(_mapMat, new Point(_mapWidth - P[0].x, _mapHeight - P[0].y), new Point(_mapWidth - P[0].x, _mapHeight - P[1].y), _mapWellColor, _mapWellThickness);
        }
    }

    //初始化地圖方格座標
    private void InitBlock()
    {
        //新增開始區塊範圍
        for (int i = 0; i < ScreenHeightBlock; i++)
        {
            for (int j = 0; j < ScreenWidthBlock ; j++)
            {
                //StartBlock[i, j] = new mapBlock();
                StartBlock[i, j].minPos = new Point((double)(_mapWidth * (j / (double)ScreenWidthBlock)), (double)(_mapHeight * (i / (double)ScreenHeightBlock)));
                StartBlock[i, j].maxPos = new Point((double)(_mapWidth * ((j + 1) / (double)ScreenWidthBlock)), (double)(_mapHeight * ((i + 1) / (double)ScreenHeightBlock)));
            }
        }
    }

    //設定旗標決定是否畫圖和是否顯示Debug資訊
    public void SetIsSaveAndisDebug()
    {
        if (Input.GetKeyUp(_saveKey))
        {
            _isDraw = (_isDraw) ? false : true;
            Debug.Log((_isDraw) ? "isSave Set True" : "isSave Set false");
            _moveState.text = (_isDraw) ? "Game Start" : "Place chess on the circle";
        }
        if (Input.GetKeyUp(_debugKey))
        {
            _isDebug = (_isDebug) ? false : true;
            Debug.Log((_isDebug) ? "isDebug Set True" : "isDebug Set false");
        }
        if (Input.GetKeyUp(_fullMapKey))
        {
            _isCheatMode = (_isCheatMode) ? false : true;
            Debug.Log((_isCheatMode) ? "isFullMap Set True" : "isFullMap Set false");
        }
        if (Input.GetKeyUp(_reSetKey))
        {
            _isReSet = (_isReSet) ? false : true;
            Debug.Log((_isReSet) ? "isReSet Set True" : "isReSet Set false");
        }
        if (Input.GetKeyUp(_nextLevel))
        {
            _isNextLevel = (_isNextLevel) ? false : true;
            Debug.Log((_isNextLevel) ? "_isNextLevel Set True" : "_isNextLevel Set false");
        }
    }

    //換場輪替的旗幟轉換
    public void FlageMove()
    {
        int playerIndex = _round % _playerState.GetEnablePlayerCount();
        int corner = _playerState.GetRealPlayerCornerByIndex(playerIndex);
        //旗標座標移動
        switch (_whoRound)
        {
            case 0:
                _flages.transform.localPosition = new Vector3(70, 0, 0);
                break;
            case 1:
                _flages.transform.localPosition = new Vector3(600, 0, 0);
                break;
            case 2:
                _flages.transform.localPosition = new Vector3(600, -200, 0);
                break;
            case 3:
                _flages.transform.localPosition = new Vector3(70, -200, 0);
                break;
            default:
                break;
        }
    }

    //閃爍效果
    public void Flicker()
    {
        _flickerTimer += Time.deltaTime;
        if (_flickerTimer > _flickerTriggerTime && _flicker)
        {
            _flickerTimer = 0f;
            _treasure.transform.Translate(0, 0, 2);
            _sight[0].transform.Translate(0, 0, 2);
            _sight[1].transform.Translate(0, 0, 2);
            _playerThickness = 1;
            _flicker = false;
        }
        else if (_flickerTimer > _flickerTriggerTime && !_flicker)
        {
            _flickerTimer = 0f;
            _treasure.transform.Translate(0, 0, -2);
            _sight[0].transform.Translate(0, 0, -2);
            _sight[1].transform.Translate(0, 0, -2);
            _playerThickness = -1;
            _flicker = true;
        }
    }

    //碰到道具的圖片放大效果
    public void BlowUp(RawImage inObject, float time)
    {
        float Rect = time / _boomTriggerTime;
        float Enlarge = 3;
        Rect *= Enlarge;
        if (Rect > (Enlarge / 2)) inObject.transform.localScale = new Vector3(Enlarge - Rect, Enlarge - Rect, 0);
        else  inObject.transform.localScale = new Vector3(Rect, Rect, 0);
    }

    private void DrawReadyGame()
    {
        _mapMat.setTo(_FogOfWarColor);
        Utils.matToTexture2D(_mapMat, _tex);
        gameObject.GetComponent<Renderer>().material.mainTexture = _tex;
    }
}
