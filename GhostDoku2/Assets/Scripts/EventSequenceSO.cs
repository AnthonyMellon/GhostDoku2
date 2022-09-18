using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "eventSequence", menuName = "Events/Event Sequence", order = -1)]
public class EventSequenceSO : ScriptableObject
{
    public List<IntGameEvent> events;
    public int currentEvent = 0;

    private void OnEnable()
    {
        currentEvent = 0;
    }

    public void CallCurrentEvent()
    {
        events[currentEvent].Raise(0);
    }

    public void NextEvent()
    {
        currentEvent++;
    }
}
