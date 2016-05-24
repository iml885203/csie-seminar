using UnityEngine;
using System.Collections;

public class fullscreen : MonoBehaviour {
    public string key;
    private KeyCode mykeycode;
    // Use this for initialization
    void Start () {
        mykeycode = (KeyCode)System.Enum.Parse(typeof(KeyCode), key.ToUpper());
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(this.transform.parent);
        if (Input.GetKeyDown(mykeycode))
        {
            
            float pos = (Camera.main.nearClipPlane + 0.01f);
            Vector3 newPos = Camera.main.transform.position + Camera.main.transform.forward * pos;
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
            float height = Camera.main.orthographicSize * 2;
            float width = height * Screen.width / Screen.height;
            transform.localScale = new Vector3(width, height, transform.localScale.z);
            
        }
	}
}
