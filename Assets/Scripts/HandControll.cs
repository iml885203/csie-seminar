using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class HandControll : MonoBehaviour {
    public GameObject BodySrcManager;
    public DrawBlock _drawBlockManager;
    public JointType TrackedJoint;
    private ButtonEvent _buttonEvent;
    private BodySourceManager _bodyManager;
    private Body[] bodies;

    public float multiplier;
    public float _ErrorRange;

    private float _clickTimer = 0f;
    public float _clickTriggerTime = 1f;

    private processBar _processBar;

    private clickPositionTrans _posTrans;
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
        _buttonEvent = this.GetComponentInParent<ButtonEvent>();
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
        if (!_drawBlockManager.SelectedBlock)
        {
            return;
        }
        if(_posTrans == null)
        {
            RectTransform parentRect = this.transform.parent as RectTransform;
            _posTrans = new clickPositionTrans(_drawBlockManager.MatchWidth, _drawBlockManager.MatchHeight, parentRect.rect.width, parentRect.rect.height);
        }
        foreach(var body in bodies)
        {
            if(body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                var pos = body.Joints[TrackedJoint].Position;
                //3D座標透過map轉換成2D座標
                Vector2 colorPos = _drawBlockManager._map.CameraSpacePointToColorVector2(pos);
                Vector2 pos_inDrawBlock = GetInDrawBlockPos(colorPos);
                RectTransform myRect = this.transform as RectTransform;
                myRect.anchoredPosition = _posTrans.TransToScreen2Pos(new Vector2(pos_inDrawBlock.x, -pos_inDrawBlock.y));
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "UI_Test") //碰撞到牆壁
        {
            //累積移動時間大於_movedTriggerTime,就移動玩家座標
            if (_clickTimer > _clickTriggerTime)
            {
                //觸發點擊UI
                _buttonEvent.CallFuncByString(other.transform.parent.name + "Click");
                _processBar.setProcessPer(0);
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
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "UI_Test")
        {
            _clickTimer = 0f;
            _processBar.setProcessPer(0f);
        }
    }

    private Vector2 GetInDrawBlockPos(Vector2 pos)
    {
        //判斷是否在選取畫面內
        if(pos.x > _drawBlockManager._minX && pos.x < _drawBlockManager._maxX &&
           pos.y > _drawBlockManager._minY && pos.y < _drawBlockManager._maxY)
        {
            //回傳畫面內座標
            return new Vector2(pos.x - _drawBlockManager._minX, pos.y - _drawBlockManager._minY);
        }
        else
        {
            return new Vector2(-99, -99);
        }
    }
}
