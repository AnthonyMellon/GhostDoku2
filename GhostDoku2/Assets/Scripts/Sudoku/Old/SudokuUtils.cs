using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuUtils : MonoBehaviour
{
    public static int[] board = new int[81];
    private static int sqrtBoardLength = Mathf.RoundToInt(Mathf.Sqrt(board.Length));

    public static bool isSolved()
    {
        //Check if there are any empty squares
        foreach (int i in board)
        {
            if (i == 0) return false;
        }

        //Check if all rows, columns, and boxes contain no duplicates
        //Loop through all numbers in the board, call them i
        for (int i = 0; i < board.Length; i++)
        {
            //Get i's numbers row , col, and box index
            int iRow = getRow(i);
            int iCol = getCol(i);
            int iBox = getBox(i);
            //Loop through all numbers in the board, call them j
            for (int j = 0; j < board.Length; j++)
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
                        if (board[j] == board[i]) return false;
                    }

                }

            }
        }

        return true;
    }

    //Return the row a given index is in
    public static int getRow(int index)
    {
        return Mathf.FloorToInt(index / sqrtBoardLength);
    }

    //Return the column a given index is in
    public static int getCol(int index)
    {
        return index % sqrtBoardLength;
    }

    //Return the box a given index is in

    public static int getBox(int index)
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
    public static bool checkWrong(int index)
    {
        int col = getCol(index);
        int row = getRow(index);
        int box = getBox(index);

        for (int i = 0; i < board.Length; i++)
        {
            if (i != index)
            {
                if (getRow(i) == row || getCol(i) == col || getBox(i) == box)
                {

                    if (board[index] == board[i]) return true;
                }
            }
        }
        return false;
    }
}
