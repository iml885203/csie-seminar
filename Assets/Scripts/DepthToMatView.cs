using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class DepthToMatView : MonoBehaviour {

    public DepthToMatManager _depthToMat;
    private Texture2D _tex;
    private clickPositionTrans _positionTrans;
    public Slider _cannyIndex;
    int _currentWidth;
    int _currentHeight;

	// Use this for initialization
	void Start () {
        _currentWidth = Screen.width;
        _currentHeight = Screen.height;
     //   _positionTrans = new clickPositionTrans(_currentWidth, _currentHeight, _depthToMat.getWidth(), _depthToMat.getheight());
	}
	
	// Update is called once per frame
	void Update () {


        if (_tex == null)_tex = new Texture2D(_depthToMat.getWidth(), _depthToMat.getheight());
        //Debug.Log("W = " + _depthToMat.getWidth() + " H = " + _depthToMat.getheight());
        Mat NewMat = new Mat(_depthToMat.getheight(), _depthToMat.getWidth(), CvType.CV_8UC1);
        NewMat = _depthToMat.getDepthMat();
        //Imgproc.Canny(NewMat, NewMat, _cannyIndex.value, _cannyIndex.value*3);
        //float x = Input.mousePosition.x;
        //float y = Screen.height - Input.mousePosition.y;
       // Point newPos = _positionTrans.TransToScreen2Pos(new Point(x, y));


        Utils.matToTexture2D(NewMat,_tex);
        this.gameObject.GetComponent<RawImage>().texture = _tex;
	}
}
