using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sudoku : MonoBehaviour
{
    public BoolSO gamePaused;
    public IntGameEvent winEvent;
    public StorySO story;
    public Transform gameGrid;
    public GameObject cellObj;
    public int currentCell;

    [Header("Colors")]
    public Color defaultColor;
    public Color selectedColor;
    public Color highlightedColor;
    public Color wrongColor;

    [Header("Sudoku Variables")]
    public IntSO currentSudoku;
    public IntSO difficulty;
    public bool showWrong;
    public bool highlight = false;

    [Header("Sudoku Files")]
    public TextAsset VeryEasySudokus;
    public TextAsset EasySudokus;
    public TextAsset MediumSudokus;
    public TextAsset HardSudokus;

    private List<SudokuCell> myCells = new List<SudokuCell>();

    private void OnEnable()
    {
        myCells = new List<SudokuCell>();

        string[] sudokuAsStrings;

        //Get sudoku based on difficulty
        switch(difficulty.value)
        {
            case -1:
                sudokuAsStrings = VeryEasySudokus.ToString().Split('\n')[0].Split(',');
                break;
            case 1:
                sudokuAsStrings = MediumSudokus.ToString().Split('\n')[currentSudoku.value].Split(',');
                break;
            case 2:
                sudokuAsStrings = HardSudokus.ToString().Split('\n')[currentSudoku.value].Split(',');
                break;
            default:
                sudokuAsStrings = EasySudokus.ToString().Split('\n')[currentSudoku.value].Split(',');
                break;
        }

        //Make the cells
        for(int i = 0; i < 81; i++)
        {
            int myVal = System.Convert.ToInt16(sudokuAsStrings[i]);

            GameObject myCell = Instantiate(cellObj, gameGrid);
            SudokuCell sCell = myCell.GetComponent<SudokuCell>();
            sCell.id = i;
            sCell.value = myVal;
            if (myVal != 0) myCell.GetComponent<Button>().interactable = false;
            sCell.UpdateText();

            myCells.Add(sCell);
        }

        SetColors();
    }

    public void SetColors()
    {
        foreach(SudokuCell sCell in myCells)
        {
            Button bCell = sCell.transform.GetComponent<Button>();

            sCell.UpdateColor(defaultColor);

            if (showWrong)
            {
                if(sCell.value != 0 && bCell.interactable)
                {
                    if(checkWrong(currentCell)) sCell.UpdateColor(wrongColor);
                }                
            }
            if (highlight)
            {
                if (sCell.id == currentCell) sCell.UpdateColor(selectedColor);
                else if (getRow(sCell.id) == getRow(currentCell)) sCell.UpdateColor(highlightedColor);
                else if (getCol(sCell.id) == getCol(currentCell)) sCell.UpdateColor(highlightedColor);
            }
        }
    }

    public void Win()
    {
        story.NextStoryPoint();
        currentSudoku.value++;

        Exit();
    }

    public void Exit()
    {
        gamePaused.value = false;
        Destroy(gameObject);
    }

    public void SetCurrentCell(int id)
    {
        //Toggle highlight
        if (currentCell == id)
        {
            highlight = !highlight;
        }
        else
        {
            currentCell = id;
            highlight = true;
        }
            

        SetColors();
    }

    public void SetCurrentCellValue(int value)
    {
        myCells[currentCell].value = value;
        myCells[currentCell].UpdateText();

        SetColors();

        if (CheckSolved()) Win();
    }

    public bool CheckSolved()
    {
        //Check if there are any empty squares
        foreach (SudokuCell cell in myCells)
        {
            if (cell.value == 0) return false;
        }

        //Check if all rows, columns, and boxes contain no duplicates
        //Loop through all numbers in the board, call them i
        for (int i = 0; i < myCells.Count; i++)
        {
            //Get i's numbers row , col, and box index
            int iRow = getRow(i);
            int iCol = getCol(i);
            int iBox = getBox(i);
            //Loop through all numbers in the board, call them j
            for (int j = 0; j < myCells.Count; j++)
            {
                //Ensure a cell isnt being compared against itself
                if (j != i)
                {
                    //get j's row, col, and box index
                    int jRow = getRow(j);
                    int jCol = getCol(j);
                    int jBox = getBox(j);
                    //If i and j are in the same row, col, or box
                    if (jRow == iRow || jCol == iCol || jBox == iBox)
                    {
                        //If the number on the board at i and j are the same number return false, the puzzle is not solved
                        if (myCells[j].value == myCells[i].value) return false;
                    }
                }
            }
        }
        return true;
    }

    //Return the row a given index is in
    public int getRow(int index)
    {
        return Mathf.FloorToInt(index / Mathf.Sqrt(myCells.Count));
    }

    //Return the column a given index is in
    public int getCol(int index)
    {
        return Mathf.RoundToInt(index % Mathf.Sqrt(myCells.Count));
    }

    //Return the box a given index is in
    public int getBox(int index)
    {
        //m = number of rows and cols in each box
        int m = 3;
        int result;
        int chunkIndex = index / m;
        int irow = chunkIndex / (m * m);
        int icol = chunkIndex % m;
        result = icol + irow * m;
        return result;
    }
    public bool checkWrong(int index)
    {
        int col = getCol(index);
        int row = getRow(index);
        int box = getBox(index);

        for (int i = 0; i < myCells.Count; i++)
        {
            if (i != index)
            {
                if (getRow(i) == row || getCol(i) == col || getBox(i) == box)
                {
                    if (myCells[index].value == myCells[i].value) return true;
                }
            }
        }
        return false;
    }

}
