using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : View
{
    public Button btnSaveGame;
    public Button btnEndGame;
    public Button btnPauseGame;

    public override string Name
    {
        get 
        {
            return "MainPanel";
        }
    }
    void Start()
    {
        btnSaveGame.onClick.AddListener(() =>
        {
            MVC.ChessModel.SaveData();
        });
        btnEndGame.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "EndState");
        });
        btnPauseGame.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "PauseState");
        });
    }
}
