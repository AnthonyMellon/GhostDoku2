using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeability : MonoBehaviour
{
    public bool fadeMe;
    public bool fadeChildren;

    float life = 1;
    Color baseColor;

    void Start()
    {  
        
    }
    public void fadeOut()
    {
        StartCoroutine(fadeOutEnum());
    }

    private IEnumerator fadeOutEnum()
    {
        while(life > 0)
        {
            life -= .1f;

            if(fadeMe)
            {
                baseColor = transform.GetComponent<SpriteRenderer>().color;
                transform.GetComponent<SpriteRenderer>().color = new Color(baseColor.r, baseColor.g, baseColor.b, life);
            }

            if(fadeChildren)
            {
                for (int i = 0; i < transform.childCount - 1; i++)
                {
                    baseColor = transform.GetChild(i).GetComponent<SpriteRenderer>().color;
                    if(baseColor.a > 0)
                    {
                        baseColor.a -= 0.1f;
                    }
                    transform.GetChild(i).GetComponent<SpriteRenderer>().color = baseColor;
                }
            }
            yield return new WaitForSeconds(.1f);
            gameObject.SetActive(false);
        }        
    }
}
