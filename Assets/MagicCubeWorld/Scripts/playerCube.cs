using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerCube : MonoBehaviour {

    private bool IsWinLoseImageDown = false;
    private processBar _processBar;
    private const int LIFE_MAX = 50;

    public GameStateIndex _gameStateIndex;
    public GameObject _WinLoseImageManage;
    public GameObject _WinLoseImage;
    public int Life { get; set; }

    public EffectSound _effectSound;
    //玩家nuff nerf狀態 0=沒狀態 1=buff -1=nerf
    public int PlayerBuffNerf { get; set; }
    private float _timer = 0f;
    private const int _buffNerfTime = 10;
    private Vector3 _oldScale;

    // Use this for initialization
    void Start () {
        Life = LIFE_MAX;
        PlayerBuffNerf = 0;
    }
	void Awake()
    {
        _processBar = this.GetComponent<processBar>();
    }
    // Update is called once per frame
    void Update () {
        if(_gameStateIndex._gameStateIndex != 2)
        {
            ReSetPlayer();
        }
        //玩家有狀態開始計時
        if(PlayerBuffNerf != 0)
        {
            _timer += Time.deltaTime;
            if(_timer >= _buffNerfTime)
            {
                _timer = 0f;
                PlayerBuffNerf = 0;
                transform.localScale = _oldScale;
            }
        }
    }
    public void IsHit(int damage)
    {
        Life -= damage*10;

        if (Life == 0)
        {
            PlayerDead();
        }
        if (Life < 0)
            Life = 0;
        _processBar.setProcessPer(Life);
    }

    //玩家死亡
    public void PlayerDead()
    {
        _effectSound.PlayEffectSound(EffectSound.BOOM);

        Renderer rend = this.gameObject.GetComponent<Renderer>();
        rend.material.color = Color.white;
        transform.FindChild("Eff_Burst_2_oneShot").gameObject.SetActive(true);
        if (IsWinLoseImageDown == false)
        {
            _WinLoseImageManage.GetComponent<ObjectMoveInEffect>().SmoothMoveInButtonEffect();
            Sprite spr = Resources.Load<Sprite>("Lose");
            _WinLoseImage.GetComponent<Image>().sprite = spr;
            IsWinLoseImageDown = true;
        }
        //rend.material.shader = Shader.Find("02 - Default");
        //rend.material.SetColor("MainColor", Color.blue);
    }

    //玩家重設
    public void ReSetPlayer()
    {
        Life = LIFE_MAX;
        _processBar.setProcessPer(Life);
        Renderer rend = this.gameObject.GetComponent<Renderer>();
        rend.material.color = Color.red;
        transform.FindChild("Eff_Burst_2_oneShot").gameObject.SetActive(false);
        if (IsWinLoseImageDown)
        {
            _WinLoseImageManage.GetComponent<ObjectMoveOutEffect>().SmoothMoveOutButtonEffect();
            Sprite spr = Resources.Load<Sprite>("Win");
            _WinLoseImage.GetComponent<Image>().sprite = spr;
            IsWinLoseImageDown = false;
        }
    }

    //上buff狀態
    public void setPlayerBuff()
    {
        _oldScale = transform.localScale;
        transform.localScale = new Vector3(transform.localScale.x * .5f, transform.localScale.y * .5f, transform.localScale.z);
        _timer = 0f;
        PlayerBuffNerf = 1;
    }

    //上nerf狀態
    public void setPlayerNerf()
    {
        _oldScale = transform.localScale;
        transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z);
        _timer = 0f;
        PlayerBuffNerf = -1;
    }
    
    //清除狀態
    public void clearPlaterBuffNerf()
    {
        transform.localScale = _oldScale;
        PlayerBuffNerf = 0;
    }
}
