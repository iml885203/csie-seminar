using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using OpenCVForUnity;

public class mapColorAndDepthView : MonoBehaviour {
    public mapColorAndDepth _mapColorAndDepth;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (_mapColorAndDepth == null)
        {
            return;
        }
        Mat mapperMat = _mapColorAndDepth.GetMapperMat();
        Texture2D output = new Texture2D(mapperMat.width(), mapperMat.height());
        Utils.matToTexture2D(mapperMat, output);
        this.gameObject.GetComponent<RawImage>().texture = output;
    }
}
