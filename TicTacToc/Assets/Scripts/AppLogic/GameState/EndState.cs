using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : GameState
{
    public override string Name { get { return "EndState"; } }
    public override string ViewName { get { return "EndPanel"; } }

    protected override void OnLoadComplete()
    {

    }
}
