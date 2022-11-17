using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SudokuCell : MonoBehaviour
{
    public IntGameEvent iEvent;
    public int id;
    public IntSO currentCell;
    public bool showID;
    public int value;

    public void UpdateText()
    {
        TMP_Text mText = transform.GetChild(0).GetComponent<TMP_Text>();

        mText.text = $"{(value == 0 ? null : value)}";
        if (showID) mText.text = $"{mText.text}\n({id})";

    }

    public void UpdateColor(Color enabledColor, Color disabledColor)
    {
        transform.GetComponent<Image>().color = enabledColor;
        transform.GetComponent<Button>().colors = new ColorBlock
        {
            normalColor = enabledColor,
            highlightedColor = new Color(0, 0, 0, 0),
            pressedColor = new Color(0, 0, 0, 0),
            selectedColor = enabledColor,
            disabledColor = disabledColor,
            colorMultiplier = 1,
            fadeDuration = .1f
        };
    }

    public void Toggle()
    {
        if (id == currentCell.value) iEvent.Raise(-1);
        else iEvent.Raise(id);
    }
}
