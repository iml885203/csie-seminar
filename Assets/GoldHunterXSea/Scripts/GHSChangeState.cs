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

    void Start()
    {
        GHSPlayerState _playerState = gameObject.GetComponent<GHSPlayerState>();
    }

    public void bouttonClick()
    {
        //遊戲提示顯示
        for (int i = 0; i < gameTip.Length; i++)
        {
            if (gameTip[i] == null) continue;
            gameTip[i].SetActive(!gameTip[i].activeSelf );
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

        //轉換按鈕文字start, back menu轉換
        if (gameStateButtonText.text == "Start")
        {
            gameStateButtonText.text = "Back Menu";
            gameStartGround.SetActive(false);
        }
        else
        {
            gameStateButtonText.text = "Start";
            gameStartGround.SetActive(true);
        }
    }

    
}
