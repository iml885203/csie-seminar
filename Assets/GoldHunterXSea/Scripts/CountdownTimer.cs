using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class CountdownTimer : MonoBehaviour
{
    private float _countDownTime = 0f;
    private float _countDownTimer = 0f;

    public Text _outputTime;

    public int _assignMinute = 0;
    public int _assignSecond = 0;

    private bool _isCountDown = false;

    private float MinuteFloat = 60.0f;
    private int MinuteInt = 60;

    private int _viewMinute = 0;
    private int _viewSecond = 0;

    // Use this for initialization
    public void Start()
    {

    }

    private void FixedUpdate()
    {

        if (_countDownTimer > 0)
        {
            if (_isCountDown)
            {
                _countDownTimer -= Time.deltaTime;
                _viewMinute = (int)_countDownTimer / MinuteInt;
                _viewSecond = (int)_countDownTimer % MinuteInt;
                _outputTime.text = _viewMinute.ToString("00") + ":" + _viewSecond.ToString("00");
            }
        }
        else
        {
            _isCountDown = false;
        }
    }

    //開始計時事件
    public void ResetCountDownTimer()
    {
        _countDownTime = (float)_assignMinute * MinuteFloat + (float)_assignSecond;
        _countDownTimer = _countDownTime;
        _isCountDown = true;
    }
}

