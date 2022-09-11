using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostlyTrailManager : MonoBehaviour
{
    public GameObject trailObj;
    public SpriteRenderer refSprites;
    public Transform trailParent;
    public bool setParent = true;
    public float trailInterval;
    private float timeSinceLastTrail = 0;


    void Start()
    {
        if(setParent) trailParent = transform.parent;
    }

    void Update()
    {
        timeSinceLastTrail += Time.deltaTime;
        if(timeSinceLastTrail >= trailInterval)
        {
            GameObject trail;
            if (trailParent)
            {
                trail = Instantiate(trailObj, transform.position, transform.rotation, trailParent.transform);
            }
            else 
            {
                trail = Instantiate(trailObj, transform.position, transform.rotation);
            } 
            trail.transform.localScale = transform.localScale;
            trail.GetComponent<SpriteRenderer>().sprite = refSprites.sprite;
            timeSinceLastTrail = 0;
        }
    }
    
}
