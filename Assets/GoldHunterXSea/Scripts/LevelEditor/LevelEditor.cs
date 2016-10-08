using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System.Text;
using System;

public class LevelEditor : MonoBehaviour
{
    private const string ENTER = "\r\n";

    public GameObject[] _otherCanvas;

    public GameObject _fileName;

    public GameObject _laserGeneratorObject;
    public GameObject _reflectObject;
    public GameObject _destoryObject;
    public GameObject _targetObject;
    public GameObject _blackHoleObject;
    public GameObject _whiteHoleObject;
    public GameObject _separateObject;
    public GameObject _transmissionObject;

    //public GameObject _selectorBlock;
    public GameObject _selectorObject;
    public GameObject _canvasPanel;

    private Vector3 _mouseClickPosition;
    public GameObject _camera;

    private LevelObjectBase _LevelObjectBase;
    //private string _selectObjectKind;

    private bool _isRotateClockWise;
    private bool _isRotateInverseClock; 

    void Start()
    {
        _isRotateClockWise = false;
        _isRotateInverseClock = false;
        _selectorObject = _laserGeneratorObject;
    }

    //用fixedUpdate會有按一下跑三次Input.GetMouseButtonUp(0)的問題
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            //_selectorObject = new GameObject();
            //_LevelObjectBase.SwitchGameObject(_selectObjectKind, ref _selectorObject);

            _mouseClickPosition = Input.mousePosition;
            //Debug.Log("_mouseClickPosition1 = " + _mouseClickPosition);
            _mouseClickPosition = _camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("_mouseClickPosition2 = " + _mouseClickPosition);
            if(_selectorObject != null)
            {
                this.SetNewObjectBySelectedObject();
            }
        }

        if (_isRotateClockWise)
            this.RotateSelectObjectClockWise();
        if (_isRotateInverseClock)
            this.RotateSelectObjectInverseClock();

    }

    //void UpdateSelected()
    //{
    //    this.RotateSelectObjectClockWise();
    //    this.RotateSelectObjectInverseClock();
    //}

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

    //存檔按鈕事件
    public void SaveButtonClick()
    {
        List<GroupObjects> listGroupObjects = new List<GroupObjects>();

        //將目前場地上的物件存進list
        GameObject currentGameObject;
        for(int index = 0; index < this.gameObject.transform.FindChild("ProduceObjects").childCount; index++)
        {
            currentGameObject = this.gameObject.transform.FindChild("ProduceObjects").GetChild(index).gameObject;

            Vector3 gameObjectPosition = new Vector3(currentGameObject.transform.localPosition.x, currentGameObject.transform.localPosition.y, 0);
            float gameObjectRotation = (float)currentGameObject.transform.eulerAngles.z;
            ObjectData objData = new ObjectData(gameObjectPosition, gameObjectRotation);
            //Debug.Log("objData.ObjectPosition = " + objData.ObjectPosition);

            string objectKind = this.TransGameObjectNameToKindName(currentGameObject.name);

            if(listGroupObjects.Exists(x => x.GroupName.Contains(objectKind)))
            {
                listGroupObjects.Find(x => x.GroupName.Contains(objectKind)).AddAnObject(objData);
            }
            else
            {
                GroupObjects newGroupObjects = new GroupObjects(objectKind, objData);
                listGroupObjects.Add(newGroupObjects);
            }
        }
        currentGameObject = new GameObject();
        Destroy(currentGameObject);


        string saveDataString = this.TransGroupObjectsDataToString(listGroupObjects);
        string saveFileName = _fileName.transform.FindChild("Text").GetComponent<Text>().text;
        if (saveFileName == "") saveFileName = "預設名稱";

        System.IO.File.WriteAllText(saveFileName + ".txt", saveDataString, Encoding.Unicode);

        //Debug.Log("_listGroupObjects = " + _listGroupObjects[0].GroupName);
        //Debug.Log(".. = " + _listGroupObjects[0].ListObjects[0].ObjectPosition);
        //Debug.Log(".. = " + _listGroupObjects[0].ListObjects[1].ObjectPosition);
        //Debug.Log("_listGroupObjects = " + _listGroupObjects[1].GroupName);
        //Debug.Log(".. = " + _listGroupObjects[1].ListObjects[0].ObjectPosition);
    }

    public string TransGroupObjectsDataToString(List<GroupObjects> listGroupObjects)
    {
        string allData = "";
        for(int groupIndex = 0; groupIndex < listGroupObjects.Count; groupIndex++)
        {
            allData += listGroupObjects[groupIndex].GroupName + ENTER +
                    listGroupObjects[groupIndex].ListObjects.Count.ToString() + ENTER;
            for (int objectDataIndex = 0; objectDataIndex < listGroupObjects[groupIndex].ListObjects.Count; objectDataIndex++)
            {
                allData += ENTER +
                 listGroupObjects[groupIndex].ListObjects[objectDataIndex].ObjectRotation.ToString() + ENTER +
                 listGroupObjects[groupIndex].ListObjects[objectDataIndex].ObjectPosition.x.ToString() + "," +
                 listGroupObjects[groupIndex].ListObjects[objectDataIndex].ObjectPosition.y.ToString() + ENTER;
            }
            allData += ENTER;
        }
        return allData;
    }

    //旋轉物件按鈕事件
    //順時鐘旋轉

    public void PointerDownClockWiseButton()
    {
        _isRotateClockWise = true;
    }

    public void PointerUpClockWiseButton()
    {
        _isRotateClockWise = false;
    }

    public void RotateSelectObjectClockWise()
    {
        _selectorObject.transform.Rotate(new Vector3(0, 0, -5));
    }

    //逆時鐘旋轉

    public void PointerDownInverseClockButton()
    {
        _isRotateInverseClock = true;
    }

    public void PointerUpInverseClockButton()
    {
        _isRotateInverseClock = false;
    }

    public void RotateSelectObjectInverseClock()
    {
        _selectorObject.transform.Rotate(new Vector3(0, 0, 5));
    }


    //選擇物件按鈕事件

    public void LaserGeneratorButtonClick()
    {
        _selectorObject = _laserGeneratorObject;
    }

    public void ReflectButtonClick()
    {
        _selectorObject = _reflectObject;
    }

    public void DestoryButtonClick()
    {
        _selectorObject = _destoryObject;
    }

    public void TargetButtonClick()
    {
        _selectorObject = _targetObject;
    }

    public void BlackHoleButtonClick()
    {
        _selectorObject = _blackHoleObject;
    }

    public void WhiteHoleButtonClick()
    {
        _selectorObject = _whiteHoleObject;
    }

    public void SeparateButtonClick()
    {
        _selectorObject = _separateObject;
    }

    public void TransmissionButtonClick()
    {
        _selectorObject = _transmissionObject;
    }



    public string TransGameObjectNameToKindName(string gameObjectName)
    {
        //Debug.Log("In Switch: gameObjectName = " + gameObjectName);
        switch (gameObjectName)
        {
            case "LaserGenerator(Clone)":
                {
                    return "雷射槍";
                }
            case "ReflectionObject(Clone)":
                {
                    return "牆壁";
                }
            case "DestoryObject(Clone)":
                {
                    return "障礙牆";
                }
            case "TargetObject(Clone)":
                {
                    return "目標";
                }
            case "BlackHoleObject(Clone)":
                {
                    return "引力裝置";
                }
            case "WhiteHoleObject(Clone)":
                {
                    return "斥力裝置";
                }
            case "SeparateObject(Clone)":
                {
                    return "分離裝置";
                }
            case "TransmissionObject(Clone)":
                {
                    return "傳送門";
                }
            default:
                return "";
        }
    }
}


