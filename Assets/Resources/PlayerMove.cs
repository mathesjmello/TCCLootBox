using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TaticsMove
{
    // Start is called before the first frame update
    void Start()
    {
     	Init();   
    }

    // Update is called once per frame
    void Update()
    {
    	if(!turn)
        {
            return;
        }
        if (!moving)
    	{
  			FindSelectableTiles();
  			CheckMouse();
    	}
    	else
    	{
		    // foreach (var tiles in selectableTiles)
		    // {
			   //  if (tiles.target)
			   //  {
				  //   transform.position = tiles.transform.position + new Vector3(0,1.1f,0);
				  //   moving = false;
			   //  }
		    // }
		    Move();
    	}
    }
    void CheckMouse()
    {
    	if (Input.GetMouseButtonUp(0))
    	{
    		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    		RaycastHit hit;
    		if (Physics.Raycast(ray, out hit))
    		{
    			if(hit.collider.tag == "Tile")
    			{
    				Tile t = hit.collider.GetComponent<Tile>();
    				Debug.Log("Tile Clicada");

    				if (t.selectable) // Move target
    				{
    					// t.target = true;
    					// moving = true;
    					MoveToTile(t);
    				}
    			}
    		}
    	}
    }
}

