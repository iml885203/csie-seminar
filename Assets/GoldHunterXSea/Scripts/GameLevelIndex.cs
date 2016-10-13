using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class GameLevelIndex : MonoBehaviour
{
    public int _gameLevelIndex;
    public int CurrentLevelIndex
    {
        get
        {
            return _gameLevelIndex;
        }
    }

    void Start()
    {
        _gameLevelIndex = 0;
    }

    public void ToGameLevel1()
    {
        _gameLevelIndex = 0;
    }

    public void ToGameLevel2()
    {
        _gameLevelIndex = 1;
    }

    public void ToGameLevel3()
    {
        _gameLevelIndex = 2;
    }

    public void ToGameFight()
    {
        _gameLevelIndex = 3;
    }
}

