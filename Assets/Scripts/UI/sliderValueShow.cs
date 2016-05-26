using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sliderValueShow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void onchange()
    {
        gameObject.transform.FindChild("Text").GetComponent<Text>().text = gameObject.GetComponent<Slider>().value.ToString();
    }
}
