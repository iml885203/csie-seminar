using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class GameStateIndex : MonoBehaviour
{
    public int _gameStateIndex;
    private int _gameRunModeIndex;
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

