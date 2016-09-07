using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

static class GameState
{
    public const int Menu = 0;
    public const int Setting = 1;
    public const int GameRun = 2;
    public const int ListProducer = 3;
}

public class GHSButtonEvent : MonoBehaviour
{
    public Text _stateFlag;

    //存取玩家狀態
    public GHSPlayerState _playerState;

    //遊戲UI提示gameObject
    public GameObject[] gameTip;
    public GameObject[] playerStateObject;
    public GameObject[] playerCoordinate;

    //遊戲背景圖片
    public GameObject _menuBackGroundImage;
    public GameObject _listProducerBackGroundImage;
    public GameObject _settingBackGroundImage;

    //頁面按鈕
    public Button[] _inMenuButton;
    public Button[] _inSettingButton;
    public Button[] _inSettingLevelChoiceButton;
    public Button[] _inGameRunButton;
    public Button[] _inListProducerButton;

    //按鈕文字
    public Text _gameStateMenuToSettingButtonText;
    public Text _gameStateSettingToGameRunButtonText;
    public Text _gameStateGameRunToSettingButtonText;
    public Text _gameStateSettingToMenuButtonText;

    //setting畫面中的ui
    public Slider[] _inSettingSoundSlider;
    public Text[] _inSettingText;
    public Text[] _inMenuText;
    public Text[] _inGameRunText;

    public Text _levelFlagText;

    public GameObject[] _levelPreviewImage;

    //製作人顯示的離開與重設flag
    private bool _exitFlage = true;
    private bool _resetFlage = false;

    //製作人顯示字幕及背景
    public Text[] _textListProducer;

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
            _listProducerBackGroundImage.SetActive(false);
            _settingBackGroundImage.SetActive(true);

            this.InMenuGameObjectEnableOrDisable(false);
            this.InSettingGameObjectEnableOrDisable(true);
            this.InGameRunGameObjectEnableOrDisable(false);
            this.InListProducerObjectEnableOrDisable(false);

            RectTransform backGroundRectTransform = _listProducerBackGroundImage.GetComponent<RectTransform>();
            _textListProducer[0].transform.position = new Vector3(_textListProducer[0].transform.position.x, backGroundRectTransform.rect.y - backGroundRectTransform.rect.height, 0);
            _textListProducer[1].transform.position = new Vector3(_textListProducer[1].transform.position.x, _textListProducer[0].transform.position.y - backGroundRectTransform.rect.height, 0);
            _textListProducer[2].transform.position = new Vector3(_textListProducer[2].transform.position.x, _textListProducer[1].transform.position.y - backGroundRectTransform.rect.height, 0);

            _resetFlage = false;
        }

        _inSettingText[0].text = "背景音樂音量: " + _inSettingSoundSlider[0].value.ToString("0");
        _inSettingText[1].text = "音效音量: " + _inSettingSoundSlider[1].value.ToString("0");
        

        for (int index = 0; index < _inSettingLevelChoiceButton.Length; index++)
        {
            if(index == int.Parse(_levelFlagText.text.ToString()) - 1)
            {
                _inSettingLevelChoiceButton[index].interactable = false;
                if (_levelFlagText.gameObject.activeSelf)
                {
                    _levelPreviewImage[index].SetActive(true);
                }
            }
            else
            {
                _inSettingLevelChoiceButton[index].interactable = true;
                if (_levelFlagText.gameObject.activeSelf)
                {
                    _levelPreviewImage[index].SetActive(false);
                }
            }
        }
    }

    //從開始畫面到設定畫面按鈕事件(menu -> setting)
    public void GameStateMenuToSettingButtonClick()
    {
        _stateFlag.text = GameState.Setting.ToString();
        this.SwitchGameStateByStateFlag();

        _gameStateSettingToGameRunButtonText.text = "開始遊戲";
    }

    //從設定畫面到遊戲執行按鈕事件(setting -> gameRun)
    public void GameStateSettingToGameRunButtonClick()
    {
        _stateFlag.text = GameState.GameRun.ToString();
        this.SwitchGameStateByStateFlag();

        _gameStateGameRunToSettingButtonText.text = "設定";

        ViewActiveEnableOrDisable(true);
    }

    //從遊戲執行到設定畫面按鈕事件(gameRun -> setting)
    public void GameStateGameRunToSettingButtonClick()
    {
        _stateFlag.text = GameState.Setting.ToString();
        this.SwitchGameStateByStateFlag();

        _gameStateSettingToGameRunButtonText.text = "繼續遊戲";

        this.ViewActiveEnableOrDisable(false);
    }

    //從設定畫面到開始畫面按鈕事件(setting -> menu)
    public void GameStateSettingToMenuButtonClick()
    {
        _stateFlag.text = GameState.Menu.ToString();
        this.SwitchGameStateByStateFlag();

        _gameStateMenuToSettingButtonText.text = "進入設定並開始遊戲";
    }

    //按下製作人按鈕事件
    public void GameStateSettingToListProducerButtonClick()
    {
        _stateFlag.text = GameState.ListProducer.ToString();
        this.SwitchGameStateByStateFlag();

        _exitFlage = false;
        _listProducerBackGroundImage.SetActive(true);
    }

    //按下回設定事件(在按下製作人後出現的按鈕)
    public void GameStateListProducerToSettingButtonClick()
    {
        _stateFlag.text = GameState.Setting.ToString();
        this.SwitchGameStateByStateFlag();

        _resetFlage = true;
        _exitFlage = true;
    }

    public void ChoiceLevel1ButtonClick()
    {
        _levelFlagText.text = "1";
    }

    public void ChoiceLevel2ButtonClick()
    {
        _levelFlagText.text = "2";
    }

    public void ChoiceLevel3ButtonClick()
    {
        _levelFlagText.text = "3";
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

    private void SwitchGameStateByStateFlag()
    {
        switch (int.Parse(_stateFlag.text))
        {
            case GameState.Menu:
                {
                    this.InMenuGameObjectEnableOrDisable(true);
                    this.InSettingGameObjectEnableOrDisable(false);
                    this.InGameRunGameObjectEnableOrDisable(false);
                    this.InListProducerObjectEnableOrDisable(false);
                    break;
                }
            case GameState.Setting:
                {
                    this.InMenuGameObjectEnableOrDisable(false);
                    this.InSettingGameObjectEnableOrDisable(true);
                    this.InGameRunGameObjectEnableOrDisable(false);
                    this.InListProducerObjectEnableOrDisable(false);
                    break;
                }
            case GameState.GameRun:
                {
                    this.InMenuGameObjectEnableOrDisable(false);
                    this.InSettingGameObjectEnableOrDisable(false);
                    this.InGameRunGameObjectEnableOrDisable(true);
                    this.InListProducerObjectEnableOrDisable(false);
                    break;
                }
            case GameState.ListProducer:
                {
                    this.InMenuGameObjectEnableOrDisable(false);
                    this.InSettingGameObjectEnableOrDisable(false);
                    this.InGameRunGameObjectEnableOrDisable(false);
                    this.InListProducerObjectEnableOrDisable(true);
                    break;
                }
            default:
                {
                    this.InMenuGameObjectEnableOrDisable(false);
                    this.InSettingGameObjectEnableOrDisable(false);
                    this.InGameRunGameObjectEnableOrDisable(false);
                    this.InListProducerObjectEnableOrDisable(false);
                    break;
                }
        }
    }

    //Menu畫面物件顯示與否
    private void InMenuGameObjectEnableOrDisable(bool value)
    {
        //menu的按鈕
        for (int index = 0; index < _inMenuButton.Length; index++)
        {
            _inMenuButton[index].gameObject.SetActive(value);
        }

        _menuBackGroundImage.SetActive(value);
    }

    //Setting畫面物件顯示與否
    private void InSettingGameObjectEnableOrDisable(bool value)
    {
        //setting的按鈕
        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(value);
        }

        //setting的選關按鈕
        for (int index = 0; index < _inSettingLevelChoiceButton.Length; index++)
        {
            _inSettingLevelChoiceButton[index].gameObject.SetActive(value);
        }

        //soundSlider的拉條
        for (int index = 0; index < _inSettingSoundSlider.Length; index++)
        {
            _inSettingSoundSlider[index].gameObject.SetActive(value);
        }

        //soundSliderText的拉條文字
        for (int index = 0; index < _inSettingText.Length; index++)
        {
            _inSettingText[index].gameObject.SetActive(value);
        }

        //setting的選關預覽圖
        for (int index = 0; index < _levelPreviewImage.Length; index++)
        {
            _levelPreviewImage[index].gameObject.SetActive(value);
        }

        _levelFlagText.gameObject.SetActive(value);

        _settingBackGroundImage.SetActive(value);
    }

    //gameRun畫面物件顯示與否
    private void InGameRunGameObjectEnableOrDisable(bool value)
    {
        //gameRun的按鈕
        for (int index = 0; index < _inGameRunButton.Length; index++)
        {
            _inGameRunButton[index].gameObject.SetActive(value);
        }
    }

    //ListProducer畫面物件顯示與否
    private void InListProducerObjectEnableOrDisable(bool value)
    {
        //listProducer的按鈕
        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(value);
        }

        _listProducerBackGroundImage.SetActive(value);
    }

    //顯示提示圖示的副程式
    private void ViewActiveEnableOrDisable(bool value)
    {
        //遊戲提示顯示
        for (int i = 0; i < gameTip.Length; i++)
        {
            if (gameTip[i] == null) continue;
            gameTip[i].SetActive(value);
        }

        //玩家狀態顯示
        for (int i = 0; i < playerStateObject.Length; i++)
        {
            if (playerStateObject[i] == null || !_playerState.GetIsPlayerEnableOrNotByIndex(i)) continue;
            playerStateObject[i].SetActive(value);
        }

        //玩家座標顯示
        for (int i = 0; i < playerCoordinate.Length; i++)
        {
            if (playerCoordinate[i] == null || !_playerState.GetIsPlayerEnableOrNotByIndex(i)) continue;
            playerCoordinate[i].SetActive(value);
        }

        this.gameObject.GetComponent<GHSMain>().GameStart = true;
    }
}
