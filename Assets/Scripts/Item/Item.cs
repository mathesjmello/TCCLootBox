using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item/baseItem")]

public class Item : ScriptableObject
{
	  public string name; 
	  public string description; // If they're any
	  public int quantity;	
	//   public int price;	 
	  public Sprite sprite; // Item's sprite
	  public enum Type {weapon, consumable, equip, potion, heal};	 
	  public Type type;
	//   public bool on_sale; // 0 - 1 (On Sale or Not)
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
