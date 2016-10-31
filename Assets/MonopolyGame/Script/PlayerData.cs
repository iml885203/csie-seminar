using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class PlayerData : MonoBehaviour
{
    //public int _playerPositionX;
    //public int _playerPositionY;
    public int _playerMoney;
    public Color _playerColor;

    public int PlayerMoney
    {
        get
        {
            return _playerMoney;
        }
        set
        {
            _playerMoney = value;
        }
    }

    public Color PlayerColor
    {
        get
        {
            return _playerColor;
        }
        set
        {
            _playerColor = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
