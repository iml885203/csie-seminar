using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class PlayerViewInformation : MonoBehaviour 
{
    public PlayerData[] _playerData;
    public Text[] _playerMoneyText;
    public Image[] _playerViewArea;

    // Use this for initialization
    void Start ()
    {
        for (int index = 0; index < _playerViewArea.Length; index++)
        {
            _playerViewArea[index].color = _playerData[index].PlayerColor;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    for(int index = 0; index < _playerData.Length; index++)
        {
            _playerMoneyText[index].text = _playerData[index].PlayerMoney.ToString();
        }
	}
}
