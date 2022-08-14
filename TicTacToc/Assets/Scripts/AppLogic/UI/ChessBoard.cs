using System.Collections;
using System.Reflection;
using UnityEngine;


public class ChessBoard : View
{
    // Start is called before the first frame update
    public override string Name
    {
        get
        {
            return "ChessBoard";
        }
    }

    private ChessPiece[ , ] chessPieceList = new ChessPiece[3, 3];

    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject res = Resources.Load<GameObject>("UI/ChessPiece");
                GameObject obj = Instantiate(res);
                obj.name = i.ToString() + j.ToString();
                obj.transform.SetParent(GameObject.Find("ChessBoard").transform, false);
                Vector3 pos = obj.transform.localPosition;
                pos.x = i * 120 - 270;
                pos.y = j * 120 - 120;
                obj.transform.localPosition = pos;
                ChessPiece piece = obj.GetComponent<ChessPiece>();
                piece.PieceIndex = new int[] { i, j };
                chessPieceList[i, j] = piece;
                piece.btnPiece.name = i.ToString() + j.ToString();
                piece.btnPiece.onClick.AddListener(() => { EventCenter.GetInstance().EventTrigger<int[]>("ClickChessPiece", piece.PieceIndex); });
            }
        }

        EventCenter.GetInstance().AddEventListener<ChessModel>("OnChessBoardDataChanged", UpdateChessBoard);
    }

    private void UpdateChessBoard(ChessModel data)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int chessData = data.GetChessAt(i, j);
                string chessText = "";
                if (chessData == 1)
                {
                    chessText = "X";
                }
                else if (chessData == -1)
                {
                    chessText = "O";
                }
                ChessPiece piece = chessPieceList[i, j];
                piece.UpdateInfo(chessText);
            }
        }
    }

}
