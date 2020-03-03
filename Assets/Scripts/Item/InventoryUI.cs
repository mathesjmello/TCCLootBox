using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Bool p/ inventário aberto ou fechado
    private bool inventoryOpen = false;
    public bool InventoryOpen => inventoryOpen;
    public GameObject inventoryParent;
    public GameObject inventoryTab;
    public GameObject craftingTab;
    // Update is called once per frame
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

    private void OpenInventory()
    {
        inventoryOpen = true;
        inventoryParent.SetActive(true);
    }
    
    private void CloseInventory()
    {
        inventoryOpen = false;
        inventoryParent.SetActive(false);
    }

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
}
