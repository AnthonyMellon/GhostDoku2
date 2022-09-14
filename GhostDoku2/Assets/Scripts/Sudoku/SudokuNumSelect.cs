using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuNumSelect : MonoBehaviour
{
    public IntGameEvent iEvent;
    public int myVal;

    public void Raise()
    {
        iEvent.Raise(myVal);
    }
}
