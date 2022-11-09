using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Sudoku : MonoBehaviour
{
    public BoolSO gamePaused;
    public IntGameEvent winEvent;
    public StorySO story;
    public Transform gameGrid;
    public GameObject cellObj;
    //private int currentCell = -1;
    public IntSO currentCell;
    public IntGameEvent enableGhostInteraction;
    public IntGameEvent storyPromptEvent;
    public AudioSource writeSound;
    public AudioSource clickSound;
    public List<SudokuNumSelect> numButtons;

    [Header("Articles")]
    public ArticleListSO articleList;
    public TMP_Text Header;
    public TMP_Text Body;
    public Image image;

    [Header("Background Colours")]
    public Color defaultColor;
    public Color selectedColor;
    public Color highlightedColor;
    public Color wrongColor;

    [Header("Text Colours")]
    public Color preFilledText;
    public Color playerFilledText;

    [Header("Text Fonts")]
    public TMP_FontAsset playerFilledFont;
    public TMP_FontAsset preFilledFont;

    [Header("Sudoku Variables")]
    public IntSO currentSudoku;
    public IntSO difficulty;
    public bool showWrong;
    private bool highlight = false;

    [Header("Sudoku Files")]
    public TextAsset VeryEasySudokus;
    public TextAsset EasySudokus;
    public TextAsset MediumSudokus;
    public TextAsset HardSudokus;

    private List<SudokuCell> myCells = new List<SudokuCell>();

    private void OnEnable()
    {
        SetCurrentCell(-1);
        Debug.Log($"Current Cell: {currentCell}");

        gamePaused.value = true;
        myCells = new List<SudokuCell>();
        clickSound = GameObject.Find("ClickSound").transform.GetComponent<AudioSource>();

        //Setup the article
        Header.text = articleList.articles[articleList.currentArticle].headline;
        string newBody =  articleList.articles[articleList.currentArticle].blurb + Body.text;
        Body.text = newBody;
        image.sprite = articleList.articles[articleList.currentArticle].image;


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
        for(int i = 0; i < sudokuAsStrings.Length; i++)
        {
            int myVal = System.Convert.ToInt16(sudokuAsStrings[i]);

            GameObject myCell = Instantiate(cellObj, gameGrid);
            SudokuCell sCell = myCell.GetComponent<SudokuCell>();
            sCell.id = i;
            sCell.value = myVal;

            if (myVal != 0)
            {
                myCell.GetComponent<Button>().interactable = false;
                myCell.transform.Find("Text (TMP)").GetComponent<TMP_Text>().color = preFilledText;
                myCell.transform.Find("Text (TMP)").GetComponent<TMP_Text>().font = preFilledFont;
                myCell.transform.GetComponent<SudokuCell>().UpdateColor(defaultColor); 
            }
            else
            {
                myCell.transform.Find("Text (TMP)").GetComponent<TMP_Text>().color = playerFilledText;
                myCell.transform.Find("Text (TMP)").GetComponent<TMP_Text>().font = playerFilledFont;
                myCell.transform.GetComponent<SudokuCell>().UpdateColor(new Color(0, 0, 0, 0));
            }
                
            sCell.UpdateText();

            myCells.Add(sCell);
        }

        Hint();
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
                    if(checkWrong(currentCell.value, -1)) sCell.UpdateColor(wrongColor);
                }                
            }
            if (highlight)
            {
                if (sCell.id == currentCell.value) sCell.UpdateColor(selectedColor);
                else if (getRow(sCell.id) == getRow(currentCell.value)) sCell.UpdateColor(highlightedColor);
                else if (getCol(sCell.id) == getCol(currentCell.value)) sCell.UpdateColor(highlightedColor);
            }
        }
    }

    public void Win()
    {
        story.NextStoryPoint();
        storyPromptEvent.Raise(0);
        currentSudoku.value++;
        articleList.currentArticle += 1;

        Destroy(gameObject);        
    }

    public void Exit()
    {
        gamePaused.value = false;
        Destroy(gameObject);
        //StartCoroutine(ExitSequence());
    }

    public IEnumerator ExitSequence()
    {
        yield return new WaitForSeconds(.2f);


    }

    public void SetCurrentCell(int id)
    {
        //Toggle highlight
        if (currentCell.value == id)
        {
            highlight = !highlight;
        }
        else
        {
            currentCell.value = id;
            highlight = true;
        }

        UpdateButtons();
        SetColors();
    }

    public void SetCurrentCellValue(int value)
    {
        if (currentCell.value == -1) return;

        myCells[currentCell.value].value = value;
        myCells[currentCell.value].UpdateText();

        SetColors();

        if (CheckSolved()) Win();
    }

    public void UpdateButtons()
    {
        if (currentCell.value == -1)
        {
            foreach(SudokuNumSelect sns in numButtons)
            {
                sns.Disable();
            }
        }
        else //If a cell is selected
        {
            foreach (SudokuNumSelect sns in numButtons)
            {
                if (checkWrong(currentCell.value, sns.myVal)) sns.Disable();
                else sns.Enable();
            }
        }
    }

    public void Hint()
    {
        var results = myCells.Where(o => o.value == 0).ToList();
        int rand = Random.Range(0, results.Count());


        Debug.Log(results[rand]);
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
    public bool checkWrong(int index, int overrideValue)
    {
        int col = getCol(index);
        int row = getRow(index);
        int box = getBox(index);

        int checkVal;
        if (overrideValue == -1) checkVal = myCells[index].value;
        else checkVal = overrideValue;


        for (int i = 0; i < myCells.Count; i++)
        {
            if (i != index && checkVal != 0)
            {
                if (getRow(i) == row || getCol(i) == col || getBox(i) == box)
                {                    
                    if (checkVal == myCells[i].value)
                    {
                        //Debug.Log($"Found same value at indexes {index} and {i} of values {myCells[index].value} and {myCells[i].value}");
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void PlayClick()
    {
        clickSound.Play();
    }

    public void PlayWriteSound()
    {
        StartCoroutine(WriteSoundIEnum());
    }

    public IEnumerator WriteSoundIEnum()
    {
        writeSound.mute = false;
        yield return new WaitForSeconds(1);
        writeSound.mute = true;
    }

}
