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

    [Header("Bob Controls")]
    public float horizBobSpeed;
    public float vertBobSpeed;
    public float horizBobCap;
    public float vertBobCap;

    private Vector2 origPos;

    // Start is called before the first frame update
    void Start()
    {
        canvasHideable = GameObject.Find("Hideable");
        guiManager = GameObject.Find("Canvas_UIoverlay").GetComponent<GameUI>();

        origPos = transform.localPosition;
    }

    void OnEnable()
    {
        UpdateFromSelf();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(origPos.x + Mathf.Cos(Time.time * horizBobSpeed) * horizBobCap, origPos.y + Mathf.Sin(Time.time * vertBobSpeed) * vertBobCap);
        
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
        transform.GetComponent<SpriteRenderer>().sprite = self.sprite;

        IntGameEventListener listener = transform.parent.GetComponent<IntGameEventListener>();
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
