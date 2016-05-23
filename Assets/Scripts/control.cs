using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {
    public string key;
    private KeyCode mykeycode;
    public GameObject[] cameraView;
    
	// Use this for initialization
	void Start () {
        mykeycode = (KeyCode)System.Enum.Parse(typeof(KeyCode), key.ToUpper());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(mykeycode))
        {
            for (int i = 0; i < cameraView.Length; i++)
            {
                if (cameraView[i] == null) continue;
                cameraView[i].SetActive(!cameraView[i].active);
            }

        }
    }

}
