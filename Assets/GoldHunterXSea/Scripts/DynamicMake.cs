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
            
            //座標系統統一(左下0,0)
            childGameObjectRect.anchorMin = new Vector2(0, 0);
            childGameObjectRect.anchorMax = new Vector2(0, 0);
            childGameObjectRect.pivot = new Vector2(.5f, .5f);
            //座標轉換
            //Debug.Log("轉換座標" + _drawBlock.MatchWidth + "," + _drawBlock.MatchHeight + "  " + superGameObjectRect.rect.width + "," + superGameObjectRect.rect.height);
            
            //Point transPos = _posTrans.TransToScreen2Pos(new Point(_DataMatch.GetDepthVector3().x, _DataMatch.GetDepthVector3().y));
            ////Debug.Log("轉換:" + transPos);
            //childGameObjectRect.anchoredPosition = new Vector2((float)transPos.x, (float)transPos.y);
            //childGameObjectRect.localPosition = new Vector3(childGameObjectRect.localPosition.x, childGameObjectRect.localPosition.y, 0);

            UpdatePos(childGameObject,1);
            //childGameObject.AddComponent<NullScript>();//動態增加名為"NullScript"的腳本到此物件身上
            //下面這一行的功能為將複製出來的子物件命名為CopyObject

            childGameObject.name = "CopyObject";

        }
        if (superGameObject.transform.GetChildCount() > 0)
        {
            //Debug.Log(_DataMatch.GetDepthVector3());
            //Debug.Log(_DataMatch.GetDepthScale());
            //Debug.Log(_DataMatch.GetDepthRotation());

            UpdatePos(superGameObject.transform.GetChild(0).gameObject, .05f);
        }
        if (GUILayout.Button("動態移除物件") == true)
        {
            //Destroy(childGameObject);//刪除複製出來的子物件
            DeleteObject();
        }
    }
    public void UpdatePos(GameObject Object,float speed)
    {
        MatchObject matchObject = _DataMatch._matchObjectList[0];

        RectTransform childGameObjectRect = Object.GetComponent<RectTransform>();
        RectTransform superGameObjectRect = superGameObject.GetComponent<RectTransform>();
        _posTrans = new clickPositionTrans(_drawBlock.MatchWidth, _drawBlock.MatchHeight, superGameObjectRect.rect.width, superGameObjectRect.rect.height);
        //Debug.Log("X" + _DataMatch.GetDepthRect().x + "Y" + _DataMatch.GetDepthRect().y);
        Point transPos = _posTrans.TransToScreen2Pos(new Point(matchObject._pos.x, matchObject._pos.y));
        //Debug.Log("轉換:" + transPos);
        childGameObjectRect.anchoredPosition = Vector3.Lerp(childGameObjectRect.anchoredPosition, new Vector2((float)transPos.x, (float)transPos.y), speed);
        childGameObjectRect.localPosition = new Vector3(childGameObjectRect.localPosition.x, childGameObjectRect.localPosition.y, 0);

        Point transScale = _posTrans.TransToScreen2Pos(new Point(matchObject._scale.x, matchObject._scale.y));
        childGameObject.transform.localScale = new Vector3((float)transScale.x, (float)transScale.y, 50);
        Object.transform.rotation = new Quaternion(0, 0, (float)((matchObject._rotation + .5f)), 1);


        //Debug.Log("X" + _DataMatch.GetDepthRect().x + "Y" + _DataMatch.GetDepthRect().y);
        //Vector3 goalPos = new Vector3(matchObject._pos.x / _Width * 1024 + 150, matchObject._pos.y / _Height * 800 + 25, -5);
        //Vector3 goalScale = new Vector3(matchObject._scale.x / _Width * 1024, matchObject._scale.y / _Height * 800, 50);
        //Object.transform.localPosition += (goalPos - Object.transform.localPosition)/ speed;
        //Object.transform.localScale += (goalScale - Object.transform.localScale) / speed;
        //Object.transform.rotation = new Quaternion(0, 0, (float)((matchObject._rotation + 0.5)), 1);
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
        ObjectCount = _DataMatch._matchObjectList.Count;

        childGameObject = Instantiate(copyGameObject);//複製copyGameObject物件(連同該物件身上的腳本一起複製)
        childGameObject.transform.parent = superGameObject.transform;//放到superGameObject物件內

        UpdatePos(childGameObject,50);
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