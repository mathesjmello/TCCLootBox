using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region singleton
    // Start is called before the first frame update
    public static InventoryManager instance;

    private void Awake()
    {
    	if (instance == null) {
    		instance = this;
        }
    }

    #endregion
    
    public delegate void OnItemChange();
    public OnItemChange onItemChange = delegate {};

    public List<Item> itensList = new List<Item>();
    public List<Item> craftRecipes = new List<Item>();

    // public Transform Canvas;
    // public GameObject itemInfoPrefab;
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

    public void AddItem(Item item)
    {
        itensList.Add(item);
        onItemChange.Invoke();
    }

    public void RemoveItem(Item item) // Remover o Item depois de usado
    {
        itensList.Remove(item);
        onItemChange.Invoke();
    }
    
    
    public bool ContainsItem(Item item, int amount) // Verificar itens no Inventário
    {
        int itemCounter = 0;

        foreach(Item i in itensList) // Verifica se o item existe na lista do inventario
        {
            
            if(i == item)
            {
                itemCounter++; // Soma +1 se o item for encontrado
            }
        }

        if (itemCounter >= amount) // Se a quantidade de itens disponivel satisfaz o total requerido p/ receita
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    public void RemoveItems(Item item, int amount)
    {
        for(int i = 0; i < amount; ++i)
        {
            RemoveItem(item);
        }
    }
}
