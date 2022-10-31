using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource clickSound;

    private void OnEnable()
    {
        clickSound = GameObject.Find("ClickSound").transform.GetComponent<AudioSource>();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void PlayClick()
    {
        clickSound.Play();
    }
    
}
