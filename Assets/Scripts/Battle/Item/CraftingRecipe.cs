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

    private void RemoveIngredientsFromInventory()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            InventoryManager.instance.RemoveItems(ingredient.item, ingredient.amount);
        }
    }

    public override void Use() // Usar a CraftRecipe
    {
        if(CanCraft())
        {
            RemoveIngredientsFromInventory(); // Remove os itens do inventário necessarios p/ Craft
            InventoryManager.instance.AddItem(result); // Adiciona o resultado no inventário e
            InventoryUI.instance.OnInventoryTabClicked(); // Volta p/ a aba de Inventory
            Debug.Log("Você criou um(a): " + result.name);
        }
        else {
            Debug.Log("Você não tem a quantidade suficiente p/ Craft:" + result.name);
        }
    }

    public override string GetItemDescription()
    {
        string itemIngredients = "";

        foreach (Ingredient ingredient in ingredients)
        {
            itemIngredients += "- x" + ingredient.amount + " " + ingredient.item.name + "\n";
        }

        return itemIngredients;

    }

    [System.Serializable]
    public class Ingredient
    {
        public Item item;
        public int amount;
    }
}
