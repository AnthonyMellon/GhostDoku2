using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class utils 
{
    public static int yToZIndex(float y)
    {
        return Mathf.RoundToInt(y * -1);
    }
}
