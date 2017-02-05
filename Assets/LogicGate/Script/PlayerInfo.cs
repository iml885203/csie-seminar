using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEditor;

public class PlayerInfo : MonoBehaviour
{
    public GameRunStatus _gameRunStatus;

    public List<Point> _playerBlockCoordinate = new List<Point>();
    private List<Point> _playerRealCoordinate = new List<Point>();

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}


}
