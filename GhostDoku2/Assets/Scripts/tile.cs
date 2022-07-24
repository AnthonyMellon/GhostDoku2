using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public enum tileStates
    {
        walkable,
        wall,
        start,
        end
    }

    public Sprite walkableSprite;
    public Sprite wallSprite;
    public Sprite startSprite;
    public Sprite endSprite;
    
    public bool walkable;
    public tileStates state;

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
            tileStates newState = tileStates.walkable;
            if (state == tileStates.walkable)
                newState = tileStates.wall;
            state = newState;

            //Update sprite
            Sprite sprite = walkableSprite;
            if(state == tileStates.wall)
                sprite = wallSprite; 
            spriteRenderer.sprite = sprite;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            state = tileStates.start;
            spriteRenderer.sprite = startSprite;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            state = tileStates.end;
            spriteRenderer.sprite = endSprite;
        }
    }
}
