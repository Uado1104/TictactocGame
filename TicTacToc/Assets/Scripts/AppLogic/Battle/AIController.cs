using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private int[][][] winList =
    {
        // winning list
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

    public void OnTurnBegin()
    {
        Debug.Log("**************AI Turn************");
        int[] cur_move = move(MVC.ChessModel.GetChessBoardModel());
        int col = cur_move[0];
        int row = cur_move[1];
        MVC.ChessModel.SetChessPieceAt(col, row, AI);
        EventCenter.GetInstance().EventTrigger<int>("OnTurnOver", -1);
    }
    public void OnTurnOver()
    {

    }

    private static int AI = -1;
    private static int PLAYER = 1;
    private static int EMPTY = 0;


    private bool CheckIsWin(int[,] chessBoard, int winNumber)
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

    private bool CheckIsFull(int[,] chessBoard)
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

    private int MinMax(int[,] chessBoard, int round, int next_round, int alpha = -2, int beta = 2)
    {
        if (CheckIsWin(chessBoard, PLAYER) == true) return -1;  // 玩家赢
        if (CheckIsWin(chessBoard, AI) == true) return 1;  // AI赢
        if (CheckIsFull(chessBoard) == true) return 0;  // 棋盘满了，和棋
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // 尝试下棋
                if (chessBoard[i, j] == EMPTY)
                {
                    chessBoard[i, j] = round;
                    int value = MinMax(chessBoard, next_round, round, alpha, beta);  // 思考对手下棋
                    chessBoard[i, j] = EMPTY;
                    if (round == AI)
                    {
                        if (value > alpha) alpha = value;
                        if (alpha >= beta) return beta; // 剪枝
                    }
                    else
                    {
                        if (value < beta) beta = value;
                        if (beta <= alpha) return alpha; // 剪枝
                    }
                }
            }

        }
        if (round == AI)
        {
            return alpha;
        }
        else
        {
            return beta;
        }
    }

    public int[] move(int[,] chessBoard)
    {
        int best = -2;
        List<int[]> moveList = new List<int[]>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(chessBoard[i, j] == EMPTY)
                {
                    chessBoard[i, j] = AI;
                    int score = MinMax(chessBoard, PLAYER, AI);
                    chessBoard[i, j] = EMPTY;
                    int[] temp = { i, j };

                    if (score > best)
                    {
                        best = score;
                        moveList = new List<int[]>();
                        moveList.Add(temp);
                    }
                    if (score == best) moveList.Add(temp);
                }
            }
        }
        // 随机选一个
        System.Random r = new System.Random();
        int idx = r.Next(0, moveList.Count);
        return moveList[idx];
    }

}