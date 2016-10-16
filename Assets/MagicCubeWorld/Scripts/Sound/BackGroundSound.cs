using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class BackGroundSound : MonoBehaviour
{
    public const int MENU_And_SETTING = 0;
    public const int LIST_PRODUCER = 1;
    public const int GAMERUN_SINGLE = 2;
    public const int GAMERUN_FIGHT = 3;

    private AudioSource _playing;

    public AudioClip[] _backGroungSound;
    public Slider _volumeSlider;
    public GameStateIndex _gameState;
    public PlayMode _playMode;

    void Start()
    {
        _playing = GetComponent<AudioSource>();
        _playing.clip = _backGroungSound[MENU_And_SETTING];
        _playing.loop = true;
        _playing.Play();
    }

    void Update()
    {
        //ChangeGameState();
        _playing.volume = _volumeSlider.value * (float)0.01;
    }

    public void ChangeGameState()
    {
        if (_gameState.CurrentStateIndex == GameState.Menu || _gameState.CurrentStateIndex == GameState.Setting)
        {
            if(_playing.clip != _backGroungSound[MENU_And_SETTING])
            {
                _playing.Stop();
                _playing.clip = _backGroungSound[MENU_And_SETTING];
                _playing.loop = true;
                _playing.Play();
            }
        }

        if (_gameState.CurrentStateIndex == GameState.ListProducer)
        {
            _playing.Stop();
            _playing.clip = _backGroungSound[LIST_PRODUCER];
            _playing.loop = true;
            _playing.Play();
        }

        if (_gameState.CurrentStateIndex == GameState.GameRun && _playMode.CurrentPlayMode == PlayMode.MODE_SINGLE)
        {
            _playing.Stop();
            _playing.clip = _backGroungSound[GAMERUN_SINGLE];
            _playing.loop = true;
            _playing.Play();
        }

        if (_gameState.CurrentStateIndex == GameState.GameRun && _playMode.CurrentPlayMode == PlayMode.MODE_FIGHT)
        {
            _playing.Stop();
            _playing.clip = _backGroungSound[GAMERUN_FIGHT];
            _playing.loop = true;
            _playing.Play();
        }
    }
}
