using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class ListProducer : MonoBehaviour
{
    public GameStateIndex _gameStateIndex;
    public GameObject _gameObject;
    public float _effectTimer;

    private Vector3 _tempPosition;
    private Vector3 _targetPosition;
    private float _timer = 0f;
    private bool _arrival = false;

    public ButtonEvent _test;
    public Button _afterEventButton;


    // Use this for initialization
    public void Start()
    {
        _tempPosition = _gameObject.transform.localPosition;
        _targetPosition = new Vector3(_gameObject.transform.localPosition.x, _gameObject.transform.localPosition.y + _gameObject.GetComponent<RectTransform>().rect.height, _gameObject.transform.localPosition.z);
    }

    private void FixedUpdate()
    {
        if(_gameStateIndex.GetCurrentGameStateIndex() == GameState.ListProducer)
        {
            if (!_arrival)
            {
                this.ListProducerMoveEvent();
            }
            else
            {
                //_test.GameStateListProducerToSettingButtonClick();
                //Debug.Log("arrival!");
                _afterEventButton.GetComponent<ObjectMoveInEffect>().SmoothMoveInButtonEffect();
                _afterEventButton.GetComponent<ObjectMoveOutEffect>().SmoothMoveOutButtonEffect();

                _gameStateIndex.ToStateSetting();
                _test.SwitchBackGroundImagesByStateFlag();
                _test.SwitchGameStateByStateFlag();
            }
        }

        if (_gameStateIndex.GetCurrentGameStateIndex() != GameState.ListProducer)
        {
            _gameObject.transform.localPosition = _tempPosition;
        }
    }

    public void ListProducerButtonClickEvent()
    {
        _timer = 0f;
        _arrival = false;
    }

    private void ListProducerMoveEvent()
    {
        _timer += Time.deltaTime;
        if (_gameObject.transform.localPosition.y < _targetPosition.y)
        {
            //Debug.Log("_timer  = " + _timer );
            _gameObject.transform.localPosition = Vector3.Lerp(_tempPosition, _targetPosition, _timer / _effectTimer);
        }
        else
        {
            _arrival = true;
        }
    }
}

