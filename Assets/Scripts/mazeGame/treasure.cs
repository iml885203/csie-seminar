using UnityEngine;
using System.Collections;

public class treasure : MonoBehaviour
{
    public RectTransform Tran;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // Tran.transform.TransformPoint(10, 10, 0);
        
        Tran.TransformPoint(10, 10, 10);
       // Tran.transform.Translate(10, 0, 0);
	}
}
