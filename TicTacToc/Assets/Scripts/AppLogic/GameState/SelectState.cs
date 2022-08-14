using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectState : GameState
{
    public override string Name { get { return "SelectState"; } }
    public override string ViewName { get { return "SelectPanel"; } }


    protected override void OnLoadComplete()
    {

    }
}