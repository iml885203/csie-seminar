using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine.UI;
using System;

public class LevelPreview : LevelObjectBase
{
    private bool _isChangePreviewLevel;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        _isChangePreviewLevel = true;
    }

    // Update is called once per frame
    new void Update()
    {
        this.SwitchLevelFile();
        if (_isChangePreviewLevel)
        {
            this.DestoryLevelObjects();
            this.SetLevelObjectsByTextFile();
            _isChangePreviewLevel = false;
        }

        if (_stateFlag.text == GameState.Menu.ToString())
        {
            this.SetLevelObjectsActive(false);
        }
        else if (_stateFlag.text == GameState.Setting.ToString())
        {
            this.SetLevelObjectsActive(true);
        }
        else if (_stateFlag.text == GameState.GameRun.ToString())
        {
            this.SetLevelObjectsActive(false);
        }
        else if (_stateFlag.text == GameState.ListProducer.ToString())
        {
            this.SetLevelObjectsActive(false);
        }
    }

    //設置關卡物件
    override public void SetLevelObjectsByTextFile()
    {
        string readLineBuffer;
        float halfRate = (float).5;

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

                cloneObject.transform.localScale = _productGameObject.transform.localScale * halfRate;
                cloneObject.transform.localRotation = _productGameObject.transform.localRotation;
                cloneObject.transform.Rotate(Vector3.forward * rotateAngle, Space.World);
                cloneObject.transform.SetParent(this.transform.FindChild("InLevelObjects"));
                cloneObject.SetActive(true);

                //轉換物件間區格用的readLine
                if (numberIndex == amount - 1) fileData.ReadLine();
            }
        }
        fileData.Close();
    }
    
    //改變預覽關卡
    private void ChangePreviewLevel()
    {
        _isChangePreviewLevel = true;
    }
}

