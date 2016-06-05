using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using System.Collections.Generic;

public class matchPointToOutputView : MonoBehaviour {

    public DrawBlock _DrawBlockManager;
    public Match _MatchManager;
    public GameObject _mapobject;
    private int width;
    private int height;
    private clickPositionTrans _clickPositionTrans;
    public List<Point> outputPoint { get; private set; }
    public double OutputX { get; private set; }
    public double OutputY { get; private set; }


    // Use this for initialization
    void Start () {
        OutputX = 0.0;
        OutputY = 0.0;
        outputPoint = new List<Point>();
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
        if(width != _DrawBlockManager.MatchWidth || height != _DrawBlockManager.MatchHeight) // 如果drawblock重新框選
        {
            width = _DrawBlockManager.MatchWidth;
            height = _DrawBlockManager.MatchHeight;
            Debug.Log("Block Size: " + width + " x " + height);
            Debug.Log("object Size: " + _mapobject.transform.localScale.x + " x " + _mapobject.transform.localScale.y);
            _clickPositionTrans = new clickPositionTrans(width, height, _mapobject.transform.localScale.x, _mapobject.transform.localScale.y);
        }

        BaseObject[] results = _MatchManager.SensingResults.ToArray();
        
            
        for(int i=0; i< results.Length; i++)
        {
            Point[] block = results[i].ObjectBlock;
            var centerX = (block[0].x + block[1].x) / 2;
            var centerY = (block[0].y + block[1].y) / 2;
            Debug.Log("#" + i + ": " + centerX + "," + centerY);
            var transPoint = _clickPositionTrans.TransToScreen2Pos(new Point(centerX, centerY));
            //Debug.Log("object" + ": " + transPoint.x + "," + transPoint.y);
            OutputX = transPoint.x;
            OutputY = transPoint.y;
        }
    }
}
