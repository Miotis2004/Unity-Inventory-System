using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe : ScriptableObject
{
    public List<Item> ingredients;
    public Item result;
}

public class CraftingSystem : MonoBehaviour
{
    public List<Recipe> recipes;
    //public bool TryCraft(List<Item> input, out Item result) { /* logic */ }
}
