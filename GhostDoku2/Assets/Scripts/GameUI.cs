using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject testText;
    public GameObject hideable;
    public BoolSO paused;

    public void textFlash()
    {
        StartCoroutine(flashText());
    }

    private void Update()
    {
        if (paused.value == true) hideable.SetActive(false);
        else hideable.SetActive(true);
    }

    private IEnumerator flashText()
    {        
        testText.SetActive(true);
        yield return new WaitForSeconds(.25f);
        testText.SetActive(false);
    }
}
