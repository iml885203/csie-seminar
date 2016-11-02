using UnityEngine;
using System.Collections;
using OpenCVForUnity;

public class BaseObject : MonoBehaviour {

    public Point[] _objectBlock { get; private set; }
    private Scalar _objectColor;
    private Scalar _objectHsvColor;
    private double[] _colorDiff = new double[3];
    private int _id;

    public BaseObject(int id,Point P1,Point P2,Scalar color, Scalar colorHsv)
    {
        _id = id;
        _objectBlock = new Point[2];
        _objectBlock[0] = new Point(P1.x, P1.y);
        _objectBlock[1] = new Point(P2.x, P2.y);
        _objectColor = new Scalar(color.val);
        _objectHsvColor = new Scalar(colorHsv.val);
        _colorDiff[0] = color.val[0] - color.val[1];
        _colorDiff[1] = color.val[1] - color.val[2];
        _colorDiff[2] = color.val[2] - color.val[0];
    }
    public BaseObject(int id, Scalar color, Scalar colorHsv)
    {
        _id = id;
        _objectColor = new Scalar(color.val);
        _objectHsvColor = new Scalar(colorHsv.val);
        _objectBlock = new Point[2];
        _objectBlock[0] = new Point((double)-100, (double)-100);
        _objectBlock[1] = new Point((double)-100, (double)-100);
        _colorDiff[0] = color.val[0] - color.val[1];
        _colorDiff[1] = color.val[1] - color.val[2];
        _colorDiff[2] = color.val[2] - color.val[0];
    }
    public Scalar getColor(){
        return _objectColor;
    }

    public Scalar getColorHsv()
    {
        return _objectHsvColor;
    }
    public void SetPoint(Point P1,Point P2)
    {
        _objectBlock[0] = new Point(P1.x, P1.y);
        _objectBlock[1] = new Point(P2.x, P2.y);
    }

    //
    public int getId()
    {
        return _id;
    }
    public double [] getColorDiff()
    {
        return _colorDiff;
    }
}
