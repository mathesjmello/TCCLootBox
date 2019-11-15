using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       public int id; 
       public string name; // Name: `Tutorial`, `First Combat`, etc..
       public string npc;	 // Number for NPC movements; 
       public string desc; // Description for the quest	
       public int status;	 // 0 - 1 (Completed or Not)
       public string rewards; // Amount of XP owned;
       public string task;	//
       public int parent; // 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
