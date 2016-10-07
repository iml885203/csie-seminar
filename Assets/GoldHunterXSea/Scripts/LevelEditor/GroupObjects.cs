using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class GroupObjects : MonoBehaviour
{
    private string _groupName;
    private List<ObjectData> _listObjects;

    public GroupObjects()
    {
        _groupName = "";
        _listObjects = new List<ObjectData>();
    }

    public GroupObjects(string groupName, ObjectData firstObjectData)
    {
        _groupName = groupName;
        _listObjects = new List<ObjectData>();
        _listObjects.Add(firstObjectData);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void AddAnObject(ObjectData objectData)
    {
        _listObjects.Add(objectData);
    }

    public string GroupName
    {
        get
        {
            return _groupName;
        }
        set
        {
            _groupName = value;
        }
    }

    public List<ObjectData> ListObjects
    {
        get
        {
            return _listObjects;
        }
        set
        {
            _listObjects = value;
        }
    }
}