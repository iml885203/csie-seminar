using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class LevelTeachState : MonoBehaviour
{
    public int _stateIndex;

    public int CurrentTeachState
    {
        get
        {
            return _stateIndex;
        }
    }

    void Start()
    {
        _stateIndex = 0;
    }

    void FixedUpdate()
    {
    }

    public void ToNextState()
    {
        _stateIndex++;
    }

    public void ToPreviousState()
    {
        _stateIndex--;
    }
}

