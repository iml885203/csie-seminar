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
    public float _speed = 1f;
    private GameStateIndex _gmaeStatusManager;

    void Start()
    {
        _gmaeStatusManager = transform.root.Find("/GameState").GetComponent<GameStateIndex>();
    }

    void Update()
    { 
        if(_gmaeStatusManager.CurrentStateIndex != GameState.GameRun)
        {
            return;
        }
        if (superGameObject.transform.childCount < _DataMatch._matchObjectList.Count && _drawBlock._ScreenSettingCompletionFlag)
        {
            //確認已開啟攝影機
            if (_drawBlock.MatchHeight == 0 && _drawBlock.MatchWidth == 0) return;
            // ==========================
            // set public Width Height ==
            // ==========================
            _Width = _drawBlock.MatchWidth;
            _Height = _drawBlock.MatchHeight;
            MatchObject matchObject = _DataMatch._matchObjectList[superGameObject.transform.childCount];
            CreateObject(matchObject);

        }
        else if(superGameObject.transform.childCount > _DataMatch._matchObjectList.Count)
        {
            DeleteObject();
        }
        else
        {
            for (int i = superGameObject.transform.childCount-1; i >=0 ; i--)
            {
                MatchObject matchObject = _DataMatch._matchObjectList[i];
                UpdatePos(superGameObject.transform.GetChild(i).gameObject, .05f, matchObject);
            }
        }
    }
    public void UpdatePos(GameObject Object,float speed, MatchObject matchObject)
    {
        RectTransform childGameObjectRect = Object.GetComponent<RectTransform>();
        //轉換對應座標並更新值
        Point transPos = _posTrans.TransToScreen2Pos(new Point(matchObject._pos.x, matchObject._pos.y));
        childGameObjectRect.anchoredPosition = Vector3.Lerp(childGameObjectRect.anchoredPosition, new Vector2((float)transPos.x, (float)transPos.y), speed);
        childGameObjectRect.localPosition = new Vector3(childGameObjectRect.localPosition.x, childGameObjectRect.localPosition.y, 0);
        //轉換對應大小並更新值
        Point transScale = _posTrans.TransToScreen2Pos(new Point(matchObject._scale.x, matchObject._scale.y));
        childGameObject.transform.localScale = Vector3.Lerp(childGameObject.transform.localScale, new Vector3((float)transScale.x, (float)transScale.y, 50), speed);
        //更新旋轉角度
        Object.transform.eulerAngles = new Vector3(0, 0, (float)((matchObject._rotation + .5f) * 180));
        return;
    }
    public void CreateObject(MatchObject matchObject)
    {
        childGameObject = Instantiate(copyGameObject);//複製copyGameObject物件(連同該物件身上的腳本一起複製)
        childGameObject.transform.SetParent(superGameObject.transform);//放到superGameObject物件內
        RectTransform childGameObjectRect = childGameObject.GetComponent<RectTransform>();

        //座標系統統一(左下0,0)
        childGameObjectRect.anchorMin = new Vector2(0, 0);
        childGameObjectRect.anchorMax = new Vector2(0, 0);
        childGameObjectRect.pivot = new Vector2(.5f, .5f);
        //初始化轉換座標class
        RectTransform superGameObjectRect = superGameObject.GetComponent<RectTransform>();
        _posTrans = new clickPositionTrans(_drawBlock.MatchWidth, _drawBlock.MatchHeight, superGameObjectRect.rect.width, superGameObjectRect.rect.height);
        //初始化位置
        UpdatePos(childGameObject, _speed, matchObject);
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