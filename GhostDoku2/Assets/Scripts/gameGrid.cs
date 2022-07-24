using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid
{
    private int width;
    private int height;
    private float cellWidth;
    private float cellHeight;
    private Vector2 origin;
    private GameObject CellObj;
    private GameObject gridParent;

    public GameObject[,] cells;

    public GameGrid(int width, int height, float cellWidth, float cellHeight, Vector2 origin, GameObject CellObj, GameObject gridParent)
    {
        this.width = width;
        this.height = height;
        this.cellWidth = cellWidth;
        this.cellHeight = cellHeight;
        this.origin = origin;
        this.CellObj = CellObj;
        this.gridParent = gridParent;
    }

    public void generate()
    {
        //Destroy all cells if there are any
        if(cells != null)
        {
            destroyAllCells();
        }

        //Make a fresh array for the new cells
        int nTilesX = Mathf.CeilToInt(width / cellWidth);
        int nTilesY = Mathf.CeilToInt(height / cellHeight);
        cells = new GameObject[nTilesX, nTilesY];
        
        //Instantiate the cell objects into the scene and pass them into the cells array
        for(int x = 0; x < nTilesX; x++)
        {
            for(int y = 0; y < nTilesY; y++)
            {
                float posX = (x + origin.x) - (nTilesX / 2);
                float posY = (y + origin.y) - (nTilesY / 2);

                GameObject currentCellObj = Transform.Instantiate(CellObj, new Vector3(posX, posY, 0), new Quaternion(0, 0, 0, 0), gridParent.transform);                   
                currentCellObj.transform.localScale = new Vector3(cellWidth, cellHeight, 1);
                currentCellObj.GetComponent<tile>().normalPosition = new Vector2Int(x, y);
                cells[x, y] = currentCellObj;
            }
        }
    }

    private void destroyAllCells()
    {
        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                Object.Destroy(cells[x, y]);
            }
        }
    }
}

