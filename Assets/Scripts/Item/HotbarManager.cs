using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    public int HotbarSlotSize => gameObject.transform.childCount;
    private List<ItemSlot> hotbarSlots = new List<ItemSlot>();

    KeyCode[] hotbarKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5 };
    
    private void Start()
    {
        SetupHotbarSlots();
        InventoryManager.instance.onItemChange += UpdateHotbarGUI;
    }

    private void Update()
    {
        for(int i = 0; i < hotbarKeys.Length; i++)
        {
            if(Input.GetKeyDown(hotbarKeys[i]))
            {
                // Debug.Log("Use item: " + i);
                hotbarSlots[i].UseItem(); // Use o item
                return;
            }
        }
    }

    private void UpdateHotbarGUI()
    {
        int slotCount = InventoryManager.instance.hotbarList.Count;
        
        for(int i = 0; i < HotbarSlotSize; i++)
        {
            if(i < slotCount)
            {
                hotbarSlots[i].AddItem(InventoryManager.instance.hotbarList[i]);
            }
            else
            {
                hotbarSlots[i].ClearSlot();
            }
        }
    }

    private void SetupHotbarSlots()
    {
        for(int i = 0; i < HotbarSlotSize; i++)
        {
            ItemSlot slot = gameObject.transform.GetChild(i).GetComponent<ItemSlot>();
            hotbarSlots.Add(slot);
        }
    }
}
