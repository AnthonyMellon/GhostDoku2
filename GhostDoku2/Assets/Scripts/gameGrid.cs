using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid
{
    public int width;
    public int height;
    private float cellWidth;
    private float cellHeight;
    private Vector2 origin;
    private int fencePad;
    private GameObject CellObj;
    private GameObject gridParent;

    public int nTilesX { get; private set; }        
    public int nTilesY { get; private set; }

    public GameObject[,] cells;
    public TileOverlaySO[,] grid;

    public List<TileOverlaySO> tileOverlays;

    public GameGrid(int width, int height, float cellWidth, float cellHeight, Vector2 origin, int fencePad, GameObject CellObj, GameObject gridParent, List<TileOverlaySO> tileOverlays)
    {
        this.width = width;
        this.height = height;
        this.cellWidth = cellWidth;
        this.cellHeight = cellHeight;
        this.origin = origin;
        this.fencePad = fencePad;
        this.CellObj = CellObj;
        this.gridParent = gridParent;
        this.tileOverlays = tileOverlays;

        nTilesX = width;
        nTilesY = height;
    }

    public void makeGrid()
    {
        grid = new TileOverlaySO[nTilesX, nTilesY];
        for(int x = 0; x < nTilesX; x++)
        {
            for(int y = 0; y < nTilesY; y++)
            {

                if ((y == fencePad || y == nTilesY - 1 - fencePad) && x >= fencePad && x < nTilesX - fencePad) grid[x, y] = grid[x, y] = tileOverlays.Find(to => to.name == "FenceHorizontal");

                else if ((x == fencePad || x == nTilesX - 1 - fencePad) && y >= fencePad && y < nTilesY - fencePad) grid[x, y] = tileOverlays.Find(to => to.name == "FenceVertical");

                else if (x == 19 && y == 4) grid[x, y] = tileOverlays.Find(to => to.name == "HusbandGrave");

                else if (x == 13 && y == 10) grid[x, y] = tileOverlays.Find(to => to.name == "BruceGrave");

                else if (x == 16 && y == 7) grid[x, y] = tileOverlays.Find(to => to.name == "CharlotteGrave");

                else if (x == 4 && y == 6) grid[x, y] = tileOverlays.Find(to => to.name == "EdithGrave");

                else if (x == 9 && y == 4) grid[x, y] = tileOverlays.Find(to => to.name == "JasperGrave");

                else if (x == 7 && y == 10) grid[x, y] = tileOverlays.Find(to => to.name == "MarthaGrave");

                else if (x == 19 && y == 10) grid[x, y] = tileOverlays.Find(to => to.name == "Tree");
                
                else if (x == 1 && y == 5) grid[x, y] = tileOverlays.Find(to => to.name == "Tree");

                else if (x == 5 && y == 1) grid[x, y] = tileOverlays.Find(to => to.name == "Tree2");
            }
        }
    }

    public void generate()
    {
        //Destroy all cells if there are any
        if(cells != null)
        {
            destroyAllCells();
        }

        //Make a fresh array for the new cells
        cells = new GameObject[nTilesX, nTilesY];
        
        //Instantiate the cell objects into the scene and pass them into the cells array
        for(int x = 0; x < nTilesX; x++)
        {
            for(int y = 0; y < nTilesY; y++)
            {
                Vector2 wPos = absoluteToWorld(new Vector2(x, y));
                GameObject currentCellObj = Object.Instantiate(CellObj, new Vector3(wPos.x, wPos.y, 0), new Quaternion(0, 0, 0, 0), gridParent.transform);
                currentCellObj.GetComponent<tile>().normalPosition = new Vector2Int(x, y);
                cells[x, y] = currentCellObj;

                if (grid[x, y] != null)
                {
                    TileOverlaySO currentOverlay = grid[x, y];                    
                    GameObject overlayObj = Object.Instantiate(currentOverlay.overlayObject, currentCellObj.transform);
                    if (currentOverlay.ghostObj && currentOverlay.ghostSO)
                    {
                        GameObject ghost = Object.Instantiate(currentOverlay.ghostObj, overlayObj.transform);
                        ghost.GetComponent<Ghost>().self = currentOverlay.ghostSO;
                        ghost.GetComponent<Ghost>().UpdateFromSelf();
                        overlayObj.GetComponent<Gravestone>().ghost = ghost;
                        overlayObj.GetComponent<SpriteRenderer>().sprite = currentOverlay.sprite;
                    }
                }
            }
        }
    }

    public Vector2 absoluteToWorld(Vector2 aPos)
    {
        Vector2 wPos;
        wPos.x = (aPos.x * cellWidth) + origin.x - (nTilesX / 2);
        wPos.y = (aPos.y * cellHeight) + origin.y - (nTilesY / 2);
        return wPos;
    }

    public Vector2 worldToAbsolute(Vector2 wPos)
    {
        Vector2 aPos;
        aPos.x = (wPos.x - origin.x + (nTilesX / 2)) / cellWidth;
        aPos.y = (wPos.y - origin.y + (nTilesY / 2)) / cellHeight;
        return aPos;
    }

    public void destroyAllCells()
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

