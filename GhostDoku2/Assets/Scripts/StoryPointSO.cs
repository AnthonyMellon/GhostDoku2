using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Story/Stroy Point")]
public class StoryPointSO : ScriptableObject
{
    public string character;
    public string description;

    [Header("Portrait")]
    public Sprite portrait;
    public bool rightSidePortrait;
    [TextArea] public string text;

    [Header("Events to Trigger")]
    public List<IntGameEvent> Events;
}
