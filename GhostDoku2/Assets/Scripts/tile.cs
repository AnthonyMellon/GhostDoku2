using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public Sprite walkableSprite;
    public Sprite wallSprite;
    public Sprite startSprite;
    public Sprite endSprite;   

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)) //Toggle sprite between walkable and wall
        {
            //Update state
            string newTag = "tile_walkable";                       
            if (tag == "tile_walkable")
                newTag = "tile_wall";
            tag = newTag;

            //Update sprite
            Sprite sprite = walkableSprite;
            if(tag == "tile_wall")
                sprite = wallSprite; 
            spriteRenderer.sprite = sprite;
        }
    }
}
