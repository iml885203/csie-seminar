using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    //遊戲狀態
    public int _stateFlag;

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
    
    //setting畫面中的ui
    public Slider[] _inSettingSoundSlider;
    public Text[] _inSettingText;

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

            RectTransform temp = _textListProducer[0].transform as RectTransform;
            temp.anchoredPosition = new Vector3(402, -102, 0);
            temp = _textListProducer[1].transform as RectTransform;
            temp.anchoredPosition = new Vector3(402, -302, 0);
            temp = _textListProducer[2].transform as RectTransform;
            temp.anchoredPosition = new Vector3(402, -502, 0);


            _resetFlage = false;
        }
        _inSettingText[0].text = "背景音樂音量: " + _inSettingSoundSlider[0].value.ToString("0");
        _inSettingText[1].text = "音效音量: " + _inSettingSoundSlider[1].value.ToString("0");


        for (int index = 0; index < _inSettingLevelChoiceButton.Length; index++)
        {
            if (index == int.Parse(_levelFlagText.text.ToString()) - 1)
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
        _stateFlag = GameState.Setting;
        this.SwitchGameStateByStateFlag();

        _inSettingButton[1].GetComponentInChildren<Text>().text = "開始遊戲";
    }

    //從設定畫面到遊戲執行按鈕事件(setting -> gameRun)
    public void GameStateSettingToGameRunButtonClick()
    {
        _stateFlag = GameState.GameRun;
        this.SwitchGameStateByStateFlag();

        _inMenuButton[0].GetComponentInChildren<Text>().text = "設定";

        ViewActiveEnableOrDisable(true);
    }

    //從遊戲執行到設定畫面按鈕事件(gameRun -> setting)
    public void GameStateGameRunToSettingButtonClick()
    {
        _stateFlag = GameState.Setting;
        this.SwitchGameStateByStateFlag();

        _inSettingButton[1].GetComponentInChildren<Text>().text = "繼續遊戲";

        this.ViewActiveEnableOrDisable(false);
    }

    //從設定畫面到開始畫面按鈕事件(setting -> menu)
    public void GameStateSettingToMenuButtonClick()
    {
        _stateFlag = GameState.Menu;
        this.SwitchGameStateByStateFlag();

        _inMenuButton[0].GetComponentInChildren<Text>().text = "進入設定並開始遊戲";
    }

    //按下製作人按鈕事件
    public void GameStateSettingToListProducerButtonClick()
    {
        _stateFlag = GameState.ListProducer;
        this.SwitchGameStateByStateFlag();

        _exitFlage = false;
        _listProducerBackGroundImage.SetActive(true);
    }

    //按下回設定事件(在按下製作人後出現的按鈕)
    public void GameStateListProducerToSettingButtonClick()
    {
        _stateFlag = GameState.Setting;
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
    private void RunListProducer()
    {
        //當最後一個字幕經過指定條件後，則進行一次重設字幕
        if (_textListProducer[2].transform.position.y >= -3)
        {
            _resetFlage = true;
        }

        //移動主程式
        if (_textListProducer[2].transform.position.y < 30 && !_exitFlage)//_textListProducer[2].transform.position.y < 300 ||
        {
            _textListProducer[0].transform.Translate(0, 0.5f, 0);
            _textListProducer[1].transform.Translate(0, 0.5f, 0);
            _textListProducer[2].transform.Translate(0, 0.5f, 0);
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
        switch (_stateFlag)
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
        //遊戲UI狀態設定
    }
}
