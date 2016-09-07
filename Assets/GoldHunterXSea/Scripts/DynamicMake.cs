using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class DynamicMake : MonoBehaviour
{
    public GameObject copyGameObject;//要被複製的物件
    public GameObject superGameObject;//要被放置在哪個物件底下
    public Match DataMatch;
    public DrawBlock _drawBlock;

    private float Width;
    private float Height;
    private GameObject childGameObject;//被複製出來的物件
    private void OnGUI()
    {
        
        if (GUILayout.Button("動態產生物件") == true)
        {
            //確認已開啟攝影機
            if (_drawBlock.MatchHeight == 0 && _drawBlock.MatchWidth == 0) return;
            // ==========================
            // set public Width Height ==
            // ==========================
            Width = _drawBlock.MatchWidth;
            Height = _drawBlock.MatchHeight;

            childGameObject = Instantiate(copyGameObject);//複製copyGameObject物件(連同該物件身上的腳本一起複製)
            childGameObject.transform.parent = superGameObject.transform;//放到superGameObject物件內



            Debug.Log("X" + DataMatch.GetDepthRect().x + "Y" + DataMatch.GetDepthRect().y);
            childGameObject.transform.localPosition = new  Vector3(DataMatch.GetDepthVector3().x/ Width * 1024  + 150, DataMatch.GetDepthVector3().y/ Height * 800   + 25, -5);//複製出來的物件放置的座標為superGameObject物件內的原點
            childGameObject.transform.localScale = new Vector3(DataMatch.GetDepthScale().x / Width * 1024, DataMatch.GetDepthScale().y / Height * 800, 50);
            childGameObject.transform.rotation= new Quaternion(0, 0, DataMatch.GetDepthRotation(),1);
            //childGameObject.AddComponent<NullScript>();//動態增加名為"NullScript"的腳本到此物件身上
            //下面這一行的功能為將複製出來的子物件命名為CopyObject

            childGameObject.name = "CopyObject";



            //產生一個Object的物件，並指定子物件上要被刪除的腳本
            Object script = childGameObject.GetComponent<DeleteScript>();
            Destroy(script);//刪除腳本
        }
        if (GUILayout.Button("動態移除物件") == true)
        {
            Destroy(childGameObject);//刪除複製出來的子物件
        }
    }
}