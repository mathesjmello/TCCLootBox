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
        inventoryScreen.SetActive(true);
    }
    
    private void CloseInventory()
    {
        inventoryOpen = false;
        inventoryScreen.SetActive(false);
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
