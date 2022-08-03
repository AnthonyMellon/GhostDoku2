﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder = utils.yToZIndex(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}