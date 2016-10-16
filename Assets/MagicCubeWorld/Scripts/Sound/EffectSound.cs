using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class EffectSound : MonoBehaviour
{
    public const int BUTTON_CLICK = 0;
    public const int WIN = 1;
    public const int LIFE_REDUCTION = 2;
    public const int BOOM = 3;

    public Slider _volumeSlider;
    public AudioClip[] _effectSound;
    private AudioSource _playing;
    private float _audioTimer;

    void Start()
    {
        _playing = GetComponent<AudioSource>();
        _audioTimer = 0;
    }

    void Update()
    {
        _playing.volume = _volumeSlider.value * (float)0.01;
    }

    public void PlayButtonClickEffectSound()
    {
        GameObject effectSoundObj = new GameObject("buttonClick _effectSoundObj");
        effectSoundObj.AddComponent<AudioSource>();
        effectSoundObj.SetActive(true);
        effectSoundObj.transform.SetParent(this.transform);
        effectSoundObj.GetComponent<AudioSource>().volume = _playing.volume;

        effectSoundObj.GetComponent<AudioSource>().clip = _effectSound[BUTTON_CLICK];
        _audioTimer = _effectSound[BUTTON_CLICK].length;

        effectSoundObj.GetComponent<AudioSource>().Play();
        StartCoroutine("AudioRecover", effectSoundObj);
    }

    public void PlayEffectSound(int soundIndex)
    {
        GameObject effectSoundObj = new GameObject(soundIndex + "_effectSoundObj");
        effectSoundObj.AddComponent<AudioSource>();
        effectSoundObj.SetActive(true);
        effectSoundObj.transform.SetParent(this.transform);
        effectSoundObj.GetComponent<AudioSource>().volume = _playing.volume;

        if (soundIndex == WIN)
        {
            effectSoundObj.GetComponent<AudioSource>().clip = _effectSound[WIN];
            _audioTimer = _effectSound[WIN].length;
        }
        else if (soundIndex == LIFE_REDUCTION)
        {
            effectSoundObj.GetComponent<AudioSource>().clip = _effectSound[LIFE_REDUCTION];
            _audioTimer = _effectSound[LIFE_REDUCTION].length;
        }
        else if (soundIndex == BOOM)
        {
            effectSoundObj.GetComponent<AudioSource>().clip = _effectSound[BOOM];
            _audioTimer = _effectSound[BOOM].length;
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
