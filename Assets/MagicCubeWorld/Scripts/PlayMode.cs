using UnityEngine;
using System.Collections;

public class PlayMode : MonoBehaviour
{
    public const int MODE_NONE = 0;
    public const int MODE_SINGLE = 1;
    public const int MODE_FIGHT = 2;

    public GameLevelIndex _levelIndex;

    public int _modeIndex;
    public int CurrentPlayMode
    {
        get
        {
            return _modeIndex;
        }
        set
        {
            _modeIndex = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        _modeIndex = MODE_NONE;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_levelIndex.CurrentLevelIndex <= GameLevelIndex.LEVEL_3)
            this.ToSingleMode();
        else if (_levelIndex.CurrentLevelIndex == GameLevelIndex.LEVEL_FIGHT)
            this.ToFightMode();
        else
            this.ToNoneMode();
	}

    public void ToSingleMode()
    {
        _modeIndex = MODE_SINGLE;
    }

    public void ToFightMode()
    {
        _modeIndex = MODE_FIGHT;
    }

    public void ToNoneMode()
    {
        _modeIndex = MODE_NONE;
    }
}
