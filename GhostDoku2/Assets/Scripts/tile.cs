using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tile : MonoBehaviour
{
    public Sprite walkableSprite;
    public Sprite wallSprite;
    public Sprite startSprite;
    public Sprite endSprite;
    public GameObject[] gravestones;

    //Values used for path finding    
    [HideInInspector] public int f = 0;
    [HideInInspector] public int g = 0;
    [HideInInspector] public int h = 0;
    [HideInInspector] public Vector2Int normalPosition;
    public tile parent;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();        
    }

    private void Update()
    {
    }

    public void calcFCost()
    {
        f = g + h;
    }
}
