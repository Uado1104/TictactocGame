using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseView : View
{
    public Button btnBack2Game;
    public Button btnSaveGame;
    public Button btnStartNewGame;
    public Button btnBack2Menu;
    public Button btnEndGame;

    public override string Name
    {
        get
        {
            return "PausePanel";
        }
    }
    void Start()
    {
        btnBack2Game.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "BattleState");
        });
        btnSaveGame.onClick.AddListener(() =>
        {
            MVC.ChessModel.SaveData();
        });
        btnStartNewGame.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "SelectState");
        });
        btnBack2Menu.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "MenuState");
        });
        btnEndGame.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<bool>("CloseGame", true);

        });
    }

}