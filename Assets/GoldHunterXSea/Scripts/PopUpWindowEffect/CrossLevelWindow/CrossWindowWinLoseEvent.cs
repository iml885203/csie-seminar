using UnityEngine;
using System.Collections;

public class CrossWindowWinLoseEvent : MonoBehaviour
{
    public PopUpWindowControl _popWindow;
    public SuccessOrFailureFlag _isWin;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void WinEvent()
    {
        _isWin.WinTheLevel();
        _popWindow.EnterCrossWindow();
    }

    public void LoseEvent()
    {
        _isWin.LoseTheLevel();
        _popWindow.EnterCrossWindow();
    }
}
