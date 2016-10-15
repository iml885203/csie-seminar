using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class GameLevelIndex : MonoBehaviour
{
    public const int LEVEL_1 = 0;
    public const int LEVEL_2 = 1;
    public const int LEVEL_3 = 2;
    public const int LEVEL_FIGHT = 3;
    public const int LEVEL_EDOTOR = 4;

    public int _gameLevelIndex;
    public Text _gameRunLevelText;

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
        _gameRunLevelText.text = "關卡1";
    }

    public void ToGameLevel1()
    {
        _gameLevelIndex = 0;
        _gameRunLevelText.text = "關卡1";
    }

    public void ToGameLevel2()
    {
        _gameLevelIndex = 1;
        _gameRunLevelText.text = "關卡2";
    }

    public void ToGameLevel3()
    {
        _gameLevelIndex = 2;
        _gameRunLevelText.text = "關卡3";
    }

    public void ToGameFight()
    {
        _gameLevelIndex = 3;
        _gameRunLevelText.text = "對戰關卡";
    }

    public void ToGameLoadEditor()
    {
        _gameLevelIndex = 4;
        _gameRunLevelText.text = "自訂關卡";
    }

    public void ToNextLevel()
    {
        _gameLevelIndex++;
        this.ChangeLevel();
    }

    public void ToPreviousLevel()
    {
        _gameLevelIndex--;
        this.ChangeLevel();
    }

    public void ChangeLevel()
    {
        if (_gameLevelIndex == LEVEL_1)
            this.ToGameLevel1();
        else if (_gameLevelIndex == LEVEL_2)
            this.ToGameLevel2();
        else if (_gameLevelIndex == LEVEL_3)
            this.ToGameLevel3();
        else if (_gameLevelIndex == LEVEL_FIGHT)
            this.ToGameFight();
        else if (_gameLevelIndex == LEVEL_EDOTOR)
            this.ToGameLoadEditor();
    }
}

