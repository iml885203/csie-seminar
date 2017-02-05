using UnityEngine;
using System.Collections;
using UnityEditor;

public class GameRunStatus : MonoBehaviour
{
    //玩家數量
    private int _playerCount;

    //移動步數、回合數、輪到的玩家Index
    private int _stepCount;
    private int _roundCount;
    private int _turnIndex;

    public int PlayerCount
    {
        get
        {
            return _playerCount;
        }
        set
        {
            _playerCount = value;
        }
    }

    public int CurrentStepCount
    {
        get
        {
            return _stepCount;
        }
    }

    public int CurrentRoundCount
    {
        get
        {
            return _roundCount;
        }
    }

    // Use this for initialization
    void Start ()
    {
        _playerCount = 2;
        _stepCount = 0;
        _roundCount = 0;
        this.CalculateWhoIsTurn();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.CalculateWhoIsTurn();
    }

    //回傳輪到的玩家index
    private void CalculateWhoIsTurn()
    {
        _turnIndex = _stepCount % _playerCount;
    }

    //增加步數
    public void AddStep()
    {
        _stepCount += 1;
    }

    //計算回合數
    private void CalculateRoundCount()
    {
        _roundCount = _stepCount / _playerCount + 1;
    }
}
