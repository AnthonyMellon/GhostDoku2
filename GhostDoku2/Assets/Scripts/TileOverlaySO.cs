using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "tile overlay", menuName = "ScriptableObjects/TileOverlay/Default", order = -1)]
public class TileOverlaySO : ScriptableObject
{
    public new string name;
    public GameObject overlayObject;
    public GameObject ghostObj;
    public GhostSO ghostSO;
}

