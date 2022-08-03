using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)) //Toggle sprite between walkable and wall
        {
            //Update state
            string newTag = "tile_walkable";                       
            if (tag == "tile_walkable")
                newTag = "tile_grave";
            tag = newTag;

            //Add or remove gravestone if necessary             
            if (tag == "tile_grave" && !transform.Find("Gravestone(Clone)"))
            {
                Instantiate(gravestones[0], new Vector3(0, 2.5f, 0) + transform.position, new Quaternion(0, 0, 0, 0), transform);
            }
            else Destroy(transform.Find("Gravestone(Clone)").gameObject);                  
        }
    }

    public void calcFCost()
    {
        f = g + h;
    }
}
