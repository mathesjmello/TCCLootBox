using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    static Dictionary<string, List<TaticsMove>> units = new Dictionary<string, List<TaticsMove>>(); 
    static Queue<string> turnkey = new Queue<string>();
    static Queue<TaticsMove> turnTeam = new Queue<TaticsMove>();


    void Update()
    {
    	if (turnTeam.Count == 0)
    	{
    		InitTeamTurnQueue();
    	}
    }
    static void InitTeamTurnQueue()
    {
    	List<TaticsMove> teamList = units[turnkey.Peek()];

    	foreach ( TaticsMove unit in teamList )
    	{
    		turnTeam.Enqueue(unit);
    	}
    }
    
}
