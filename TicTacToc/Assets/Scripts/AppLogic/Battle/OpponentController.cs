using System;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public void OnTurnBegin()
    {
        Debug.Log("**************Computer Turn************");

        if (MVC.OpponentModel.GameDifficulty == E_GameDifficulty.Easy)
        {
            EasyMove();
        }
        else 
        {
            NormalMove();
        }

        EventCenter.GetInstance().EventTrigger<int>("OnTurnOver", -1);
    }
    public void OnTurnOver()
    {

    }

    private void HardMove()
    {
        ChessModel chessModel = MVC.ChessModel;




    }

    private void EasyMove()
    {
        ChessModel chessModel = MVC.ChessModel;
        for (int i = 0; i < 3; i++)
        {
            bool is_finshed = false;
            for (int j = 0; j < 3; j++)
            {
                if (chessModel.GetChessAt(i, j) == 0)
                {
                    chessModel.SetChessPieceAt(i, j, -1);
                    is_finshed = true;
                    break;
                }

            }
            if (is_finshed == true) break;
        }
    }
    private void NormalMove()
    {
        List<int[]> candidates = new List<int[]>();
        ChessModel chessModel = MVC.ChessModel;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (chessModel.GetChessAt(i, j) == 0)
                {
                    candidates.Add( new int []{i, j});
                }
            }
        }
        int idx = 0;
        System.Random r = new System.Random();
        idx = r.Next(0, candidates.Count);
        int row = candidates[idx][0];
        int col = candidates[idx][1];
        chessModel.SetChessPieceAt(row, col, -1);
    }

}
