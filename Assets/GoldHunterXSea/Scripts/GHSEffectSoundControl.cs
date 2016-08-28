using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

static class EffectSoundList
{
    public const int Fight = 0;
    public const int Swimming = 1;
    public const int GetItem = 2;
}

public class GHSEffectSoundControl : MonoBehaviour
{
    private int _soundSize = 10;

    public Slider _volumeSlider;
    public AudioClip[] _effectSound;
    private AudioSource _playing;
    private float _audioTimer;

    void Start()
    {
        _playing = GetComponent<AudioSource>();
        _audioTimer = 0;
        //for(int index = 0; index < _soundSize; index++)
        //{
        //    GameObject effectSoundObj = new GameObject("effectSoundObj");
        //    effectSoundObj.AddComponent<AudioSource>();
        //    effectSoundObj.SetActive(false);
        //    effectSoundObj.transform.SetParent(this.transform);
        //}
    }

    void Update()
    {
        _playing.volume = _volumeSlider.value * (float)0.01;
    }

    public void PlayEffectSound(String even)
    {
        GameObject effectSoundObj = new GameObject(even + "_effectSoundObj");
        effectSoundObj.AddComponent<AudioSource>();
        effectSoundObj.SetActive(true);
        effectSoundObj.transform.SetParent(this.transform);
        effectSoundObj.GetComponent<AudioSource>().volume = _playing.volume;

        if (even == "Fight")
        {
            effectSoundObj.GetComponent<AudioSource>().clip = _effectSound[EffectSoundList.Fight];
            _audioTimer = _effectSound[EffectSoundList.Fight].length;
        }
        else if (even == "Swimming")
        {
            effectSoundObj.GetComponent<AudioSource>().clip = _effectSound[EffectSoundList.Swimming];
            _audioTimer = _effectSound[EffectSoundList.Swimming].length;
        }
        else if(even == "GetItem")
        {
            effectSoundObj.GetComponent<AudioSource>().clip = _effectSound[EffectSoundList.GetItem];
            _audioTimer = _effectSound[EffectSoundList.GetItem].length;
        }
        else
        {
            
        }

        effectSoundObj.GetComponent<AudioSource>().Play();
        StartCoroutine("AudioRecover", effectSoundObj);
        
    }

    IEnumerator AudioRecover(GameObject recoverAudioObj)
    {
        yield return new WaitForSeconds(_audioTimer);
        recoverAudioObj.SetActive(false);
        Destroy(recoverAudioObj);
    }
}
