using UnityEngine;
using System.Collections;

public class LaserBall : MonoBehaviour {
    private LaserGenerator _generator;
    private int _reflectCount;
	// Use this for initialization
	void Start () {
        _generator = gameObject.GetComponentInParent<LaserGenerator>();
        _reflectCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.contacts[0];
        Vector3 nowPosition = contact.point;
        if (other.gameObject.tag == "wall") //碰撞到牆壁
        {
            _generator.SetLaserLinesPos(_reflectCount, 1, nowPosition);
            _generator.HideNotUseLaser(_reflectCount);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "reflectionObject") //碰撞反射物體
        {
            _reflectCount++;
            _generator.SetLaserLinesPos(_reflectCount - 1, 1, nowPosition);
            _generator.SetLaserLinesPos(_reflectCount, 0, nowPosition);
        }
    }
}
