using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Inventory playerInventory;

    public int defaultCapacity = 20;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        playerInventory = new Inventory(defaultCapacity);
    }

    private void Start()
    {
        Debug.Log("Inventory initialized with " + defaultCapacity + " slots.");
    }
}
