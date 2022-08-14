using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : Singleton<BattleMgr>
{
    private OpponentController m_opponentController;
    private PlayerController m_playerController;
    private int m_curTurn;
    public string Winner;
    public BattleMgr()
    {
        GameObject obj = new GameObject("OpponentController");
        m_opponentController = obj.AddComponent<OpponentController>();
        GameObject obj_1 = new GameObject("PlayerController");
        m_playerController = obj_1.AddComponent<PlayerController>();
        m_curTurn = 1;
        EventCenter.GetInstance().AddEventListener<int>("OnGameBegin", OnTurnBegin);
        EventCenter.GetInstance().AddEventListener<int>("OnTurnOver", OnTurnOver);
    }

    private void OnTurnBegin(int turn)
    {
        if (turn == 1)
        {
            m_playerController.OnTurnBegin();
        }
        else
        {
            m_opponentController.OnTurnBegin();
        }
    }
    private void OnTurnOver(int turn)
    {
        
        if (turn == 1)
        {
            m_playerController.OnTurnOver();
        }
        else
        {
            m_opponentController.OnTurnOver();
        }
        
        bool PlayerIsWin = MVC.ChessModel.CheckPlayerIsWin(turn);
        if (PlayerIsWin == true)
        {
            Winner = "玩家";
            if (turn == -1) Winner = "电脑";
            Debug.Log("*********" + Winner + "  Win!!!**********");
            MVC.ChessModel.ClearChessBoard();
            EventCenter.GetInstance().EventTrigger<string>("GameOver", Winner);
            EventCenter.GetInstance().EventTrigger<string>("EnterToState", "WinState");
            return;
        }

        m_curTurn = turn * -1;
        OnTurnBegin(m_curTurn);
    }


}
