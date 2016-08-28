using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class GHSListProducer : MonoBehaviour
{
    private bool _exitFlage;
    public Text[] _textListProducer;
    public GameObject _backGround;
    private bool _listProducerTrigger;

    void Start()
    {
        
    }

    void Update()
    {
        this.RunListProducer();
        if(_exitFlage)
            _backGround.SetActive(false);
    }

    public void buttonClick()
    {
        _exitFlage = false;
        _listProducerTrigger = true;
        _backGround.SetActive(true);
        //_textListProducer[0].transform.position = new Vector3(0, -300, 0);
        //_textListProducer[1].transform.position = new Vector3(0, _textListProducer[0].transform.position.y - 200, 0);
        //_textListProducer[2].transform.position = new Vector3(0, _textListProducer[1].transform.position.y - 200, 0);
    }

    void RunListProducer()
    {
        if (_textListProducer[2].transform.position.y < 500 && _listProducerTrigger)//_textListProducer[2].transform.position.y < 300 ||
        {
            _textListProducer[0].transform.Translate(0, 10, 0);
            _textListProducer[1].transform.Translate(0, 10, 0);
            _textListProducer[2].transform.Translate(0, 10, 0);
            //_textListProducer[0].transform.position = new Vector3(0, _textListProducer[0].transform.position.y + 1, 0);
            //_textListProducer[1].transform.position = new Vector3(0, _textListProducer[1].transform.position.y + 1, 0);
            //_textListProducer[2].transform.position = new Vector3(0, _textListProducer[2].transform.position.y + 1, 0);
        }
        else
        {
            _exitFlage = true;
        }
    }
}