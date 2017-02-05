using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEditor;
using System;

public class PlayerInfo : MonoBehaviour
{
    //取得玩家人數
    public GameRunStatus _gameRunStatus;
    //取得地圖格數
    public MapManager _mapManager;

    //角色移動的地板及其長寬
    public GameObject _playerMoveWholeGround;
    private float _playerMoveWholeGroundWidth;
    private float _playerMoveWholeGroundHeight;

    //玩家座標
    private List<Point> _playerBlockCoordinate = new List<Point>();
    private List<Point> _playerRealCoordinate = new List<Point>();

    //格子實際長寬
    private float _blockWidthSize;
    private float _blockHeightSize;

    //回傳指定玩家實際座標
    public Point GetPlayerRealCoordinateByIndex(int index)
    {
        return _playerRealCoordinate[index];
    }

    //設定指定玩家實際座標
    public void SetPlayerRealCoordinateByIndex(int index, Point coordinatePoint)
    {
         _playerRealCoordinate[index] = coordinatePoint;
    }

    // Use this for initialization
    void Start ()
    {
        _playerMoveWholeGroundWidth = _playerMoveWholeGround.GetComponent<RectTransform>().rect.width;
        _playerMoveWholeGroundHeight = _playerMoveWholeGround.GetComponent<RectTransform>().rect.height;

        _blockWidthSize = _playerMoveWholeGroundWidth / Convert.ToSingle(_mapManager.GetBlockWidth);
        _blockHeightSize = _playerMoveWholeGroundHeight / Convert.ToSingle(_mapManager.GetBlockHeight);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    //轉換實際座標到格子座標
    private void CalculateRealCoordinateToBlock()
    {
        for(int playerIndex = 0; playerIndex < _gameRunStatus.PlayerCount; playerIndex++)
        {
            _playerBlockCoordinate[playerIndex] = new Point(_playerMoveWholeGroundWidth / _blockWidthSize, _playerMoveWholeGroundHeight / _blockHeightSize) ;
            
        }
    }
}
