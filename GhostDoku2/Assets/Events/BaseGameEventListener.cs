using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class BaseGameEventListener<T> : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    [SerializeField]
    public GameEvent<T> @event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    private UnityEvent<T> response;

    public void OnEnable()
    {
        RegisterSelf();
    }

    public void OnDisable()
    {
        UnregisterSelf();
    }

    public void swapEvent(GameEvent<T> newEvent)
    {
        UnregisterSelf();
        @event = newEvent;
        RegisterSelf();
    }

    private void RegisterSelf()
    {
        if (@event != null) @event.RegisterListener(this);
    }

    private void UnregisterSelf()
    {
        @event.UnregisterListener(this);
    }

    public void OnEventRaised(T arg)
    {
        response?.Invoke(arg);
    }
}
