
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : TaticsMove
{
    private GameObject NPC;
    GameObject target;
    public Animator GS;
    TempDistCheck tempDistCheck;
    // Start is called before the first frame update
    void Start()
    {
	    NPC = gameObject;
        tempDistCheck = NPC.GetComponent<TempDistCheck>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!turn)
        {
            return;
        }
        if (!moving)
        {
            FindNearestTarget();
            FindSelectableTiles(); // Still show the movement from NPC
            CalculatePath();
            actualTargetTile.target = true;
        }
        else
        {
            if (tempDistCheck.distTotal >= 1.5f)
            {
                StartCoroutine("MoveAnim");
            }

            Move();
        }
    }

    IEnumerator MoveAnim()
    {
        GS.SetTrigger("Move");
        yield return new WaitForSeconds(0.9f);
        GS.ResetTrigger("Move");
    }

    void CalculatePath() 
    {
    	Tile targetTile = GetTargetTile(target);
    	FindPath(targetTile); // Perform A*
    }

    void FindNearestTarget()
    {
    	GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

    	// Put simple AI
    	GameObject nearest = null;
    	float distance = Mathf.Infinity;

    	foreach (GameObject obj in targets)
    	{
    		float d = Vector3.Distance(transform.position, obj.transform.position);

    		if (d < distance)
    		{
    			distance = d;
    			nearest = obj;
    		}
    	}

    	target = nearest;
    }
}
