using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public StorySO story;
    public void goToMainMenu() 
    {
        story.SetCurrentStoryPoint(0);
        SceneManager.LoadScene("MainMenuScene");
    }
}
