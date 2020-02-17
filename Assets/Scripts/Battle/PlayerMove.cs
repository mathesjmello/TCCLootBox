using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : TaticsMove
{

    public Animator PlayerAnim;

    

    //private GameObject ItemGen;
    //UIScript UIScript;
    //private int LootGen;
    //public int LootGenTest;

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
        //TempReact();
        if (!turn)
        {
            PlayerAnim.SetBool("Walk", false);
            return;
        }
        if (!moving)
        {
            CheckMouse();
	        PlayerAnim.SetBool("Walk", false);
        }
        else
        {
            Move();
            PlayerAnim.SetBool("Walk", true);
        }
    }

	public override void  Move() {
    	
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
			PlayerAnim.SetBool("Walk", false);
			RemoveSelectableTiles();
			moving = false;
			
			// Mudar a Rodada ou Terminar o turno;
			//RoundManager.EndTurn();
		}
	}

//    void TempReact()
//    {
//        if (Input.GetKeyDown(KeyCode.UpArrow))
//        {
//            PlayerAnim.SetTrigger("PositiveReact");
//        }
//        if (Input.GetKeyDown(KeyCode.DownArrow))
//        {
//            PlayerAnim.SetTrigger("NegativeReact");
//        }
//    }

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

