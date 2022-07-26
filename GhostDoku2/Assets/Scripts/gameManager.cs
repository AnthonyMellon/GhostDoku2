using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameGrid myGrid;

    public Sprite pathSprite;
    public Sprite whiteSprite;

    [Space]
    [Header("Grid Varibles")]
    public int gridWidth;
    public int gridHeight;
    public float cellWidth;
    public float cellHeight;
    public Vector2 gridOrigin;
    public GameObject CellObj;
    public GameObject gridParent;

    private List<tile> path;

    // Start is called before the first frame update
    void Start()
    {
        myGrid = new GameGrid(gridWidth, gridHeight, cellWidth, cellHeight, gridOrigin, CellObj, gridParent);
        myGrid.generate();

        path = PathFinder.FindPath(0, 0, 2, 6, myGrid);
        Debug.Log(path.Count);
        StartCoroutine(pathAnimate(path));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            foreach(tile tile in path)
            {
                if(tile.gameObject.tag == "tile_walkable") tile.gameObject.GetComponent<SpriteRenderer>().sprite = whiteSprite;
            }

            path = PathFinder.FindPath(0, 0, 2, 6, myGrid);
            StartCoroutine(pathAnimate(path));
        }
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
