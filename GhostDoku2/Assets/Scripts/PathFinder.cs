using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder 
{
    private struct node
    {
        public GameObject tile;
        public GameObject previous;
        public float fScore;
        public float gScore;        
    }

    //Returns a list of vector 2 positions representing the path along a grid
    public static List<tile> findPath(GameGrid grid, Vector2Int startPos, Vector2Int endPos, int gridWidth, int gridHeight, Sprite redSprite)
    {
        //Initialize the open and closed list
        List<node> unvisitedList = new List<node>();
        List<node> visitedList = new List<node>();

        //Add the starting node to the unvisited list
        node startNode = new node()
        {
            tile = grid.cells[startPos.x, startPos.y],
            gScore = 0,
            fScore = 10,
            previous = null

        };
        unvisitedList.Add(startNode);

        //Populate the rest of the unvisited list
        for(int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                if(x != startPos.x && y != startPos.y)
                {
                    unvisitedList.Add(new node()
                    {
                        tile = grid.cells[x, y],
                        gScore = float.MaxValue,
                        fScore = float.MaxValue,
                        previous = null
                    });                
                }
            }
        }

        //Pick the node with the lowest f score in the unvisited list
        node currentNode = unvisitedList[0];
        foreach (node node in unvisitedList)
        {
            if (node.fScore < currentNode.fScore)
                currentNode = node;
        }

        //Examine current nodes neighbours
        Vector2[] neighbours = new Vector2[8];

        /*int searchCount = 0;
        //While the open list is not empty
        while(unvisitedList.Count != 0 && searchCount < 250)
        {
            //Find node in open list with lowest f score, call it q
            int qIndex = 0;
            tile q = unvisitedList[qIndex];            
            for(int i = 0; i < unvisitedList.Count; i++)
            {
                if (unvisitedList[i].f < q.f)
                {
                    q = unvisitedList[i];
                    qIndex = i;
                }                    
                i++;
            }

            //Remove q from the open list
            unvisitedList.RemoveAt(qIndex);

            //Generate q's 8 successors and set their parents to q
            Vector2Int[] successorPositions = new Vector2Int[8];
            successorPositions[0] = new Vector2Int(q.normalPosition.x + 0, q.normalPosition.y + 1); //top mid                        
            successorPositions[1] = new Vector2Int(q.normalPosition.x + 1, q.normalPosition.y + 1); //top left
            successorPositions[2] = new Vector2Int(q.normalPosition.x + 1, q.normalPosition.y + 0); //mid left
            successorPositions[3] = new Vector2Int(q.normalPosition.x + 1, q.normalPosition.y - 1); //bottom left
            successorPositions[4] = new Vector2Int(q.normalPosition.x + 0, q.normalPosition.y - 1); //bottom mid
            successorPositions[5] = new Vector2Int(q.normalPosition.x - 1, q.normalPosition.y - 1); //bottom right
            successorPositions[6] = new Vector2Int(q.normalPosition.x - 1, q.normalPosition.y + 0); //mid right
            successorPositions[7] = new Vector2Int(q.normalPosition.x - 1, q.normalPosition.y + 1); //top right

            List<tile> successors = new List<tile>();

            foreach (Vector2Int successorPosition in successorPositions)
            {
                if (successorPosition.x < 0 || successorPosition.x >= gridWidth || successorPosition.y < 0 || successorPosition.y >= gridHeight) //Check if the position of the sucessor is out of bounds
                {
                    successors.Add(null);
                }
                else
                {
                    successors.Add(grid.cells[successorPosition.x, successorPosition.y].GetComponent<tile>());
                }                    
                    
                //set parent to q
            }

            //Loop throuh each sucessor
            for(int i = 0; i < successors.Count; i++)
            {
                //Make sure the sucessor isnt null
                if(successors[i] != null)
                {
                    //If the sucessor is the goal, stop the search
                    if(successors[i].normalPosition == endPos)
                    {
                        Debug.Log($"I found the target at {successors[i].normalPosition}");
                        successors[i].gameObject.GetComponent<SpriteRenderer>().sprite = redSprite;
                        return unvisitedList;
                        //Stop the search!
                    }

                    //else, compute both g and h for the sucessor
                    else
                    {
                        //compute g
                        successors[i].g = q.g + distanceBetween(successors[i].normalPosition, q.normalPosition);

                        //compute h
                        successors[i].h = distanceBetween(successors[i].normalPosition, endPos);

                        successors[i].f = successors[i].g + successors[i].h;
                    }

                    bool skip = false;
                    //If a node with the same position as this sucessor is in the open list which has a lower f than this sucessor, skip this sucessor
                    int n = 0;
                    while(n < unvisitedList.Count && !skip)
                    {
                        if(unvisitedList[n].normalPosition == successors[i].normalPosition) //Is the open list node in the same position as the current sucessor
                        {
                            if(unvisitedList[n].f < successors[i].f) //Does the open list node have a lower f than the current sucessor
                            {
                                skip = true;
                            }
                        }
                        n++;
                    }

                    //If a node with the same position as this sucessor is in the closed list which has a lower f than sucessor, skip this sucessor otherwise, as the node to the open list
                    n = 0;
                    while (n < visitedList.Count && !skip)
                    {
                        if(visitedList[n].normalPosition == successors[i].normalPosition) //Is the closed list node in the same position as the current sucessor
                        {
                            if(visitedList[n].f < successors[i].f) //Does the closed list node have a lower f than the current sucessor
                            {
                                skip = true;
                            }
                        }
                        n++;
                    }

                    if(!skip)
                    {
                        unvisitedList.Add(successors[i]);
                    }
                }


            }

            //push q to the closed list
            visitedList.Add(q);
            
            searchCount++;
        }
        return unvisitedList;*/
        return null;
    }

    private static float distanceBetween(Vector2Int pos1, Vector2Int pos2)
    {
        return Mathf.Sqrt(Mathf.Pow((pos2.x - pos1.x), 2) + Mathf.Pow((pos2.y - pos1.y), 2));
    }
}

