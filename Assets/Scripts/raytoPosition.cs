using UnityEngine;
using System.Collections;

public class raytoPosition : MonoBehaviour {
    public mapCoordinate _mapCoordinate;
	// Use this for initialization
	void Start () {
        
        //Debug.Log(_mapCoordinate.StartBlock.maxPos.y);
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
                double coordinateX = hit.point.x - transform.position.x;
                double coordinateY = hit.point.y - transform.position.y;
                double posX = (transform.localScale.x / 2) + coordinateX;
                double posY = (transform.localScale.y / 2) - coordinateY;
                Debug.ClearDeveloperConsole();
                Debug.Log("coordinate:" + (int)coordinateX + ", " + (int)coordinateY);
                Debug.Log("Pos:" + (int)posX + ", " + (int)posY);
                //map check
                Debug.Log("checkPos:" + _mapCoordinate.StartBlock.Check(posX, posY));
            }
        }
        
    }
}
