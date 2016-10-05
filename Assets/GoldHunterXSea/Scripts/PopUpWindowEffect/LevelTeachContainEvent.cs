using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class LevelTeachContainEvent : MonoBehaviour
{
    public LevelTeachState _teachState;
    public Button _nextButton;
    public Button _previousButton;
    public Button _skipButton;
    public GameObject[] _image;
    public GameObject[] _description;

    private int _stateCount;

    void Start()
    {
        _stateCount = _image.Length;
        this.SetCurrentContainActiveOrNot();
        this.SetCurrentButtonEnableOrNot();
    }

    void FixedUpdate()
    {

    }

    public void ToNextTeachStateEvent()
    {
        _teachState.ToNextState();
        this.SetCurrentContainActiveOrNot();
        this.SetCurrentButtonEnableOrNot();
    }

    public void ToPreviousTeachStateEvent()
    {
        _teachState.ToPreviousState();
        this.SetCurrentContainActiveOrNot();
        this.SetCurrentButtonEnableOrNot();
    }

    public void SetCurrentContainActiveOrNot()
    {
        for(int index = 0; index < _stateCount; index++)
        {
            if(_teachState.CurrentTeachState == index)
            {
                _image[index].SetActive(true);
                _description[index].SetActive(true);
            }
            else
            {
                _image[index].SetActive(false);
                _description[index].SetActive(false);
            }
        }
    }

    public void SetCurrentButtonEnableOrNot()
    {
        _previousButton.interactable = true;
        _nextButton.interactable = true;

        if (_teachState.CurrentTeachState == 0)
            _previousButton.interactable = false;
        if (_teachState.CurrentTeachState == _stateCount - 1)
            _nextButton.interactable = false;
    }
}


