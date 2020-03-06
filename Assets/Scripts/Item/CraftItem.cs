using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CraftItem", menuName = "Item/craftItem")]

public class CraftItem : Item
{
    // Definição do tipo do CraftItem
    public CraftItemType itemType;
    // Definindo qual o valor de cada Item;
    public int amount;
    
    // Herdando a clase Use() do Item
    public override void Use()
    {
        base.Use();
        
        GameManager.instance.OnCraftItemUse(itemType, amount);
        InventoryManager.instance.RemoveItem(this);
    }

}

public enum CraftItemType
{
    HealthItem,
    PotionItem,
    AttackItem    
}
