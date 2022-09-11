using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku : MonoBehaviour
{
    public BoolSO gamePaused;
    public IntGameEvent winEvent;
    public EventSequenceSO eventSequence;
    public GhostSO parentGhost;
    public void Win()
    {
        gamePaused.value = false;
        eventSequence.CallCurrentEvent();
        eventSequence.NextEvent();
        //parentGhost.levelEvent.Raise(0);
        
        Destroy(gameObject);
    }
}
