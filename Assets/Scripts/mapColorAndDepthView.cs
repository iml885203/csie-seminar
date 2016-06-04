using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using OpenCVForUnity;

public class mapColorAndDepthView : MonoBehaviour {
    public mapColorAndDepth _mapColorAndDepth;
    private Texture2D output;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (_mapColorAndDepth == null)
        {
            return;
        }
        if (_mapColorAndDepth.GetMapperMat() == null)
        {
            return;
        }
        Mat mapperMat = _mapColorAndDepth.GetMapperMat();
        if(output == null)
        {
            output = new Texture2D(mapperMat.width(), mapperMat.height());
        }
        
        Utils.matToTexture2D(mapperMat, output);
        this.gameObject.GetComponent<RawImage>().texture = output;
    }
}
