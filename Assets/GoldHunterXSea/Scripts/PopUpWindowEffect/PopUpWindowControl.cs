using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class PopUpWindowControl : MonoBehaviour
{
    private bool _isPopUpWinsowsMode;

    public ObjectMoveOutEffect _moveOutEffect;
    public ObjectMoveInEffect _moveInEffect;

    //public LevelBeenTeachFlag _levelBeenTeachFlag;

    public GameStateIndex _stateIndex;
    public GameObject _backGroundPanel;

    private int _originStateIndex;

    void Start()
    {
        _isPopUpWinsowsMode = false;
    }

    void FixedUpdate()
    {

    }

    public void EnterPopUpWindowMode()
    {
        _moveInEffect.SmoothMoveInButtonEffect();
        _originStateIndex = _stateIndex.CurrentStateIndex;
        _stateIndex.ToStateTeach();
        _isPopUpWinsowsMode = true;
        _backGroundPanel.SetActive(true);
    }

    public void ExitPopUpWindowMode()
    {
        _moveOutEffect.SmoothMoveOutButtonEffect();
        _stateIndex.CurrentStateIndex = _originStateIndex;
        _isPopUpWinsowsMode = false;
        _backGroundPanel.SetActive(false);
    }
}


