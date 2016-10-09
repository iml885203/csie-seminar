using UnityEngine;
using System.Collections;

public class TransmissionShareTimer : MonoBehaviour {

    public float _timer;
    public float _triggerTime;
    public bool _isBeTrigger;

	// Use this for initialization
	void Start ()
    {
        _timer = 0;
        _isBeTrigger = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_timer > 0)
        {
            _isBeTrigger = false;
            _timer -= Time.deltaTime;
        }
        else
        {
            _isBeTrigger = true;
        }
    }

    public bool TriggerEvent()
    {
        if (_timer <= 0 && _isBeTrigger)
        {
            _timer = _triggerTime;
            return true;
        }
        else
        {
            return false;
        }
    }
}
