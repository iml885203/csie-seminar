using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class SuccessOrFailureFlag : MonoBehaviour
{
    public const int NONE = 0;
    public const int LEVEL_WIN = 1;
    public const int LEVEL_LOSE = 2;

    public int _successOrFailureFlag;
    public int CurrentWinOrLoseFlag
    {
        get
        {
            return _successOrFailureFlag;
        }
        set
        {
            _successOrFailureFlag = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        _successOrFailureFlag = NONE;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void WinTheLevel()
    {
        _successOrFailureFlag = LEVEL_WIN;
    }

    public void LoseTheLevel()
    {
        _successOrFailureFlag = LEVEL_LOSE;
    }

    public void ResetLevel()
    {
        _successOrFailureFlag = NONE;
    }
}
