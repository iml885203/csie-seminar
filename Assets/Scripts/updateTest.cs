using UnityEngine;
using System.Collections;

public class updateTest : MonoBehaviour {
    private double resetTime = 0.0;
    private int count = 0;
    private int regisCount = 0;
    private Texture2D reset = new Texture2D(500, 500);
    private Texture2D red;
    private int FPS = 0;
    // Use this for initialization
    void Start () {
        red = new Texture2D(500, 500);
        for (int i = 0; i < red.width; i++)
        {
            for (int j = 0; j < red.height; j++)
            {
                red.SetPixel(i, j, new Color(1, 0, 0));
            }
        }
        red.Apply();
        this.gameObject.GetComponent<Renderer>().material.mainTexture = red;

    }
	
	// Update is called once per frame
	void FixedUpdate() {
        this.gameObject.GetComponent<Renderer>().material.mainTexture = red;
        //resetTime += Time.deltaTime;
        int frame = Time.frameCount - count;
        if (frame >= FPS)
        {
            Debug.Log("set"+ frame);
            count = Time.frameCount;
            
            this.gameObject.GetComponent<Renderer>().material.mainTexture = reset;
        }
        resetTime += Time.deltaTime;
        if (resetTime >= 1)
        {
            resetTime = 0.0;
            
            FPS = Time.frameCount - regisCount;
            Debug.Log("FPS: "+ FPS);
            regisCount = Time.frameCount;

        }

    }
}
