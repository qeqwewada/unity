using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCenter
{
    public static EventCenter instance;
    public static EventCenter Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventCenter();
            }
            return instance;
        }
    }
    Dictionary<string, IEvent> eventDic = new Dictionary<string, IEvent>();
    public void AddEventListener(string eventName, UnityAction action)
    {   
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as Event).actions += action;
        }
        else
        {
            eventDic.Add(eventName, new Event(action));
        }
    }
    public void AddEventListener<T>(string eventName, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as Event<T>).actions += action;
        }
        else
        {
            eventDic.Add(eventName, new Event<T>(action));
        }
    }
    public void RemoveEventListener(string eventName, UnityAction action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as Event).actions -= action;
        }
    }
    public void RemoveEventListener<T>(string eventName, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as Event<T>).actions -= action;
        }
    }   
    public void DispatchEvent(string eventName)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as Event).actions.Invoke();
        }
    }
    public void DispatchEvent<T>(string eventName, T arg)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as Event<T>).actions.Invoke(arg);
        }
    }
    
}

public interface IEvent
{

}

public class Event : IEvent
{
    public UnityAction actions;
    public Event(UnityAction action)
    {
        actions = action;
    }
}

public class Event<T> : IEvent
{
    public UnityAction<T> actions;
    public Event(UnityAction<T> action)
    {
        actions = action;
    }
}

