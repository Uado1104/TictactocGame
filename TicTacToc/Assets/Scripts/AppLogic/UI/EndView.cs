using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndView : View
{
    public Button btnBack2Menu;
    public Button btnStartNewGame;
    public Button btnCloseGame;
    public override string Name
    {
        get
        {
            return "EndPanel";
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
    }

}

