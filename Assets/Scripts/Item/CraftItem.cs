using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CraftItem", menuName = "Item/craftItem")]

public enum CraftItemType
{
    HealthItem,
    PotionItem,
    AttackItem    
}

public class CraftItem : Item
{
    // Definição do tipo do CraftItem
    public CraftItemType itemType;
    // Definindo quantidade de elementos p/ craft do Item
    public int amount;
    
    // Herdando a clase Use() do Item
    public override void Use()
    {
        base.Use();
    }

}
