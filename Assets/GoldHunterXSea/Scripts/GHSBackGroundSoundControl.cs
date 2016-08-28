using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

static class BackGroundSoundList
{
    public const int Menu = 0;
    public const int Setting = 1;
    public const int GameRun = 2;
}

public class GHSBackGroundSoundControl : MonoBehaviour
{
    public AudioClip[] _backGroungSound;
    public Slider _volumeSlider;
    private AudioSource _playing;
    public Text gameStateButtonText;

    void Start()
    {
        _playing = GetComponent<AudioSource>();
        _playing.clip = _backGroungSound[BackGroundSoundList.Menu];
        _playing.Play();
    }

    void Update()
    {
        _playing.volume = _volumeSlider.value * (float)0.01;
    }

    public void buttonClick()
    {
        if(gameStateButtonText.text == "Start")
        {
            _playing.Stop();
            _playing.clip = _backGroungSound[BackGroundSoundList.Menu];
            _playing.Play();
        }
        
        if(gameStateButtonText.text == "Back Menu")
        {
            _playing.Stop();
            _playing.clip = _backGroungSound[BackGroundSoundList.GameRun];
            _playing.Play();
        }
    }
}
