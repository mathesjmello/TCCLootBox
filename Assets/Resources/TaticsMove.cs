using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaticsMove : MonoBehaviour
{
	public bool turn = false;

    protected List<Tile> selectableTiles = new List<Tile>();
    GameObject[] tiles;

    Stack<Tile> path = new Stack<Tile>();
    Tile currentTile;

    public bool moving = false;
    public int move = 3;
    public float jumpHeight = 1;
    public float moveSpeed = 2;

    Vector3 velocity = new Vector3();
    Vector3 pointVector = new Vector3();

    float halfHeight = 0;

    public Tile actualTargetTile;

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

    public void Move() {
    	
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
                transform.forward = pointVector;
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

    void CalculatePointVector(Vector3 target)
    {
    	pointVector = target - transform.position;
    	pointVector.Normalize();
    }

    void SetHorizotalVelocity()
    {
    	velocity = pointVector * moveSpeed;
    }

    protected void FindPath(Tile target)
    {
        ComputeProximityList(jumpHeight, target);
    }

    public void BeginTurn()
    {
        turn = true;
    }

    public void EndTurn()
    {
        turn = false;
    }   
}
