using UnityEngine;
using System.Collections;

public class TransmissionObject : MonoBehaviour {

    public GameObject _anotherPortal;
    public GameObject _triggerTimer;
    private TransmissionShareTimer _timer;

    // Use this for initialization
    void Start ()
    {
        _timer = _triggerTimer.GetComponent<TransmissionShareTimer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(_timer == null)
        {
            Debug.Log("_timer null");
            return;
        }
        if(_timer._timer > 0)
        {
            transform.FindChild("layer2").GetComponent<ParticleSystem>().maxParticles = 2;
            this.GetComponent<ParticleSystem>().maxParticles = 2;
        }
        else
        {
            transform.FindChild("layer2").GetComponent<ParticleSystem>().maxParticles = 12;
            this.GetComponent<ParticleSystem>().maxParticles = 24;
        }
    }

    public bool CanMoveToAnotherSidePortal()
    {
        return _timer.TriggerEvent();
    }

    public Vector3 ReturnAnotherSidePortalPosition()
    {
        return _anotherPortal.transform.position;
    }
}
