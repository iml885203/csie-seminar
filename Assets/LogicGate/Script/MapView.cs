using UnityEngine;
using System.Collections;

public class MapView : MonoBehaviour {
    //螢幕框高
    private float _viewWidth;
    private float _viewHeight;

    //要被複製的物件
    public GameObject copyWall;
    public GameObject copyBlock;
    //要被放置在哪個物件底下
    public GameObject superWall;
    public GameObject superBlock;

    //遊戲狀態
    private GameStateIndex _gmaeStatusManager;

    //MapManager
    private MapManager _mapManager;

    // Use this for initialization
    void Start()
    {
        _gmaeStatusManager = transform.root.Find("/GameState").GetComponent<GameStateIndex>();
        _mapManager = transform.root.Find("/MapManager").GetComponent<MapManager>();
        initSize();
        initBlocks();
        initWalls();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void initSize()
    {
        Vector2 viewSize = superBlock.GetComponent<RectTransform>().rect.size;
        SetViewSize(viewSize.x, viewSize.y);
    }

    private void initBlocks()
    {
        RectTransform copyBlockRect = copyBlock.GetComponent<RectTransform>();
        //初始化大小
        copyBlockRect.localScale = new Vector3(_viewWidth / MapManager.BlockWidth, _viewHeight / MapManager.BlockHeight, 10);
        Vector3 copyBlockSize = copyBlockRect.localScale;

        //複製物件
        for(int j = 0; j < MapManager.BlockHeight; j++)
        {
            for(int i = 0; i < MapManager.BlockWidth; i++)
            {
                GameObject newBlock = Instantiate(copyBlock);//複製copyGameObject物件(連同該物件身上的腳本一起複製)
                newBlock.transform.parent = superBlock.transform;//放到superGameObject物件內

                RectTransform newBlockRect = newBlock.GetComponent<RectTransform>();
                //座標系統統一(左上0,0)
                newBlockRect.anchorMin = new Vector2(0, 1);
                newBlockRect.anchorMax = new Vector2(0, 1);
                newBlockRect.pivot = new Vector2(.5f, .5f);
                //初始化座標
                newBlockRect.anchoredPosition = new Vector3(copyBlockSize.x / 2 + (i * copyBlockSize.x), -copyBlockSize.y / 2 - (j * copyBlockSize.y), 0);
                newBlockRect.localPosition = new Vector3(newBlockRect.localPosition.x, newBlockRect.localPosition.y, 10);
                newBlockRect.localScale = copyBlockSize;
            }
        }
    }

    private void initWalls()
    {
        Vector3 copyWallSize = copyWall.GetComponent<RectTransform>().localScale;
        Vector3 copyBlockSize = copyBlock.GetComponent<RectTransform>().localScale;

        //複製物件
        for (int j = 0; j < MapManager.BlockHeight; j++)
        {
            for (int i = 0; i < MapManager.BlockWidth; i++)
            {
                for(int k = 3; k >= 0; k--)// 8->4->2->1
                {
                    if((_mapManager.getWall(i, j) & (int)Mathf.Pow(2, k)) != 0)
                    {
                        GameObject newWall = Instantiate(copyWall);//複製copyGameObject物件(連同該物件身上的腳本一起複製)
                        newWall.transform.parent = superWall.transform;//放到superGameObject物件內

                        RectTransform newWallRect = newWall.GetComponent<RectTransform>();
                        //座標系統統一(左上0,0)
                        newWallRect.anchorMin = new Vector2(0, 1);
                        newWallRect.anchorMax = new Vector2(0, 1);
                        newWallRect.pivot = new Vector2(.5f, .5f);
                        //初始化座標
                        newWallRect.anchoredPosition = new Vector3(copyBlockSize.x / 2 + (i * copyBlockSize.x), -copyBlockSize.y / 2 - (j * copyBlockSize.y), 0);
                        newWallRect.localPosition = new Vector3(newWallRect.localPosition.x, newWallRect.localPosition.y, 10);
                        newWallRect.localScale = copyWallSize;
                        newWallRect.localRotation = Quaternion.Euler(newWallRect.localRotation.x, newWallRect.localRotation.y, 90 * k);
                    }
                }
                
            }
        }
    }

    //設定螢幕寬高
    public void SetViewSize(float width, float height)
    {
        _viewWidth = width;
        _viewHeight = height;
    }

}
