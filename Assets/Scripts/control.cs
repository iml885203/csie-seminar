using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {
    public GameObject[] cameraView;
    private double resetTime = 0.0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            for(int i=0 ; i<cameraView.Length; i++)
            {
                cameraView[i].SetActive(!cameraView[i].active);
            }
            
        }

        //Debug.Log("Update time :" + Time.deltaTime);

    }
    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate time :" + Time.deltaTime);
        
    }

}
