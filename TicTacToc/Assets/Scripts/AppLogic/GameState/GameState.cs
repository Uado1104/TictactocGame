using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{

    public void Start()
    {
        OnStart();
    }
    public void Stop()
    {
        OnStop();
    }

    public void LoadComplete(params object[] args)
    {
        OnLoadComplete();
    }


    public abstract string Name { get; }
    public abstract string ViewName { get; }
    protected virtual void OnStart()
    {
        GUIManager.ShowView(ViewName);
    }
    protected virtual void OnStop()
    {
        GUIManager.HideView(ViewName);
    }
    protected abstract void OnLoadComplete();

}
