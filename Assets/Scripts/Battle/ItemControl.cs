using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };
    
    [SerializeField]
    private Text prizeText;
    [SerializeField]
    private Row[] rows;
    
    private int prizeValue;
    private bool resultsChecked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped)
        {
        	// prizeValue = 0;
        	// prizeText.enable = false;
        	resultsChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && !resultsChecked)
        {
        	CheckResults();
        	// prizeText.enable = true;
        	// prizeText.Text = "Seu item " + prizeValue;
        }
    }

    public void OnMouseDown()
    {
    	if (rows[0].rowStopped && rows[1].rowStopped)
    	{
    		StartCoroutine("PullHandle");
    	}
    }

    // Transform Handle in-game
    private IEnumerator PullHandle()
    {
    	for (int i = 0; i < 15; i += 5)
    	{
    		// Call button function
    		// handle.Rotate(0f, 0f, -i);
    		yield return new WaitForSeconds(0.1f);
    	}	

    	HandlePulled();

    	// for (int i = 0; i < 15; i += 5)
    	// {
    	// 	// Call button function
    	// 	// handle.Rotate(0f, 0f, -i);
    	// 	yield return new WaitForSeconds(0.1f);
    	// }	
    }

    private void CheckResults()
    {
    	if (rows[0].stoppedSlot == "Diamond" && rows[1].stoppedSlot == "Diamond" )
    	{
    		prizeValue = 200;
    	}
    	else if (rows[0].stoppedSlot == "Crown" && rows[1].stoppedSlot == "Crown" )
    	{
    		prizeValue = 400;
    	}
    	else if (rows[0].stoppedSlot == "Melon" && rows[1].stoppedSlot == "Melon" )
    	{
    		prizeValue = 600;
    	}
    	else if (rows[0].stoppedSlot == "Bar" && rows[1].stoppedSlot == "Bar" )
    	{
    		prizeValue = 800;
    	}
    	else if (rows[0].stoppedSlot == "Seven" && rows[1].stoppedSlot == "Seven" )
    	{
    		prizeValue = 1500;
    	}
    	else if (rows[0].stoppedSlot == "Cherry" && rows[1].stoppedSlot == "Cherry" )
    	{
    		prizeValue = 3000;
    	}
    	else if (rows[0].stoppedSlot == "Lemon" && rows[1].stoppedSlot == "Lemon" )
    	{
    		prizeValue = 1500;
    	}

    	resultsChecked = true;
    }
}
