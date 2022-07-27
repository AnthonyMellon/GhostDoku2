using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gameManager;
    private List<tile> path;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            path = PathFinder.FindPath(0, 0, 5, 6, gameManager.GetComponent<gameManager>().myGrid);
        }
    }

    private void FixedUpdate()
    {
        if (path != null)
        {
            if (path.Count != 0)
            {
                transform.position = new Vector3(path[0].normalPosition.x, path[0].normalPosition.x, 0);
                path.RemoveAt(0);
            }
        }

    }
}
