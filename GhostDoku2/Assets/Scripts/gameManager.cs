using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private gameGrid myGrid;

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
        myGrid = new gameGrid(gridWidth, gridHeight, cellWidth, cellHeight, gridOrigin, CellObj, gridParent);
        myGrid.generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
