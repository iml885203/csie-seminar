using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;

public class GHSPlayerState : MonoBehaviour
{
    private List<bool> _isPlayerEnable = new List<bool>();

    public GHSPlayerState()
    {
        _isPlayerEnable.Add(false);
        _isPlayerEnable.Add(false);
        _isPlayerEnable.Add(false);
        _isPlayerEnable.Add(false);
    }

    public bool GetIsPlayerEnableOrNotByIndex(int playerId)
    {
        return _isPlayerEnable[playerId];
    }

    public void SetPlayerEnableByIndex(int playerId)
    {
        _isPlayerEnable[playerId] = true;
    }

    public void SetPlayerDisableByIndex(int playerId)
    {
        _isPlayerEnable[playerId] = false;
    }
}
