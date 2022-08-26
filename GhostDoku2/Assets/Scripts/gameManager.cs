using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameGrid myGrid;

    public Sprite pathSprite;
    public GameObject touchIndicator;

    [Space]
    [Header("Grid Varibles")]
    public int gridWidth;
    public int gridHeight;
    public int cellWidth;
    public int cellHeight;
    public Vector2 gridOrigin;
    public GameObject CellObj;
    public GameObject gridParent;

    private List<tile> path;
    public List<TileOverlaySO> tileOverlays;

    // Start is called before the first frame update
    void Start()
    {
        myGrid = new GameGrid(gridWidth, gridHeight, cellWidth, cellHeight, gridOrigin, CellObj, gridParent, tileOverlays);
        myGrid.makeGrid();
        myGrid.generate();
    }

    // Update is called once per frame
    void Update()
    {

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
