using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Articles/Article")]
public class ArticleSO : ScriptableObject
{
    public string headline;
    public string blurb;
    public Sprite image;
}
