using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class View : MonoBehaviour

{
    public abstract string Name { get; }
    public virtual void Init()
    { }
    public virtual void Refresh()
    { }
    public GameObject GameObject;
}
