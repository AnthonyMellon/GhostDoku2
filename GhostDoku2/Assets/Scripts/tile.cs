using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public Sprite walkableSprite;
    public Sprite wallSprite;
    public Sprite startSprite;
    public Sprite endSprite;

    //Values used for path finding    
    [HideInInspector] public float f = 0;
    [HideInInspector] public float g = 0;
    [HideInInspector] public float h = 0;
    [HideInInspector] public Vector2Int normalPosition;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Find("fScore").GetComponent<TextMesh>().text = $"F: {f.ToString("F2")}";
        transform.Find("gScore").GetComponent<TextMesh>().text = $"G: {g.ToString("F2")}";
        transform.Find("hScore").GetComponent<TextMesh>().text = $"H: {h.ToString("F2")}";
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
