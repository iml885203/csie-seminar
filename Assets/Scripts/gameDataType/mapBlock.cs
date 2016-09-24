using UnityEngine;
using System.Collections;
using OpenCVForUnity;

public class mapBlock {

    public Point minPos;
    public Point maxPos;

    public mapBlock()
    {
        minPos = new Point(0, 0);
        maxPos = new Point(0, 0);
    }
    /*check if in block by Point*/
    public bool Check(Point pos)
    {
        if(pos.x > minPos.x && pos.x < maxPos.x && pos.y > minPos.y && pos.y < maxPos.y)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    /*check if in block by double position*/
    public bool Check(double posX, double poxY)
    {
        //Debug.Log("min:" + minPos.x + "," + minPos.y + ". max:" + maxPos.x + "," + maxPos.y);
        if (posX > minPos.x && posX < maxPos.x && poxY > minPos.y && poxY < maxPos.y)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
