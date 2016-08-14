using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GHSChangeState : MonoBehaviour {

    public GHSPlayerState _playerState;
    public GameObject[] mazeGameObject;
    public GameObject[] gameTip;
    public GameObject[] playerState;
    public GameObject[] playerCoordinate;
    public Text gameStateButtonText;
    public GameObject gameStartGround;

    public GHSChangeState()
    {

    }

    public void bouttonClick()
    {
        //for (int i = 0; i < mazeGameObject.Length; i++)
        //{
        //    if (mazeGameObject[i] == null) continue;
        //    mazeGameObject[i].SetActive(!mazeGameObject[i].activeSelf);
        //}

        for (int i = 0; i < gameTip.Length; i++)
        {
            Debug.Log("gameTip i = " + i);
            if (gameTip[i] == null) continue;
            gameTip[i].SetActive(!gameTip[i].activeSelf);
        }

        for (int i = 0; i < playerState.Length; i++)
        {
            //Debug.Log("playerState i = " + i);
            //Debug.Log("_playerState.GetIsPlayerEnableOrNotByIndex(i)" + _playerState.GetIsPlayerEnableOrNotByIndex(i));
            if (playerState[i] == null ) continue;
            playerState[i].SetActive(!playerState[i].activeSelf);
        }

        for (int i = 0; i < playerCoordinate.Length; i++)
        {

            if (playerCoordinate[i] == null) continue;
            playerCoordinate[i].SetActive(!playerCoordinate[i].activeSelf);
        }

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
