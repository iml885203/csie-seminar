using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using System;

public class GHSPlayerState : MonoBehaviour
{
    System.Random rnd = new System.Random();
    private List<bool> _isPlayerEnable = new List<bool>();
    private List<bool> _enablePlayer = new List<bool>();
    private List<int> _realPlayer = new List<int>();

    public GHSPlayerState()
    {
        _isPlayerEnable.Add(false);
        _isPlayerEnable.Add(false);
        _isPlayerEnable.Add(false);
        _isPlayerEnable.Add(false);
    }

    //回傳玩家是否啟用
    public bool GetIsPlayerEnableOrNotByIndex(int playerId)
    {
        return _isPlayerEnable[playerId];
    }
    
    //設定玩家啟用/不啟用
    public void SetPlayerEnableOrNotByIndex(int playerId, bool setValue)
    {
        _isPlayerEnable[playerId] = setValue;
    }

    //初始化真實玩家(四個角落玩家決定p1,p2,p3...),p1是現有玩家雖機的一個,順時鐘輪流
    public void InitializeRealPlayer()
    {
        for (int index = 0; index < _isPlayerEnable.Count; index++)
        {
            if (_isPlayerEnable[index] == true)
            {
                _realPlayer.Add(index);
            }
        }

        int realPlayerCount = this.GetEnablePlayerCount();
        int firstPlayerIndex = rnd.Next(0, realPlayerCount); //creates a number between 1 and realPlayerCount-1
        List<int> tempRealPlayer = new List<int>(_realPlayer);

        for (int index = 0; index < realPlayerCount; index++)
        {
            _realPlayer[index] = tempRealPlayer[firstPlayerIndex % realPlayerCount];
            firstPlayerIndex++;
        }
    }

    //取得啟動的玩家數量
    public int GetEnablePlayerCount()
    {
        int playerCount = 0;
        for(int index = 0; index < _isPlayerEnable.Count; index++)
        {
            if (_isPlayerEnable[index] == true) playerCount++;
        }
        return playerCount;
    }

    public int GetRealPlayerCornerByIndex(int index)
    {
        return _realPlayer[index];
    }
}
