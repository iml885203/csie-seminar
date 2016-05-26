using UnityEngine;
using System.Collections;
using OpenCVForUnity;

public class mapCoordinate : MonoBehaviour {
    private float _mapWidth;
    private float _mapHeight;
    public mapBlock StartBlock;

    void Start()
    {
        _mapWidth = transform.localScale.x;
        _mapHeight = transform.localScale.y;
        //新增開始區塊範圍
        StartBlock = new mapBlock();
        StartBlock.minPos = new Point(0, _mapHeight * (7.0 / 8.0));
        StartBlock.maxPos = new Point(_mapWidth * (1.0 / 8.0), _mapHeight);
        
    }

    void Update()
    {
        //顯示大小改變
        if(transform.localScale.x != _mapWidth || transform.localScale.y != _mapHeight)
        {
            //Debug.Log("update map coordinate");
            _mapWidth = transform.localScale.x;
            _mapHeight = transform.localScale.y;
            //Debug.Log("update map" + _mapWidth + "x" + _mapHeight);
            StartBlock.minPos = new Point(0, _mapHeight * (7.0 / 8.0));
            StartBlock.maxPos = new Point(_mapWidth * (1.0 / 8.0), _mapHeight);
        }
    }
}
