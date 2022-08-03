using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchIndicator : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float alpha;

    // Update is called once per frame
    void Update()
    {
        alpha -= fadeSpeed * Time.deltaTime;
        Color currentColor = transform.GetComponent<SpriteRenderer>().color;
        transform.GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);

        if(alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
