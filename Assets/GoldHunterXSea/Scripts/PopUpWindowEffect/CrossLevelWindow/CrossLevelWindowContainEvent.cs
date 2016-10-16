using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class CrossLevelWindowContainEvent : MonoBehaviour
{
    public SuccessOrFailureFlag _isWinFlag;

    public GameObject _winGameObject;
    public GameObject _loseGameObject;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(_isWinFlag.CurrentWinOrLoseFlag == SuccessOrFailureFlag.NONE)
        {
            _winGameObject.SetActive(false);
            _loseGameObject.SetActive(false);
        }
        else if (_isWinFlag.CurrentWinOrLoseFlag == SuccessOrFailureFlag.LEVEL_WIN)
        {
            _winGameObject.SetActive(true);
            _loseGameObject.SetActive(false);
        }
        else if (_isWinFlag.CurrentWinOrLoseFlag == SuccessOrFailureFlag.LEVEL_LOSE)
        {
            _winGameObject.SetActive(false);
            _loseGameObject.SetActive(true);
        }
    }


}
