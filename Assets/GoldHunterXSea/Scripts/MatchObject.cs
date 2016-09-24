using OpenCVForUnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MatchObject : MonoBehaviour
{
    public Vector3 _pos { get; set; }
    public Vector2 _scale { get; set; }
    public float _rotation { get; set; }
    public Scalar _objectColor { get; set; }
    public int _id { get; set; }
}

