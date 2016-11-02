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
            double[] scalarHsv = new double[3];
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
            //取得HSV
            scalarHsv = matchDataBaseObjectList[index].getColorHsv().val;
            //存入HSV
            saveDataString += scalarHsv[0].ToString();
            saveDataString += ENTER;
            saveDataString += scalarHsv[1].ToString();
            saveDataString += ENTER;
            saveDataString += scalarHsv[2].ToString();
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
            int id = 0;
            Scalar color = new Scalar(0, 0, 0);
            Scalar colorHsv = new Scalar(0, 0, 0);
            try
            {
                id = int.Parse(readLineBuffer);
                color = new Scalar(
                    double.Parse(fileData.ReadLine()),
                    double.Parse(fileData.ReadLine()),
                    double.Parse(fileData.ReadLine()));
                colorHsv = new Scalar(
                    double.Parse(fileData.ReadLine()),
                    double.Parse(fileData.ReadLine()),
                    double.Parse(fileData.ReadLine()));
            }
            catch
            {
                Debug.Log("ColorText.txt沒有顏色資料");
            }
            baseObjectList.Add(new BaseObject(id, color, colorHsv));
            Debug.Log("Id = " + id);
            Debug.Log("Color = " + color);
            Debug.Log("ColorHSV = " + colorHsv);
        }
        return baseObjectList;
    }
}
