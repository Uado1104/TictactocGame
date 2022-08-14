using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    private Dictionary<string, GameState> m_GameStateMap = null;
    private GameState m_CurState = null;

    public void Init()
    {
        m_GameStateMap = new Dictionary<string, GameState>();
        m_CurState = null;

        MenuState menuState = new MenuState();
        m_GameStateMap[menuState.Name] = menuState;

        SelectState selectState = new SelectState();
        m_GameStateMap[selectState.Name] = selectState;

        PauseState pauseState = new PauseState();
        m_GameStateMap[pauseState.Name] = pauseState;

        BattleState battleState = new BattleState();
        m_GameStateMap[battleState.Name] = battleState;

        EndState gameOverState = new EndState();
        m_GameStateMap[gameOverState.Name] = gameOverState;

        WinState winState = new WinState();
        m_GameStateMap[winState.Name] = winState;

        EventCenter.GetInstance().AddEventListener<string>("EnterToState", SetState);
        EventCenter.GetInstance().AddEventListener<string>("Enter2Battle", Enter2Battle);
        EventCenter.GetInstance().AddEventListener<bool>("CloseGame", CloseGame);
    }

    private void Enter2Battle(string modeName)
    {
        MVC.ChessModel.ClearChessBoard();
        MVC.OpponentModel.GameDifficulty = E_GameDifficulty.Easy;

        if (modeName == "Load")
        {
            MVC.ChessModel.LoadLastGame();
        }
        else
        {
            if (modeName == "Easy")
            {
                MVC.OpponentModel.GameDifficulty = E_GameDifficulty.Easy;
            }
            else
            {
                MVC.OpponentModel.GameDifficulty = E_GameDifficulty.Normal;
            }

        }
        EventCenter.GetInstance().EventTrigger<int>("OnGameBegin", 1);
        SetState("BattleState");
    }

    private void SetState(string stateName)
    {
        if (m_GameStateMap.ContainsKey(stateName))
        {
            GameState state = m_GameStateMap[stateName];
            Debug.Log(state.Name);
            if (state != m_CurState && m_CurState != null)
            {
                m_CurState.Stop();
            }
            m_CurState = state;
            m_CurState.Start();
        }
    }

    private void CloseGame(bool isCloseGame)
    {
        if(isCloseGame)
        {
            MVC.HideAllView();
            Application.Quit();
        }
    }
}
