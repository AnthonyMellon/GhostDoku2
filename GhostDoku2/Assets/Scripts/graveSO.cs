using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newGravestone", menuName = "ScriptableObjects/Gravestone")]
public class graveSO : ScriptableObject
{    
    public int maxLevel = 3;
    public int currentLevel = 0;

    public void IncLevel()
    {
        if(currentLevel < maxLevel)
        {
            currentLevel++;
        }
    }
}
