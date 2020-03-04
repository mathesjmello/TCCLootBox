using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CraftingRecipe/baseRecipe")]

public class CraftingRecipe : Item
{
    public Item result;

    public Ingredient[] ingredients;

    private bool CanCraft()
    {
        foreach(Ingredient ingredient in ingredients) // Percorre e pergunta objeto do inventário se existem recursos necessarios p/ o craft
        {
            bool containsIngredient = InventoryManager.instance.ContainsItem(ingredient.item, ingredient.amount);

            if(!containsIngredient)
            {
                return false;
            }
        }

        return true;
    }

    public override void Use() // Usar o CraftRecipe
    {
        if(CanCraft())
        {

        }
    }



    public class Ingredient
    {
        public Item item;
        public int amount;
    }
}
