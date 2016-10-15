using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class LevelChangeEvent : MonoBehaviour
{
    public GameLevelIndex _levelIndex;

    public LevelPreview _levelPreview;
    public LevelTeachEvent _levelTeachEvent;

    public GameObject _popWindow;
    public PopUpWindowControl _popControl;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeLevelEvent()
    {
        _levelIndex.ToNextLevel();
        _levelPreview.ChangePreviewLevel();
        _levelTeachEvent.ChangeLevelEvent();

        _popControl.EnterPopUpWindowMode();
    }
}


