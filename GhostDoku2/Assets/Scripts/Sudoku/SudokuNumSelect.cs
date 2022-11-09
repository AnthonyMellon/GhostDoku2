using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SudokuNumSelect : MonoBehaviour
{
    public IntGameEvent iEvent;
    public int myVal;
    public Button myButton;

    public void Raise()
    {
        iEvent.Raise(myVal);
    }

    public void Disable()
    {
        myButton.interactable = false;
    }

    public void Enable()
    {
        myButton.interactable = true;
    }
}
