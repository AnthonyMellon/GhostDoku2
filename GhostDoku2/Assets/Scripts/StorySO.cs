using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Story/Story")] 
public class StorySO : ScriptableObject
{
    public List<StoryPointSO> storyPoints;

    [SerializeField]private int currentStoryPoint = 0;

    private void OnEnable()
    {
        currentStoryPoint = 0;
    }

    public bool NextStoryPoint() //Change current stroy point to the next story point, return true if successfull
    {
        if (currentStoryPoint >= storyPoints.Count - 1) return false;

        currentStoryPoint++;
        return true;
    }

    public StoryPointSO GetCurrentStoryPoint()
    {
        return storyPoints[currentStoryPoint];
    }
}
