using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OpenCVForUnity;

public class ColorSaveData : MonoBehaviour {
    public List<BaseObject> _baseObjectList;
    private const string ENTER = "\r\n";

    public void SaveColorData(List<BaseObject> matchDataBaseObjectList)
    {
        string saveDataString = "";
        for (int index = 0; index < matchDataBaseObjectList.Count; index++)
        {
            double[] scalar = new double[3];
            //取得ID
            saveDataString += matchDataBaseObjectList[index].getId();
            saveDataString += ENTER;
            //取得RGB
            scalar = matchDataBaseObjectList[index].getColor().val;
            //存入RGB
            saveDataString += scalar[0].ToString();
            saveDataString += ENTER;
            saveDataString += scalar[1].ToString();
            saveDataString += ENTER;
            saveDataString += scalar[2].ToString();
            saveDataString += ENTER;
        }
        System.IO.File.WriteAllText("ObjectColor.txt", saveDataString, Encoding.Unicode);
    }

    public List<BaseObject> ReadColorData()
    {
        List<BaseObject> baseObjectList = new List<BaseObject>();
        string readLineBuffer;

        //讀檔設立物件
        System.IO.StreamReader fileData = new System.IO.StreamReader("ObjectColor.txt", System.Text.Encoding.Default);
        while ((readLineBuffer = fileData.ReadLine()) != null)
        {
            int id = int.Parse(readLineBuffer);
            Scalar color = new Scalar(
                double.Parse(fileData.ReadLine()),
                double.Parse(fileData.ReadLine()),
                double.Parse(fileData.ReadLine()));
            baseObjectList.Add(new BaseObject(id,color));
            Debug.Log("Id = " + id);
            Debug.Log("Color = " + color);
        }
        return baseObjectList;
    }
}
