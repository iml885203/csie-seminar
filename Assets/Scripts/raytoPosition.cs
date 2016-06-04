using UnityEngine;
using System.Collections;
using OpenCVForUnity;

public class raytoPosition : MonoBehaviour {
  //  public mapCoordinate _mapCoordinate;
    public mazeCoordinate mazeCoordinate;
    public double posX {get; private set;}
    public double posY { get; private set; }
    public Point posXY;
	// Use this for initialization
	void Start () {
        posXY = new Point(-1, -1);
        //Debug.Log(_mapCoordinate.StartBlock.maxPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
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
                //Debug.Log("coordinate:" + (int)coordinateX + ", " + (int)coordinateY);
               // Debug.Log("Pos:" + (int)posX + ", " + (int)posY);
                
                //map check
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if (mazeCoordinate.StartBlock[i, j].Check(posX, posY))
                        {
                            //Debug.Log("PosX:" + j + "PosX:" + i);
                            posXY.x = j;
                            posXY.y = i;
                        }
                    }
                }
                //Debug.Log("checkPos:" + _mapCoordinate.StartBlock.Check(posX, posY));
            }
        }
        
    }
    public Point getPos()
    {
        return posXY;
    }
}
