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

    // Use this for initialization
    void Start () {
        Life = LIFE_MAX;
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
}
