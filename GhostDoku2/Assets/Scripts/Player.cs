using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed;

    public GameObject gameManager;
    private List<tile> path;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            path = PathFinder.FindPath(0, 0, 5, 6, gameManager.GetComponent<gameManager>().myGrid);
            transform.position = gameManager.GetComponent<gameManager>().myGrid.absoluteToWorld(path[0].GetComponent<tile>().normalPosition);
        }
    }

    private void FixedUpdate()
    {
        if (path != null)
        {
            if (path.Count != 0)
            {
                //Vector2 position = new Vector2(path[0].normalPosition.x, path[0].normalPosition.y);
                //position = gameManager.GetComponent<gameManager>().myGrid.absoluteToWorld(position);                

                //transform.position = new Vector3(position.x, position.y, 0);
                //path.RemoveAt(0);

                Vector2 targetPosition = new Vector2(path[0].normalPosition.x, path[0].normalPosition.y);
                targetPosition = gameManager.GetComponent<gameManager>().myGrid.absoluteToWorld(targetPosition);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, walkSpeed * Time.deltaTime);
                if(reachedBreacCrumb(targetPosition))
                {
                    path.RemoveAt(0);
                }
            }
        }

    }

    private bool reachedBreacCrumb(Vector2 breadCrumbPos)
    {
        bool reachedBreadCrumb = false;

        if((Vector2)transform.position == breadCrumbPos)
        {
            reachedBreadCrumb = true;
        }

        return reachedBreadCrumb;
    }

    private void rotateTowardsTarget(Vector2 targetPos)
    {

    }
}
