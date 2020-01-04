using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool walkable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;

    public List<Tile> proximityList = new List<Tile>();

    // Breadth First Search (BFS)
    public bool visited = false;
    public Tile parent = null;
	public int distance = 0;

    //For A*
    public float f = 0;
    public float g = 0;
    public float h = 0;

    void Start()
    {
        
    }

    void Update()
    {
    	if(current)
    	{
    		GetComponent<Renderer>().material.color = Color.magenta;
    	}
    	else if(selectable)
    	{
    		GetComponent<Renderer>().material.color = Color.green;
    	}
    	else if(target)
    	{
    		GetComponent<Renderer>().material.color = Color.red;
    	}
    	else {
    		GetComponent<Renderer>().material.color = Color.white;	
    	}
    }

    public void Reset() 
    {
    	proximityList.Clear();

    	current = false;
    	target = false;
    	selectable = false;

    	visited = false;
    	parent = null;
    	distance = 0;
    }

    public void FindNear(float jumpHeight, Tile target)
    {
    	Reset();
    	CheckTile(Vector3.forward, jumpHeight, target);
    	CheckTile(-Vector3.forward, jumpHeight, target);
    	CheckTile(Vector3.right, jumpHeight, target);
    	CheckTile(-	Vector3.right, jumpHeight, target);
    }

    public void CheckTile(Vector3 direction, float jumpHeight, Tile target)
    {
    	Vector3 jumpLimit = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
    	Collider[] colliders = Physics.OverlapBox(transform.position + direction, jumpLimit);

    	foreach (Collider item in colliders)
    	{
    		Tile tile = item.GetComponent<Tile>();
    		if ( tile != null && tile.walkable )
    		{
    			RaycastHit hit;

    			if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1) || (tile == target))
    			{
    				proximityList.Add(tile);	
    			}
    		}
    	}
    }
}
