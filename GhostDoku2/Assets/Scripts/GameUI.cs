using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject testText;

    public void textFlash()
    {
        StartCoroutine(flashText());
    }

    private IEnumerator flashText()
    {        
        testText.SetActive(true);
        yield return new WaitForSeconds(.25f);
        testText.SetActive(false);
    }
}
