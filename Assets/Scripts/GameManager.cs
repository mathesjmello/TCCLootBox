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

    public Transform canvas;
    public GameObject itemInfoPrefab;
    private GameObject currentInfo = null;

    public float moveX = 0f;
    public float moveY = 0f;
    
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
            Item newItem = itemList[Random.Range(0, itemList.Count)];

            InventoryManager.instance.AddItem(Instantiate(newItem));
        }
    }

    public void OnCraftItemUse(CraftItemType itemType, int amount)
    {
        Debug.Log("Consumindo: " + itemType + "| Add amount: " + amount);
    }

    public void DisplayItemInfo(string itemName, string itemDescription, Vector2 buttonPos)
    {
        if(currentInfo != null)
        {
            Destroy(currentInfo.gameObject);
        }

        buttonPos.x += moveX;
        buttonPos.y += moveY;
        
        currentInfo = Instantiate(itemInfoPrefab, buttonPos, Quaternion.identity, canvas);
        currentInfo.GetComponent<ItemInfo>().Setup(itemName, itemDescription);
    }

    public void DestroyItemInfo()
    {
        if(currentInfo != null)
        {
            Destroy(currentInfo.gameObject);
        }
    }
}
