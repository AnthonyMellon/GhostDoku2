using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject pauseMenu;
    
    public void togglePause()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
}
