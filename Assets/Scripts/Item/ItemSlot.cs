using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    private Item item;
    // Start is called before the first frame update
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
    }

    public void UseItem() // Condição p/ atalho do teclado em mudar 
    {
        if (item == null) return;
   
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Debug.Log("Trying to switch");
            InventoryManager.instance.ChangeHotbarInventory(item);
        }
        else
        {
            item.Use();
        }
    }   
    
    public void DestroySlot()
    {
        Destroy(gameObject);
    }

    // public void OnRemoveButtonClicked()
    // {
    //     if(item != null)
    //     {
    //         Inventory.instance.RemoveItem(item);
    //     }
    // }

    public void OnCursorEnter() // Mostrar informação dos items
    {
        if (item == null) return; // Se o item ñ existir then return;

        //display item info
        GameManager.instance.DisplayItemInfo(item.name, item.GetItemDescription(), transform.position);
    }

    public void OnCursorExit() // Destruir informação dos items
    {
        if (item == null) return;// Se o item ñ existir then return;

        GameManager.instance.DestroyItemInfo();
    }
}
