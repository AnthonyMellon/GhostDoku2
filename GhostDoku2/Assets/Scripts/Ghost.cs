using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    private GameObject canvasHideable;
    [SerializeField] private GameObject sudokuPromptPrefab;
    private GameObject currentPrompt;
    public GameObject sudoku;
    private GameUI guiManager;
    public GameEvent levelEvent;
    public int currentLevel = 0;

    public bool increaseLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasHideable = GameObject.Find("Hideable");
        guiManager = GameObject.Find("Canvas_UIoverlay").GetComponent<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!currentPrompt)
            {
                currentPrompt = Instantiate(sudokuPromptPrefab, canvasHideable.transform);
            }
        }

        if(increaseLevel)
        {
            levelUp();
            increaseLevel = false;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        Destroy(currentPrompt.gameObject);
        gameObject.SetActive(false);
    }

    public void levelUp()
    {
        currentLevel++;
        levelEvent.Raise();
    }
}
