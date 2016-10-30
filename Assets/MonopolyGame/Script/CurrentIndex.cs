using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class CurrentIndex : MonoBehaviour
{
    public int _currentPlayerIndex;
    public PlayerData[] _allPlayer;
    public PlayerData _currentPlayer;

    public int CurrentPlayerIndex
    {
        get
        {
            return _currentPlayerIndex;
        }
        set
        {
            _currentPlayerIndex = value;
        }
    }

	// Use this for initialization
	void Start ()
    {
        _currentPlayerIndex = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        _currentPlayer = _allPlayer[_currentPlayerIndex];
	}
}
