using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Bool p/ inventário aberto ou fechado
    private bool inventoryOpen = false;
    public bool InventoryOpen => inventoryOpen;
    public GameObject inventoryScreen;
    public GameObject inventoryTab;
    public GameObject craftingTab;
    
    private List<ItemSlot> itemSlotList = new List<ItemSlot>();
    public GameObject itemSlotPrefab;
    public Transform inventaryItemTransform;

    private void Start()
    {
        InventoryManager.instance.onItemChange += UpdateInventoryUI;
        UpdateInventoryUI();
    }
    
    void Update()
    {
        // Abrir o inventário
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryOpen)
            {
                // Fechar inventario
                CloseInventory();
            }
            else
            {
                // Abrir inventario
                OpenInventory();
            }
        }
    }

    private void UpdateInventoryUI()
    {
        int itemCount = InventoryManager.instance.itensList.Count;
        
        if(itemCount > itemSlotList.Count)
        {
            // Adiciona mais itens nos slots
            AddItemSlots(itemCount);
        }

        // Passa por cada item e checa se 
        for(int i = 0; i < itemSlotList.Count; ++i)
        {
            if(i <= itemCount)
            {
                itemSlotList[i].AddItem(InventoryManager.instance.itensList[i]);
            }
            else
            {
                itemSlotList[i].DestroySlot();
                itemSlotList.RemoveAt(i);
            }
        }
    }

    // Adiciona mais itens nos slots do invetário
    private void AddItemSlots(int itemCount)
    {
        int amount = itemCount - itemSlotList.Count;

        for(int i = 0; i < amount; ++i)
        {
            GameObject gameObject = Instantiate(itemSlotPrefab, inventaryItemTransform);
            ItemSlot newSlot = gameObject.GetComponent<ItemSlot>();
            itemSlotList.Add(newSlot);
        }
    }

    // Ao pressionar a tecla "i", o inventario abre
    private void OpenInventory()
    {
        inventoryOpen = true;
        inventoryScreen.SetActive(true);
    }
    
    // Ao pressionar a tecla "i", o inventario fecha
    private void CloseInventory()
    {
        inventoryOpen = false;
        inventoryScreen.SetActive(false);
    }

    // Alternar entre as abas de invetário e crafting
    public void OnCraftingTabClicked()
    {
        craftingTab.SetActive(true);
        inventoryTab.SetActive(false);
    }
    
    public void OnInventoryTabClicked()
    {
        craftingTab.SetActive(false);
        inventoryTab.SetActive(true);
    }

    // P/ travar o cursor do player e não atrapalhar no mapa
    // private void ChangeCursorState(bool lockCursor)
    // {
    //     if (lockCursor)
    //     {
    //         Cursor.lockState = CursorLockMode.Locked;
    //         Cursor.visible = false;
    //     }
    //     else {
    //         Cursor.lockState = CursorLockMode.None;
    //         Cursor.visible = true;
    //     }
    // }
}
