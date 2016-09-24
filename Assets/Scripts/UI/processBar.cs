using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class processBar : MonoBehaviour {

    private Transform _process;
    private float textPer = 0f;
    
	// Use this for initialization
	void Start () {
        _process = this.transform.GetChild(0);
    }
	
	// Update is called once per frame
	void Update () {
        //測試用
        //if (Input.GetKeyUp(KeyCode.N))
        //{
        //    textPer += 10f;
        //    if (textPer > 100f)
        //    {
        //        textPer = 0f;
        //    }
        //    this.setProcessPer(textPer);
        //}
	}

    public void setProcessPer(float per)//輸入百分比
    {
        _process.GetComponent<Image>().fillAmount = per / 100;
    }
}
