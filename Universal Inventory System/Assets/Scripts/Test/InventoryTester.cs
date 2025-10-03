using UnityEngine;

public class InventoryTester : MonoBehaviour
{
    public Item potion;

    private void Start()
    {
        var inv = InventoryManager.Instance.playerInventory;

        Debug.Log("Adding potion...");
        inv.AddItem(potion, 5);

        Debug.Log("Contains potion? " + inv.Contains(potion));

        inv.RemoveItem(potion, 2);
        Debug.Log("Removed 2 potions. Still has? " + inv.Contains(potion, 1));
    }
}
