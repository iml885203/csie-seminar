using UnityEngine;
using System.Collections;

public class LaserBall : MonoBehaviour {
    private LaserGenerator _generator;
    private Rigidbody _ballRigidbody;
    private int _reflectCount;
    private Vector3 _beforeReflectVelocity;

    Vector3 _windForce;

    // Use this for initialization
    void Start ()
    {
        //_windForce = _wind.GetComponent<Wind>().GetWindForce();
        //_windRadius = _wind.GetComponent<Wind>().GetWindRadius();

        //_reflashVelocityFlag = true;
        _ballRigidbody = GetComponent<Rigidbody>();
        _generator = gameObject.GetComponentInParent<LaserGenerator>();
        _reflectCount = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Transform child in this.transform.parent)
        {
            if (child.tag == "LaserBall")
            {
                Physics.IgnoreCollision(this.gameObject.GetComponent<SphereCollider>(), child.GetComponent<SphereCollider>());
            }
        }
    }

    void FixedUpdate()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "BlackHoleObject")
        {
            this.GetComponent<ConstantForce>().force = Vector3.zero;
        }

        if (other.gameObject.tag == "WhiteHoleObject")
        {
            this.GetComponent<ConstantForce>().force = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        ////碰撞折射物事件
        //if (other.gameObject.tag == "refractionObjects")
        //{
        //    //取得入射點
        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position, transform.forward, out hit))
        //    {
        //        Debug.Log("Point of contact: " + hit.point);
        //    }

        //    Vector3 beforeReflectVelocity;
        //    Vector3 afterReflectVelocity;

        //    beforeReflectVelocity = _ballRigidbody.velocity;
        //    afterReflectVelocity = Vector3.Reflect(_ballRigidbody.velocity, hit.normal);

        //    Debug.Log("beforeReflectVelocity.velocity = " + beforeReflectVelocity);
        //    Debug.Log("afterReflectVelocity.velocity = " + afterReflectVelocity);

        //    Vector3 horizontaVector = new Vector3((beforeReflectVelocity.x + afterReflectVelocity.x) / 2, (beforeReflectVelocity.y + afterReflectVelocity.y) / 2, 0);

        //    _ballRigidbody.velocity = new Vector3((horizontaVector.x + beforeReflectVelocity.x) / 2, (horizontaVector.y + beforeReflectVelocity.y) / 2, 0);
        //}

        //碰撞黑洞事件
        if (other.gameObject.tag == "BlackHoleObject")
        {
            Debug.Log("enter blackhole");
            Vector3 blackHoleForce = new Vector3((other.transform.position.x - this.gameObject.transform.position.x) * 300,
                                            (other.transform.position.y - this.gameObject.transform.position.y) * 300,
                                            0);

            this.GetComponent<ConstantForce>().force = blackHoleForce;
        }

        //碰撞白洞事件
        if (other.gameObject.tag == "WhiteHoleObject")
        {
            Vector3 whiteHoleForce = new Vector3((other.transform.position.x - this.gameObject.transform.position.x) * -300,
                                            (other.transform.position.y - this.gameObject.transform.position.y) * -300,
                                            0);

            this.GetComponent<ConstantForce>().force = whiteHoleForce;
        }


        if (other.gameObject.tag == "SeparateObject")
        {
            if (other.GetComponent<SeparateObject>().TriggerEvent())
            {
                //Debug.Log("touch SeparateObject");
                //修改物體速度(根據vector3)
                //入射向量
                Vector3 originVelocity = _ballRigidbody.velocity;

                Vector3 verticalVelocity1 = new Vector3();
                Vector3 verticalVelocity2 = new Vector3();
                this.GetTwoVerticalVector(originVelocity, ref verticalVelocity1, ref verticalVelocity2);

                verticalVelocity1 = this.GetShiftPosition(verticalVelocity1, this.gameObject.GetComponent<RectTransform>().rect.width / 5);
                verticalVelocity2 = this.GetShiftPosition(verticalVelocity2, this.gameObject.GetComponent<RectTransform>().rect.width / 5);

                GameObject cloneLaserBall1 = (GameObject)Instantiate(this.gameObject,
                                new Vector3(this.transform.position.x + verticalVelocity1.x, this.transform.position.y + verticalVelocity1.y, this.transform.position.z),
                                new Quaternion(0, 0, 0, 1)
                                );
                cloneLaserBall1.GetComponent<Rigidbody>().velocity = Quaternion.Euler(0, 0, 10) * originVelocity;
                cloneLaserBall1.transform.localScale = this.gameObject.transform.lossyScale;
                cloneLaserBall1.transform.SetParent(this.transform.parent);

                GameObject cloneLaserBall2 = (GameObject)Instantiate(this.gameObject,
                                new Vector3(this.transform.position.x + verticalVelocity2.x, this.transform.position.y + verticalVelocity2.y, this.transform.position.z),
                                new Quaternion(0, 0, 0, 1)
                                );
                cloneLaserBall2.GetComponent<Rigidbody>().velocity = Quaternion.Euler(0, 0, -10) * originVelocity;
                cloneLaserBall2.transform.localScale = this.gameObject.transform.lossyScale;
                cloneLaserBall2.transform.SetParent(this.transform.parent);
            }
        }

        if(other.gameObject.tag == "TransmissionObject")
        {
            if(other.GetComponent<TransmissionObject>().CanMoveToAnotherSidePortal())
                this.transform.position = other.GetComponent<TransmissionObject>().ReturnAnotherSidePortalPosition();
        }
    }

    void OnCollisionEnter(Collision other)
    {

        ContactPoint contact = other.contacts[0];
        Vector3 reflectPosition = contact.point;
        //Debug.Log("reflectPosition = " + reflectPosition);

        if (other.gameObject.tag == "Wall") //碰撞到牆壁
        {
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "ReflectionObject") //碰撞反射物體
        {
            _reflectCount++;
            //Debug.Log("_reflectCount = " + _reflectCount + ", nowPosition = " + nowPosition + "."); 
        }
        else if(other.gameObject.tag == "DestoryObject")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "TargetObject")
        {
            //Debug.Log("Win");
            Destroy(this.gameObject);
            other.gameObject.GetComponent<playerCube>().IsHit(1);
        }
    }

    private Vector3 GetShiftPosition(Vector3 originVector, float distance)
    {
        float dist = Vector3.Distance(Vector3.zero, originVector);
        float shiftX = originVector.x * (distance / dist);
        float shiftY = originVector.y * (distance / dist);
        float shiftZ = originVector.z * (distance / dist);
        //if (originVector.x == 0)
        //    shiftX = 0;
        //else if (originVector.y == 0)
        //    shiftY = 0;
        //else if (originVector.z == 0)
        //    shiftZ = 0;
        return new Vector3(shiftX, shiftY, shiftZ);
    }

    private void GetTwoVerticalVector(Vector3 originVector, ref Vector3 verticalVector1, ref Vector3 verticalVector2)
    {
        verticalVector1 = new Vector3(0f - originVector.y, originVector.x, originVector.z);
        verticalVector2 = new Vector3(originVector.y, 0f - originVector.x, originVector.z);
    }
}
