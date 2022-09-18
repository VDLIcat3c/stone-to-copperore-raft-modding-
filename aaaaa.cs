using HarmonyLib;
using UnityEngine;


public class stonetocopper : Mod
{
    public void Start()
    {
       CreateRecipe(ItemManager.GetItemByName("CopperOre"), 1, new CostMultiple(new Item_Base[] { ItemManager.GetItemByName("Stone") }, 20));
    }

    /// <param name="pResultItem">Item resulting from the crafting.</param>
    public static void CreateRecipe(Item_Base pResultItem, int pAmount, params CostMultiple[] pCosts)
    {
        Debug.Log(pResultItem);
        Traverse.Create(pResultItem.settings_recipe).Field("newCostToCraft").SetValue(pCosts);
        Traverse.Create(pResultItem.settings_recipe).Field("learned").SetValue(true);
        Traverse.Create(pResultItem.settings_recipe).Field("learnedFromBeginning").SetValue(true);
        Traverse.Create(pResultItem.settings_recipe).Field("craftingCategory").SetValue(CraftingCategory.Resources);
        Traverse.Create(pResultItem.settings_recipe).Field("amountToCraft").SetValue(pAmount);
    }

    public void OnModUnload()
    {
        Debug.Log("Mod stonetocopper has been unloaded!");
    }
}