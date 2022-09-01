using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostlyTrail : MonoBehaviour
{
    public Sprite sprite;
    [SerializeField] private float lifeTime = 1;
    void Start()
    {
        Animator anim = transform.GetComponent<Animator>();
        lifeTime = anim.runtimeAnimatorController.animationClips[0].length;
        Debug.Log("Duration: " + lifeTime);
    }

    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
