using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class LevelTeachContainEvent : MonoBehaviour
{
    public PopUpWindowControl _popControl;
    public ObjectMoveOutEffect _moveOutEffect;

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
        this.SetCurrentContainActiveOrNot();
        this.SetCurrentButtonEnableOrNot();
    }

    public void ToNextTeachStateEvent()
    {
        if (_nextButton.transform.FindChild("Text").GetComponent<Text>().text == "開始遊戲")
            this.ExitTeachMode();
        else if (_teachState.CurrentTeachState < _stateCount - 1)
            _teachState.ToNextState();
    }

    public void ToPreviousTeachStateEvent()
    {
        _teachState.ToPreviousState();
    }

    public void ToSkipTeachStateEvent()
    {
        this.ExitTeachMode();
    }

    public void ExitTeachMode()
    {
        _teachState.ToSkipState();
        _popControl.ExitPopUpWindowMode();
        _moveOutEffect.SmoothMoveOutButtonEffect();
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
        if (_teachState.CurrentTeachState == 0)
            _previousButton.interactable = false;
        else
            _previousButton.interactable = true;

        if (_teachState.CurrentTeachState == _stateCount - 1)
            _nextButton.transform.FindChild("Text").GetComponent<Text>().text = "開始遊戲";
        else
            _nextButton.transform.FindChild("Text").GetComponent<Text>().text = "下一步";
    }
}


