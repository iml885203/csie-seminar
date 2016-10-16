using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class LevelBeenTeachFlag : MonoBehaviour
{
    public bool _isBeenTeach;

    public bool BeenTeach
    {
        get
        {
            return _isBeenTeach;
        }
        set
        {
            _isBeenTeach = value;
        }
    }

    // Use this for initialization
    public void Start()
    {
        _isBeenTeach = false;
    }

    private void Update()
    {

    }
}

