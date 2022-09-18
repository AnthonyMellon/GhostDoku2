using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    public graveSO self;
    public GameObject fog;
    public GameObject ghost;
    public GhostSO ghostSelf;

    // Start is called before the first frame update
    void Start()
    {
        ghostSelf = ghost.GetComponent<Ghost>().self;
        transform.GetComponent<SpriteRenderer>().sortingOrder = utils.yToZIndex(transform.position.y);
        self.Setup();
        UpdateFog();
        UpdateWalkableTiles();
        UpdateGhost();
    }    

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
/*        if(ghost)
            ghost.GetComponent<Ghost>().Show();*/
    }

    void OnTriggerExit2D(Collider2D other)
    {
/*        if(ghost)
            ghost.GetComponent<Ghost>().Hide();*/
    }    

    public void levelUp()
    {
        ghostSelf.IncLevel();
        Debug.Log($"{ghostSelf.name} is now level {ghostSelf.currentLevel}");

        UpdateWalkableTiles();
        UpdateGhost();
    }

    public void UpdateGhost()
    {
        if (ghostSelf.currentLevel > 0)
            ghost.GetComponent<Ghost>().Show();
        else
            ghost.GetComponent<Ghost>().Hide();
    }

    public void UpdateFog()
    {
        switch (ghostSelf.currentLevel)
        {
            case 0:
                fog.SetActive(true);
                break;
            default:
                fog.SetActive(false);
                break;
        }
    }

    public void UpdateWalkableTiles()
    {
        PathBlocker blocker = transform.GetComponent<PathBlocker>();
        if (!blocker.setupComplete) blocker.Setup();

        List<Vector2> noFogNonWalkables = new List<Vector2> { new Vector2(0, 0) };
        List<Vector2> fogNonWalkables = new List<Vector2> { 
            new Vector2(-1, 1), new Vector2(0, 1), new Vector2(1, 1),
            new Vector2(-1, 0), new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(-1, -1), new Vector2(0, -1), new Vector2(1, -1)
        };


        switch (ghostSelf.currentLevel)
        {
            case 0:
                blocker.UnBlockTiles();
                blocker.relativeTilesBlocked = fogNonWalkables;
                blocker.BlockTiles();
                break;
            default:
                blocker.UnBlockTiles();
                blocker.relativeTilesBlocked = noFogNonWalkables;
                blocker.BlockTiles();
                break;
        }
    }
}
