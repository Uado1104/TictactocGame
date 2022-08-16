using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChessModel: Model
{
    public int GetChessAt(int row, int col)
    {
        return chessBoard[row, col];
    }
    public void SetChessPieceAt(int row, int col, int pieceData)
    {
        chessBoard[row, col] = pieceData;
        OnDataChanged();
    }
    public override string Name 
    {
        get 
        {
            return "ChessModel";
        } 
    }

    protected override void OnDataChanged()
    {
        EventCenter.GetInstance().EventTrigger<ChessModel>("OnChessBoardDataChanged", this);
    }

    private int[,] chessBoard = new int[3, 3];

public ChessModel()
    {   
        chessBoard = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        OnDataChanged();
    }

    public void ClearChessBoard()
    {
        chessBoard = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        OnDataChanged();
    }

    public int[,] GetChessBoardModel()
    {
        int[,] chessList = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int v = chessBoard[i, j];
                chessList[i, j] = v;
          }
        }
        return chessList;
    }
    public bool CheckPlayerIsWin(int winNumber = 1)
    {
        bool isWin = false;

        for (int i = 0; i < winList.Length; i++)
        {
            isWin = true;

            int[][] winCheck = winList[i];
            for (int j = 0; j < winCheck.Length; j++)
            {
                int[] cur = winCheck[j];
                int row = cur[0];
                int col = cur[1];
                if (chessBoard[row, col] != winNumber)
                {
                    isWin = false;
                    break;
                }
            }
            if (isWin == true) break;
        }
        return isWin;
    }

    public bool CheckIsFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (chessBoard[i, j] == 0) return false;
            }
        }
        return true;
    }

    public void LoadLastGame()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int d = PlayerPrefs.GetInt(i.ToString() + j.ToString(), 0);
                chessBoard[i, j] = d;
            }
        }
        OnDataChanged();
    }
    public void SaveData()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                PlayerPrefs.SetInt(i.ToString() + j.ToString(), chessBoard[i, j]);
            }
        }
        OnDataChanged();
    }


    private int[][][] winList =
    {
        // 8��ʤ����ʽ
        new int [][]{
            new int[] {0, 0},
            new int[] {0, 1},
            new int[] {0, 2},
        },
        new int [][]{
            new int[] {1, 0},
            new int[] {1, 1},
            new int[] {1, 2},
        },
        new int [][]{
            new int[] {2, 0},
            new int[] {2, 1},
            new int[] {2, 2},
        },
        new int [][]{
            new int[] {0, 0},
            new int[] {1, 0},
            new int[] {2, 0},
        },
        new int [][]{
            new int[] {0, 1},
            new int[] {1, 1},
            new int[] {2, 1},
        },
        new int [][]{
            new int[] {0, 2},
            new int[] {1, 2},
            new int[] {2, 2},
        },
                new int [][]{
            new int[] {0, 0},
            new int[] {1, 1},
            new int[] {2, 2},
        },
        new int [][]{
            new int[] {2, 0},
            new int[] {1, 1},
            new int[] {0, 2},
        },
    };

}
