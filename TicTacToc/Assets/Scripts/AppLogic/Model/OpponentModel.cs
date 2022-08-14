using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum E_GameDifficulty
{
    Easy,
    Normal,
    Hard,
}

public class OpponentModel : Model
{
    public override string Name
    {
        get
        {
            return "OpponentModel";
        }
    }

    public E_GameDifficulty GameDifficulty;

 
    public OpponentModel()
    {
        GameDifficulty = E_GameDifficulty.Normal;
    }

    public void LoadData()
    {
        
    }
}

