using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    public graveSO self;
    public GameObject fog;
    public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder = utils.yToZIndex(transform.position.y);
        self.Setup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(ghost)
            ghost.GetComponent<Ghost>().Show();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(ghost)
            ghost.GetComponent<Ghost>().Hide();
    }    

    public void levelUp()
    {
        self.IncLevel();
        Debug.Log($"I'm now level {self.currentLevel}");

        switch (self.currentLevel) {
            case 0:
                fog.SetActive(true);
                break;
            default:
                fog.SetActive(false);
                break;
        }
    }
}
