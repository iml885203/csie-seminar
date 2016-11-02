using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoodsOpenControl : MonoBehaviour {
    public DrawBlock _drawBlockManager;
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
    void Awake () {
        _processBar = this.GetComponent<processBar>();
        _gmaeStatusManager = transform.root.Find("/GameState").GetComponent<GameStateIndex>();
        _kinectSettingView = transform.root.Find("/UICanvas/InfoView/view-KinectSetting").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_drawBlockManager.MatchHeight == 0 || _drawBlockManager.MatchWidth == 0)
        {
            _posTrans = null;//初始化
            return;
        }
        if (_kinectSettingView.active)
        {
            return;
        }
        if (_posTrans == null)
        {
            RectTransform parentRect = this.transform.parent as RectTransform;
            _posTrans = new clickPositionTrans(_drawBlockManager.MatchWidth, _drawBlockManager.MatchHeight, parentRect.rect.width, parentRect.rect.height);
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
        if (pos.x > _drawBlockManager._minX && pos.x < _drawBlockManager._maxX &&
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
