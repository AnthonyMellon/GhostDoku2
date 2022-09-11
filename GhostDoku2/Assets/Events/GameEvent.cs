using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvent<T> : ScriptableObject
{
    [SerializeField]
    private readonly List<BaseGameEventListener<T>> m_eventListeners = new List<BaseGameEventListener<T>>();

    public void Raise(T arg)
    {
        for(int i = m_eventListeners.Count - 1; i >= 0; i--)
        {
            m_eventListeners[i].OnEventRaised(arg);
        }
    }

    public void RegisterListener(BaseGameEventListener<T> listener)
    {
        if (!m_eventListeners.Contains(listener))
            m_eventListeners.Add(listener);
    }

    public void UnregisterListener(BaseGameEventListener<T> listener)
    {
        if (m_eventListeners.Contains(listener))
            m_eventListeners.Remove(listener);
    }
}
