using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class DepthToMatView : MonoBehaviour {

    public DepthToMatManager _depthToMat;
    private Texture2D _tex;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (_tex == null)_tex = new Texture2D(_depthToMat.getWidth(), _depthToMat.getheight());
        //Debug.Log("W = " + _depthToMat.getWidth() + " H = " + _depthToMat.getheight());
        Mat NewMat = new Mat(_depthToMat.getheight(), _depthToMat.getWidth(), CvType.CV_8UC1);
        NewMat = _depthToMat.getDepthMat();

        Utils.matToTexture2D(NewMat,_tex);
        this.gameObject.GetComponent<RawImage>().texture = _tex;
	}
}
