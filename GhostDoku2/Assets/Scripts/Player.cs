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
                Vector2 position = new Vector2(path[0].normalPosition.x, path[0].normalPosition.y);
                position = gameManager.GetComponent<gameManager>().myGrid.absoluteToWorld(position);                

                transform.position = new Vector3(position.x, position.y, 0);
                path.RemoveAt(0);
            }
        }

    }

    private bool reachedBreacCrumb()
    {
        bool reachedBreadCrumb = false;

        return reachedBreadCrumb;
    }

    private void rotateTowardsTarget(Vector2 targetPos)
    {

    }
}
