using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : GameState
{
    public override string Name { get { return "BattleState"; } }
    public override string ViewName { get { return "MainPanel"; } }

    protected override void OnLoadComplete()
    {

    }
}
