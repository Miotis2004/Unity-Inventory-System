using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class ConsumableItem : Item
{
    public int healAmount;
    public float cooldown;
    public bool isStackable = true;
}
