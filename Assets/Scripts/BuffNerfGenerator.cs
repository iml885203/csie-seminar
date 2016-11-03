using UnityEngine;
using System.Collections;
using System;

public class BuffNerfGenerator : MonoBehaviour {
    public GameObject CopyObject;
    public float GenetatorTime = 1f;
    private float _timer = 0f;
    //重複產生次數，避免無限迴圈
    private int repeatTime = 5;
    private GameStateIndex _gameState;
    private GameLevelIndex _gameLevel;
    
    // Use this for initialization
    void Start () {
        _gameState = transform.root.Find("/GameState").GetComponent<GameStateIndex>();
        _gameLevel = transform.root.Find("/LevelIndex").GetComponent<GameLevelIndex>();
    }
	
	// Update is called once per frame
	void Update () {
        if(_gameState == null || _gameLevel == null)
        {
            Debug.Log("Can't get game state object");
        }
        if(_gameState.CurrentStateIndex != GameState.GameRun || _gameLevel.CurrentLevelIndex != GameLevelIndex.LEVEL_FIGHT)
        {
            if (transform.Find(CopyObject.name + "(Clone)") != null)
            {
                Destroy(transform.Find(CopyObject.name + "(Clone)").gameObject);
            }
            return;
        }
        _timer += Time.deltaTime;
        if(_timer >= GenetatorTime)
        {
            if (transform.Find(CopyObject.name + "(Clone)") == null)
            {
                CreateBuffNerfObject(repeatTime);
            }
            _timer = 0f;
        }

    }

    public void CreateBuffNerfObject(int repeatTime)
    {
        if (repeatTime < 0)
        {
            Debug.Log("repeat too much! :" + repeatTime);
            return;
        }
        RectTransform rect = transform as RectTransform;
        //Debug.Log(rect.rect.size);
        float ranX = UnityEngine.Random.Range(-rect.rect.width / 2, rect.rect.width / 2);
        float ranY = UnityEngine.Random.Range(-rect.rect.height / 2, rect.rect.height / 2);
        //Debug.Log(ranX+", "+ ranY);
        GameObject cloneBuffObject = (GameObject)Instantiate(CopyObject, transform.position, transform.rotation);
        cloneBuffObject.transform.SetParent(transform);
        cloneBuffObject.transform.localPosition = new Vector2(ranX, ranY);
        cloneBuffObject.transform.position = new Vector3(cloneBuffObject.transform.position.x , cloneBuffObject.transform.position.y, CopyObject.transform.position.z);
        cloneBuffObject.SetActive(true);
        var checkResult = Physics.OverlapSphere(cloneBuffObject.transform.position, .5f);
        if(checkResult.Length >= 2)
        {
            Destroy(cloneBuffObject);
            CreateBuffNerfObject(--repeatTime);
        }
    }

    internal void ClearTimer()
    {
        _timer = 0f;
    }
}
