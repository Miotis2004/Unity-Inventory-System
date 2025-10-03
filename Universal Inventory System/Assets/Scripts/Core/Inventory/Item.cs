using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemID;
    public string itemName;
    public Sprite icon;
    public ItemType type;
    public int maxStack = 1;
    public int value;
    [TextArea] public string description;
}
