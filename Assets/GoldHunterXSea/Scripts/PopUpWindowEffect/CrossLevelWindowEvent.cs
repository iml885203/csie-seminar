using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class CrossLevelWindowEvent : MonoBehaviour
{
    public GameLevelIndex _levelIndex;
    public PopUpWindowControl _popWindowControl;

    public Button _toSettingButton;
    public Button _replayButton;
    public Button _nextLevelButton;
    public Button _previousButton;

    public LevelPreview _levelPreview;
    public LevelTeachEvent _levelTeachEvent;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.SetLevelButtonInterativeOrNot();

    }

    public void ClickNextLevelButtonEvent()
    {
        _popWindowControl.ExitCrossLevelWindow();
        this.ToNextLevelEvent();
    }

    public void ClickPreviousLevelButtonEvent()
    {
        _popWindowControl.ExitCrossLevelWindow();
        this.ToPreviousLevelEvent();
    }

    public void ClickReplayButtonEvent()
    {
        _popWindowControl.ExitCrossLevelWindow();
        this.ReplayLevelEvent();
    }

    public void ClickToSettingButtonEvent()
    {

    }

    public void EnterCrossLevelModeEvent()
    {
        this.GetComponent<ObjectMoveInEffect>().SmoothMoveInButtonEffect();
    }

    public void ExitCrossLevelModeEvent()
    {
        this.GetComponent<ObjectMoveOutEffect>().SmoothMoveOutButtonEffect();
    }

    public void ReplayLevelEvent()
    {
        _levelPreview.ChangePreviewLevel();
        _levelTeachEvent.ChangeActiveContainEvent();

        _popWindowControl.EnterTeachWindow();
    }

    public void ToPreviousLevelEvent()
    {
        _levelIndex.ToPreviousLevel();
        _levelPreview.ChangePreviewLevel();
        _levelTeachEvent.ChangeActiveContainEvent();

        _popWindowControl.EnterTeachWindow();
    }

    public void ToNextLevelEvent()
    {
        _levelIndex.ToNextLevel();
        _levelPreview.ChangePreviewLevel();
        _levelTeachEvent.ChangeActiveContainEvent();

        _popWindowControl.EnterTeachWindow();
    }

    public void SetLevelButtonInterativeOrNot()
    {
        if (_levelIndex.CurrentLevelIndex == GameLevelIndex.LEVEL_1)
            _previousButton.interactable = false;
        else
            _previousButton.interactable = true;

        if (_levelIndex.CurrentLevelIndex == GameLevelIndex.LEVEL_3)
            _nextLevelButton.interactable = false;
        else
            _nextLevelButton.interactable = true;
    }
}
