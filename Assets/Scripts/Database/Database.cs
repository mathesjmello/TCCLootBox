using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public Sprite[] sprites; // Place some sprites for items

    public static List<Item> itemList = new List<Item>(); // 

    // Making Database seed
    void Start()
    {	
    	// Item i0 = new Item();
    	// i0.name = "";
    	// i0.type = Item.Type.equip;
    	// i0.sprite = sprites[0]; 	   
    	// itemList.Add(i0);
    }

    
    void Update()
    {
        
    }
}
