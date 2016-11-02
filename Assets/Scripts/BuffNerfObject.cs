using UnityEngine;
using System.Collections;

public class BuffNerfObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        //transform.parent.GetComponent<BuffNerfGenerator>().CreateBuffNerfObject();
        //Destroy(gameObject);
    }
}
