using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuView : View
{
    public Button btnStartGame;
    public Button btnLoadGame;
    public Button btnCloseGame;
    public override string Name
    {
        get
        {
            return "MenuPanel";
        }
    }
    void Start()
    {
        btnStartGame.onClick.AddListener(() => {
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "SelectState"); });
        btnLoadGame.onClick.AddListener(() => {
            EventCenter.GetInstance().EventTrigger<string>("Enter2Battle", "Load"); });
        btnCloseGame.onClick.AddListener(() => { EventCenter.GetInstance().EventTrigger<bool>("CloseGame", true); });
        

    }

}
