using UnityEngine;
using System.Collections;
using OpenCVForUnity;

public class clickPositionTrans {
    private double _screenWidth1;
    private double _screenHeight1;
    private double _screenWidth2;
    private double _screenHeight2;
    private double _to2TateWidth;
    private double _to2TateHeight;

    public clickPositionTrans(int width1, int height1, int width2, int height2)
    {
        _screenWidth1 = (double)width1;
        _screenHeight1 = (double)height1;
        _screenWidth2 = (double)width2;
        _screenHeight2 = (double)height2;
        _to2TateWidth = _screenWidth2 / _screenWidth1;
        _to2TateHeight = _screenHeight2 / _screenHeight1;
    }
    public clickPositionTrans(double width1, double height1, double width2, double height2)
    {
        _screenWidth1 = width1;
        _screenHeight1 = height1;
        _screenWidth2 = width2;
        _screenHeight2 = height2;
        _to2TateWidth = _screenWidth2 / _screenWidth1;
        _to2TateHeight = _screenHeight2 / _screenHeight1;
    }

    public Point TransToScreen2Pos(Point pos)
    {
        return new Point(pos.x * _to2TateWidth, pos.y * _to2TateHeight);
    }
    public Point TransToScreen1Pos(Point pos)
    {
        return new Point(pos.x / _to2TateWidth, pos.y / _to2TateHeight);
    }
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
