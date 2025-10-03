using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [SerializeField] private List<InventorySlot> slots;

    public int Capacity => slots.Count;

    public Inventory(int capacity)
    {
        slots = new List<InventorySlot>(capacity);
        for (int i = 0; i < capacity; i++)
            slots.Add(new InventorySlot());
    }

    /// <summary>
    /// Adds an item to the inventory. Returns true if successful.
    /// </summary>
    public bool AddItem(Item item, int quantity = 1)
    {
        if (item == null || quantity <= 0) return false;

        // Check if stackable and already exists
        if (item.maxStack > 1)
        {
            foreach (var slot in slots)
            {
                if (slot.item == item && slot.quantity < item.maxStack)
                {
                    int spaceLeft = item.maxStack - slot.quantity;
                    int amountToAdd = Mathf.Min(spaceLeft, quantity);
                    slot.quantity += amountToAdd;
                    quantity -= amountToAdd;
                    if (quantity <= 0) return true;
                }
            }
        }

        // Place in empty slots
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                int amountToAdd = Mathf.Min(item.maxStack, quantity);
                slot.item = item;
                slot.quantity = amountToAdd;
                quantity -= amountToAdd;
                if (quantity <= 0) return true;
            }
        }

        return false; // inventory full
    }

    /// <summary>
    /// Removes items from the inventory. Returns true if successful.
    /// </summary>
    public bool RemoveItem(Item item, int quantity = 1)
    {
        if (item == null || quantity <= 0) return false;

        for (int i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];
            if (slot.item == item)
            {
                if (slot.quantity >= quantity)
                {
                    slot.quantity -= quantity;
                    if (slot.quantity == 0) ClearSlot(slot);
                    return true;
                }
                else
                {
                    quantity -= slot.quantity;
                    ClearSlot(slot);
                }
            }
        }
        return false; // not enough items found
    }

    /// <summary>
    /// Checks if the inventory contains a specific item (and optional quantity).
    /// </summary>
    public bool Contains(Item item, int quantity = 1)
    {
        int count = 0;
        foreach (var slot in slots)
        {
            if (slot.item == item)
                count += slot.quantity;
            if (count >= quantity) return true;
        }
        return false;
    }

    /// <summary>
    /// Gets a read-only list of slots (for UI).
    /// </summary>
    public List<InventorySlot> GetSlots() => slots;

    private void ClearSlot(InventorySlot slot)
    {
        slot.item = null;
        slot.quantity = 0;
    }
}
