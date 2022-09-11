using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZINdexer : MonoBehaviour
{
    public bool onUpdate;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder = utils.yToZIndex(transform.position.y);
    }

    private void Update()
    {
        if(onUpdate) transform.GetComponent<SpriteRenderer>().sortingOrder = utils.yToZIndex(transform.position.y);
    }
}
