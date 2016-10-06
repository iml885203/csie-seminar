using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class PopUpWindowControl : MonoBehaviour
{
    private bool _isPopUpWinsowsMode;

    public GameObject _backGroundPanel;


    void Start()
    {
        _isPopUpWinsowsMode = false;
    }

    void FixedUpdate()
    {
        //if (_isPopUpWinsowsMode)
        //{
            
        //}
        //else
        //{
        //    _backGroundPanel.SetActive(false);
        //}
    }

    public void EnterPopUpWindowMode()
    {
        _isPopUpWinsowsMode = true;
        _backGroundPanel.SetActive(true);
    }

    public void ExitPopUpWindowMode()
    {
        _isPopUpWinsowsMode = false;
        _backGroundPanel.SetActive(false);
    }
}


