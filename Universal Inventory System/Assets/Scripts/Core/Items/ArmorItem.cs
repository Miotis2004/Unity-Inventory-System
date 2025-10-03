using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Inventory/Armor")]
public class ArmorItem : Item
{
    public int defense;
    public float weight;
    public ArmorSlot slotType; // Helmet, Chest, Legs, etc.
}

public enum ArmorSlot
{
    Helmet,
    Chest,
    Legs,
    Boots,
    Shield
}
