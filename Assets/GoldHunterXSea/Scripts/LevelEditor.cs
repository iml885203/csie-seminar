using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class LevelEditor : MonoBehaviour
{
    public GameObject[] _otherCanvas;

    public GameObject[] _referenceObject;
    public GameObject _selectorBlock;
    public GameObject _selectorObject;
    public GameObject _canvasPanel;

    private Vector3 _mouseClickPosition;
    public GameObject _camera;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _mouseClickPosition = Input.mousePosition;
            Debug.Log("_mouseClickPosition1 = " + _mouseClickPosition);
            _mouseClickPosition = _camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("_mouseClickPosition2 = " + _mouseClickPosition);
            if(_selectorObject != null)
            {
                this.SetNewObjectBySelectedObject();
            }
        }
        
    }

    public void EnterLevelEditor()
    {
        this.gameObject.SetActive(true);
        foreach (GameObject currentCanvas in _otherCanvas)
            currentCanvas.SetActive(false);
    }

    public void ExitLevelEditor()
    {
        this.gameObject.SetActive(false);
        foreach (GameObject currentCanvas in _otherCanvas)
            currentCanvas.SetActive(true);
    }

    public void SetNewObjectBySelectedObject()
    {
        GameObject cloneObject = (GameObject)Instantiate(_selectorObject,
                    new Vector3(Convert.ToSingle(_mouseClickPosition.x), Convert.ToSingle(_mouseClickPosition.y), Convert.ToSingle(this.transform.position.z)),
                    new Quaternion(0, 0, 0, 1)
                    );

        cloneObject.transform.localScale = _selectorObject.transform.lossyScale;
        cloneObject.transform.localRotation = _selectorObject.transform.localRotation;
        cloneObject.transform.Rotate(Vector3.forward * 0, Space.World);
        cloneObject.transform.SetParent(this.transform.FindChild("ProduceObjects"));

        cloneObject.SetActive(true);
    }
}


