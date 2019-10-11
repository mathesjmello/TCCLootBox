using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaticsMove : MonoBehaviour
{
    List<Tile> selectableTiles = new List<Tile>();
    GameObject[] tiles;

    Stack<Tile> path = new Stack<Tile>();
    Tile currentTile;

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

    public void GetCurrentTile()
    {
    	currentTile = GetTargetTile(gameObject);
    	currentTile.current = true;
    	currentTile.selectable = false;
    }

    public Tile GetTargetTile(GameObject target)
    {
    	RaycastHit hit;
    	Tile tile = null;

			if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1))
			{
				tile = hit.collider.GetComponent<Tile>();	
			}

			return tile;
    }

    public void ComputeProximityList(float jumpHeight, Tile target)
    {
    	// tiles = GameObject.FindGameObjectsWithTag("Tile");

    	foreach (GameObject tile in tiles)
    	{
    		Tile t = tile.GetComponent<Tile>();
    		t.FindNear(jumpHeight, target);
    	}
    }

    public void FindSelectableTiles() 
    {
    	ComputeProximityList(jumpHeight, null);
    	GetCurrentTile();

    	Queue<Tile> process = new Queue<Tile>();

    	process.Enqueue(currentTile);
    	currentTile.visited = true;
    	// currentTile.parent = ?? leave as null

    	while (process.Count > 0)
    	{
    		Tile t = process.Dequeue();

    		selectableTiles.Add(t);
    		t.selectable = true;
    		// Debug.Log("Tile Entrou");

    		if (t.distance < move) 
    		{
    			foreach (Tile tile in t.proximityList)
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
