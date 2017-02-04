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

    // Use this for initialization
    void Start()
    {
        _gmaeStatusManager = transform.root.Find("/GameState").GetComponent<GameStateIndex>();
        initSize();
        initBlocks();
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
        Vector3 copyBlockSize = copyBlockRect.localScale;
        //初始化大小
        copyBlockRect.localScale = new Vector3(_viewWidth / MapManager.BlockWidth, _viewHeight / MapManager.BlockHeight, 10);

        //複製物件
        for(int i = 0; i < MapManager.BlockWidth; i++)
        {
            for(int j = 0; j < MapManager.BlockHeight; j++)
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
                newBlockRect.localScale = copyBlock.GetComponent<RectTransform>().localScale;
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
