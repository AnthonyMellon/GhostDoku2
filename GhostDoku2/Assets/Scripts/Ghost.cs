using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    public GameObject textPrompt;

    // Start is called before the first frame update
    void Start()
    {
        textPrompt = GameObject.Find("TextPrompt");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ShowText("Do you want to play my sudoku?"));
        }
    }

    IEnumerator ShowText(string text)
    {
        textPrompt.GetComponent<Text>().text = text;
        yield return new WaitForSeconds(1);
        textPrompt.GetComponent<Text>().text = "";
    }
}
