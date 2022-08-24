using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityGameEventListener : MonoBehaviour, IGameEventListener
{
    [Tooltip("Event to register with.")]
    [SerializeField]
    public GameEvent @event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    private UnityEvent response;

    public void OnEnable()
    {
        RegisterSelf();
    }

    public void OnDisable()
    {
        UnregisterSelf();
    }

    public void swapEvent(GameEvent newEvent)
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

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}
