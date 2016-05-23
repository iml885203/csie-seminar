using UnityEngine;
using System.Collections;

public class sizeControl : MonoBehaviour {
    private Transform thisTrans;
	// Use this for initialization
	void Start () {
        thisTrans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            thisTrans.localScale = new Vector3(thisTrans.localScale.x + 1, thisTrans.localScale.y, thisTrans.localScale.z);
        }

        else if (Input.GetKey(KeyCode.T))
        {
            thisTrans.localScale = new Vector3(thisTrans.localScale.x - 1, thisTrans.localScale.y, thisTrans.localScale.z);
        }

        if (Input.GetKey(KeyCode.F))
        {
            thisTrans.localScale = new Vector3(thisTrans.localScale.x, thisTrans.localScale.y+1, thisTrans.localScale.z);
        }

        else if (Input.GetKey(KeyCode.G))
        {
            thisTrans.localScale = new Vector3(thisTrans.localScale.x, thisTrans.localScale.y-1, thisTrans.localScale.z);
        }

    }
}
