using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class GHSButtonEvent : MonoBehaviour
{
    //存取玩家狀態
    public GHSPlayerState _playerState;

    //遊戲UI提示gameObject
    public GameObject[] gameTip;
    public GameObject[] playerStateObject;
    public GameObject[] playerCoordinate;

    //遊戲開始畫面
    public GameObject gameStartGround;

    //頁面按鈕
    public Button[] _inMenuButton;
    public Button[] _inSettingButton;
    public Button[] _inGameRunButton;
    public Button[] _inListProducerButton;

    //按鈕文字
    public Text _gameStateMenuToSettingButtonText;
    public Text _gameStateSettingToGameRunButtonText;
    public Text _gameStateGameRunToSettingButtonText;
    public Text _gameStateSettingToMenuButtonText;

    //setting畫面中的ui
    public Slider[] _inSettingSoundSlider;
    public Text[] _inSettingSoundText;

    //製作人顯示的離開與重設flag
    private bool _exitFlage = true;
    private bool _resetFlage = false;

    //製作人顯示字幕及背景
    public Text[] _textListProducer;
    public GameObject _backGround;

    void Start()
    {
        GHSPlayerState _playerState = gameObject.GetComponent<GHSPlayerState>();
    }

    void Update()
    {
        this.RunListProducer();
        //在字幕離開
        if (_exitFlage && _resetFlage)
        {
            _backGround.SetActive(false);

            for (int index = 0; index < _inSettingButton.Length; index++)
            {
                _inSettingButton[index].gameObject.SetActive(true);
            }

            RectTransform backGroundRectTransform = _backGround.GetComponent<RectTransform>();
            _textListProducer[0].transform.position = new Vector3(backGroundRectTransform.rect.x, backGroundRectTransform.rect.y - backGroundRectTransform.rect.height, 0);
            _textListProducer[1].transform.position = new Vector3(backGroundRectTransform.rect.x, _textListProducer[0].transform.position.y - backGroundRectTransform.rect.height, 0);
            _textListProducer[2].transform.position = new Vector3(backGroundRectTransform.rect.x, _textListProducer[1].transform.position.y - backGroundRectTransform.rect.height, 0);

            _resetFlage = false;
        }
    }

    //從開始畫面到設定畫面按鈕事件(menu -> setting)
    public void GameStateMenuToSettingButtonClick()
    {
        //menu的按鈕顯示
        for (int index = 0; index < _inMenuButton.Length; index++)
        {
            _inMenuButton[index].gameObject.SetActive(false);
        }

        //setting的按鈕顯示
        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(true);
        }

        //gameRun的按鈕消失
        for (int index = 0; index < _inGameRunButton.Length; index++)
        {
            _inGameRunButton[index].gameObject.SetActive(false);
        }

        //listProducer的按鈕消失
        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(false);
        }

        _gameStateSettingToGameRunButtonText.text = "開始遊戲";

        gameStartGround.SetActive(true);
    }

    //從設定畫面到遊戲執行按鈕事件(setting -> gameRun)
    public void GameStateSettingToGameRunButtonClick()
    {
        //menu的按鈕顯示
        for (int index = 0; index < _inMenuButton.Length; index++)
        {
            _inMenuButton[index].gameObject.SetActive(false);
        }

        //setting的按鈕消失
        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(false);
        }

        //gameRun的按鈕顯示
        for (int index = 0; index < _inGameRunButton.Length; index++)
        {
            _inGameRunButton[index].gameObject.SetActive(true);
        }

        //listProducer的按鈕消失
        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(false);
        }

        _gameStateGameRunToSettingButtonText.text = "設定";

        gameStartGround.SetActive(false);
        ViewActiveEnable();
    }

    //從遊戲執行到設定畫面按鈕事件(gameRun -> setting)
    public void GameStateGameRunToSettingButtonClick()
    {
        //menu的按鈕顯示
        for (int index = 0; index < _inMenuButton.Length; index++)
        {
            _inMenuButton[index].gameObject.SetActive(false);
        }

        //setting的按鈕顯示
        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(true);
        }

        //gameRun的按鈕消失
        for (int index = 0; index < _inGameRunButton.Length; index++)
        {
            _inGameRunButton[index].gameObject.SetActive(false);
        }

        //listProducer的按鈕消失
        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(false);
        }

        _gameStateSettingToGameRunButtonText.text = "繼續遊戲";

        gameStartGround.SetActive(true);
    }

    //從設定畫面到開始畫面按鈕事件(setting -> menu)
    public void GameStateSettingToMenuButtonClick()
    {
        //menu的按鈕顯示
        for (int index = 0; index < _inMenuButton.Length; index++)
        {
            _inMenuButton[index].gameObject.SetActive(true);
        }

        //setting的按鈕消失
        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(false);
        }

        //gameRun的按鈕消失
        for (int index = 0; index < _inGameRunButton.Length; index++)
        {
            _inGameRunButton[index].gameObject.SetActive(false);
        }

        //listProducer的按鈕消失
        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(false);
        }

        _gameStateMenuToSettingButtonText.text = "進入設定並開始遊戲";

        gameStartGround.SetActive(true);
    }

    //按下製作人按鈕事件
    public void GameStateListProducerButtonClick()
    {
        _exitFlage = false;
        _backGround.SetActive(true);

        //listProducer的按鈕顯示
        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(true);
        }

        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(false);
        }
    }

    //按下回設定事件(在按下製作人後出現的按鈕)
    public void GameStateListProducerBackToMenuButtonClick()
    {
        _resetFlage = true;
        _exitFlage = true;

        //setting的按鈕消失
        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(true);
        }

        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(false);
        }
    }

    //字幕移動
    void RunListProducer()
    {
        //當最後一個字幕經過指定條件後，則進行一次重設字幕
        if (_textListProducer[2].transform.position.y >= 500)
        {
            _resetFlage = true;
        }

        //移動主程式
        if (_textListProducer[2].transform.position.y < 500 && !_exitFlage)//_textListProducer[2].transform.position.y < 300 ||
        {
            _textListProducer[0].transform.Translate(0, 10, 0);
            _textListProducer[1].transform.Translate(0, 10, 0);
            _textListProducer[2].transform.Translate(0, 10, 0);
        }
        else
        {
            //判定為字幕已離開，並將回設定的按鈕取消active
            _exitFlage = true;
            for (int index = 0; index < _inListProducerButton.Length; index++)
            {
                _inListProducerButton[index].gameObject.SetActive(false);
            }
        }
    }

    //顯示提示圖示的副程式
    private void ViewActiveEnable()
    {
        //遊戲提示顯示
        for (int i = 0; i < gameTip.Length; i++)
        {
            if (gameTip[i] == null) continue;
            gameTip[i].SetActive(!gameTip[i].activeSelf);
        }

        //玩家狀態顯示
        for (int i = 0; i < playerStateObject.Length; i++)
        {
            if (playerStateObject[i] == null || !_playerState.GetIsPlayerEnableOrNotByIndex(i)) continue;
            playerStateObject[i].SetActive(!playerStateObject[i].activeSelf);
        }

        //玩家座標顯示
        for (int i = 0; i < playerCoordinate.Length; i++)
        {
            if (playerCoordinate[i] == null || !_playerState.GetIsPlayerEnableOrNotByIndex(i)) continue;
            playerCoordinate[i].SetActive(!playerCoordinate[i].activeSelf);
        }

        this.gameObject.GetComponent<GHSMain>().GameStart = true;
    }
}
