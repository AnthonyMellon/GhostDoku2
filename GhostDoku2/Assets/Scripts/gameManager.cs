using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameGrid myGrid;

    public Sprite pathSprite;
    public GameObject touchIndicator;
    public BoolSO gamePaused;

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
        gamePaused.value = false;
        myGrid = new GameGrid(gridWidth, gridHeight, cellWidth, cellHeight, gridOrigin, fencePad, CellObj, gridParent, tileOverlays);
        myGrid.makeGrid();
        myGrid.generate();
    }

    // Update is called once per frame
    void Update()
    {
        if(prevWidth != gridWidth || prevHeight != gridHeight || prevPad != fencePad)
        {
            myGrid.destroyAllCells();
            myGrid = new GameGrid(gridWidth, gridHeight, cellWidth, cellHeight, gridOrigin, fencePad, CellObj, gridParent, tileOverlays);
            myGrid.makeGrid();
            myGrid.generate();
        }

        prevWidth = gridWidth;
        prevHeight = gridHeight;
        prevPad = fencePad;
    }

    private IEnumerator pathAnimate(List<tile> path)
    {
        foreach (tile step in path)
        {
            step.gameObject.GetComponent<SpriteRenderer>().sprite = pathSprite;
            yield return new WaitForSeconds(.1f);
        }        
    }
}
