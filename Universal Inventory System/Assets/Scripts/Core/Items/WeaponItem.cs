using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class WeaponItem : Item
{
    public int damage;
    public float attackSpeed;
    public float range;
}
