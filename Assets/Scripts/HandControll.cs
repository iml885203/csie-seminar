using UnityEngine;
using System.Collections;
using Windows.Kinect;
using UnityEngine.UI;

public class HandControll : MonoBehaviour {
    public GameObject BodySrcManager;
    public DrawBlock _drawBlockManager;
    public JointType TrackedJoint;
    private BodySourceManager _bodyManager;
    private Body[] bodies;

    private float _clickTimer = 0f;
    public float _clickTriggerTime = 1f;

    private processBar _processBar;
    private bool _isTriggerButton = false;
    private bool _idClicked = false;

    private clickPositionTrans _posTrans;

    public float _speed = 2f;
    private GameObject _handImage;
    private GameStateIndex _gmaeStatusManager;
    private bool _drawblockReset = false;
    private GameObject _kinectSettingView;

    // Use this for initialization
    void Start () {
	    if(BodySrcManager == null)
        {
            Debug.Log("Error");
        }
        else
        {
            _bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }
        _processBar = this.GetComponent<processBar>();
        _handImage = transform.Find("handImage").gameObject;
        _gmaeStatusManager = transform.root.Find("/GameState").GetComponent<GameStateIndex>();
        _kinectSettingView = transform.root.Find("/UICanvas/InfoView/view-KinectSetting").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(_bodyManager == null)
        {
            return;
        }
        bodies = _bodyManager.GetData();
        if(bodies == null)
        {
            return;
        }
        if (_drawBlockManager.MatchHeight == 0 || _drawBlockManager.MatchWidth == 0)
        {
            _posTrans = null;//初始化
            return;
        }
        if(_posTrans == null)
        {
            RectTransform parentRect = this.transform.parent as RectTransform;
            _posTrans = new clickPositionTrans(_drawBlockManager.MatchWidth, _drawBlockManager.MatchHeight, parentRect.rect.width, parentRect.rect.height);
        }
        if (_kinectSettingView.active)
        {
            return;
        }
        //遊戲狀態關閉手的圖案，保留手勢功能
        var gameStatus = _gmaeStatusManager.CurrentStateIndex;
        Color imageColor = _handImage.GetComponent<Image>().color;
        //if (gameStatus == GameState.GameRun && !_isTriggerButton)
        //{
        //    if(imageColor.a == 1f)
        //        _handImage.GetComponent<Image>().color = new Color(imageColor.r, imageColor.g, imageColor.b, .1f);
        //    //if(_handImage.active)
        //    //    _handImage.SetActive(false);
        //}
        //else
        //{
        //    if (imageColor.a == .1f)
        //        _handImage.GetComponent<Image>().color = new Color(imageColor.r, imageColor.g, imageColor.b, 1f);
        //    //if(!_handImage.active)
        //    //    _handImage.SetActive(true);
        //}
        foreach (var body in bodies)
        {
            RectTransform myRect = this.transform as RectTransform;
            if (body == null)
            {
                if (_handImage.active)
                    _handImage.SetActive(false);
                continue;
            }
            if (body.IsTracked)
            {
                var pos = body.Joints[TrackedJoint].Position;
                //3D座標透過map轉換成2D座標
                Vector2 colorPos = _drawBlockManager._map.CameraSpacePointToColorVector2(pos);
                Vector2 pos_inDrawBlock = GetInDrawBlockPos(colorPos);
                
                if(pos_inDrawBlock.x == -99 && pos_inDrawBlock.y == -99)//不在drawblock範圍內
                {
                    myRect.localPosition = new Vector3(myRect.localPosition.x, myRect.localPosition.y, 100);
                    if (_handImage.active)
                        _handImage.SetActive(false);
                }
                else
                {
                    if (!_handImage.active)
                        _handImage.SetActive(true);
                    myRect.anchoredPosition = Vector2.Lerp(myRect.anchoredPosition, _posTrans.TransToScreen2Pos(new Vector2(-pos_inDrawBlock.x, -pos_inDrawBlock.y)), _speed);
                    myRect.localPosition = new Vector3(myRect.localPosition.x, myRect.localPosition.y, 0);
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "UI_Test") //碰撞到牆壁
        {
            _isTriggerButton = true;
            var button = other.transform.parent.GetComponent<Button>();
            if (!button.IsInteractable() || _idClicked)
            {
                return;
            }
            //累積移動時間大於_movedTriggerTime,就移動玩家座標
            if (_clickTimer > _clickTriggerTime)
            {
                _processBar.setProcessPer(0);
                _idClicked = true;
                //觸發點擊UI
                button.onClick.Invoke();
                
            }
            else
            {
                //累積移動時間增加
                _clickTimer += Time.deltaTime;
                _processBar.setProcessPer(_clickTimer / _clickTriggerTime * 100);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "UI_Test")
        {
            _clickTimer = 0f;
            _processBar.setProcessPer(0f);
            _idClicked = false;
            _isTriggerButton = false;
        }
    }

    private Vector2 GetInDrawBlockPos(Vector2 pos)
    {
        //判斷是否在選取畫面內
        if(pos.x > _drawBlockManager._minX && pos.x < _drawBlockManager._maxX &&
           pos.y > _drawBlockManager._revertMinY && pos.y < _drawBlockManager._revertMaxY)
        {
            //回傳畫面內座標
            return new Vector2(pos.x - _drawBlockManager._minX, pos.y - _drawBlockManager._revertMinY);
        }
        else
        {
            return new Vector2(-99, -99);
        }
    }
}
