using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class LevelObjectsBase : MonoBehaviour
{
    public GameLevelIndex _gameLevel;
    public GameStateIndex _gameState;

    protected string TEXT_FILE_NAME;

    protected GameObject _productGameObject;

    //public GameObject _laserGenerator;
    //public GameObject _reflectionObject;
    //public GameObject _destoryObject;
    //public GameObject _blackHoleObject;
    //public GameObject _whiteHoleObject;
    //public GameObject _separateObject;
    //public GameObject _transmissionObject;
    //public GameObject _targetObject;
    //public GameObject _targetFightObject;

    public GameObject _canvas;

    private List<OpenCVForUnity.Rect> _logicGatesArea = new List<OpenCVForUnity.Rect>();
    private List<int> _inputSerialNumberList = new List<int>();
    private List<bool> _inputTFList = new List<bool>();

    private List<int> _outputSerialNumberList = new List<int>();
    private List<OpenCVForUnity.Rect> _gateDetectAreaLisr = new List<OpenCVForUnity.Rect>();
    private List<Gate> _gateDataList = new List<Gate>();

    //protected float _canvasWidth;
    //protected float _canvasHeight;

    //protected float _blockWidth;
    //protected float _blockHeight;
    //protected const float HalfRate = (float).5;

    //protected int _blockWidthCount;
    //protected int _blockHeightCount;

    //protected float _originPointX;
    //protected float _originPointY;

    private bool _isChangePreviewLevel;

    // Use this for initialization
    public void Start()
    {
        ////格數
        //_blockWidthCount = 16;
        //_blockHeightCount = 8;

        ////畫布寬高
        //_canvasWidth = _canvas.GetComponent<RectTransform>().rect.width;
        //_canvasHeight = _canvas.GetComponent<RectTransform>().rect.height;

        ////原點座標
        //_originPointX = _canvas.transform.localPosition.x - (_canvasWidth / 2);
        //_originPointY = _canvas.transform.localPosition.y + (_canvasHeight / 2);
        //Debug.Log("_originPointX = " + _originPointX + ",_originPointY = " + _originPointY);

        ////框格寬度
        //_blockWidth = _canvasWidth / _blockWidthCount;
        //_blockHeight = _canvasHeight / _blockHeightCount;

        _isChangePreviewLevel = true;
    }

    // Update is called once per frame
    public void Update()
    {
        this.SwitchLevelFile();
        if (_isChangePreviewLevel)
        {
            this.DestoryLevelObjects();
            this.ReadLevelDataByTextFile();
            //this.SetLevelObjectsByTextFileRealPosition();
            //this.SetLevelObjectsByTextFile();
            _isChangePreviewLevel = false;
        }

        if (_gameState.CurrentStateIndex == GameState.Menu)
        {
            this.SetLevelObjectsActive(false);
        }
        else if (_gameState.CurrentStateIndex == GameState.Setting)
        {
            this.SetLevelObjectsActive(true);
        }
        else if (_gameState.CurrentStateIndex == GameState.GameRun)
        {
            this.SetLevelObjectsActive(true);
        }
        else if (_gameState.CurrentStateIndex == GameState.ListProducer)
        {
            this.SetLevelObjectsActive(false);
        }
    }

    public void ReadLevelDataByTextFile()
    {
        string readLineBuffer;

        //讀檔設立物件
        System.IO.StreamReader fileData = new System.IO.StreamReader(TEXT_FILE_NAME, System.Text.Encoding.Default);

        //直到沒讀到資訊
        while ((readLineBuffer = fileData.ReadLine()) != null)
        {
            //給定讀取類型
            string readMode = readLineBuffer;

            //讀取數量跑迴圈
            int amount = Convert.ToInt16(fileData.ReadLine());
            for(int numberIndex = 0; numberIndex < amount; numberIndex++)
            {
                string currentStr = fileData.ReadLine();
                switch (readMode)
                {
                    case "input":
                        {
                            this.ReadInputData(currentStr);
                            break;
                        }
                    case "output":
                        {
                            this.ReadOutputData(currentStr);
                            break;
                        }
                    case "gate":
                        {
                            this.ReadGateData(currentStr);
                            break;
                        }
                }
            }
        }
        fileData.Close();
    }

    //讀取input資訊
    private void ReadInputData(string currentStr)
    {
        string[] currentStrArray = currentStr.Split(',');
        int inputPort = Convert.ToInt32(currentStrArray[0]);
        bool inputTF = (currentStrArray[1] == "True") ? true : false;
        Debug.Log("port = " + inputPort + ", inputTF = " + inputTF);
    }

    //讀取output資訊
    private void ReadOutputData(string currentStr)
    {
        int outputPort = Convert.ToInt32(currentStr);
        Debug.Log("outputport = " + outputPort);
    }

    //讀取邏輯閘資訊
    private void ReadGateData(string currentStr)
    {
        string[] currentStrArray = currentStr.Split('|');
        string[] currentGatePortArray = currentStr.Split(',');
        string[] currentRectAreaArray = currentStr.Split(',');
        Debug.Log("currentGatePortArray = " + currentGatePortArray + ", currentRectAreaArray = " + currentRectAreaArray);
    }

    //設置關卡物件
    public void SetLevelObjectsByTextFileRealPosition()
    {
        string readLineBuffer;

        //讀檔設立物件
        System.IO.StreamReader fileData = new System.IO.StreamReader(TEXT_FILE_NAME, System.Text.Encoding.Default);

        //直到沒讀到資訊
        while ((readLineBuffer = fileData.ReadLine()) != null)
        {
            //給定讀取類型
            string readMode = readLineBuffer;

            //將gameObject給定指定的物件
            //this.SwitchGameObject(kind, ref _productGameObject);

            //讀取數量跑迴圈
            int amount = Convert.ToInt16(fileData.ReadLine());

            for (int numberIndex = 0; numberIndex < amount; numberIndex++)
            {
                //區間用的readLine
                fileData.ReadLine();

                //讀取角度及格子座標
                float rotateAngle = Convert.ToSingle(fileData.ReadLine());
                string positionByBlock = fileData.ReadLine();

                //把格子座標eg.1,1存成兩個int
                string[] positionByBlockXY = positionByBlock.Split(',');
                float positionByBlockX = Convert.ToSingle(positionByBlockXY[0]);
                float positionByBlockY = Convert.ToSingle(positionByBlockXY[1]);

                //給定格子座標
                Point objectPoint = new Point((double)positionByBlockX, (double)positionByBlockY);


                //根據給定的物件來創建關卡物件
                GameObject cloneObject = (GameObject)Instantiate(_productGameObject,
                    new Vector3(Convert.ToSingle(objectPoint.x), Convert.ToSingle(objectPoint.y), Convert.ToSingle(this.transform.position.z)),
                    new Quaternion(0, 0, 0, 1)
                    );

                cloneObject.transform.localScale = _productGameObject.transform.localScale;
                cloneObject.transform.eulerAngles = _productGameObject.transform.eulerAngles;
                cloneObject.transform.Rotate(Vector3.forward * rotateAngle, Space.World);
                cloneObject.transform.SetParent(this.transform.FindChild("InLevelObjects"));

                cloneObject.SetActive(true);

                //轉換物件間區格用的readLine
                if (numberIndex == amount - 1) fileData.ReadLine();
            }
        }
        fileData.Close();
    }

    //清除關卡物件
    public void DestoryLevelObjects()
    {
        for (int destoryIndex = 0; destoryIndex < this.transform.FindChild("InLevelObjects").childCount; destoryIndex++)
        {
            Destroy(this.transform.FindChild("InLevelObjects").GetChild(destoryIndex).gameObject);
        }
    }

    //設定關卡物件顯示與否
    public void SetLevelObjectsActive(bool value)
    {
        for (int activeIndex = 0; activeIndex < this.transform.FindChild("InLevelObjects").childCount; activeIndex++)
        {
            this.transform.FindChild("InLevelObjects").GetChild(activeIndex).gameObject.SetActive(value);
        }
    }

    //轉換框格點座標到畫布點座標
    //public Point TransBlockToCanvasPosition(Point position)
    //{
    //    Point canvasPosition;

    //    //將座標給到指定格數的左上角
    //    canvasPosition = new Point((double)_originPointX + (position.x * _blockWidth), (double)_originPointY - (position.y * _blockHeight));

    //    //將座標寬高各進行半個格子的位移，使物件在格子中心
    //    canvasPosition = new Point(canvasPosition.x + (double)_blockWidth * HalfRate, canvasPosition.y - (double)_blockHeight * HalfRate);

    //    return canvasPosition;
    //}

    //依據選的關卡更變讀取的文件
    public void SwitchLevelFile()
    {
        switch (_gameLevel.CurrentLevelIndex)
        {
            case 0:
                {
                    TEXT_FILE_NAME = LogicGateLevelFile.LEVEL_1;
                    break;
                }
            case 1:
                {
                    TEXT_FILE_NAME = LogicGateLevelFile.LEVEL_2;
                    break;
                }
            case 2:
                {
                    TEXT_FILE_NAME = LogicGateLevelFile.LEVEL_3;
                    break;
                }
            case 3:
                {
                    //TEXT_FILE_NAME = LogicGateLevelFile.LEVEL_FIGHT;
                    break;
                }
            case 4:
                {
                    TEXT_FILE_NAME = LogicGateLevelFile.LEVEL_EDITOR;
                    break;
                }
            default:
                break;
        }
    }

    //改變預覽關卡
    public void ChangePreviewLevel()
    {
        _isChangePreviewLevel = true;
    }
}

