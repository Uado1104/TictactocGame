using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMono<T> : MonoBehaviour
    where T : MonoBehaviour
{
    protected static T m_instance = null;
    public static T GetInstance()
    {
        return m_instance;
    }
    protected virtual void Awake()
    {
        m_instance = this as T;
    }
    
}

public abstract class Singleton<T>  where T : new()
{
    protected static T m_instance;
    public static T GetInstance()
    {
        if(m_instance == null)
        {
            m_instance = new T();
        }
        return m_instance;
    }

}
