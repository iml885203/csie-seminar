using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;

public class GameController : MonoBehaviour {

    //傳入match
    private Match _match;
    //偵測的物件
    private List<MatchObject> _matchColorObjectList;
    //點擊功能class
    private raytoPosition _rayPosData;
    //地圖資料
    private MapManager _mapManager;
    // Use this for initialization
    void Start () {
        _match = transform.root.Find("/KinectManagers/MatchManager").GetComponent<Match>();
        _mapManager = transform.root.Find("/MapManager").GetComponent<MapManager>();
    }

    // Update is called once per frame
    void Update () {
        //載入偵測物件
        _matchColorObjectList = _match._matchColorObjectList;
        
    }
}
