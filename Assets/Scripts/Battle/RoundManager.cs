using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
	public static bool playerTurn;
    static Dictionary<string, List<TaticsMove>> units = new Dictionary<string, List<TaticsMove>>(); 
    static Queue<string> turnKey = new Queue<string>();
    public static Queue<TaticsMove> turnTeam = new Queue<TaticsMove>();
    private static GameObject EnemyPainel;
    public GameObject Painel;
    public static bool Tutorial;
    private void Start()
    {
	    EnemyPainel = Painel;
    }

    void Update()
    {
    	if (turnTeam.Count == 0)
        {
	        
    		InitTeamTurnQueue();
    	}
    }
    static void InitTeamTurnQueue()
    {
    	List<TaticsMove> teamList = units[turnKey.Peek()];

    	foreach (TaticsMove unit in teamList)
    	{
    		turnTeam.Enqueue(unit);
    	}
    	StartTurn();
    }

    public static void StartTurn()
    {
    	if (turnTeam.Count > 0)
    	{
		    if (turnTeam.Peek().gameObject.GetComponent<PlayerMove>())
		    {
			    playerTurn = true;
			    EnemyPainel.SetActive(false);
			    return;
		    }

		    playerTurn = false;
		    EnemyPainel.SetActive(true);
    		turnTeam.Peek().BeginTurn();
    	}
    }

    public static void EndTurn()
    {
    	TaticsMove unit = turnTeam.Dequeue();
    	unit.EndTurn();
	    
    	if (turnTeam.Count > 0)
    	{
    		StartTurn();
    	}
    	else
    	{
    		string team = turnKey.Dequeue();
    		turnKey.Enqueue(team);
    		InitTeamTurnQueue();
    	}
    }

    public static void AddUnit(TaticsMove unit)
    {
    	List<TaticsMove> list;

    	if (!units.ContainsKey(unit.tag))
    	{
    		list = new List<TaticsMove>();
    		units[unit.tag] = list;

    		if (!turnKey.Contains(unit.tag))
    		{
    			turnKey.Enqueue(unit.tag);
    		}
    	}
    	else
    	{
    		list = units[unit.tag];
    	}
    	
    	list.Add(unit);
    }
}
