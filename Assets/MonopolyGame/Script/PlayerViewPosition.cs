using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class PlayerViewPosition : MonoBehaviour
{
    public PlayerData[] _playerData;
    public Image[] _playerViewPositionImage;

    // Use this for initialization
    void Start()
    {
        for (int index = 0; index < _playerViewPositionImage.Length; index++)
        {
            _playerViewPositionImage[index].color = _playerData[index].PlayerColor;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
