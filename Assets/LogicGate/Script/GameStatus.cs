using UnityEngine;
using System.Collections;
using UnityEditor;

public class GameStatus : MonoBehaviour {

    public string[] Statuses;
    public string CurrentStatus = "初始化狀態為第一個";
    public int CurrentStateIndex
    {
        get
        {
            return ArrayUtility.IndexOf(Statuses, CurrentStatus);
        }
    }
    public string PrevStatus;
    public int PrevStateIndex
    {
        get
        {
            
            return (PrevStatus != null) ? ArrayUtility.IndexOf(Statuses, PrevStatus) : -1;
        }
    }

    // Use this for initialization
    void Start () {
	    if(Statuses.Length == 0)
        {
            Debug.Log("缺少設定狀態");
            return;
        }

        CurrentStatus = Statuses[0]; //初始化遊戲狀態

    }
	
	public bool setStatus(string status)
    {
        if(ArrayUtility.IndexOf(Statuses, status) == -1)
        {
            Debug.Log("無法設定遊戲狀態為 " + status);
            return false;
        }

        PrevStatus = CurrentStatus;
        CurrentStatus = status;
        return true;
    }

    public bool setStatus(int statusesIndex)
    {
        if (statusesIndex < 0 || statusesIndex > Statuses.Length - 1)
        {
            Debug.Log("無法設定遊戲狀態為第 " + statusesIndex + " 個狀態");
            return false;
        }

        PrevStatus = CurrentStatus;
        CurrentStatus = Statuses[statusesIndex];
        return true;
    }
}
