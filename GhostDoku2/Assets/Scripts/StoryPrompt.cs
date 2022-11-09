using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryPrompt : MonoBehaviour
{
    public StorySO myStory;
    public Image portrait;
    public TMP_Text characterName;
    public TMP_Text dialogue;
    public IntGameEvent disableGhostInteraction;
    private AudioSource clickSound;
    public BoolSO paused;

    private void OnEnable()
    {        
        clickSound = GameObject.Find("ClickSound").transform.GetComponent<AudioSource>();
        disableGhostInteraction.Raise(0);
        UpdatePrompt();
        paused.value = true;
    }

    public void UpdatePrompt()
    {
        StoryPointSO currentStoryPoint = myStory.GetCurrentStoryPoint();
        portrait.sprite = currentStoryPoint.portrait;
        characterName.text = currentStoryPoint.character;
        dialogue.text = currentStoryPoint.text;
    }

    public void RunCurrentEvents()
    {
        paused.value = false;
        foreach (IntGameEvent myEvent in myStory.GetCurrentStoryPoint().Events)
        {
            myEvent.Raise(0);
        }
    }

    public void Delete()
    {
        //clickSound.Play();        
        Destroy(gameObject);
    }


    private void Update() //Test stuff
    {
        if (Input.GetKeyDown(KeyCode.U)) UpdatePrompt();
    }
}
