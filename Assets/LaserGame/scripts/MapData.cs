using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class MapData : MonoBehaviour
{
    //private List<Vector3> _ballPosition;
    public GameObject _reflectionObject;
    public GameObject _refractionObject;
    public GameObject _windObject;
    public GameObject _targetObject;
    public GameObject _laserBall;

    //private List<>

    void Start()
    {
        System.IO.StreamReader fileData = new System.IO.StreamReader("objectData.txt", System.Text.Encoding.Default);

        GameObject productGameObject = new GameObject();
        for(int kindIndex = 0; kindIndex < 4; kindIndex++)
        {
            SwitchGameObject(fileData.ReadLine(), ref productGameObject);
            int indexCount = Convert.ToInt16(fileData.ReadLine());
            fileData.ReadLine();
            for (int index = 0; index < indexCount; index++)
            {
                GameObject cloneObject = (GameObject)Instantiate(productGameObject,
                    this.transform.position + new Vector3(Convert.ToSingle(fileData.ReadLine()), Convert.ToSingle(fileData.ReadLine()), Convert.ToSingle(fileData.ReadLine())),
                    new Quaternion(Convert.ToSingle(fileData.ReadLine()), Convert.ToSingle(fileData.ReadLine()), Convert.ToSingle(fileData.ReadLine()), 0),
                    this.transform);
                fileData.ReadLine();
            }
        }
        //int index = 0;
        //int mealListCount = Convert.ToInt32(fileData.ReadLine());
        //for (index = 0; index < mealListCount; index++)//菜單讀檔
        //{
            //fileData.ReadLine();
            //GameObject clone = (GameObject)Instantiate(_reflectionObject, 
            //    this.transform.position + new Vector3(Convert.ToSingle(fileData.ReadLine()) , Convert.ToSingle(fileData.ReadLine()), Convert.ToSingle(fileData.ReadLine())),
            //    new Quaternion(Convert.ToSingle(fileData.ReadLine()), Convert.ToSingle(fileData.ReadLine()), Convert.ToSingle(fileData.ReadLine()), 0), 
            //    this.transform);
        //}
        fileData.Close();

        //GameObject clone = (GameObject)Instantiate(ReflectionObjects, this.transform.position, this.transform.rotation, this.transform);

    }

    void Update()
    {

    }

    private void SwitchGameObject(string gameObjectName,ref GameObject gameObject)
    {
        switch (gameObjectName)
        {
            case "reflectionObject":
                {
                    Debug.Log("gameObject = " + "reflectionObject");
                    gameObject = _reflectionObject;
                    break;
                }
            case "refractionObject":
                {
                    gameObject = _refractionObject;
                    break;
                }
            case "windObject":
                {
                    gameObject = _windObject;
                    break;
                }
            case "targetObject":
                {
                    gameObject = _targetObject;
                    break;
                }
            case "laserBall":
                {
                    gameObject = _laserBall;
                    break;
                }
            default:
                break;
        }
    }
}
