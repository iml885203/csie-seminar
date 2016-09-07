using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserGenerator : MonoBehaviour {
    public GameObject LaserBall;
    public GameObject LaserLine;
    public int BallForce = 2000;
    public float GeneratorBallTime = .1f;

    private float _timer = 0f;
    private List<GameObject> _laserBalls;
    private List<GameObject> _laserLines;
    
	// Use this for initialization
	void Start () {
        _laserLines = new List<GameObject>();
        LineRenderer laserLineRenderer = LaserLine.GetComponentInChildren<LineRenderer>();
        //init laser pos
        laserLineRenderer.SetWidth(.2f, .2f);
        laserLineRenderer.SetPosition(0, transform.position);
        laserLineRenderer.SetPosition(1, transform.position);
        GameObject cloneLaserLine = (GameObject)Instantiate(LaserLine, this.transform.position, this.transform.rotation);
        cloneLaserLine.transform.parent = this.transform;
        _laserLines.Add(cloneLaserLine);
    }

    // Update is called once per frame
    void Update () {
        _timer += Time.deltaTime;
        if (_timer >= GeneratorBallTime)
        {
            _timer = 0f;
            GameObject clone = (GameObject)Instantiate(LaserBall, this.transform.position, this.transform.rotation);
            clone.transform.parent = this.transform;
            foreach (Transform child in transform)
            {
                if (child.tag == "laserBall")
                {
                    Physics.IgnoreCollision(clone.GetComponent<SphereCollider>(), child.GetComponent<SphereCollider>());
                }
            }
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * BallForce);
        }
	}

    //設定laserLineByIndes
    public void SetLaserLinesPos(int index, int StartOrEndIndex, Vector3 pos)
    {
        //第index個沒有就增加一個laserLine
        while (true)
        {
            if (_laserLines.Count <= index)
            {
                GameObject cloneLaserLine = (GameObject)Instantiate(LaserLine, this.transform.position, this.transform.rotation);
                cloneLaserLine.transform.parent = this.transform;
                if (StartOrEndIndex == 0) //初始化start和end座標一致避免線亂跑
                    cloneLaserLine.GetComponent<LineRenderer>().SetPosition(1, pos);
                _laserLines.Add(cloneLaserLine);
                continue;
                
            }
            break;
        }
        //設定第index個的position
        _laserLines[index].GetComponent<LineRenderer>().SetPosition(StartOrEndIndex, pos);
    }

    //隱藏無用的laserLine
    public void HideNotUseLaser(int lastIndex)
    {
        if(_laserLines.Count - 1 > lastIndex)
        {
            for(int i = lastIndex + 1; i < _laserLines.Count; i++)
            {
                _laserLines[i].GetComponent<LineRenderer>().SetPositions(new Vector3[] { transform.position, transform.position});
            }
        }
    }
}
