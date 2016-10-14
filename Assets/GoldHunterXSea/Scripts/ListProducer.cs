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

    public ButtonEvent _ButtonEvent;
    public Button _afterEventButton;


    // Use this for initialization
    public void Start()
    {
        //紀錄原始座標及目標座標
        _tempPosition = _gameObject.transform.localPosition;
        _targetPosition = new Vector3(_gameObject.transform.localPosition.x, _gameObject.transform.localPosition.y + (_gameObject.GetComponent<RectTransform>().rect.height * 2), _gameObject.transform.localPosition.z);
    }

    private void FixedUpdate()
    {
        //如果在listProducer的GameState的話
        if(_gameStateIndex.GetCurrentGameStateIndex() == GameState.ListProducer)
        {
            if (!_arrival)//未到達目標時
            {
                this.ListProducerMoveEvent();
            }
            else//到達目標時
            {
                //顯示動畫
                _afterEventButton.GetComponent<ObjectMoveInEffect>().SmoothMoveInButtonEffect();
                _afterEventButton.GetComponent<ObjectMoveOutEffect>().SmoothMoveOutButtonEffect();

                //轉GameState 背景
                _gameStateIndex.ToStateSetting();
                _ButtonEvent.SwitchBackGroundImagesByStateFlag();
                _ButtonEvent.SwitchGameStateByStateFlag();
            }
        }

        //如果GameState不在listProducer的話 物件回原始座標
        if (_gameStateIndex.GetCurrentGameStateIndex() != GameState.ListProducer)
        {
            _gameObject.transform.localPosition = _tempPosition;
        }
    }

    //設定畫面按下製作人按鈕事件
    public void ListProducerButtonClickEvent()
    {
        _timer = 0f;
        _arrival = false;
    }

    //製作人圖片移動事件
    private void ListProducerMoveEvent()
    {
        _timer += Time.deltaTime;
        if (_gameObject.transform.localPosition.y < _targetPosition.y)
        {
            _gameObject.transform.localPosition = Vector3.Lerp(_tempPosition, _targetPosition, _timer / _effectTimer);
        }
        else
        {
            _arrival = true;
        }
    }
}

