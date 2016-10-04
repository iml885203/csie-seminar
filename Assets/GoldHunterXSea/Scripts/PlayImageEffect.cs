using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public static class Extensions
{
    public static void SetTransparency(this UnityEngine.UI.Image p_image, float p_transparency)
    {
        if (p_image != null)
        {
            UnityEngine.Color __alpha = p_image.color;
            __alpha.a = p_transparency;
            p_image.color = __alpha;
        }
    }
}

public class PlayImageEffect : MonoBehaviour
{
    public GameObject[] _imageGroup;

    public float _aImageTime;
    private float _timer;

    private int _currentImageIndex;

    void Start()
    {
        _currentImageIndex = 0;
        this.ChangeImage();
    } 

    void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if(_timer > _aImageTime)
        {
            _timer = 0f;
            _currentImageIndex++;
            _currentImageIndex = _currentImageIndex % _imageGroup.Length;
            this.ChangeImage();
        }
    }

    public void ChangeImage()
    {
        for (int index = 0; index < _imageGroup.Length; index++)
        {
            if (index == _currentImageIndex)
                _imageGroup[index].SetActive(true);
            else
                _imageGroup[index].SetActive(false);
        }
    }
}

