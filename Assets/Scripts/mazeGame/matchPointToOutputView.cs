using UnityEngine;
using System.Collections;
using OpenCVForUnity;

public class matchPointToOutputView : MonoBehaviour {

    public Match _MatchManager;
    public GameObject _mapobject;
    private int width;
    private int height;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if(_MatchManager != null)
        {
            showData();
        }
	}
    
    void showData()
    {
        if(width != _MatchManager.Width || height != _MatchManager.Height)
        {
            width = _MatchManager.Width;
            height = _MatchManager.Height;
            Debug.Log("Block Size: " + width + " x " + height);
        }
        
        Point[] objectPoint = _MatchManager.MatchObjectPoint.ToArray();
        
            
        for(int i=0; i<objectPoint.Length; i++)
        {
            Debug.Log("#" + i + ": " + objectPoint[i].x + "," + objectPoint[i].y);

        }
    }
}
