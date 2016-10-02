using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class ObjectMoveOutEffect : MonoBehaviour
{
    public float _wholeTime;
    public float _effectTime;
    public float _waitTime;

    private float _wholeTimer;
    private float _effectTimer;
    private float _waitTimer;

    public GameObject[] _moveGameObjects;
    public GameObject _targetGameObject;

    public string _direction;

    //private float _xySmooth = .5f;
    //private float _effectTimer = 2.5f;

    private float _buttonTimeTracker = 0f;

    private List<Vector3> _tempPositionList;
    private List<Vector3> _targetVectorList;

    private bool[] _isMoveGameObjectArrial;

    private Vector3 _tempPosition;
    private Vector3 _smoothPosition = Vector3.zero;

    private bool _isButtonClick;
    private bool _isMoveOut;


    // Use this for initialization
    public void Start()
    {
        _tempPositionList = new List<Vector3>(_moveGameObjects.Length);
        _targetVectorList = new List<Vector3>(_moveGameObjects.Length);
        _isMoveGameObjectArrial = new bool[_moveGameObjects.Length];
        for (int index = 0; index < _moveGameObjects.Length; index++)
        {
            _tempPositionList.Add(Vector3.zero);
            _targetVectorList.Add(Vector3.zero);
            _isMoveGameObjectArrial[index] = false;
        }

        if (_targetGameObject == null)

            _isButtonClick = false;
        _isMoveOut = false;

        _wholeTimer = 0f;
        _waitTimer = 0f;
        _effectTimer = 0f;
    }

    // Update is called once per frame
    public void Update()
    {

    }

    private void FixedUpdate()
    {
        if (_targetGameObject != null && _isButtonClick)
            this.MoveInByTargetObject();

        //Debug.Log("_buttonTimeTracker = " + _buttonTimeTracker);
        //_buttonTimeTracker += Time.deltaTime;

        //else if (_isButtonClick)
        //    this.MenuMoveInEvent();
    }

    public void MoveInByTargetObject()
    {
        //Debug.Log("_buttonTimeTracker = " + _buttonTimeTracker);
        //Debug.Log("_effectTimer = " + _effectTimer);
        bool buttonTimerFlag = true;
        bool effectTimerFlag = true;
        for (int index = 0; index < _moveGameObjects.Length; index++)
        {

            //按鈕進入事件&&右側按鈕標籤
            if (_isMoveOut)
            {
                //update一次只加一次 Time.deltaTime 以免重複增加
                if (buttonTimerFlag)
                {
                    _buttonTimeTracker += Time.deltaTime;
                    buttonTimerFlag = false;
                }

                _wholeTimer = _buttonTimeTracker;

                //在整個時間內
                if (_wholeTimer < _wholeTime)
                {
                    //在效果時間內
                    if (_buttonTimeTracker > _waitTime && _buttonTimeTracker < (_waitTime + _effectTime))
                    {
                        //update一次只加一次 Time.deltaTime 以免重複增加
                        if (effectTimerFlag)
                        {
                            _effectTimer += Time.deltaTime;
                            effectTimerFlag = false;
                        }

                        //移動座標
                        if (this.IsMoveGameObjectArrivalByIndex(index))
                        {
                            //當移動物件尚未到指定位置
                            try
                            {
                                //移動物件及按下的按鈕變不可按
                                _moveGameObjects[index].GetComponent<Button>().enabled = false;
                                this.gameObject.GetComponent<Button>().enabled = false;
                            }
                            catch
                            { }
                            //Debug.Log("_xySmooth * (_buttonTimeTracker - 1f) = " + _xySmooth * (_buttonTimeTracker - 1f));
                            //如果在效果時間內 則進行移動
                            if (_effectTimer < _effectTime)
                                _moveGameObjects[index].transform.localPosition = Vector3.Lerp(_moveGameObjects[index].transform.localPosition, _targetVectorList[index], _effectTimer * (1 / _effectTime));
                        }
                        else
                        {
                            //當移動完畢到了指定位置
                            try
                            {
                                //移動物件及按下的按鈕變回可按
                                _moveGameObjects[index].GetComponent<Button>().enabled = true;
                                this.gameObject.GetComponent<Button>().enabled = true;
                                //Debug.Log("run index = " + index);
                            }
                            catch
                            { }

                            _isMoveGameObjectArrial[index] = true;
                            //最後一個跑完才是結束
                            if (this.IsAllMoveGameObjectsArrival())
                            {
                                //Debug.Log("button index = " + index);
                                _isMoveOut = false;
                                _isButtonClick = false;
                            }
                        }
                    }
                }
            }
        }
    }

    private bool IsAllMoveGameObjectsArrival()
    {
        bool value = true;
        //跑過所有的 只要有一個沒有抵達目標點 就代表沒有完成
        for (int index = 0; index < _isMoveGameObjectArrial.Length; index++)
        {
            if (_isMoveGameObjectArrial[index] == false)
            {
                value = false;
            }
        }
        return value;
    }

    private bool IsMoveGameObjectArrivalByIndex(int index)
    {
        switch (_direction)
        {
            case "up":
                {
                    return _moveGameObjects[index].transform.localPosition.y < _targetVectorList[index].y;
                }
            case "down":
                {
                    return _moveGameObjects[index].transform.localPosition.y > _targetVectorList[index].y;
                }
            case "left":
                {
                    return _moveGameObjects[index].transform.localPosition.x > _targetVectorList[index].x;
                }
            case "right":
                {
                    return _moveGameObjects[index].transform.localPosition.x < _targetVectorList[index].x;
                }
            default:
                return false;
        }
    }

    private void SetTargetPositionByDirection()
    {
        switch (_direction)
        {
            case "up":
                {
                    for (int index = 0; index < _moveGameObjects.Length; index++)
                    {
                        _targetVectorList[index] = new Vector3(_tempPositionList[index].x, _tempPositionList[index].y + _targetGameObject.GetComponent<RectTransform>().rect.height, _tempPositionList[index].z);
                    }
                    break;
                }
            case "down":
                {
                    for (int index = 0; index < _moveGameObjects.Length; index++)
                    {
                        _targetVectorList[index] = new Vector3(_tempPositionList[index].x, _tempPositionList[index].y - _targetGameObject.GetComponent<RectTransform>().rect.height, _tempPositionList[index].z);
                    }
                    break;
                }
            case "left":
                {
                    for (int index = 0; index < _moveGameObjects.Length; index++)
                    {
                        _targetVectorList[index] = new Vector3(_tempPositionList[index].x - _targetGameObject.GetComponent<RectTransform>().rect.width, _tempPositionList[index].y, _tempPositionList[index].z);
                    }
                    break;
                }
            case "right":
                {
                    for (int index = 0; index < _moveGameObjects.Length; index++)
                    {
                        _targetVectorList[index] = new Vector3(_tempPositionList[index].x + _targetGameObject.GetComponent<RectTransform>().rect.width, _tempPositionList[index].y, _tempPositionList[index].z);
                    }
                    break;
                }
            default:
                break;
        }
        //_targetVectorList[index] = new Vector3(_tempPositionList[index].x, _tempPositionList[index].y - _targetGameObject.GetComponent<RectTransform>().rect.height, _tempPositionList[index].z);
    }

    //public void MoveInByTargetObject()
    //{
    //    for (int index = 0; index < _moveGameObjects.Length; index++)
    //    {
    //        //按鈕進入事件&&右側按鈕標籤
    //        if (_isMoveIn)
    //        {
    //            _buttonTimeTracker += Time.deltaTime;
    //            //Debug.Log("_buttonTimeTracker = " + _buttonTimeTracker);
    //            //if(_buttonTimeTracker > _effectTimer)
    //            //{
    //                //暫存目標位置
    //                _targetVectorList[index] = new Vector3(_tempPositionList[index].x, _tempPositionList[index].y - _targetGameObject.GetComponent<RectTransform>().rect.height, _tempPositionList[index].z);
    //                //移動座標
    //                if (_moveGameObjects[index].transform.localPosition.y > _targetVectorList[index].y)
    //                {
    //                    try
    //                    {
    //                        _moveGameObjects[index].GetComponent<Button>().enabled = false;
    //                        this.gameObject.GetComponent<Button>().enabled = false;
    //                    }
    //                    catch
    //                    { }
    //                //Debug.Log("_xySmooth * (_buttonTimeTracker - 1f) = " + _xySmooth * (_buttonTimeTracker - 1f));
    //                    _moveGameObjects[index].transform.localPosition = Vector3.Lerp(_moveGameObjects[index].transform.localPosition, _targetVectorList[index], _buttonTimeTracker );
    //                }
    //                else
    //                {
    //                    try
    //                    {
    //                        _moveGameObjects[index].GetComponent<Button>().enabled = true;
    //                        this.gameObject.GetComponent<Button>().enabled = true;
    //                    }
    //                    catch
    //                    { }
    //                    _isMoveIn = false;
    //                    _isButtonClick = false;
    //                }
    //            //}
    //        }
    //    }
    //}

    //public void MenuMoveInEvent()
    //{
    //    for(int index = 0; index < _moveGameObjects.Length; index++)
    //    {
    //        //按鈕進入事件&&右側按鈕標籤
    //        if (_isButtonClick && _isMoveIn)
    //        {
    //            _buttonTimeTracker += Time.deltaTime;
    //            if(_buttonTimeTracker > _effectTimer)
    //            {
    //                //暫存目標位置
    //                _targetVectorList[index] = new Vector3(_tempPositionList[index].x, _tempPositionList[index].y - _moveGameObjects[index].GetComponent<RectTransform>().rect.height, _tempPositionList[index].z);
    //                //移動座標
    //                if (_moveGameObjects[index].transform.localPosition.y > _targetVectorList[index].y)
    //                {
    //                    try
    //                    {
    //                        _moveGameObjects[index].GetComponent<Button>().enabled = false;
    //                        this.gameObject.GetComponent<Button>().enabled = false;
    //                    }
    //                    catch
    //                    { }
    //                    _moveGameObjects[index].transform.localPosition = Vector3.Lerp(_moveGameObjects[index].transform.localPosition, _targetVectorList[index], _xySmooth * _buttonTimeTracker);
    //                }
    //                else
    //                {
    //                    try
    //                    {
    //                        _moveGameObjects[index].GetComponent<Button>().enabled = true;
    //                        this.gameObject.GetComponent<Button>().enabled = true;
    //                    }
    //                    catch
    //                    { }
    //                    _isMoveIn = false;
    //                    _isButtonClick = false;
    //                }
    //            }
    //        }
    //    }

    //    //foreach (GameObject currentObject in _moveGameObjects)
    //    //{
    //    //    //按鈕進入事件&&右側按鈕標籤
    //    //    if (_isButtonClick && _isMoveIn)
    //    //    {
    //    //        //暫存目標位置
    //    //        Vector3 targetVector = new Vector3(_tempPosition.x - currentObject.GetComponent<RectTransform>().rect.width, _tempPosition.y, _tempPosition.z);
    //    //        //移動座標
    //    //        if (currentObject.transform.localPosition.x > targetVector.x)
    //    //        {
    //    //            try
    //    //            {
    //    //                currentObject.GetComponent<Button>().enabled = false;
    //    //                this.gameObject.GetComponent<Button>().enabled = false;
    //    //            }
    //    //            catch
    //    //            { }
    //    //            _buttonTimeTracker += Time.deltaTime;
    //    //            currentObject.transform.localPosition = Vector3.Lerp(currentObject.transform.localPosition, targetVector, xSmooth * _buttonTimeTracker);
    //    //        }
    //    //        else
    //    //        {
    //    //            try
    //    //            {
    //    //                currentObject.GetComponent<Button>().enabled = true;
    //    //                this.gameObject.GetComponent<Button>().enabled = true;
    //    //            }
    //    //            catch
    //    //            { }
    //    //            _isMoveIn = false;
    //    //            _isButtonClick = false;
    //    //        }
    //    //    }
    //    //}
    //}

    public void SmoothMoveOutButtonEffect()
    {
        for (int index = 0; index < _moveGameObjects.Length; index++)
        {
            _tempPositionList[index] = _moveGameObjects[index].transform.localPosition;
            _isMoveGameObjectArrial[index] = false;
            //Debug.Log("_moveGameObjects[index].name" + _moveGameObjects[index].name);
        }


        this.SetTargetPositionByDirection();

        _wholeTimer = 0f;
        _waitTimer = 0f;
        _effectTimer = 0f;

        _buttonTimeTracker = 0f;
        _isMoveOut= true;
        _isButtonClick = true;
    }
}

