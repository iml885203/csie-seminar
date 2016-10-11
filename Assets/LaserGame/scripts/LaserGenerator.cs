using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserGenerator : MonoBehaviour {
    public GameObject LaserBall;
    public int BallForce = 2000;
    public float GeneratorBallTime = .1f;

    private float _timer = 0f;
    private List<GameObject> _laserBalls;
    public GameStateIndex _gameStateIndex;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        if (_gameStateIndex._gameStateIndex != 2)
        {
            //遊戲尚未開始 不攻擊
            return;
        }

        _timer += Time.deltaTime;
        if (_timer >= GeneratorBallTime)
        {
            try
            {
                _timer = 0f;
                GameObject clone = (GameObject)Instantiate(LaserBall, this.transform.position, this.transform.rotation);
                clone.transform.SetParent(this.transform);
                clone.transform.localScale = LaserBall.transform.localScale; //給複製的球跟LaserBall一樣大
                foreach (Transform child in transform)
                {
                    if (child.tag == "LaserBall")
                    {
                        Physics.IgnoreCollision(clone.GetComponent<SphereCollider>(), child.GetComponent<SphereCollider>());
                    }
                }
                clone.SetActive(true);
                clone.GetComponent<Rigidbody>().AddForce(transform.right * BallForce);
            }
            catch
            {

            }
            
        }
	}
}
