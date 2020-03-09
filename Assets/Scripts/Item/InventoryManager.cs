using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DEVE SER ASSIMILADO COMO COMPONENTE DO PLAYER
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

    public HotbarManager hotbarManager;

    public List<Item> itemsList = new List<Item>();
    // public List<Item> craftRecipes = new List<Item>();
    public List<Item> hotbarList = new List<Item>();

    // public Transform Canvas;
    // public GameObject itemInfoPrefab;
    
    private GameObject currentItemInfo = null;

    public float moveX = 0f;
    public float moveY = 0f;

    public delegate void OnItemChange();
    public OnItemChange onItemChange = delegate {};
    
    private void Update()
    {
    	// if() Se o botão da loot for clicado:
    	// {
    	// 	Item newItem = itemList[Random.Range(0, itemList.Count)];
    	// 	Inventory.instance.AddItem(Instantiate(newItem));	
    	// }
    }
    
    public void ChangeHotbarInventory(Item item) // Muda item do Inventário p/ Hotbar e vice-versa 
    {
        foreach (Item i in itemsList)
        {
            if(i == item) // Se o item existir no index
            {
                if(hotbarList.Count >= hotbarManager.HotbarSlotSize) // Checa se tem espaço suficiente nos Slots
                {
                    Debug.Log("Não há espaço suficiente para mais items");
                }
                else
                {
                    hotbarList.Add(item);
                    itemsList.Remove(item);
                    onItemChange.Invoke();
                }
                
                return;
            }
        }

        foreach(Item i in hotbarList)
        {
            if (i == item)
            {
                hotbarList.Remove(item);
                itemsList.Add(item);
                onItemChange.Invoke();
                return;
            }
        }
    }

    public void AddItem(Item item)
    {
        itemsList.Add(item);
        onItemChange.Invoke();
    }

    public void RemoveItem(Item item) // Remover o Item depois de usado
    {
        Debug.Log("RemoveItemMethod()");
        
        if (itemsList.Contains(item))
        {
            itemsList.Remove(item);
            
        } 
        else if (hotbarList.Contains(item))
        {
            hotbarList.Remove(item);
        }

        onItemChange.Invoke();
    }
     
    public bool ContainsItem(Item item, int amount) // Verificar items no Inventário
    {
        int itemCounter = 0;

        foreach(Item i in itemsList) // Verifica se o item existe na lista do inventario
        {
            
            if(i == item)
            {
                itemCounter++; // Soma +1 se o item for encontrado
            }
        }

        if (itemCounter >= amount) // Se a quantidade de items disponivel satisfaz o total requerido p/ receita
        {
            return true;
        } else {
            return false;
        }
    }

    public void RemoveItems(Item item, int amount) // Remove mais de um Item. [Usado p/ o Craft]
    {
        for(int i = 0; i < amount; ++i)
        {
            RemoveItem(item);
        }
    }
}
