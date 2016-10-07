using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class ObjectData : MonoBehaviour
{
    private Vector3 _objectPosition;
    private float _objectRotation;

    public ObjectData()
    {
        _objectPosition = new Vector3(0, 0, 0);
        _objectRotation = 0f;
    }

    public ObjectData(Vector3 objectPosition, float objectRotation)
    {
        _objectPosition = objectPosition;
        _objectRotation = objectRotation;
    }

    void Start()
    {

    }
    
    void Update()
    {

    }

    public Vector3 ObjectPosition
    {
        get
        {
            return _objectPosition;
        }
        set
        {
            _objectPosition = value;
        }
    }

    public float ObjectRotation
    {
        get
        {
            return _objectRotation;
        }
        set
        {
            _objectRotation = value;
        }
    }
}