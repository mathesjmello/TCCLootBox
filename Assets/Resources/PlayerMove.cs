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
    	if (!moving)
    	{
  			FindSelectableTiles();
  			CheckMouse();
    	}
    	else
    	{

    	}
    }
    void CheckMouse()
    {
    	if (Input.GetMouseButtonUp(0))
    	{
    		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    		RaycastHit hit;
    		if (Physics.Raycast(ray, out hit))
    	}
    }

}

