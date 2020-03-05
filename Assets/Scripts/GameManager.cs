using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region  singleton
    public static GameManager instance;
    #endregion

    public List<Item> itemList = new List<Item>();
    public List<Item> craftingRecipes = new List<Item>();
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    // [TESTE] - Adicionar Item no Inventário
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            InventoryManager.instance.AddItem(itemList[Random.Range(0, itemList.Count)]);
        }
    }

    public void OnCraftItemUse(CraftItemType itemType, int amount)
    {
        Debug.Log("Consumindo: " + itemType + "| Add amount: " + amount);
    }
}
