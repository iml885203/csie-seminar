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

    public GameObject[] _originObject;

    public GameObject _laserGeneratorObject;
    public GameObject _reflectObject;
    public GameObject _destoryObject;
    public GameObject _blackHoleObject;
    public GameObject _whiteHoleObject;
    public GameObject _separateObject;
    public GameObject _transmissionObject;
    public GameObject _targetObject;
    public GameObject _targetFightObject;

    //public GameObject _selectorBlock;
    public GameObject _selectorObject;
    public GameObject _saveCanvasPanel;

    private Vector3 _mouseClickPosition;
    private Vector3 _test;
    public GameObject _camera;

    private LevelObjectBase _LevelObjectBase;
    //private string _selectObjectKind;

    private bool _isRotateClockWise;
    private bool _isRotateInverseClock;

    private List<Vector3> _originPositionList;

    void Start()
    {
        _isRotateClockWise = false;
        _isRotateInverseClock = false;
        _selectorObject = _laserGeneratorObject;

        _originPositionList = new List<Vector3>();
        //暫存每個物件的原始位置
        for (int index = 0; index < _originObject.Length; index++)
        {
            _originPositionList.Add(_originObject[index].transform.position);
        }
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

        if(_selectorObject.gameObject != null)
        {
            _test = _camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            _test = new Vector3(_test.x, _test.y, 0);
            _selectorObject.transform.position = _test;
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

    //重設按鈕事件
    public void ResetButtonClick()
    {
        GameObject currentGameObject;
        for (int index = 0; index < this.gameObject.transform.FindChild("ProduceObjects").childCount; index++)
        {
            currentGameObject = this.gameObject.transform.FindChild("ProduceObjects").GetChild(index).gameObject;
            Destroy(currentGameObject);
        }
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

            //這邊要再做座標轉換
            gameObjectPosition = this.TransCoordinateMapping(gameObjectPosition);

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

    //座標轉換 用要存檔的panel座標系統為基準
    public Vector3 TransCoordinateMapping(Vector3 originVector)
    {
        float XShift = _saveCanvasPanel.GetComponent<RectTransform>().position.x;
        float YShift = _saveCanvasPanel.GetComponent<RectTransform>().position.y;

        float XRate = _saveCanvasPanel.GetComponent<RectTransform>().rect.width / this.GetComponent<RectTransform>().rect.width;
        float YRate = _saveCanvasPanel.GetComponent<RectTransform>().rect.height / this.GetComponent<RectTransform>().rect.height;

        return new Vector3(originVector.x * XRate + XShift, originVector.y * YRate + YShift, originVector.z);
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
        foreach(GameObject gameObject in _originObject)
        {
            if(gameObject.name == "LaserGenerator")
            {
                _selectorObject = gameObject;
            }
        }
        this.ResetObjectPosition();
    }

    public void ReflectButtonClick()
    {
        foreach (GameObject gameObject in _originObject)
        {
            if (gameObject.name == "ReflectionObject")
            {
                _selectorObject = gameObject;
            }
        }
        this.ResetObjectPosition();
    }

    public void DestoryButtonClick()
    {
        foreach (GameObject gameObject in _originObject)
        {
            if (gameObject.name == "DestoryObject")
            {
                _selectorObject = gameObject;
            }
        }
        this.ResetObjectPosition();
    }

    public void TargetButtonClick()
    {
        foreach (GameObject gameObject in _originObject)
        {
            if (gameObject.name == "TargetObject")
            {
                _selectorObject = gameObject;
            }
        }
        this.ResetObjectPosition();
    }

    public void TargetFightButtonClick()
    {
        foreach (GameObject gameObject in _originObject)
        {
            if (gameObject.name == "TargetFightObject")
            {
                _selectorObject = gameObject;
            }
        }
        this.ResetObjectPosition();
    }

    public void BlackHoleButtonClick()
    {
        foreach (GameObject gameObject in _originObject)
        {
            if (gameObject.name == "BlackHoleObject")
            {
                _selectorObject = gameObject;
            }
        }
        this.ResetObjectPosition();
    }

    public void WhiteHoleButtonClick()
    {
        foreach (GameObject gameObject in _originObject)
        {
            if (gameObject.name == "WhiteHoleObject")
            {
                _selectorObject = gameObject;
            }
        }
        this.ResetObjectPosition();
    }

    public void SeparateButtonClick()
    {
        foreach (GameObject gameObject in _originObject)
        {
            if (gameObject.name == "SeparateObject")
            {
                _selectorObject = gameObject;
            }
        }
        this.ResetObjectPosition();
    }

    public void TransmissionButtonClick()
    {
        foreach (GameObject gameObject in _originObject)
        {
            if (gameObject.name == "TransmissionObject")
            {
                _selectorObject = gameObject;
            }
        }
        this.ResetObjectPosition();
    }

    public void ResetObjectPosition()
    {
        for(int index = 0; index < _originObject.Length; index++)
        {
            _originObject[index].transform.position = _originPositionList[index];
        }
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
                    return "反彈牆";
                }
            case "DestoryObject(Clone)":
                {
                    return "障礙牆";
                }
            case "BlackHoleObject(Clone)":
                {
                    return "蟲洞";
                }
            case "WhiteHoleObject(Clone)":
                {
                    return "白洞";
                }
            case "SeparateObject(Clone)":
                {
                    return "分離器";
                }
            case "TransmissionObject(Clone)":
                {
                    return "傳送門";
                }
            case "TargetObject(Clone)":
                {
                    return "接收器";
                }
            case "TargetFightObjects(Clone)":
                {
                    return "生命裝置";
                }
            default:
                return "";
        }
    }
}


