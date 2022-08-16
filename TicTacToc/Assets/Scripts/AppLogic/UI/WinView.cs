using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinView : View
{
    public Text txtWinInfo;
    public Button btnBack2Menu;
    public Button btnStartNewGame;
    public Button btnCloseGame;

    public override string Name
    {
        get
        {
            return "WinPanel";
        }
    }
    void Start()
    {
        btnBack2Menu.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "MenuState");
        });
        btnStartNewGame.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "SelectState");
        });
        btnCloseGame.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<bool>("CloseGame", true);
        });
        EventCenter.GetInstance().AddEventListener<string>("GameOver", OnGameOver);

    }

    private void OnGameOver(string winner)
    {
        if (winner == "0")
        {
            txtWinInfo.text = "平局 !!!";
        }
        else
        {
            string info = winner + "胜利！！！";
            txtWinInfo.text = info;
        }

    }

}