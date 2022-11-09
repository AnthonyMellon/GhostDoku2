using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ghostInteraction : MonoBehaviour
{
    public bool interactable { get; set; }
    private PromptManager promptManager;
    private AudioSource clickSound;
    public SpriteRenderer interactableAlert;

    private void Start()
    {
        promptManager = GameObject.Find("Canvas_UIoverlay").transform.GetComponent<PromptManager>();
        clickSound = GameObject.Find("ClickSound").transform.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (interactable) interactableAlert.color = new Color(interactableAlert.color.r, interactableAlert.color.g, interactableAlert.color.b, 1);
        else interactableAlert.color = new Color(interactableAlert.color.r, interactableAlert.color.g, interactableAlert.color.b, .5f);
    }

    private void OnMouseDown()
    {
        if(interactable)
        {
            clickSound.Play();
            promptManager.SpawnPrompt();
        }
    }  
}
