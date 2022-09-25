using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
    public GameObject PromptUI;
    public StorySO story;
    public GameObject promptLeft;
    public GameObject promptRight;

    public void SpawnPrompt()
    {
        GameObject myPrompt;
        if (story.GetCurrentStoryPoint().rightSidePortrait) myPrompt = promptRight;
        else myPrompt = promptLeft;

        Instantiate(myPrompt, transform);
    }

}
