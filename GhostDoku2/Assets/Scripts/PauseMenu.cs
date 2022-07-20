using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void goToMainMenu() 
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
