using UnityEngine;
using System.Collections;
using OpenCVForUnity;

public class BaseObject : MonoBehaviour {

    public Point[] ObjectBlock { get; private set; }
    private Scalar ObjectColor;
    private int _id;

    public BaseObject(int id,Point P1,Point P2,Scalar color)
    {
        _id = id;
        ObjectBlock = new Point[2];
        ObjectBlock[0] = new Point(P1.x, P1.y);
        ObjectBlock[1] = new Point(P2.x, P2.y);
        ObjectColor = new Scalar(color.val);
    }
    public BaseObject(int id, Scalar color)
    {
        _id = id;
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

    //
    public int getId()
    {
        return _id;
    }
}
