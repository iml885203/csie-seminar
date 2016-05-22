using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MatchView : MonoBehaviour {
    //public GameObject ColorSourceManager;
    public Match _matchManager;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<RawImage>() != null)
        {
            this.GetComponent<RawImage>().texture = _matchManager.GetMatchTexture();
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = _matchManager.GetMatchTexture();
        }
        //
    }
}
