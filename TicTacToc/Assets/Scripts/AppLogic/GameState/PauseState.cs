using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : GameState
{
    public override string Name { get { return "PauseState"; } }
    public override string ViewName { get { return "PausePanel"; } }

    protected override void OnLoadComplete()
    {

    }
}