using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBlocker : MonoBehaviour
{
    public Vector2 myPosition;
    public List<Vector2> relativeTilesBlocked;

    private gameManager manager;
    private GameGrid grid;

    public bool setupComplete = false;

    private void Start()
    {
        if(!setupComplete) Setup();   
        BlockTiles();
    }

    public void Setup()
    {
        manager = GameObject.Find("GameManager").GetComponent<gameManager>();
        grid = manager.myGrid;
        myPosition = grid.worldToAbsolute(transform.position);

        setupComplete = true;
    }

    public void BlockTiles()
    {      
        foreach(Vector2 tilePos in relativeTilesBlocked)
        {
            Vector2 pos = tilePos + myPosition;
            grid.cells[(int)pos.x, (int)pos.y].tag = "tile_nonWalkable";
        }
    }

    public void UnBlockTiles()
    {
        foreach (Vector2 tilePos in relativeTilesBlocked)
        {
            Vector2 pos = tilePos + myPosition;
            grid.cells[(int)pos.x, (int)pos.y].tag = "tile_walkable";
        }
    }


}
