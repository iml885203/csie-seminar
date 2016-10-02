using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class GameStateIndex : MonoBehaviour
{
    public int _gameStateIndex;

    // Use this for initialization
    public void Start()
    {
        _gameStateIndex = GameState.Menu;
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
}

