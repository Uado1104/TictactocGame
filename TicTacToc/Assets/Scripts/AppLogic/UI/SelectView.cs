using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectView : View
{
    public Button btnSelectEasy;
    public Button btnSelectNormal;
    public Button btnSelectHard;
    public Button btnBack2Menu;
    public override string Name
    {
        get
        {
            return "SelectPanel";
        }
    }
    void Start()
    {
        btnSelectEasy.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("Enter2Battle", "Easy");
        });
        btnSelectNormal.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("Enter2Battle", "Normal");
        });
        btnSelectHard.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("Enter2Battle", "Hard");
        });
        btnBack2Menu.onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "MenuState");
        });
    }

}
