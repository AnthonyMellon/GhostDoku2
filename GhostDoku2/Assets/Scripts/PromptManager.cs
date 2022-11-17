using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PromptManager : MonoBehaviour
{
    public GameObject PromptUI;
    public StorySO story;
    public GameObject promptLeft;
    public GameObject promptRight;
    [Header("Character prompts (temporary and hacky)")]
    public GameObject georgePrompt;
    public GameObject charlottePrompt;
    public GameObject brucePrompt;
    public GameObject jasperPrompt;
    public GameObject marthaPrompt;
    public GameObject edithPrompt;



    public void SpawnPrompt()
    {
        GameObject myPrompt;
        if (story.GetCurrentStoryPoint().rightSidePortrait) myPrompt = promptRight;
        else myPrompt = promptLeft;

        Instantiate(myPrompt, transform);
    }
     
    public void SpawnDefaultPrompt(string characterName)
    {
        //This is gonna be very hacky
        GameObject myPrompt;
        Debug.Log(characterName);

        switch (characterName)
        {
            case "Charlotte":                
                myPrompt = charlottePrompt;
                break;
            case "Bruce":
                myPrompt = brucePrompt;
                break;
            case "Jasper":
                myPrompt = jasperPrompt;
                break;
            case "Martha":
                myPrompt = marthaPrompt;
                break;
            case "Edith":
                myPrompt = edithPrompt;
                break;
            default: // <- this will be george
                myPrompt = georgePrompt;
                break;
        }

        Instantiate(myPrompt, transform);
    }

}
