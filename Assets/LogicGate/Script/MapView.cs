using UnityEngine;
using System.Collections;

public class MapView : MonoBehaviour {
    //螢幕框高
    private int _screenWidth;
    private int _screenHeight;
    //地圖方格數
    private int _blockWidth;
    private int _blockHeight;

    //要被複製的物件
    public GameObject copyGameWallObject;
    public GameObject copyGameBlockObject;
    //要被放置在哪個物件底下
    public GameObject superGameWallObject;
    public GameObject superGameBlockObject;
    //被複製出來的物件
    private GameObject childGameWallObject;
    private GameObject childGameBlockObject;

    //遊戲狀態
    private GameStateIndex _gmaeStatusManager;

    public MapView(int screenWidth, int screenHeight, int blockWidth, int blockHeight)
    {
        SetScreenSize(screenWidth, screenHeight);
        _blockWidth = blockWidth;
        _blockHeight = blockHeight;
    }

    // Use this for initialization
    void Start()
    {
        _gmaeStatusManager = transform.root.Find("/GameState").GetComponent<GameStateIndex>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //設定螢幕寬高
    public void SetScreenSize(int width, int height)
    {
        _screenWidth = width;
        _screenHeight = height;
    }

    //設定方格數量
    public void SetBlockAmount(int blockWidth, int blockHeight)
    {
        _blockWidth = blockWidth;
        _blockHeight = blockHeight;
    }


}
