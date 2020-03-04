using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item/baseItem")]

public class Item : ScriptableObject
{
	//   public string name; 
	//   public string description; // If they're any
	//   public int quantity;	
	// //   public int price;	 
	//   public Sprite sprite; // Item's sprite
	//   public enum Type {weapon, consumable, equip, potion, heal};	 
	//   public Type type;
	// //   public bool on_sale; // 0 - 1 (On Sale or Not)
    
    new public string name = "Default Item";
	public Sprite icon = null;

	public virtual void Use()
	{
		Debug.Log("Using " + name);
	}
}
