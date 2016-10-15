using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class PopUpWindowControl : MonoBehaviour
{
    private bool _isPopUpWinsowsMode;

    //public ObjectMoveOutEffect _moveOutEffect;
    //public ObjectMoveInEffect _moveInEffect;

    //public LevelBeenTeachFlag[] _levelBeenTeachFlag;

    public GameStateIndex _stateIndex;
    public GameLevelIndex _levelIndex;
    public GameObject _backGroundPanel;

    public TeachWindowEvent _teachWindowEvent;
    public CrossLevelWindowEvent _crossLevelWindowEvent;

    private int _originStateIndex;

    void Start()
    {
        _isPopUpWinsowsMode = false;
    }

    void Update()
    {
        _backGroundPanel.SetActive(_isPopUpWinsowsMode);
    }

    public void EnterTeachWindow()
    {
        //如果已經教學過就不再進入
        if (!_teachWindowEvent.IsBeenTeach(_levelIndex.CurrentLevelIndex))
        {
            this.EnterPopUpWindowMode();
            _stateIndex.ToStateTeach();
            _teachWindowEvent.EnterTeachModeEvent();
        }
    }

    public void ExitTeachWindow()
    {
        this.ExitPopUpWindowMode();
        _teachWindowEvent.ExitTeachModeEvent();
    }

    public void EnterCrossWindow()
    {
        this.EnterPopUpWindowMode();
        _stateIndex.ToStateCrossLevel();
        _crossLevelWindowEvent.EnterCrossLevelModeEvent();
    }

    public void ExitCrossLevelWindow()
    {
        this.ExitPopUpWindowMode();
        _crossLevelWindowEvent.ExitCrossLevelModeEvent();
    }

    private void EnterPopUpWindowMode()
    {
        _originStateIndex = _stateIndex.CurrentStateIndex;
        _isPopUpWinsowsMode = true;
    }

    private void ExitPopUpWindowMode()
    {
        _stateIndex.CurrentStateIndex = _originStateIndex;
        _isPopUpWinsowsMode = false;
    }

    

    //原本
    //public void EnterPopUpWindowMode()
    //{
    //    //如果已經進過教學了
    //    if (!_levelBeenTeachFlag[_levelIndex.CurrentLevelIndex].BeenTeach)
    //    {
    //        _moveInEffect.SmoothMoveInButtonEffect();
    //        _originStateIndex = _stateIndex.CurrentStateIndex;
    //        _stateIndex.ToStateTeach();
    //        _isPopUpWinsowsMode = true;
    //        _backGroundPanel.SetActive(true);
    //    }
    //}
    //public void ExitPopUpWindowMode()
    //{
    //    _moveOutEffect.SmoothMoveOutButtonEffect();
    //    _stateIndex.CurrentStateIndex = _originStateIndex;
    //    _isPopUpWinsowsMode = false;
    //}
}


