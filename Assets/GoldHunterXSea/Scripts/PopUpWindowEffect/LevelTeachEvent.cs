using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class LevelTeachEvent : MonoBehaviour
{
    public GameLevelIndex _levelIndex;
    public GameObject[] _levelContain;

    private int _levelCount;

    void Start()
    {
        _levelCount = _levelContain.Length;
        this.ChangeLevelEvent();
    }

    void FixedUpdate()
    {

    }

    public void ClickNextButtonEvent()
    {
        _levelContain[_levelIndex.CurrentLevelIndex].GetComponent<LevelTeachContainEvent>().ToNextTeachStateEvent();
    }

    public void ClickPreviousButtonEvent()
    {
        _levelContain[_levelIndex.CurrentLevelIndex].GetComponent<LevelTeachContainEvent>().ToPreviousTeachStateEvent();
    }

    public void ClickSkipButtonEvent()
    {
        _levelContain[_levelIndex.CurrentLevelIndex].GetComponent<LevelTeachContainEvent>().ToSkipTeachStateEvent();
    }

    public void ChangeLevelEvent()
    {
        for(int index = 0;index < _levelCount; index++)
        {
            if (_levelIndex.CurrentLevelIndex == index)
                _levelContain[index].SetActive(true);
            else
                _levelContain[index].SetActive(false);
        }
    }
}


