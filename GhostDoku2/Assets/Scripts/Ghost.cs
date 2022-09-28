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
    public BoolSO gamePaused;
    public Vec2GameEvent cutscene;
    public Animator anim;
    public IntGameEvent spawnPrompt;
    public IntGameEvent enableGhostInteraction;
    public IntGameEvent disableGhostInteraction;
    public StorySO story;

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

        GetComponent<IntGameEventListener>().@event = self.levelEvent;
    }

    void OnEnable()
    {
        UpdateFromSelf();
        cutscene.Raise(transform.position);
    }

    // Update is called once per frame
    void Update()
    {        
        if(!gamePaused.value)
        {
            transform.localPosition = new Vector2(origPos.x + Mathf.Cos(Time.time * horizBobSpeed) * horizBobCap, origPos.y + Mathf.Sin(Time.time * vertBobSpeed) * vertBobCap);
        }
    }

    public void SpawnPrompt()
    {
        if (!currentPrompt)
        {
            currentPrompt = Instantiate(sudokuPromptPrefab, canvasHideable.transform);
            currentPrompt.GetComponent<textPrompt>().parentGhost = self;
        }
    }

    public void UpdateFromSelf()
    {
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

    public void LevelSelf()
    {
        self.IncLevel();
    }

    public void EnableAnimator()
    {
        anim.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (story.GetCurrentStoryPoint().Initiator == self) enableGhostInteraction.Raise(0);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        disableGhostInteraction.Raise(0);
    }
}
