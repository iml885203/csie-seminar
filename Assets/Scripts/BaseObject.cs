using UnityEngine;
using System.Collections;
using OpenCVForUnity;

public class BaseObject : MonoBehaviour {

    private Point [] ObjectBlock;
    private Scalar ObjectColor;
    private string name;

    public BaseObject(Point P1,Point P2,Scalar color)
    {
        ObjectBlock = new Point[2];
        ObjectBlock[0] = new Point(P1.x, P1.y);
        ObjectBlock[1] = new Point(P2.x, P2.y);
        ObjectColor = new Scalar(color.val);
    }
    public Scalar getColor(){
        return ObjectColor;
    }
    public void SetPoint(Point P1,Point P2)
    {
        ObjectBlock[0] = new Point(P1.x, P1.y);
        ObjectBlock[1] = new Point(P2.x, P2.y);
    }
}
