using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class GameStateIndex : MonoBehaviour
{
    public int _gameStateIndex;
    //0未設定1單人模式2雙人模式
    private int _gameRunModeIndex;

    public int CurrentStateIndex
    {
        get
        {
            return _gameStateIndex;
        }
        set
        {
            _gameStateIndex = value;
        }
    }

    // Use this for initialization
    public void Start()
    {
        _gameStateIndex = GameState.Menu;
        _gameRunModeIndex = 0;
    }

    private void FixedUpdate()
    {
    }

    public void ToStateMenu()
    {
        _gameStateIndex = GameState.Menu;
    }

    public void ToStateSetting()
    {
        _gameStateIndex = GameState.Setting;
    }

    public void ToStateGameRun()
    {
        _gameStateIndex = GameState.GameRun;
    }

    public void ToStateListProducer()
    {
        _gameStateIndex = GameState.ListProducer;
    }

    public void ToStateTeach()
    {
        _gameStateIndex = GameState.Teach;
    }

    public void ToStateCrossLevel()
    {
        _gameStateIndex = GameState.CrossLevel;
    }

    public int GetCurrentGameStateIndex()
    {
        return _gameStateIndex;
    }

    //取得單雙人模式
    public int GetGameRunMode()
    {
        return _gameRunModeIndex;
    }

    //設定單雙人模式
    public void SetGameRunMode(int gameMode)
    {
        _gameRunModeIndex = gameMode;
    }
}

