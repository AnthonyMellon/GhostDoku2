using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameGrid myGrid;

    public Sprite goodSprite;
    public Sprite redSprite;

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

        //List<tile> path = PathFinder.findPath(myGrid, new Vector2Int(0, 0), new Vector2Int(1, 5), gridWidth, gridHeight, redSprite);
        //StartCoroutine(pathAnimate(path));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator pathAnimate(List<tile> path)
    {
        foreach (tile step in path)
        {
            step.gameObject.GetComponent<SpriteRenderer>().sprite = goodSprite;
            Debug.Log("Displaying part of the path!");
            yield return new WaitForSeconds(.5f);
        }        
    }
}
