using UnityEngine;
using System.Collections;

public class TransmissionObject : MonoBehaviour {

    public GameObject _anotherPortal;
    public GameObject _triggerTimer;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public bool CanMoveToAnotherSidePortal()
    {
        return _triggerTimer.GetComponent<ShareTimer>().TriggerEvent();
    }

    public Vector3 ReturnAnotherSidePortalPosition()
    {
        return _anotherPortal.transform.position;
    }
}
