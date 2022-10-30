using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ghost", menuName = "ScriptableObjects/Ghost")]
public class GhostSO : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public IntGameEvent levelEvent;
    public RuntimeAnimatorController animation;
    public int startLevel;
    public int maxLevel;
    public int currentLevel;


    private void OnEnable()
    {
        currentLevel = startLevel;
    }

    public void IncLevel()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
        }
    }
}
