using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class GameStateIndex : MonoBehaviour
{
    public int _gameStateIndex;
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

    public int GetCurrentGameStateIndex()
    {
        return _gameStateIndex;
    }
}

