using UnityEngine;
using System.Collections;

public class outputViewPointToChildPoint : MonoBehaviour {
    public matchPointToOutputView _matchPointToOutputView;
    private double _width;
    private double _height;
    private Transform child;
	// Use this for initialization
	void Start () {
        
        _width = transform.localScale.x;
        _height = transform.localScale.y;
        child = transform.FindChild("child");
        
    }
	
	// Update is called once per frame
	void Update () {
        if (_matchPointToOutputView == null)
        {
            Debug.Log("not to find matchPointToOutputView");
            return;
        }
        
        if (_matchPointToOutputView.OutputX !=0.0 && _matchPointToOutputView.OutputY != 0.0)
        {
            var childPointX = _matchPointToOutputView.OutputX / _width;
            var childPointY = _matchPointToOutputView.OutputY / _height;
            //Debug.Log(childPointX + "," + childPointY);

            RectTransform rectTransform = (RectTransform)child.transform;
            Vector2 newPos = new Vector2((float)childPointX, -(float)childPointY);
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, newPos, 0.1f);
            
            Debug.Log(child.localPosition);
            Debug.Log(child.position);
            Debug.Log(rectTransform.anchoredPosition);

        }


    }
}
