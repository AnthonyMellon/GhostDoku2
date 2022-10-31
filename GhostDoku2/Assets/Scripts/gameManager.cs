using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameGrid myGrid;

    public Sprite pathSprite;
    public GameObject touchIndicator;
    public BoolSO gamePaused;
    public StorySO story;
    public GameObject sudoku;
    public GameObject sudokuParent;

    [Space]
    [Header("Grid Varibles")]
    [Range(1, 100)]
    public int gridWidth;
    private int prevWidth;
    [Range(1, 100)]
    public int gridHeight;
    private int prevHeight;
    public int cellWidth;
    public int cellHeight;
    [Range(0, 15)]
    public int fencePad;
    private int prevPad;
    public Vector2 gridOrigin;
    public GameObject CellObj;
    public GameObject gridParent;

    private List<tile> path;
    public List<TileOverlaySO> tileOverlays;

    // Start is called before the first frame update
    void Start()
    {
        gamePaused.value = true;
    }

    public void ProgressStory()
    {
        story.NextStoryPoint();
    }

    public void LaunchSudoku()
    {
        Instantiate(sudoku, sudokuParent.transform);
    }
}
