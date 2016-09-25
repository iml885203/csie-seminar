using UnityEngine;
using System.Collections;

public class LaserBall : MonoBehaviour {
    private LaserGenerator _generator;
    private Rigidbody _ballRigidbody;
    private int _reflectCount;
    private Vector3 _beforeReflectVelocity;

    public WindZone _wind;
    Vector3 _windForce;
    float _windRadius;

    // Use this for initialization
    void Start ()
    {
        _windForce = _wind.GetComponent<Wind>().GetWindForce();
        _windRadius = _wind.GetComponent<Wind>().GetWindRadius();

        //_reflashVelocityFlag = true;
        _ballRigidbody = GetComponent<Rigidbody>();
        _generator = gameObject.GetComponentInParent<LaserGenerator>();
        _reflectCount = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(this.gameObject.transform.position, _wind.transform.position) < _windRadius)
        {
            //Vector3 windForce = new Vector3((this.gameObject.transform.position.x - _wind.transform.position.x),
            //                            (this.gameObject.transform.position.y - _wind.transform.position.y),
            //                            0);

            Vector3 windForce = new Vector3((_wind.transform.position.x - this.gameObject.transform.position.x) * 30000,
                                            (_wind.transform.position.y - this.gameObject.transform.position.y) * 30000,
                                            0);

            //windForce = windForce.normalized;
            Debug.Log("windForce = " + windForce);
            this.GetComponent<ConstantForce>().force = windForce;
        }
        else
        {
            this.GetComponent<ConstantForce>().force = Vector3.zero;
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        

        //碰撞折射物事件
        if (other.gameObject.tag == "refractionObjects")
        {
            //取得入射點
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log("Point of contact: " + hit.point);
            }

            Vector3 beforeReflectVelocity;
            Vector3 afterReflectVelocity;

            beforeReflectVelocity = _ballRigidbody.velocity;
            afterReflectVelocity = Vector3.Reflect(_ballRigidbody.velocity, hit.normal);

            Debug.Log("beforeReflectVelocity.velocity = " + beforeReflectVelocity);
            Debug.Log("afterReflectVelocity.velocity = " + afterReflectVelocity);

            Vector3 horizontaVector = new Vector3((beforeReflectVelocity.x + afterReflectVelocity.x) / 2, (beforeReflectVelocity.y + afterReflectVelocity.y) / 2, 0);

            _ballRigidbody.velocity = new Vector3((horizontaVector.x + beforeReflectVelocity.x) / 2, (horizontaVector.y + beforeReflectVelocity.y) / 2, 0);
        }

        //碰撞黑洞事件
        if (other.gameObject.tag == "windObject")
        {
            Vector3 windForce = new Vector3((_wind.transform.position.x - this.gameObject.transform.position.x) * 1000,
                                            (_wind.transform.position.y - this.gameObject.transform.position.y) * 1000,
                                            0);
            Debug.Log("_wind.transform.position.x = " + _wind.transform.position.x + ", this.gameObject.transform.position.x = " + this.gameObject.transform.position.x);
            Debug.Log("_wind.transform.position.y = " + _wind.transform.position.y + ", this.gameObject.transform.position.y = " + this.gameObject.transform.position.y);
            
            //windForce = windForce.normalized;
            Debug.Log("windForce = " + windForce);
            this.GetComponent<ConstantForce>().force = windForce;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        
        ContactPoint contact = other.contacts[0];
        Vector3 reflectPosition = contact.point;
        //Debug.Log("reflectPosition = " + reflectPosition);

        if (other.gameObject.tag == "wall") //碰撞到牆壁
        {
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "reflectionObject") //碰撞反射物體
        {
            _reflectCount++;
            //Debug.Log("_reflectCount = " + _reflectCount + ", nowPosition = " + nowPosition + "."); 
        }
        //else if (other.gameObject.tag == "dispersionObject")
        //{
        //    //修改物體速度(根據vector3)
        //    //入射向量
        //    Vector3 beforeReflectVelocity = other.relativeVelocity;
        //    //反射向量
        //    //Vector3 afterReflectVelocity = new Vector3(20, -1, 0);
        //    //_ballRigidbody.velocity = afterReflectVelocity;
        //    Debug.Log("reflectPosition = " + reflectPosition);
        //    Debug.Log("beforeReflectVelocity.velocity = " + beforeReflectVelocity);
        //    Debug.Log("afterReflectVelocity.velocity = " + _ballRigidbody.velocity);

        //    //this.gameObject.transform.rotation = Quaternion.AngleAxis(20, Vector3.up);
        //    //Debug.Log("after = " + this.gameObject.transform.rotation);
        //    //cloneBall.transform.SetParent(this.transform.parent);
        //}
        else if (other.gameObject.tag == "targetObject")
        {
            Debug.Log("Win");
            Destroy(this.gameObject);

        }
    }
}
