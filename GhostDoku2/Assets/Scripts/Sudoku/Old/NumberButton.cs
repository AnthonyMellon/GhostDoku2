using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NumberButton : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //GameEvents.updateSquareNumberMethod(value);
    }
    public void OnSubmit(BaseEventData eventData)
    {

    }
}
