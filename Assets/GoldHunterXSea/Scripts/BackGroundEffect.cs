using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class BackGroundEffect : MonoBehaviour
{
    public GameStateIndex _gameStateIndex;
    public GameObject[] _gameObject;

    private float _floatObjectTimeTracker = 0f;
    private float _floatObjectTimeTrigger = 6;
    private float _floatObjectSpeed = .5f;

    private Vector3 _tempPosition;
    private Vector3 _smoothPosition = Vector3.zero;

    // Use this for initialization
    public void Start()
    {
    }

    private void FixedUpdate()
    {
        if (_gameStateIndex.CurrentStateIndex == GameState.Menu)
            this.MenuMoveEvent();
    }

    public void MenuMoveEvent()
    {
        foreach (GameObject currentObject in _gameObject)
        {
            //漂浮標籤物
            if (currentObject.gameObject.tag == "FloatObject")
            {
                //_floatObjectTimeTrigger/2的時間往下漂浮，_floatObjectTimeTrigger/2的時間往上漂浮
                _floatObjectTimeTracker += Time.deltaTime;
                if (_floatObjectTimeTracker % _floatObjectTimeTrigger < _floatObjectTimeTrigger / 2)
                {
                    currentObject.transform.Translate(Vector3.down * Time.deltaTime * _floatObjectSpeed);
                }
                else if (_floatObjectTimeTracker % _floatObjectTimeTrigger > _floatObjectTimeTrigger / 2)
                {
                    currentObject.transform.Translate(Vector3.up * Time.deltaTime * _floatObjectSpeed);
                }
                currentObject.transform.Rotate(Vector3.forward * Time.deltaTime * _floatObjectSpeed * 10);
            }
        }
    }
}

