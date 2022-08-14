using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class Model
{
    public virtual string Name { get; }
    public virtual void Init()
    {

    }
    protected virtual void OnDataChanged()
    {
    }
}
