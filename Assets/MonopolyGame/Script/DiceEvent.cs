using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class DiceEvent : MonoBehaviour
{
    public int _diceIndex;
    public Image[] _diceImage;
    public float _timer;
    public float _runTimer;
    public float _effectTime;
    public bool _isEffect;

    private bool _canDiceChange;
    public float _canDiceChangeTimer;

    // Use this for initialization
    void Start()
    {
        _canDiceChangeTimer = 0;
        _canDiceChange = false;
        _isEffect = false;
        _timer = 0;
        UnityEngine.Random.seed = System.Guid.NewGuid().GetHashCode();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_isEffect)
        {
            _timer += Time.deltaTime;

            _runTimer = Mathf.Lerp(_runTimer, _effectTime, _timer * (1 / _effectTime));
            if(_runTimer >= _canDiceChangeTimer)
            {
                this.SetRandomDiceIndex();
                this.gameObject.GetComponent<Image>().sprite = _diceImage[_diceIndex].sprite;
                _canDiceChangeTimer += _effectTime / 10;
            }

            if (_runTimer >= _effectTime)
                _isEffect = false;
        }
    }

    public void DicingButtonClick()
    {
        _isEffect = true;
        _timer = 0;
        _runTimer = 0;
        _canDiceChangeTimer = _effectTime / 10;
    }

    public void SetRandomDiceIndex()
    {
        _diceIndex = UnityEngine.Random.Range(0, 6);
    }
}
