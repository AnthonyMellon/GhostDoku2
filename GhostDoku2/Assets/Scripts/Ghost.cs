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
    public GhostSO self;

    // Start is called before the first frame update
    void Start()
    {
        canvasHideable = GameObject.Find("Hideable");
        guiManager = GameObject.Find("Canvas_UIoverlay").GetComponent<GameUI>();
        UpdateFromSelf();
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
    }

    public void UpdateFromSelf()
    {
        Debug.Log("Updating from self");
        transform.GetComponent<SpriteRenderer>().sprite = self.sprite;

        UnityGameEventListener listener = transform.parent.GetComponent<UnityGameEventListener>();
        listener.swapEvent(self.levelEvent);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        if(currentPrompt)
            Destroy(currentPrompt.gameObject);
        gameObject.SetActive(false);
    }
}
