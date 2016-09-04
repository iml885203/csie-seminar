using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class GHSListProducer : MonoBehaviour
{
    private bool _exitFlage = true;
    private bool _resetFlage = false;

    public Text[] _textListProducer;
    public GameObject _backGround;
    public Button _backToMenuButton;

    public Button _gameStateSettingToGameRunButton;
    public Button _gameStateSettingToMenuButton;
    public Button _listProducerButton;

    void Start()
    {
        
    }

    void Update()
    {
        this.RunListProducer();
        if(_exitFlage && _resetFlage)
        {
            _backGround.SetActive(false);
            _listProducerButton.gameObject.SetActive(true);
            _gameStateSettingToMenuButton.gameObject.SetActive(true);
            _gameStateSettingToGameRunButton.gameObject.SetActive(true);

            RectTransform backGroundRectTransform = _backGround.GetComponent<RectTransform>();
            _textListProducer[0].transform.position = new Vector3(backGroundRectTransform.rect.x, backGroundRectTransform.rect.y - backGroundRectTransform.rect.height, 0);
            _textListProducer[1].transform.position = new Vector3(backGroundRectTransform.rect.x, _textListProducer[0].transform.position.y - backGroundRectTransform.rect.height, 0);
            _textListProducer[2].transform.position = new Vector3(backGroundRectTransform.rect.x, _textListProducer[1].transform.position.y - backGroundRectTransform.rect.height, 0);

            _resetFlage = false;
        }
    }

    public void ListProducerButtonClick()
    {
        
        _exitFlage = false;

        _backGround.SetActive(true);
        _backToMenuButton.gameObject.SetActive(true);
        _listProducerButton.gameObject.SetActive(false);

        _gameStateSettingToMenuButton.gameObject.SetActive(false);
        _gameStateSettingToGameRunButton.gameObject.SetActive(false);
    }

    void RunListProducer()
    {
        if (_textListProducer[2].transform.position.y >= 500)
        {
            _resetFlage = true;
        }

        if (_textListProducer[2].transform.position.y < 500 && !_exitFlage)//_textListProducer[2].transform.position.y < 300 ||
        {
            _textListProducer[0].transform.Translate(0, 10, 0);
            _textListProducer[1].transform.Translate(0, 10, 0);
            _textListProducer[2].transform.Translate(0, 10, 0);
        }
        else
        {
            _exitFlage = true;
            _backToMenuButton.gameObject.SetActive(false);
        }
    }

    public void BackToMenuButtonClick()
    {
        _resetFlage = true;
        _exitFlage = true;
        _backToMenuButton.gameObject.SetActive(false);
        _listProducerButton.gameObject.SetActive(true);

        _gameStateSettingToMenuButton.gameObject.SetActive(true);
        _gameStateSettingToGameRunButton.gameObject.SetActive(true);
    }
}