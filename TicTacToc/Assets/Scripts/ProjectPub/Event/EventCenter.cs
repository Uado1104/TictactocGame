using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public interface IEventInfo{ }

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}
public class EventCenter : Singleton<EventCenter>
{
    private Dictionary<string, IEventInfo> m_eventDic = new Dictionary<string, IEventInfo>();

    /// <summary>
    /// Ìí¼ÓÊÂ¼þ¼àÌý
    /// </summary>
    public void AddEventListener<T>(string name, UnityAction<T> action) 
    {
        if (m_eventDic.ContainsKey(name))
        {
            (m_eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            m_eventDic.Add(name, new EventInfo<T>(action));
        }
    }

    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (m_eventDic.ContainsKey(name))
        {
            (m_eventDic[name] as EventInfo<T>).actions -= action;
        }
    }

    public void EventTrigger<T>(string name, T info)
    {
        if (m_eventDic.ContainsKey(name))
            (m_eventDic[name] as EventInfo<T>).actions.Invoke(info);
    }

}
