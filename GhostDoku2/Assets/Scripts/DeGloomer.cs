using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DeGloomer : MonoBehaviour
{
    public DecorationSO spriteList;
    public List<Sprite> sprites;
    private int gloomLevel = 0;

    private void Start()
    {
        if (spriteList != null)
        {
            sprites = spriteList.Sprites;
            transform.GetComponent<SpriteRenderer>().sprite = spriteList.Sprites[0];
        }
    }

    private void OnEnable()
    {
        gloomLevel = 0;
    }

    public void deGloom()
    {
        gloomLevel ++;
        limitGloom();
        UpdateSprite();
    }

    public void reGloom()
    {
        gloomLevel --;
        limitGloom();
        UpdateSprite();
    }

    private void limitGloom()
    {
        if (gloomLevel > sprites.Count - 1) gloomLevel = sprites.Count - 1;
        else if (gloomLevel < 0) gloomLevel = 0;
    }

    private void UpdateSprite()
    {
        transform.GetComponent<SpriteRenderer>().sprite = sprites[gloomLevel];
    }
}
