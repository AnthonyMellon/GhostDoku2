using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityGameEventListener : MonoBehaviour, IGameEventListener
{
    [Tooltip("Event to register with.")]
    [SerializeField]
    private GameEvent @event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    private UnityEvent response;

    public void OnEnable()
    {
        if (@event != null) @event.RegisterListener(this);
    }

    public void OnDisable()
    {
        @event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}
