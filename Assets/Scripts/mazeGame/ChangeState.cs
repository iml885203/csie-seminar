using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeState : MonoBehaviour {

    public GameObject[] mazeGameObject;
    public Text gameStateButtonText;
    public GameObject gameStartGround;
    public void bouttonClick()
    {
        for (int i = 0; i < mazeGameObject.Length; i++)
        {
            if (mazeGameObject[i] == null) continue;
            mazeGameObject[i].SetActive(!mazeGameObject[i].active);
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
