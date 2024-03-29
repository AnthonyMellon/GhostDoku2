using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SudokuGrid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public int numRemoved = 2;
    public float everySquareOffset = 0.0f;
    public Vector2 startPos = new Vector2(0.0f, 0.0f);
    public GameObject gridSquare;
    public float squareScale = 1.0f;
    [Range(0, 100)]
    public int currentSudoku = 0;
    [Range(1, 4)]
    public int difficulty = 4;

    [Range(0, 150)]
    public int smallOffset;
    [Range(0, 150)]
    public int bigOffset;

    public TextAsset easySudokus;
    public TextAsset medSudokus;
    public TextAsset hardSudokus;

    public GameObject tileParent;

    public TextAsset veryEasy;
    private List<GameObject> gridSquares = new List<GameObject>();

    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (gridSquare.GetComponent<GridSquare>() == null)
            Debug.LogError("gridSquare object neds to have GridSquare script attatched");
        CreateGrid();
        SetGridNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetGridNumbers();
        }

        SetSquarePos();

    }

    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquarePos();
    }

    private void SpawnGridSquares()
    {
        print(SudokuUtils.board.Length);
        int square_index = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                gridSquares.Add(Instantiate(gridSquare) as GameObject);
                gridSquares[gridSquares.Count - 1].GetComponent<GridSquare>().setSquareIndex(square_index);
                gridSquares[gridSquares.Count - 1].transform.parent = this.transform;
                gridSquares[gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);
                gridSquares[gridSquares.Count - 1].transform.name = $"Cell {square_index}";
                gridSquares[gridSquares.Count - 1].transform.parent = tileParent.transform;
                square_index++;
            }

        }
    }

    private void SetSquarePos()
    {
        var squareRect = gridSquares[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        offset.x = squareRect.rect.width * squareRect.transform.localScale.x + everySquareOffset;
        offset.y = squareRect.rect.height * squareRect.transform.localScale.y + everySquareOffset;



        int columnNum = 0;
        int rowNum = 0;
        int index = 0;
        foreach (GameObject square in gridSquares)
        {
            int myRow = SudokuUtils.getRow(index);
            int boxRow = Mathf.FloorToInt(myRow / 3);
            int myCol = SudokuUtils.getCol(index);
            int boxCol = Mathf.FloorToInt(myCol / 3);

            square.GetComponent<RectTransform>().anchoredPosition = new Vector3(startPos.x + (myCol * smallOffset) + (boxCol * bigOffset), startPos.y + (myRow * smallOffset) + (boxRow * bigOffset));
            index++;
        }
    }
    private void SetGridNumbers()
    {
        currentSudoku = Random.Range(0, 100);
        //difficulty = GameObject.Find("gameManager").GetComponent<GameSettings>().restorationLevel + 1;
        difficulty = 1;
        string[] sudokuAsStrings;
        /*        difficulty = 0;
                currentSudoku = 0;*/
        if (difficulty == 1)
        {
            sudokuAsStrings = easySudokus.ToString().Split('\n')[currentSudoku].Split(',');
        }
        else if (difficulty == 2)
        {
            sudokuAsStrings = medSudokus.ToString().Split('\n')[currentSudoku].Split(',');
        }
        else if (difficulty == 3)
        {
            sudokuAsStrings = hardSudokus.ToString().Split('\n')[currentSudoku].Split(',');
        }
        else
        {
            sudokuAsStrings = veryEasy.ToString().Split('\n')[currentSudoku].Split(',');
        }
        int[] gridNums = new int[sudokuAsStrings.Length];
        for (int i = 0; i < sudokuAsStrings.Length; i++)
        {
            gridNums[i] = System.Convert.ToInt16(sudokuAsStrings[i]);
        }

        //gridNums = sodokuGeneratorScript.getSudoku(columns, numRemoved);        

        for (int j = 0; j < 81; j++)
        {
            gridSquares[j].GetComponent<GridSquare>().SetNumber(gridNums[j]);
            if (gridNums[j] != 0)
            {
                gridSquares[j].GetComponent<GridSquare>().SetHasDefaultValue(true);
                gridSquares[j].transform.Find("Image").GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 0.5f); //Set the color to gray
            }
        }
    }
}
