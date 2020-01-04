using System.Collections.Generic;
using UnityEngine;

public partial class TaticsMove
{
    protected void FindPath(Tile target)
    {
        ComputeProximityList(jumpHeight, target);
        GetCurrentTile();

        // 
        List<Tile> openList = new List<Tile>(); // Tiles that're not processed yet
        List<Tile> closedList = new List<Tile>(); // Tiles that're already processed

        openList.Add(currentTile);
        // currentTile.parent = ??
        currentTile.h = Vector3.Distance(currentTile.transform.position, target.transform.position);
        currentTile.f = currentTile.h;

        while (openList.Count > 0)
        {
            Tile t = FindLowestF(openList); //Find the low F Cost for A*

            closedList.Add(t);

            if (t == target) // WE FIND THE PATH HERE!
            {
                // Stop A* from count tile next enemy
                actualTargetTile = FindEndTile(t);
                MoveToTile(actualTargetTile);
                return;
            }

            foreach (Tile tile in t.proximityList)
            {
                if (closedList.Contains(tile))
                {
                    // Do nothing, already processed
                }
                else if (openList.Contains(tile))
                {
                    // On openList, but not close to player
                    float tempG =
                        t.g + Vector3.Distance(tile.transform.position, t.transform.position); // Temporary cost for A*

                    if (tempG < tile.g) // If tempG is faster than g Cost
                    {
                        tile.parent = t;
                        tile.g = tempG;
                        tile.f = tile.g + tile.h;
                    }
                }
                else
                {
                    // First time see the tile
                    tile.parent = t;

                    tile.g = t.g + Vector3.Distance(tile.transform.position, t.transform.position);
                    tile.h = Vector3.Distance(tile.transform.position, target.transform.position);
                    tile.f = tile.g + tile.h;

                    openList.Add(tile);
                }
            }
        }

        // TODO - What to do if there's no path on target file?
        Debug.Log("Path not found");
    }
}