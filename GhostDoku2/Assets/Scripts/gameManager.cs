using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameGrid myGrid;

    [Space]
    [Header("Grid Varibles")]
    public int gridWidth;
    public int gridHeight;
    public float cellWidth;
    public float cellHeight;
    public Vector2 gridOrigin;
    public GameObject CellObj;
    public GameObject gridParent;

    // Start is called before the first frame update
    void Start()
    {
        myGrid = new GameGrid(gridWidth, gridHeight, cellWidth, cellHeight, gridOrigin, CellObj, gridParent);
        myGrid.generate();

        Debug.Log(PathFinder.findPath(myGrid, new Vector2(0, 0), new Vector2(1, 1)));        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
