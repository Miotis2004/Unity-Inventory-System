using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootEntry
{
    public Item item;
    public float dropChance;
}

public class LootSystem : MonoBehaviour
{
    public List<LootEntry> lootTable;
    //public Item GetRandomDrop() { /* logic */ }
}
