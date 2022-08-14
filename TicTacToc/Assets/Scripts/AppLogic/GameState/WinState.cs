using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : GameState
{
    public override string Name { get { return "WinState"; } }
    public override string ViewName { get { return "WinPanel"; } }

    protected override void OnLoadComplete()
    {

    }
}