using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void OnTurnBegin()
    {
        Debug.Log("**************Your Turn************");
        EventCenter.GetInstance().AddEventListener<int[]>("ClickChessPiece", OnClickChessPiece);

    }
    public void OnTurnOver()
    {
        EventCenter.GetInstance().RemoveEventListener<int[]>("ClickChessPiece", OnClickChessPiece);
    }
    private void OnClickChessPiece(int[] pieceIndex)
    {
        int row = pieceIndex[0], col = pieceIndex[1];
        Debug.Log("OnBtnClick  " + row + col);
        ChessModel chessModel = MVC.ChessModel;
        int pieceData = chessModel.GetChessAt(row, col);
        if (pieceData == 0)
        {
            chessModel.SetChessPieceAt(row, col, 1);
        }
        EventCenter.GetInstance().EventTrigger<int>("OnTurnOver", 1);
    }

}
