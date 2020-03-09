using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region singleton
    public static InventoryUI instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    private bool inventoryOpen = false; // Bool p/ inventário aberto ou fechado
    public bool InventoryOpen => inventoryOpen;
    
    public GameObject inventoryScreen; // GUI do Inventário
    public GameObject inventoryTab; // Aba Inventario
    public GameObject craftingTab; // Aba Craft
    
    private List<ItemSlot> itemSlotList = new List<ItemSlot>();
    public GameObject itemSlotPrefab;
    public Transform inventoryItemTransform;
    
    public Transform craftingItemTransform;


    private void Start()
    {
        InventoryManager.instance.onItemChange += UpdateInventoryUI;
        UpdateInventoryUI();
        SetupCraftingRecipes();
    }
    
    void Update() // Abrir e fechar inventário
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryOpen)
            {
                CloseInventory();
            } else {
                OpenInventory();
            }
        }
    }

    private void SetupCraftingRecipes()
    {
        List<Item> craftingRecipes = GameManager.instance.craftingRecipes;

        foreach(Item recipe in craftingRecipes) // Adiciona as receitas na aba Craft
        {
            GameObject gameObject = Instantiate(itemSlotPrefab, craftingItemTransform);
            ItemSlot slot = gameObject.GetComponent<ItemSlot>();
            slot.AddItem(recipe);
        }

    }

    private void UpdateInventoryUI() // Adiciona os items novos no slot
    {
        int itemCount = InventoryManager.instance.itemsList.Count;
        
        if(itemCount > itemSlotList.Count)
        {
            AddItemSlots(itemCount); // Adiciona o primeiro item se não existir numericamente
        }

        for(int i = 0; i < itemSlotList.Count; ++i) // Se existir
        {
            if(i < itemCount)
            {
                itemSlotList[i].AddItem(InventoryManager.instance.itemsList[i]); // Adiciona uma instacia do item na lista atual do inventario
            }
            else
            {
                itemSlotList[i].DestroySlot(); // Remove o item da lista atual e,
                itemSlotList.RemoveAt(i); // Destroy o slot com e o icone
            }
        }
    }

    private void AddItemSlots(int itemCount) // Adiciona mais items nos slots do invetário
    {
        int amount = itemCount - itemSlotList.Count;

        for(int i = 0; i < amount; ++i)
        {
            GameObject gameObject = Instantiate(itemSlotPrefab, inventoryItemTransform);
            ItemSlot newSlot = gameObject.GetComponent<ItemSlot>();
            itemSlotList.Add(newSlot);
        }
    }

    private void OpenInventory() // Ao pressionar a tecla "i", o inventario abre
    {
        inventoryOpen = true;
        inventoryScreen.SetActive(true);
    }
    
    private void CloseInventory() // Ao pressionar a tecla "i", o inventario fecha
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
