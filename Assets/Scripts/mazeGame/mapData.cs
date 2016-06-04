using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;

public class mapData : MonoBehaviour {

    private byte[,] _mapCoordinateByte = new byte[9,16]{//Height,Width
        {9,12,9,10,12,9,10,14,9,10,12,13,13,13,11,12},
        {5,1,2,12,3,6,9,10,0,12,3,6,5,3,12,5},
        {7,1,12,5,13,9,6,11,4,3,10,8,6,11,2,4},
        {11,4,7,1,6,5,9,14,5,9,10,2,12,9,8,4},
        {9,2,12,3,10,2,6,9,4,7,13,13,7,5,5,7},
        {7,9,6,9,14,9,10,6,3,14,1,0,10,4,1,10},
        {9,2,8,4,9,4,9,14,9,10,6,5,13,7,3,12},
        {5,9,6,7,5,5,5,9,0,10,10,2,6,9,12,5},
        {7,3,10,14,7,3,2,6,3,14,11,10,10,6,3,6}};
    private List<Point> _canMoveArea = new List<Point>();



    public List<Point> getCanMoveArea()
    {   
        return _canMoveArea;
    }
    public void setCanMoveArea(Point P)
    {
        _canMoveArea.Add(P);
    }
    public byte getWall(int x, int y)
    {
        return _mapCoordinateByte[y, x];
    }
    public bool isExist(Point P)
    {
        return _canMoveArea.Exists(List => List.x== P.x && List.y == P.y);
    }
}
