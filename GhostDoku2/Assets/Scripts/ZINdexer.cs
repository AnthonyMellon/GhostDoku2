using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZINdexer : MonoBehaviour
{
    public bool onUpdate;
    public int offset;
    public SpriteRenderer spriteRendererOverride;

    // Start is called before the first frame update
    void Start()
    {
        if (spriteRendererOverride) UpdateOtherSR();
        else UpdateOwnSR();
        
    }

    private void Update()
    {
        if(onUpdate)
        {
            if (spriteRendererOverride) UpdateOtherSR();
            else UpdateOwnSR();
        }
    }

    private void UpdateOtherSR()
    {
        spriteRendererOverride.sortingOrder = utils.yToZIndex(transform.position.y) + offset;
    }

    private void UpdateOwnSR()
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder = utils.yToZIndex(transform.position.y) + offset;
    }
}
