using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryManager instance;

    private void Awake()
    {
    	if (instance == null)
    		instance.this;
    }
    
    public List<Item> itemList = new List<Item>();
    public List<Item> craftRecipes = new List<Item>();

    public Transform Canvas;
    public GameObject itemInfoPrefab;
    private GameObject currentItemInfo = null;

    public float moveX = 0f;
    public float moveY = 0f;

    private void Update()
    {
    	// if() Se o botão da loot for clicado:
    	// {
    	// 	Item newItem = itemList[Random.Range(0, itemList.Count)];
    	// 	Inventory.instance.AddItem(Instantiate(newItem));	
    	// }
    }

    
}
