using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : TaticsMove
{

    //private GameObject ItemGen;
    //UIScript UIScript;
    //private int LootGen;
    public int LootGenTest = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        //ItemGen = GameObject.Find("BatlleUI");
    }
    void Start()
    {
        //UIScript = ItemGen.GetComponent<UIScript>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        //LootGen = UIScript.LootID;
        LootTest();
        if (!turn)
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

    void LootTest()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LootGenTest = Random.Range(1, 3);
            Debug.Log(LootGenTest);
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

    				if (t.selectable && LootGenTest == 1) // Move target
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

