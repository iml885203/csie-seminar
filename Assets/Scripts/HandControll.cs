using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class HandControll : MonoBehaviour {
    public GameObject BodySrcManager;
    public JointType TrackedJoint;
    private BodySourceManager bodyManager;
    private Body[] bodies;

    private Vector2 _handPos;
    private Vector2 _handPosOld;

    public float multiplier;
    public float _ErrorRange;

    private float _clickTimer = 0f;
    private float _clickTriggerTime = 1f;

    private processBar _processBar;
    // Use this for initialization
    void Start () {
	    if(BodySrcManager == null)
        {
            Debug.Log("Error");
        }
        else
        {
            bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }
        _handPos = new Vector2();
        _handPosOld = new Vector2();
        _processBar = this.GetComponent<processBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bodyManager == null)
        {
            return;
        }
        bodies = bodyManager.GetData();
        if(bodies == null)
        {
            return;
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
                gameObject.transform.position = new Vector3(pos.X * multiplier, pos.Y * multiplier ,89);
                _handPosOld = new Vector2(_handPos.x, _handPos.y);
                _handPos = new Vector3(pos.X * multiplier, pos.Y * multiplier);
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
            }
            else
            {
                //累積移動時間增加
                _clickTimer += Time.deltaTime;
                //gameObject.transform.localScale = new Vector3(_clickTimer * 50 + 50, _clickTimer *50 + 50,  30);
                _processBar.setProcessPer(_clickTimer / _clickTriggerTime * 100);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "UI_Test")
        {
            gameObject.transform.localScale = new Vector3(50, 50, 30);
            _clickTimer = 0f;
            _processBar.setProcessPer(0f);
        }
    }
}
