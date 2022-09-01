using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ghost", menuName = "ScriptableObjects/Ghost")]
public class GhostSO : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public IntGameEvent levelEvent;
}
