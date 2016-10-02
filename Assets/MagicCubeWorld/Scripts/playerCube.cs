using UnityEngine;
using System.Collections;

public class playerCube : MonoBehaviour {
    private processBar _processBar;

    public int Life { get; set; }
    // Use this for initialization
    void Start () {
        Life = 50;
    }
	void Awake()
    {
        _processBar = this.GetComponent<processBar>();
    }
    // Update is called once per frame
    void Update () {

     
    }
    public void IsHit(int damage)
    {
        Life -= damage*10;
        if (Life < 0) Life = 0;
        if (Life == 0)
        {
            //gameObject.GetComponent<Renderer> ().material.color = Color.green;
            Renderer rend = this.gameObject.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("02 - Default");
            rend.material.SetColor("MainColor", Color.blue);
        }
        _processBar.setProcessPer(Life);
    }
}
