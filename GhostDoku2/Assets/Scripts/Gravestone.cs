using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private int currentLevel = 0;
    public GameObject fog;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder = utils.yToZIndex(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        transform.Find("GhostMarvin").GetComponent<Ghost>().Show();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        transform.Find("GhostMarvin").GetComponent<Ghost>().Hide();
    }    

    public void levelUp()
    {
        currentLevel++;
        Debug.Log($"I'm now level {currentLevel}");

        switch (currentLevel) {
            case 0:
                fog.SetActive(true);
                break;
            case 1:
                fog.SetActive(false);
                break;
        }
    }
}
