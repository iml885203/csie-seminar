using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class PlayerMoveEvent : MonoBehaviour
{
    public CurrentIndex _movePlayerIndex;
    public Image[] _movePlayerImage;
    public ObjectMoveInEffect _moveEvent;

    public DiceEvent _dice1;
    public DiceEvent _dice2;

    private bool _isMove;
    private bool _getMoveStepNumber;
    public int _moveStepNumber;
    private float _effectTimer;

    // Use this for initialization
    void Start()
    {
        _effectTimer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_getMoveStepNumber)
        {
            if(!_dice1._isEffect && !_dice2._isEffect)
            {
                _moveStepNumber = (_dice1._diceIndex + 1) + (_dice2._diceIndex + 1);
                _getMoveStepNumber = false;
                _isMove = true;
            }
        }


        this.gameObject.GetComponent<ObjectMoveInEffect>()._moveGameObjects[0] = _movePlayerImage[_movePlayerIndex.CurrentPlayerIndex].gameObject;

        if(_isMove)
        {
            _effectTimer += Time.deltaTime;
            if(_effectTimer > _moveEvent._effectTime)
            {
                this.gameObject.GetComponent<ObjectMoveInEffect>().SmoothMoveInButtonEffect();
                _effectTimer = 0;
                _moveStepNumber--;
            }
        }
        if (_moveStepNumber < 1)
        {
            _isMove = false;
        }
    }

    public void CurrentPlayerMoveEvent()
    {
        _effectTimer = 0;
        _isMove = true;
        _getMoveStepNumber = true;
        //_moveStepNumber = (_dice1._diceIndex + 1) + (_dice2._diceIndex + 1);
        //this.gameObject.GetComponent<ObjectMoveInEffect>().SmoothMoveInButtonEffect();
    }
}
