using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Grid/Gird Settings")]
public class GridSettingsSO : ScriptableObject
{
    public Vector2 stepSize;
    public Vector2 offset;
}
