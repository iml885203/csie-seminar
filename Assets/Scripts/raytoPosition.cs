using UnityEngine;
using System.Collections;

public class raytoPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                //transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                int coordinateX = (int)(hit.point.x - transform.position.x);
                int coordinateY = (int)(hit.point.y - transform.position.y);
                Debug.Log(coordinateX + ", " + coordinateY);
            }
        }
        
    }
}
