using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Articles/Article List")]
public class ArticleListSO : ScriptableObject
{
    public List<ArticleSO> articles;
    public int currentArticle;

    private void OnEnable()
    {
        currentArticle = 0;
    }
}
