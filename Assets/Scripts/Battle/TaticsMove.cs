using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TaticsMove : MonoBehaviour
{
	public bool turn = false;

    protected List<Tile> selectableTiles = new List<Tile>();
    GameObject[] tiles;

	protected Stack<Tile> path = new Stack<Tile>();
    Tile currentTile;

	public int HitForce; 
    public bool moving = false;
    public int move = 3;
    public float jumpHeight = 1;
    public float moveSpeed = 2;

	protected Vector3 velocity = new Vector3();
    Vector3 pointVector = new Vector3();

	protected float halfHeight = 0;

    public Tile actualTargetTile;

	public int LootGenTest;

	

	protected void Init()
    {
    	tiles = GameObject.FindGameObjectsWithTag("Tile");

    	halfHeight = GetComponent<Collider>().bounds.extents.y;

        RoundManager.AddUnit(this); // Init the Round
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
			tile.selectable = true;
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

    public void MoveToTile(Tile tile)
    {
    	path.Clear();
    	moving = true;

    	Tile next = tile;
    	while (next != null)
    	{
    		path.Push(next);
    		next = next.parent;
    	}
    }

    public virtual void  Move() {
    	
    	if (path.Count > 0)
    	{
    		Tile t = path.Peek();
    		Vector3 target = t.transform.position;

    		// Calcula a unidade da posição em cima da Tile alvo 'target'
    		target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

    		if (Vector3.Distance(transform.position, target) >= 0.05f)
    		{
    			bool jump = transform.position.y != target.y;

    			if (jump)
    			{
    			  // Implementar o pulo
    			}
    			else {
    				CalculatePointVector(target);
                    SetHorizotalVelocity();
    			}

    			//Locomoção
                //transform.forward = pointVector;
                transform.position += velocity * Time.deltaTime;
    		} else {
    			transform.position = target;
    			path.Pop();
    		}
    	} 
    	else
  		{
  			RemoveSelectableTiles();
  			moving = false;

  			// Mudar a Rodada ou Terminar o turno;
            RoundManager.EndTurn();
  		}
    }
	
    protected void RemoveSelectableTiles()
    {
      if (currentTile != null)
      {
          currentTile.current = false;
          currentTile = null;
      }

      foreach (Tile tile in selectableTiles)
      {
          tile.Reset();
      }

      selectableTiles.Clear();
    }

	protected void CalculatePointVector(Vector3 target)
    {
    	pointVector = target - transform.position;
    	pointVector.Normalize();
    }

	protected void SetHorizotalVelocity()
    {
    	velocity = pointVector * moveSpeed;
    }

    protected Tile FindLowestF(List<Tile> list)
    {
        Tile lowest = list[0]; // Get the first member for lowest Array

        foreach (Tile t in list)
        {
            if (t.f < lowest.f)
            {
                lowest = t;
            }
        }

        list.Remove(lowest);
        return lowest;
    }

    protected Tile FindEndTile(Tile t)
    {
        Stack<Tile> tempPath = new Stack<Tile>(); // Temp Cost for all the map

        Tile next = t.parent;
        while (next != null)
        {
            tempPath.Push(next);
            next = next.parent;
        }

        if (tempPath.Count <= move)
        {
            return t.parent;
        }

        Tile endTile = null;
        for (int i = 0; i <= move; i++)
        {
            endTile = tempPath.Pop();
        }

        return endTile;
    }
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

	public void BeginTurn()
    {
	   // LootGenTest = Random.Range(1, 3);
	    Debug.Log(LootGenTest);
	    if (LootGenTest == 1)
	    {	    
		    FindSelectableTiles();
	    }

	    if (LootGenTest == 2)
	    {
		    var enimi = FindObjectsOfType<Damage>();
		    foreach (var objDamage in enimi)
		    {
			    objDamage.DistCheck();
		    }
	    }
        turn = true;
    }


	public void EndTurn()
    {
        turn = false;
    }   
}
