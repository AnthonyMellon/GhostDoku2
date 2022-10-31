using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed;

    public GameObject gameManager;
    private List<tile> path;
    private GameObject spriteObj;
    public Animator playerAnimation;
    public BoolSO gamePaused;
    public Joystick moveInput;
    public float speed;
    private Rigidbody2D rb;
    public AudioSource walkingSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(rb);
        spriteObj = transform.Find("PlayerSprite").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if(!gamePaused.value) getNewTargetPos();
    }

    private void FixedUpdate()
    {
        //if(!gamePaused.value) followPath();
        if (!gamePaused.value) JoysticMove();

    }

    public void JoysticMove()
    {
        if (Mathf.Abs(moveInput.Horizontal) > 0 || Mathf.Abs(moveInput.Vertical) > 0)
        {
            spriteObj.transform.GetComponent<Animator>().SetBool("moving", true);
            walkingSound.mute = false;
        }
        else
        {
            spriteObj.transform.GetComponent<Animator>().SetBool("moving", false);
            walkingSound.mute = true;
        }
        if(moveInput.Horizontal > 0) transform.Find("PlayerSprite").localScale = new Vector3(-1, 1, 1);
        else if (moveInput.Horizontal < 0) transform.Find("PlayerSprite").localScale = new Vector3(1, 1, 1);

        Vector2 move = new Vector2(moveInput.Horizontal * speed, moveInput.Vertical * speed);
        //transform.position = (Vector2)transform.position + move;
        rb.velocity = move;
    }

/*    private void followPath()
    {
        if (path != null)
        {
            if (path.Count != 0)
            {
                Vector2 targetPosition = new Vector2(path[0].normalPosition.x, path[0].normalPosition.y);
                targetPosition = gameManager.GetComponent<gameManager>().myGrid.absoluteToWorld(targetPosition);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, walkSpeed * Time.deltaTime);
                spriteObj.transform.GetComponent<Animator>().SetBool("moving", true);

                if (targetPosition.x < transform.position.x)
                {
                    transform.Find("PlayerSprite").localScale = new Vector3(1, 1, 1);
                }
                else if (targetPosition.x > transform.position.x)
                {
                    transform.Find("PlayerSprite").localScale = new Vector3(-1, 1, 1);
                }

                if (reachedBreacCrumb(targetPosition))
                {
                    path.RemoveAt(0);
                }
            }
            else
            {
                spriteObj.transform.GetComponent<Animator>().SetBool("moving", false);
            }
        }        
    }*/

/*    private void getNewTargetPos()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameGrid grid = gameManager.GetComponent<gameManager>().myGrid;

            Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos = grid.worldToAbsolute(targetPos);
            targetPos.x = Mathf.RoundToInt(targetPos.x);
            targetPos.y = Mathf.RoundToInt(targetPos.y);

            Vector2 originPos = transform.position;
            originPos = grid.worldToAbsolute(originPos);
            originPos.x = Mathf.RoundToInt(originPos.x);
            originPos.y = Mathf.RoundToInt(originPos.y);

            path = PathFinder.FindPath((int)originPos.x, (int)originPos.y, (int)targetPos.x, (int)targetPos.y, grid);
            //transform.position = grid.absoluteToWorld(path[0].GetComponent<tile>().normalPosition);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            GameGrid grid = gameManager.GetComponent<gameManager>().myGrid;

            Vector2 targetPos = Camera.main.ScreenToWorldPoint(touch.position);
            targetPos = grid.worldToAbsolute(targetPos);
            targetPos.x = Mathf.RoundToInt(targetPos.x);
            targetPos.y = Mathf.RoundToInt(targetPos.y);

            Vector2 originPos = transform.position;
            originPos = grid.worldToAbsolute(originPos);
            originPos.x = Mathf.RoundToInt(originPos.x);
            originPos.y = Mathf.RoundToInt(originPos.y);

            path = PathFinder.FindPath((int)originPos.x, (int)originPos.y, (int)targetPos.x, (int)targetPos.y, grid);
            //transform.position = grid.absoluteToWorld(path[0].GetComponent<tile>().normalPosition);
        }
    }*/

/*    private bool reachedBreacCrumb(Vector2 breadCrumbPos)
    {
        bool reachedBreadCrumb = false;

        if((Vector2)transform.position == breadCrumbPos)
        {
            reachedBreadCrumb = true;
        }

        return reachedBreadCrumb;
    }*/
}
