using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    //遊戲狀態
    public GameStateIndex _gameStateIndex;

    public GameObject[] _menuBackGroundImages;
    public GameObject[] _settingBackGroundImages;
    public GameObject[] _listProducerBackGroundImages;
    public GameObject[] _gameRunBackGroundImages;

    //頁面按鈕
    public Button[] _inMenuButton;
    public Button[] _inSettingButton;
    public Button[] _inSettingLevelChoiceButton;
    public Button[] _inGameRunButton;
    public Button[] _inListProducerButton;
    
    //setting畫面中的ui
    public Slider[] _inSettingSoundSlider;
    public Text[] _inSettingText;

    public GameLevelIndex _levelIndex;

    private float _effectTimer = 1f;
    private float _readyTimer = 1f;

    void Start()
    {
        GHSPlayerState _playerState = gameObject.GetComponent<GHSPlayerState>();
    }

    void Update()
    {
        _inSettingText[0].text = "背景音量: " + _inSettingSoundSlider[0].value.ToString("0");
        _inSettingText[1].text = "音效音量: " + _inSettingSoundSlider[1].value.ToString("0");


        for (int index = 0; index < _inSettingLevelChoiceButton.Length; index++)
        {
            if (index == _levelIndex.CurrentLevelIndex)
            {
                _inSettingLevelChoiceButton[index].interactable = false;
            }
            else
            {
                _inSettingLevelChoiceButton[index].interactable = true;
            }
        }
    }

    //用function name字串呼叫function
    public void CallFuncByString(string funcName)
    {
        System.Reflection.MethodInfo mi = this.GetType().GetMethod(funcName);
        mi.Invoke(this, null);
    }

    IEnumerator MenuToSetting()
    {
        yield return new WaitForSeconds(_effectTimer);
        _gameStateIndex.ToStateSetting();
        this.SwitchBackGroundImagesByStateFlag();
        //yield return new WaitForSeconds(_readyTimer);
        this.SwitchGameStateByStateFlag();

        _inSettingButton[1].GetComponentInChildren<Text>().text = "開始遊戲";
    }

    //從開始畫面到設定畫面按鈕事件(menu -> setting)
    public void GameStateMenuToSettingButtonClick()
    {
        StartCoroutine(MenuToSetting());
    }

    IEnumerator SettingToGameRun()
    {
        yield return new WaitForSeconds(_effectTimer);
        _gameStateIndex.ToStateGameRun();
        this.SwitchBackGroundImagesByStateFlag();
        //yield return new WaitForSeconds(_readyTimer);
        this.SwitchGameStateByStateFlag();

        _inMenuButton[0].GetComponentInChildren<Text>().text = "設定";

        //ViewActiveEnableOrDisable(true);
    }

    //從設定畫面到遊戲執行按鈕事件(setting -> gameRun)
    public void GameStateSettingToGameRunButtonClick()
    {
        StartCoroutine(SettingToGameRun());
    }

    IEnumerator GameRunToSetting()
    {
        yield return new WaitForSeconds(_effectTimer);
        _gameStateIndex.ToStateSetting();
        this.SwitchBackGroundImagesByStateFlag();
        //yield return new WaitForSeconds(_readyTimer);
        this.SwitchGameStateByStateFlag();

        _inSettingButton[1].GetComponentInChildren<Text>().text = "繼續遊戲";

        //this.ViewActiveEnableOrDisable(false);
    }

    //從遊戲執行到設定畫面按鈕事件(gameRun -> setting)
    public void GameStateGameRunToSettingButtonClick()
    {
        StartCoroutine(GameRunToSetting());
    }

    IEnumerator SettingToMenu()
    {
        yield return new WaitForSeconds(_effectTimer);
        _gameStateIndex.ToStateMenu();
        this.SwitchBackGroundImagesByStateFlag();
        //yield return new WaitForSeconds(_readyTimer);
        this.SwitchGameStateByStateFlag();

        _inMenuButton[0].GetComponentInChildren<Text>().text = "進入設定並開始遊戲";
    }

    //從設定畫面到開始畫面按鈕事件(setting -> menu)
    public void GameStateSettingToMenuButtonClick()
    {
        StartCoroutine(SettingToMenu());
    }

    IEnumerator SettingToListProducer()
    {
        yield return new WaitForSeconds(_effectTimer);
        _gameStateIndex.ToStateListProducer();
        this.SwitchBackGroundImagesByStateFlag();
        //yield return new WaitForSeconds(_readyTimer);
        this.SwitchGameStateByStateFlag();

        //_exitFlage = false;
        //_listProducerBackGroundImage.SetActive(true);
    }

    //按下製作人按鈕事件
    public void GameStateSettingToListProducerButtonClick()
    {
        StartCoroutine(SettingToListProducer());
    }

    IEnumerator ListProducerToSetting()
    {
        yield return new WaitForSeconds(_effectTimer);
        _gameStateIndex.ToStateSetting();
        this.SwitchBackGroundImagesByStateFlag();
        //yield return new WaitForSeconds(_readyTimer);
        this.SwitchGameStateByStateFlag();

        //_resetFlage = true;
        //_exitFlage = true;
    }

    //按下回設定事件(在按下製作人後出現的按鈕)
    public void GameStateListProducerToSettingButtonClick()
    {
        StartCoroutine(ListProducerToSetting());
    }

    public void SwitchGameStateByStateFlag()
    {
        switch (_gameStateIndex.GetCurrentGameStateIndex())
        {
            case GameState.Menu:
                {
                    this.InMenuGameObjectEnableOrDisable(true);
                    this.InSettingGameObjectEnableOrDisable(true);
                    this.InGameRunGameObjectEnableOrDisable(true);
                    this.InListProducerObjectEnableOrDisable(true);
                    break;
                }
            case GameState.Setting:
                {
                    this.InMenuGameObjectEnableOrDisable(true);
                    this.InSettingGameObjectEnableOrDisable(true);
                    this.InGameRunGameObjectEnableOrDisable(true);
                    this.InListProducerObjectEnableOrDisable(true);
                    break;
                }
            case GameState.GameRun:
                {
                    this.InMenuGameObjectEnableOrDisable(true);
                    this.InSettingGameObjectEnableOrDisable(true);
                    this.InGameRunGameObjectEnableOrDisable(true);
                    this.InListProducerObjectEnableOrDisable(true);
                    break;
                }
            case GameState.ListProducer:
                {
                    this.InMenuGameObjectEnableOrDisable(true);
                    this.InSettingGameObjectEnableOrDisable(true);
                    this.InGameRunGameObjectEnableOrDisable(true);
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

        //_menuBackGroundImage.SetActive(value);
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

        //_settingBackGroundImage.SetActive(value);
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

        //_listProducerBackGroundImage.SetActive(value);
    }

    //////////////////////////////////////////////////////
    /// 背景影像群處理
    //////////////////////////////////////////////////////

    //menu的背景圖片群顯示與否
    private void MenuBackGroundImagesEnableOrDisable(bool value)
    {
        //menu的背景圖片群
        for (int index = 0; index < _menuBackGroundImages.Length; index++)
        {
            _menuBackGroundImages[index].gameObject.SetActive(value);
        }
    }

    //setting的背景圖片群顯示與否
    private void SettingBackGroundImagesEnableOrDisable(bool value)
    {
        //setting的背景圖片群
        for (int index = 0; index < _settingBackGroundImages.Length; index++)
        {
            _settingBackGroundImages[index].gameObject.SetActive(value);
        }
    }

    //gameRun的背景圖片群顯示與否
    private void GameRunBackGroundImagesEnableOrDisable(bool value)
    {
        //listProducer的背景圖片群
        for (int index = 0; index < _gameRunBackGroundImages.Length; index++)
        {
            _gameRunBackGroundImages[index].gameObject.SetActive(value);
        }
    }

    //listProducer的背景圖片群顯示與否
    private void ListProducerBackGroundImagesEnableOrDisable(bool value)
    {
        //listProducer的背景圖片群
        for (int index = 0; index < _listProducerBackGroundImages.Length; index++)
        {
            _listProducerBackGroundImages[index].gameObject.SetActive(value);
        }
    }

    public void SwitchBackGroundImagesByStateFlag()
    {
        switch (_gameStateIndex.GetCurrentGameStateIndex())
        {
            case GameState.Menu:
                {
                    this.MenuBackGroundImagesEnableOrDisable(true);
                    this.SettingBackGroundImagesEnableOrDisable(false);
                    this.GameRunBackGroundImagesEnableOrDisable(false);
                    this.ListProducerBackGroundImagesEnableOrDisable(false);
                    break;
                }
            case GameState.Setting:
                {
                    this.MenuBackGroundImagesEnableOrDisable(false);
                    this.SettingBackGroundImagesEnableOrDisable(true);
                    this.GameRunBackGroundImagesEnableOrDisable(false);
                    this.ListProducerBackGroundImagesEnableOrDisable(false);
                    break;
                }
            case GameState.GameRun:
                {
                    this.MenuBackGroundImagesEnableOrDisable(false);
                    this.SettingBackGroundImagesEnableOrDisable(false);
                    this.GameRunBackGroundImagesEnableOrDisable(true);
                    this.ListProducerBackGroundImagesEnableOrDisable(false);
                    break;
                }
            case GameState.ListProducer:
                {
                    this.MenuBackGroundImagesEnableOrDisable(false);
                    this.SettingBackGroundImagesEnableOrDisable(false);
                    this.GameRunBackGroundImagesEnableOrDisable(false);
                    this.ListProducerBackGroundImagesEnableOrDisable(true);
                    break;
                }
            default:
                {
                    this.MenuBackGroundImagesEnableOrDisable(false);
                    this.SettingBackGroundImagesEnableOrDisable(false);
                    this.GameRunBackGroundImagesEnableOrDisable(false);
                    this.ListProducerBackGroundImagesEnableOrDisable(false);
                    break;
                }
        }
    }
}
