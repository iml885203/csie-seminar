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
            //Debug.Log("_reflectCount = " + _reflectCount + ", nowPosition = " + nowPosition + "."); 
        }
        else if(other.gameObject.tag == "dispersionObject")
        {
            //Vector3 movementCurrentDirection = transform.TransformDirection(1, 1, 0);
            //Vector3 reflectionDirection = Vector3.Reflect(movementCurrentDirection, nowPosition);

            //Vector3 randomReflectDirection = Quaternion.Euler(0, 0, Random.Range(-80, 80)) * reflectionDirection;
            //movementCurrentDirection = randomReflectDirection;
            //Debug.Log("movementCurrentDirection = " + movementCurrentDirection);

            Rigidbody myRigidbody = GetComponent<Rigidbody>();
            Vector3 test = new Vector3(19, 6, 0);
            Debug.Log("myRigidbody.velocity = " + myRigidbody.velocity);
            myRigidbody.velocity = test;
            //Vector3 velocity = myRigidbody.velocity;
            //myRigidbody.velocity = Vector3.zero;
            //StartCoroutine(Example());
            //myRigidbody.velocity = velocity;

            //Debug.Log("before = " + this.gameObject.transform.rotation);
            //GameObject cloneBall = (GameObject)Instantiate(this.gameObject, this.transform.position, this.transform.rotation);

            //this.gameObject.transform.rotation = Quaternion.AngleAxis(20, Vector3.up);
            //Debug.Log("after = " + this.gameObject.transform.rotation);
            //cloneBall.transform.SetParent(this.transform.parent);
        }
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}
