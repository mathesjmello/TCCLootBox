using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaticsMove : MonoBehaviour
{
    List<TileScript> selectableTiles = new List<TileScript>();
    GameObject[] tiles;

    Stack<TileScript> path = new Stack<TileScript>();
    TileScript currentTile;

    public int move = 1;
    public float jumpHeight = 1;
    public float moveSpeed = 2;

    Vector3 velocity = new Vector3();
    Vector3 pointVector = new Vector3();

    float halfHeight = 0;

    protected void Init()
    {
    	tiles = GameObject.FindGameObjectsWithTag("Tile");

    	halfHeight = GetComponent<Collider>().bounds.extents.y;
    }

    public void CurrentTile()
    {
    	currentTile = GetTargetTile(gameObject);
    	currentTile.currentTile = true;
    	currentTile.selectable = false;
    }

    public TileScript GetTargetTile(GameObject target)
    {
    	RaycastHit hit;
    	TileScript tile = null;

			if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1))
			{
				tile = hit.collider.GetComponent<TileScript>();	
			}

			return tile;
    }

    public void ComputeProximityList()
    {
    	// tiles = GameObject.FindGameObjectsWithTag("Tile");

    	foreach (GameObject tile in tiles)
    	{
    		TileScript t = tile.GetComponent<TileScript>();
    		t.FindNear(jumpHeight);
    	}
    }

    public void FindSelectableTiles() 
    {
    	ComputeProximityList();
    	CurrentTile();

    	Queue<TileScript> process = new Queue<TileScript>();

    	process.Enqueue(currentTile);
    	currentTile.visited = true;
    	// currentTile.parent = ?? leave as null

    	while (process.Count > 0)
    	{
    		TileScript t = process.Dequeue();

    		selectableTiles.Add(t);
    		t.selectable = true;
    		// Debug.Log("Tile Entrou");

    		if (t.distance < move) 
    		{
    			foreach (TileScript tile in t.proximityList)
    			{
	    			if(!tile.visited)
	    			{
	    				tile.parent = t;
	    				tile.visited = true;
	    				tile.distance = 1 + t.distance;
	    				process.Enqueue(tile);
	    			}
    			}
    		}
    	}
    }
}
