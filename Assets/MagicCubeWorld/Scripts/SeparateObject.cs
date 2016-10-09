using UnityEngine;
using System.Collections;

public class SeparateObject : MonoBehaviour {
    public float _triggerTime;
    public float _triggerTimer;
    public bool _isBeTrigger;

    // Use this for initialization
    void Start ()
    {
        _triggerTimer = 0f;
        _isBeTrigger = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_triggerTimer > 0)
        {
            _isBeTrigger = false;
            _triggerTimer -= Time.deltaTime;
        }
        else
        {
            _isBeTrigger = true;
        }
    }

    //觸發事件
    public bool TriggerEvent()
    {
        if(_triggerTimer <= 0 && _isBeTrigger)
        {
            _triggerTimer = _triggerTime;
            return true;
        }
        else
        {
            return false;
        }
    }


}
