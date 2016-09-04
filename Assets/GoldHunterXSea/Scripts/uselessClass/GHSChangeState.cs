using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class GHSChangeState : MonoBehaviour {

    public GHSPlayerState _playerState;
    public GameObject[] gameTip;
    public GameObject[] playerStateObject;
    public GameObject[] playerCoordinate;
    public Text gameStateButtonText;
    public GameObject gameStartGround;

    public Button[] _inMenuButton;
    public Button[] _inSettingButton;
    public Button[] _inGameRunButton;
    public Button[] _inListProducerButton;

    public Text _gameStateMenuToSettingButtonText;
    public Text _gameStateSettingToGameRunButtonText;
    public Text _gameStateGameRunToSettingButtonText;
    public Text _gameStateSettingToMenuButtonText;
    
    public Button _gameStateMenuToSettingButton;
    public Button _gameStateSettingToGameRunButton;
    public Button _gameStateGameRunToSettingButton;
    public Button _gameStateSettingToMenuButton;

    public Button _listProducerButton;


    void Start()
    {
        GHSPlayerState _playerState = gameObject.GetComponent<GHSPlayerState>();
    }

    //從開始畫面到設定畫面按鈕事件
    public void GameStateMenuToSettingButtonClick()
    {
        for(int index = 0; index < _inMenuButton.Length; index++)
        {
            _inMenuButton[index].gameObject.SetActive(false);
        }

        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(true);
        }

        for (int index = 0; index < _inGameRunButton.Length; index++)
        {
            _inGameRunButton[index].gameObject.SetActive(false);
        }

        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(false);
        }

        _gameStateSettingToGameRunButtonText.text = "開始遊戲";

        gameStartGround.SetActive(true);
    }

    //從設定畫面到遊戲執行按鈕事件
    public void GameStateSettingToGameRunButtonClick()
    {
        for (int index = 0; index < _inMenuButton.Length; index++)
        {
            _inMenuButton[index].gameObject.SetActive(false);
        }

        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(false);
        }

        for (int index = 0; index < _inGameRunButton.Length; index++)
        {
            _inGameRunButton[index].gameObject.SetActive(true);
        }

        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(false);
        }

        _gameStateGameRunToSettingButtonText.text = "設定";

        gameStartGround.SetActive(false);
        ViewActiveEnable();
    }

    //從遊戲執行到設定畫面按鈕事件
    public void GameStateGameRunToSettingButtonClick()
    {
        for (int index = 0; index < _inMenuButton.Length; index++)
        {
            _inMenuButton[index].gameObject.SetActive(false);
        }

        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(true);
        }

        for (int index = 0; index < _inGameRunButton.Length; index++)
        {
            _inGameRunButton[index].gameObject.SetActive(false);
        }

        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(false);
        }

        _gameStateSettingToGameRunButtonText.text = "繼續遊戲";

        gameStartGround.SetActive(true);
    }

    //從設定畫面到開始畫面按鈕事件
    public void GameStateSettingToMenuButtonClick()
    {
        for (int index = 0; index < _inMenuButton.Length; index++)
        {
            _inMenuButton[index].gameObject.SetActive(true);
        }

        for (int index = 0; index < _inSettingButton.Length; index++)
        {
            _inSettingButton[index].gameObject.SetActive(false);
        }

        for (int index = 0; index < _inGameRunButton.Length; index++)
        {
            _inGameRunButton[index].gameObject.SetActive(false);
        }

        for (int index = 0; index < _inListProducerButton.Length; index++)
        {
            _inListProducerButton[index].gameObject.SetActive(false);
        }

        gameStartGround.SetActive(true);
    }

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
    }
}
