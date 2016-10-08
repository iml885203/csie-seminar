using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

/// <關卡文字檔格式說明>
/// 雷射槍      <物件名稱>
/// 1           <物件數量>
///              <區隔用>
/// 0            <旋轉角度>
/// 1,5          <擺放格數>
/// 
/// 牆壁
/// 2            <兩個以上時>
///
/// 135
/// 13,5
///
/// 135
/// 13,4
///
/// 目標
/// 1
///
/// 90
/// 13,2
/// </關卡文字檔格式說明>

public class LevelObjectBase : MonoBehaviour
{
    public GameLevelIndex _gameLevel;
    public GameStateIndex _gameState;

    protected string TEXT_FILE_NAME;

    protected GameObject _productGameObject;

    public GameObject _laserGenerator;
    public GameObject _reflectionObject;
    public GameObject _refractionObject;
    public GameObject _blackHoleObject;
    public GameObject _targetObject;
    //public GameObject _laserBall;

    public GameObject _canvas;

    protected float _canvasWidth;
    protected float _canvasHeight;

    protected float _blockWidth;
    protected float _blockHeight;
    protected const float HalfRate = (float).5;

    protected int _blockWidthCount;
    protected int _blockHeightCount;

    //public GHSMapData _mapData;

    protected float _originPointX;
    protected float _originPointY;

    // Use this for initialization
    public void Start()
    {
        //格數
        _blockWidthCount = 16;
        _blockHeightCount = 8;

        //畫布寬高
        _canvasWidth = _canvas.GetComponent<RectTransform>().rect.width;
        _canvasHeight = _canvas.GetComponent<RectTransform>().rect.height;

        //原點座標
        _originPointX = _canvas.transform.localPosition.x - (_canvasWidth / 2);
        _originPointY = _canvas.transform.localPosition.y + (_canvasHeight / 2);
        Debug.Log("_originPointX = " + _originPointX + ",_originPointY = " + _originPointY);

        //框格寬度
        _blockWidth = _canvasWidth / _blockWidthCount;
        _blockHeight = _canvasHeight / _blockHeightCount;
    }

    // Update is called once per frame
    public void Update()
    {
        //this.SwitchLevelFile();

        //if(_stateFlag.text == GameState.Menu.ToString())
        //{
        //    if(this.name == "GameLevelObjects")
        //    {
        //        this.SetLevelObjectsActive(false);
        //    }
        //    if (this.name == "PreviewGameLevel")
        //    {
        //        this.SetLevelObjectsActive(false);
        //    }
        //}
        //else if(_stateFlag.text == GameState.Setting.ToString())
        //{
        //    if (this.name == "GameLevelObjects")
        //    {
        //        this.SetLevelObjectsActive(false);
        //    }
        //    if (this.name == "PreviewGameLevel")
        //    {
        //        this.SetLevelObjectsActive(true);
        //    }
        //}
        //else if (_stateFlag.text == GameState.GameRun.ToString())
        //{
        //    if (this.name == "GameLevelObjects")
        //    {
        //        this.SetLevelObjectsActive(true);
        //    }
        //    if (this.name == "PreviewGameLevel")
        //    {
        //        this.SetLevelObjectsActive(false);
        //    }
        //}
        //else if (_stateFlag.text == GameState.ListProducer.ToString())
        //{
        //    if (this.name == "GameLevelObjects")
        //    {
        //        this.SetLevelObjectsActive(false);
        //    }
        //    if (this.name == "PreviewGameLevel")
        //    {
        //        this.SetLevelObjectsActive(false);
        //    }
        //}
    }

    //設置關卡物件
    virtual public void SetLevelObjectsByTextFile()
    {
        string readLineBuffer;

        //讀檔設立物件
        System.IO.StreamReader fileData = new System.IO.StreamReader(TEXT_FILE_NAME, System.Text.Encoding.Default);

        //直到沒讀到資訊
        while ((readLineBuffer = fileData.ReadLine()) != null)
        {
            //給定物件種類字串
            string kind = readLineBuffer;

            //將gameObject給定指定的物件
            _productGameObject = new GameObject();
            this.SwitchGameObject(kind, ref _productGameObject);

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
                int positionByBlockX = Convert.ToInt16(positionByBlockXY[0]);
                int positionByBlockY = Convert.ToInt16(positionByBlockXY[1]);

                //給定格子座標
                Point objectPoint = new Point((double)positionByBlockX, (double)positionByBlockY);

                //轉換格子座標成畫布實際座標
                objectPoint = this.TransBlockToCanvasPosition(objectPoint);

                //根據給定的物件來創建關卡物件
                GameObject cloneObject = (GameObject)Instantiate(_productGameObject,
                    new Vector3(Convert.ToSingle(objectPoint.x), Convert.ToSingle(objectPoint.y), Convert.ToSingle(0)),
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

    public void SetLevelObjectsActive(bool value)
    {
        for (int activeIndex = 0; activeIndex < this.transform.FindChild("InLevelObjects").childCount; activeIndex++)
        {
            this.transform.FindChild("InLevelObjects").GetChild(activeIndex).gameObject.SetActive(value);
        }
    }

    //轉換框格點座標到畫布點座標
    public Point TransBlockToCanvasPosition(Point position)
    {
        Point canvasPosition;

        //將座標給到指定格數的左上角
        canvasPosition = new Point((double)_originPointX + (position.x * _blockWidth), (double)_originPointY - (position.y * _blockHeight));

        //將座標寬高各進行半個格子的位移，使物件在格子中心
        canvasPosition = new Point(canvasPosition.x + (double)_blockWidth * HalfRate, canvasPosition.y - (double)_blockHeight * HalfRate);

        return canvasPosition;
    }

    //依據選的關卡更變讀取的文件
    public void SwitchLevelFile()
    {
        switch (_gameLevel.CurrentLevelIndex)
        {
            case 0:
                {
                    TEXT_FILE_NAME = GameLevelFile.LEVEL_1;
                    break;
                }
            case 1:
                {
                    TEXT_FILE_NAME = GameLevelFile.LEVEL_2;
                    break;
                }
            case 2:
                {
                    TEXT_FILE_NAME = GameLevelFile.LEVEL_3;
                    break;
                }
            case 3:
                {
                    TEXT_FILE_NAME = GameLevelFile.LEVEL_4;
                    break;
                }
            case 4:
                {
                    TEXT_FILE_NAME = GameLevelFile.LEVEL_5;
                    break;
                }
            default:
                break;
        }
    }

    //將欲產生物件給到productGameObject上
    public void SwitchGameObject(string gameObjectName, ref GameObject productGameObject)
    {
        switch (gameObjectName)
        {
            case "雷射槍":
                {
                    productGameObject = _laserGenerator;
                    break;
                }
            case "牆壁":
                {
                    productGameObject = _reflectionObject;
                    break;
                }
            case "折射":
                {
                    productGameObject = _refractionObject;
                    break;
                }
            case "黑洞":
                {
                    productGameObject = _blackHoleObject;
                    break;
                }
            case "目標":
                {
                    productGameObject = _targetObject;
                    break;
                }
            //case "雷射球":
            //    {
            //        productGameObject = _laserBall;
            //        break;
            //    }
            default:
                break;
        }
    }
}

