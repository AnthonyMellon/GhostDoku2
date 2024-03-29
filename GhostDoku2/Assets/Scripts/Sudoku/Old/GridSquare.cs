using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GridSquare : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    Image image;
    Text text;

    public GameObject number_text;
    private int number_ = 0;
    public GameObject gridBox;

    private bool newGame = true;

    private bool selected_ = false;
    private int square_index_ = -1;
    public bool has_default_value_ = false;
    public bool isWrong = false;

    public void SetHasDefaultValue(bool has_default)
    {
        has_default_value_ = has_default;
    }
    public bool GetHasDefaultValue()
    {
        return has_default_value_;
    }
    public bool IsSelected() { return selected_; }
    public void setSquareIndex(int index)
    {
        square_index_ = index;
    }
    public void Start()
    {
        newGame = true;
        image = gridBox.transform.Find("Image").GetComponent<Image>(); //The image component of the selected cell
        text = gridBox.transform.Find("Text").GetComponent<Text>();
        selected_ = false;
        if (has_default_value_)
        {
            image.color = new Color(0.35f, 0.35f, 0.35f, 1f); //Gray
            text.color = new Color(0.1f, 0.1f, 0.1f, 1f);
        }
        else
        {
            image.color = new Color(1f, 1f, 1f, 0.0f); //White
            text.color = new Color(0.46f, 0.78f, 0.73f, 1f);
        }
    }
    public void DisplayText()
    {
        if (number_ <= 0)
        {
            number_text.GetComponent<Text>().text = "";
        }

        else
        {
            number_text.GetComponent<Text>().text = number_.ToString();
        }


    }
    public void SetNumber(int number)
    {
        if (has_default_value_ == false)
        {
            //Update the array representing the sudoku board
            SudokuUtils.board[square_index_] = number;

            number_ = number;
            DisplayText();

            //Check if the sudoku has been solved
            print($"Board is solved: {SudokuUtils.isSolved()}");
            if (SudokuUtils.isSolved() && !newGame)
            {
                //GameObject.Find("gameManager").GetComponent<GameSettings>().restorationLevel++;
                Time.timeScale = 0f;
                transform.root.GetComponent<SudokuGrid>().winScreen.SetActive(true);

                Transform timer = transform.root.Find("Timer");

                timer.SetParent(transform.root.GetComponent<SudokuGrid>().winScreen.transform);
                timer.GetComponent<RectTransform>().anchoredPosition = new Vector2(-455, -455);
            }
        }

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        newGame = false;
        selected_ = true;
        GameEvents.SquareSelectedMethod(square_index_);
    }
    public void OnSubmit(BaseEventData eventData)
    {

    }
    private void OnEnable()
    {
        GameEvents.OnUpdateSquareNumber += OnSetNumber;
        GameEvents.OnSquareSelected += OnSquareSelected;
    }
    private void OnDisable()
    {
        GameEvents.OnUpdateSquareNumber -= OnSetNumber;
        GameEvents.OnSquareSelected -= OnSquareSelected;
    }
    public void OnSetNumber(int number)
    {
        if (selected_)
        {
            SetNumber(number);
            if (SudokuUtils.checkWrong(square_index_))
            {
                isWrong = true;
            }
            else
            {
                isWrong = false;
            }

        }
    }
    public void OnSquareSelected(int sqaure_index)
    {
        //If this is not the selected cell
        if (square_index_ != sqaure_index)
        {
            selected_ = false;
        }

        cellColours(sqaure_index);
    }

    private void cellColours(int squareIndex)
    {
        int myRow = SudokuUtils.getRow(squareIndex); //The row of the selected cell
        int myCol = SudokuUtils.getCol(squareIndex); //The col of the selected cell

        bool defaultCell = transform.parent.Find($"Cell {squareIndex}").GetComponent<GridSquare>().has_default_value_;
        Transform parent = transform.root;
        if (has_default_value_)
        {
            image.color = new Color(0.35f, 0.35f, 0.35f, 1f); //Gray
            text.color = new Color(0.1f, 0.1f, 0.1f, 1f);

        }
        else if (isWrong)
        {
            image.color = new Color(1f, 0f, 0f, 0.6f); //White
            text.color = new Color(0.46f, 0.78f, 0.73f, 1f);
        }
        else
        {
            image.color = new Color(1f, 1f, 1f, 0f); //White
            text.color = new Color(0.46f, 0.78f, 0.73f, 1f);
        }


        //If this is not the selected cell
        if (square_index_ != squareIndex)
        {
            if (!defaultCell)
            {
                if (myRow == SudokuUtils.getRow(square_index_) || myCol == SudokuUtils.getCol(square_index_)) //If this cell is in the same row or col as the selected cell
                {
                    //If there is a default value for this cell
                    if (has_default_value_)
                    {
                        image.color = new Color(0.6f, 0.9f, 0.8f, 0.5f); //Dark-Yellow    
                    }
                    else
                    {
                        image.color = new Color(0.46f, 0.78f, 0.73f, 0.5f); //Yellow    
                    }

                }
            }
        }

        //If this is the selected cell
        else
        {
            if (!defaultCell)
            {
                image.color = new Color(0.4f, 0.8f, 0.5f, 0.5f);//Pale-Yellow
            }
        }
    }
}
