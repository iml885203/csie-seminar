using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class DepthToMatView : MonoBehaviour {

    public DepthToMatManager _depthToMat;
    private Texture2D _tex;

	// Use this for initialization
	void Start () {
        _tex = new Texture2D(_depthToMat.getWidth(), _depthToMat.getheight());
	}
	
	// Update is called once per frame
	void Update () {
        Mat NewMat = new Mat();
        NewMat = _depthToMat.getDepthMat();

        Utils.matToTexture(NewMat,_tex);
        this.gameObject.GetComponent<RawImage>().texture = _tex;
	}
}
