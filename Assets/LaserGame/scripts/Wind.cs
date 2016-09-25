using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour
{
    private float _radius;
    private Vector3 _force;
    public GameObject ball;

    void Start()
    {
        
        _radius = 1;
        _force = new Vector3(0, -10, 0);
    }

    void Update()
    {
        //Debug.Log("transform.parent = " + transform.parent.parent.ToString());
        try
        {
            ball = transform.parent.parent.FindChild("LaserGenerator").FindChild("laserBall(Clone)").gameObject;
        }
        catch
        {
          //  Debug.Log("Ball not exist");
        }
    }

    public float GetWindRadius()
    {
        return _radius;
    }

    public Vector3 GetWindForce()
    {
        return _force;
    }

}
