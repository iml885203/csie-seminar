using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using System;

static class GameLevelFile
{
    public const string LEVEL_1 = "objectDataLevel1.txt";
    public const string LEVEL_2 = "objectDataLevel2.txt";
    public const string LEVEL_3 = "objectDataLevel3.txt";
    public const string LEVEL_4 = "objectDataLevel4.txt";
    public const string LEVEL_5 = "objectDataLevel5.txt";
}

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

public class LevelObject : MonoBehaviour
{
    private const string TEXT_FILE_NAME = GameLevelFile.LEVEL_1;

    private GameObject _productGameObject;

    public GameObject _laserGenerator;
    public GameObject _reflectionObject;
    public GameObject _refractionObject;
    public GameObject _blackHoleObject;
    public GameObject _targetObject;
    public GameObject _laserBall;

    public GameObject _canvas;

    private float _canvasWidth;
    private float _canvasHeight;

    private float _blockWidth;
    private float _blockHeight;
    private const float HalfRate = (float).5;

    private int _blockWidthCount;
    private int _blockHeightCount;

    public GHSMapData _mapData;

    private float _originPointX;
    private float _originPointY;

    // Use this for initialization
    void Start()
    {
        //格數
        _blockWidthCount = _mapData.ScreenWidthBlock;
        _blockHeightCount = _mapData.ScreenHeightBlock;

        //畫布寬高
        _canvasWidth = _canvas.GetComponent<RectTransform>().rect.width;
        _canvasHeight = _canvas.GetComponent<RectTransform>().rect.height;

        //原點座標
        _originPointX = _canvas.transform.localPosition.x - (_canvasWidth / 2);
        _originPointY = _canvas.transform.localPosition.y + (_canvasHeight / 2);

        //框格寬度
        _blockWidth = _canvasWidth / _blockWidthCount;
        _blockHeight = _canvasHeight / _blockHeightCount;

        string readLineBuffer;

        //讀檔設立物件
        System.IO.StreamReader fileData = new System.IO.StreamReader(TEXT_FILE_NAME, System.Text.Encoding.Default);

        //直到沒讀到資訊
        while((readLineBuffer = fileData.ReadLine()) != null)
        {
            //給定物件種類字串
            string kind = readLineBuffer;

            //將gameObject給定指定的物件
            _productGameObject = new GameObject();
            this.SwitchGameObject(kind, ref _productGameObject);

            //讀取數量跑迴圈
            int amount = Convert.ToInt16(fileData.ReadLine());
            for(int numberIndex = 0; numberIndex < amount; numberIndex++)
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
                cloneObject.transform.localRotation = _productGameObject.transform.localRotation;
                cloneObject.transform.Rotate(Vector3.forward * rotateAngle, Space.World);
                cloneObject.transform.SetParent(this.transform.FindChild("InLevelObjects"));

                //轉換物件間區格用的readLine
                if(numberIndex == amount - 1) fileData.ReadLine();
            }
        }
        fileData.Close();
    }

    // Update is called once per frame
    void Update()
    {

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

    //將欲產生物件給到productGameObject上
    private void SwitchGameObject(string gameObjectName, ref GameObject productGameObject)
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
            case "雷射球":
                {
                    productGameObject = _laserBall;
                    break;
                }
            default:
                break;
        }
    }
}

