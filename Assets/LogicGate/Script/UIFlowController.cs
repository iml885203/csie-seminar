using UnityEngine;
using System.Collections;

public class UIFlowController : MonoBehaviour {

    public GameStatus GameStatus;

    // Use this for initialization
    void Start () {
	    if(!validateObject())
        {
            return;
        }
        Debug.Log(GameStatus.CurrentStatus);
        showStatusUIOnly(GameStatus.CurrentStatus);
	}

    private bool validateObject()
    {
        if (GameStatus == null)
        {
            Debug.Log("缺少GameStatus");
            return false;
        }

        return true;
    }

    public void backPrevStatus()
    {
        showStatusUIOnly(GameStatus.PrevStatus);
    }
	
	public void showStatusUIOnly(string status)
    {
        if (!validateObject())
        {
            return;
        }

        Transform childUIGroup = transform.Find(status);
        if(childUIGroup == null)
        {
            Debug.Log("缺少創建" + status + "狀態的UIGroup");
            return;
        }

        if (!GameStatus.setStatus(status))
        {
            return;
        }

        hideStatusUIAll();

        childUIGroup.gameObject.SetActive(true);

    }

    private void hideStatusUIAll()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
