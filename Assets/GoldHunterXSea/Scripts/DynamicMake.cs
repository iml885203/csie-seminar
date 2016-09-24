using UnityEngine;
using System.Collections;
using OpenCVForUnity;
using UnityEngine.UI;

public class DynamicMake : MonoBehaviour
{
    public GameObject copyGameObject;//要被複製的物件
    public GameObject superGameObject;//要被放置在哪個物件底下
    public Match _DataMatch;
    public DrawBlock _drawBlock;

    private float _Width;
    private float _Height;
    private GameObject  childGameObject;//被複製出來的物件

    private int ObjectCount;
    private clickPositionTrans _posTrans;

    public Slider RotateSlider;

    private void OnGUI()
    {
        
        if (GUILayout.Button("動態產生物件") == true)
        {
            //確認已開啟攝影機
            if (_drawBlock.MatchHeight == 0 && _drawBlock.MatchWidth == 0) return;
            // ==========================
            // set public Width Height ==
            // ==========================
            _Width = _drawBlock.MatchWidth;
            _Height = _drawBlock.MatchHeight;
            // ==========================
            // set public ObjectCount ==
            // ==========================

            childGameObject = Instantiate(copyGameObject);//複製copyGameObject物件(連同該物件身上的腳本一起複製)
            childGameObject.transform.parent = superGameObject.transform;//放到superGameObject物件內
            RectTransform childGameObjectRect = childGameObject.GetComponent<RectTransform>();
            RectTransform superGameObjectRect = superGameObject.GetComponent<RectTransform>();
            //座標系統統一(左下0,0)
            childGameObjectRect.anchorMin = new Vector2(0, 0);
            childGameObjectRect.anchorMax = new Vector2(0, 0);
            childGameObjectRect.pivot = new Vector2(.5f, .5f);
            //座標轉換
            //Debug.Log("轉換座標" + _drawBlock.MatchWidth + "," + _drawBlock.MatchHeight + "  " + superGameObjectRect.rect.width + "," + superGameObjectRect.rect.height);
            _posTrans = new clickPositionTrans(_drawBlock.MatchWidth, _drawBlock.MatchHeight, superGameObjectRect.rect.width, superGameObjectRect.rect.height);
            Point transPos = _posTrans.TransToScreen2Pos(new Point(_DataMatch.GetDepthVector3().x, _DataMatch.GetDepthVector3().y));
            //Debug.Log("轉換:" + transPos);
            childGameObjectRect.anchoredPosition = new Vector2((float)transPos.x, (float)transPos.y);
            childGameObjectRect.localPosition = new Vector3(childGameObjectRect.localPosition.x, childGameObjectRect.localPosition.y, 0);

            Debug.Log("X" + _DataMatch.GetDepthVector3().x + "Y" + _DataMatch.GetDepthVector3().y);
            Point transScale = _posTrans.TransToScreen2Pos(new Point(_DataMatch.GetDepthScale().x, _DataMatch.GetDepthScale().y));
            childGameObject.transform.localScale = new Vector3((float)transScale.x, (float)transScale.y, 50);
            childGameObject.transform.rotation= new Quaternion(0, 0, _DataMatch.GetDepthRotation(),1);

            

            //childGameObject.AddComponent<NullScript>();//動態增加名為"NullScript"的腳本到此物件身上
            //下面這一行的功能為將複製出來的子物件命名為CopyObject

            childGameObject.name = "CopyObject";

        }
        if (superGameObject.transform.GetChildCount() > 0)
        {
            UpdatePos(superGameObject.transform.GetChild(0).gameObject);
            //Debug.Log(_DataMatch.GetDepthVector3());
            //Debug.Log(_DataMatch.GetDepthScale());
            //Debug.Log(_DataMatch.GetDepthRotation());

        }
        if (GUILayout.Button("動態移除物件") == true)
        {
            //Destroy(childGameObject);//刪除複製出來的子物件
            DeleteObject();
        }
    }
    public void UpdatePos(GameObject Object)
    {
        Debug.Log("runrunrun");
        //RectTransform childGameObjectRect = Object.GetComponent<RectTransform>();
        ////Debug.Log("X" + _DataMatch.GetDepthRect().x + "Y" + _DataMatch.GetDepthRect().y);
        //Point transPos = _posTrans.TransToScreen2Pos(new Point(_DataMatch.GetDepthVector3().x, _DataMatch.GetDepthVector3().y));
        ////Debug.Log("轉換:" + transPos);
        //childGameObjectRect.anchoredPosition = new Vector2((float)transPos.x, (float)transPos.y);
        //childGameObjectRect.localPosition = new Vector3(childGameObjectRect.localPosition.x, childGameObjectRect.localPosition.y, 0);

        //Debug.Log("X" + _DataMatch.GetDepthVector3().x + "Y" + _DataMatch.GetDepthVector3().y);
        //Point transScale = _posTrans.TransToScreen2Pos(new Point(_DataMatch.GetDepthScale().x, _DataMatch.GetDepthScale().y));
        //childGameObject.transform.localScale = new Vector3((float)transScale.x, (float)transScale.y, 50);
        //Object.transform.rotation = new Quaternion(0, 0, (float)((_DataMatch.GetDepthRotation() + RotateSlider.value)), 1);
        //RotateSlider.GetComponentInChildren<Text>().text = RotateSlider.value.ToString();
        //Debug.Log(_DataMatch.GetDepthRotation() + ".." + Object.transform.rotation);
        return;
    }
    public void CreateObject()
    {
        //確認已開啟攝影機
        if (_drawBlock.MatchHeight == 0 && _drawBlock.MatchWidth == 0) return;
        // ==========================
        // set public Width Height ==
        // ==========================
        _Width = _drawBlock.MatchWidth;
        _Height = _drawBlock.MatchHeight;
        // ==========================
        // set public ObjectCount ==
        // ==========================
        ObjectCount = _DataMatch.GetObjectCount();

        childGameObject = Instantiate(copyGameObject);//複製copyGameObject物件(連同該物件身上的腳本一起複製)
        childGameObject.transform.parent = superGameObject.transform;//放到superGameObject物件內


        Debug.Log("X" + _DataMatch.GetDepthRect().x + "Y" + _DataMatch.GetDepthRect().y);
        childGameObject.transform.localPosition = new Vector3(_DataMatch.GetDepthVector3().x / _Width * 1024 + 150, _DataMatch.GetDepthVector3().y / _Height * 800 + 25, -5);//複製出來的物件放置的座標為superGameObject物件內的原點
        childGameObject.transform.localScale = new Vector3(_DataMatch.GetDepthScale().x / _Width * 1024, _DataMatch.GetDepthScale().y / _Height * 800, 50);
        childGameObject.transform.rotation = new Quaternion(0, 0, _DataMatch.GetDepthRotation(), 1);
        //childGameObject.AddComponent<NullScript>();//動態增加名為"NullScript"的腳本到此物件身上
        //下面這一行的功能為將複製出來的子物件命名為CopyObject

        childGameObject.name = "CopyObject";
    }
    public void DeleteObject()
    {
        for(int Count=0;Count< superGameObject.transform.childCount; Count++)
        {
            Destroy(superGameObject.transform.GetChild(Count).gameObject);
        }
    }
}