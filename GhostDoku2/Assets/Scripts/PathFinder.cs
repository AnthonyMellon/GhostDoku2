using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder 
{
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    private static GameGrid grid;
    private static List<tile> openList;
    private static List<tile> closedList;

    public static List<tile> FindPath(int startX, int startY, int endX, int endY, GameGrid myGrid)
    {
        grid = myGrid;

        tile startNode = myGrid.cells[startX, startY].GetComponent<tile>();
        tile endNode = myGrid.cells[endX, endY].GetComponent<tile>();

        openList = new List<tile> { startNode };
        closedList = new List<tile>();

        for(int x = 0; x < myGrid.nTilesX; x++)
        {
            for(int y = 0; y < myGrid.nTilesY; y++)
            {
                tile currentNode = myGrid.cells[x, y].GetComponent<tile>();
                currentNode.g = int.MaxValue;
                currentNode.calcFCost();
                currentNode.parent = null;
            }
        }

        startNode.g = 0;
        startNode.h = calcDistance(startNode.normalPosition, endNode.normalPosition);
        startNode.calcFCost();

        int limit = 0;

        while(openList.Count > 0)
        {
            limit++;
            tile currentNode = getLowestFCostNode();
            if(currentNode.normalPosition == endNode.normalPosition)
            {
                //Reached final node
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach(tile neighbourNode in GetNeighboursList(currentNode))
            {
                if (closedList.Contains(neighbourNode)) continue;
                if (neighbourNode.gameObject.tag != "tile_walkable") continue;

                int tentativeGCost = currentNode.g + calcDistance(currentNode.normalPosition, neighbourNode.normalPosition);
                if(tentativeGCost < neighbourNode.g)
                {
                    neighbourNode.parent = currentNode;
                    neighbourNode.g = tentativeGCost;
                    neighbourNode.h = calcDistance(neighbourNode.normalPosition, endNode.normalPosition);
                    neighbourNode.calcFCost();

                    if(!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }

        //Out of nodes on the open list
        return null;
    }

    private static List<tile> GetNeighboursList(tile currentTile)
    {
        List<tile> neighbourList = new List<tile>();

        if(currentTile.normalPosition.x - 1 >= 0)
        {
            //Left
            neighbourList.Add(grid.cells[currentTile.normalPosition.x - 1, currentTile.normalPosition.y].GetComponent<tile>());
            //Left Down
            if (currentTile.normalPosition.y - 1 >= 0) neighbourList.Add(grid.cells[currentTile.normalPosition.x - 1, currentTile.normalPosition.y - 1].GetComponent<tile>());
            //Left Up
            if (currentTile.normalPosition.y + 1 < grid.nTilesY) neighbourList.Add(grid.cells[currentTile.normalPosition.x - 1, currentTile.normalPosition.y + 1].GetComponent<tile>());
        }

        if(currentTile.normalPosition.x + 1 < grid.nTilesX)
        {
            //Right
            neighbourList.Add(grid.cells[currentTile.normalPosition.x + 1, currentTile.normalPosition.y].GetComponent<tile>());
            //Right Down
            if (currentTile.normalPosition.y - 1 >= 0) neighbourList.Add(grid.cells[currentTile.normalPosition.x + 1, currentTile.normalPosition.y - 1].GetComponent<tile>());
            //Right Up
            if (currentTile.normalPosition.y + 1 < grid.nTilesY) neighbourList.Add(grid.cells[currentTile.normalPosition.x + 1, currentTile.normalPosition.y + 1].GetComponent<tile>());
        }

        //Down
        if (currentTile.normalPosition.y - 1 >= 0) neighbourList.Add(grid.cells[currentTile.normalPosition.x, currentTile.normalPosition.y - 1].GetComponent<tile>());
        //Up
        if (currentTile.normalPosition.y + 1 < grid.nTilesY) neighbourList.Add(grid.cells[currentTile.normalPosition.x, currentTile.normalPosition.y + 1].GetComponent<tile>());

        return neighbourList;
    }

    private static List<tile> CalculatePath(tile endNode)
    {
        List<tile> path = new List<tile>();
        path.Add(endNode);
        tile currentNode = endNode;
        while(currentNode.parent != null)
        {
            path.Add(currentNode.parent);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }

    private static tile getLowestFCostNode()
    {
        tile lowestFCostNode = openList[0];
        for(int x = 0; x < openList.Count; x++)
        {
            if (openList[x].GetComponent<tile>().f < lowestFCostNode.f)
            {
                lowestFCostNode = openList[x];
            }
        }
        return lowestFCostNode;
    }

    private static int calcDistance(Vector2Int pos1, Vector2Int pos2)
    {
        int xDistance = Mathf.Abs(pos1.x - pos2.x);
        int yDistance = Mathf.Abs(pos1.y - pos2.y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }
}

