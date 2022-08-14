using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("*************** Init  *************");

        Debug.Log("*************** InitData  *************");
        ChessModel chessModel = new ChessModel();
        MVC.ChessModel = chessModel;
        OpponentModel opponentModel = new OpponentModel();
        MVC.OpponentModel = opponentModel;

        Debug.Log("*************** Init Mgr  *************");
        EventCenter eventCenter = EventCenter.GetInstance();
        MVC.EventCenter = eventCenter;
        BattleMgr battleMgr = BattleMgr.GetInstance();
        GameStateManager.GetInstance().Init();

        Debug.Log("*************** Init View  *************");
        GUIManager.Init();

        // game start
        EventCenter.GetInstance().EventTrigger<string>("EnterToState", "MenuState");
    }

}
