using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using System;

public class LevelObject : MonoBehaviour
{
    private const string TEXT_FILE_NAME = "objectData.txt";

    public GameObject productGameObject;

    public GameObject _laserGenerator;
    public GameObject _reflectionObject;
    public GameObject _refractionObject;
    public GameObject _windObject;
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


        //讀檔設立物件
        System.IO.StreamReader fileData = new System.IO.StreamReader(TEXT_FILE_NAME, System.Text.Encoding.Default);

        for(int testIndex = 0; testIndex < 3; testIndex++)
        {
            int kindAndNumber = Convert.ToInt16(fileData.ReadLine());

            int kindIndex = (kindAndNumber & 224) / 32;
            //Debug.Log("kindIndex = " + kindIndex);

            productGameObject = new GameObject();
            this.SwitchGameObject(kindIndex, ref productGameObject);

            int numberIndex = kindAndNumber & 15;
            //Debug.Log("numberIndex = " + numberIndex);
            for (int index = 0; index < numberIndex; index++)
            {
                int dir = Convert.ToInt16(fileData.ReadLine());
                int position = Convert.ToInt16(fileData.ReadLine());

                float realDirection = this.TransferDirection(dir);
                //Debug.Log("realDirection = " + realDirection);

                int widthBlock = (position & 240) / 16;
                int heightBlock = (position & 15);
                Debug.Log("widthBlock = " + widthBlock);
                Debug.Log("heightBlock = " + heightBlock);

                //Debug.Log("productGameObject.name = " + productGameObject);
                Point objectPoint = new Point((double)widthBlock, (double)heightBlock);

                objectPoint = this.TransBlockToCanvasPosition(objectPoint);
                Debug.Log("objectPoint = " + objectPoint);

                GameObject cloneObject = (GameObject)Instantiate(productGameObject,
                    new Vector3(Convert.ToSingle(objectPoint.x), Convert.ToSingle(objectPoint.y), Convert.ToSingle(0)),
                    new Quaternion(0, 0, 0, 1)
                    );
                cloneObject.transform.localScale = productGameObject.transform.localScale;
                cloneObject.transform.localRotation = productGameObject.transform.localRotation;
                cloneObject.transform.Rotate(Vector3.forward * realDirection, Space.World);
                cloneObject.transform.SetParent(this.transform);
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

        canvasPosition = new Point((double)_originPointX + (position.x * _blockWidth), (double)_originPointY - (position.y * _blockHeight));
        Debug.Log("canvasPosition = " + canvasPosition);

        canvasPosition = new Point(canvasPosition.x + (double)_blockWidth * HalfRate, canvasPosition.y - (double)_blockHeight * HalfRate);
        Debug.Log("canvasPosition = " + canvasPosition);

        return canvasPosition;
    }

    //轉換八方位的角度
    private float TransferDirection(int dir)
    {
        return (dir & 7) * (float)45.0;
    }

    //將欲產生物件給到productGameObject上
    private void SwitchGameObject(int gameObjectNumber, ref GameObject productGameObject)
    {
        switch (gameObjectNumber)
        {
            case 0:
                {
                    productGameObject = _laserGenerator;
                    break;
                }
            case 1:
                {
                    Debug.Log("gameObject = reflectionObject");
                    productGameObject = _reflectionObject;
                    break;
                }
            case 2:
                {
                    productGameObject = _refractionObject;
                    break;
                }
            case 3:
                {
                    productGameObject = _windObject;
                    break;
                }
            case 4:
                {
                    productGameObject = _targetObject;
                    break;
                }
            case 5:
                {
                    productGameObject = _laserBall;
                    break;
                }
            default:
                break;
        }
    }
}

