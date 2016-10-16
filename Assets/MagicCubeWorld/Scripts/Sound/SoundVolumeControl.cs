using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class SoundVolumeControl : MonoBehaviour
{
    public Slider _backGroundSound;
    public Slider _effectSound;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void RaiseBackGroundSoundVolume()
    {
        _backGroundSound.value += 20f;
    }

    public void ReduceBackGroundSoundVolume()
    {
        _backGroundSound.value -= 20f;
    }

    public void RaiseEffectSoundVolume()
    {
        _effectSound.value += 20f;
    }

    public void ReduceEffectSoundVolume()
    {
        _effectSound.value -= 20f;
    }
}
