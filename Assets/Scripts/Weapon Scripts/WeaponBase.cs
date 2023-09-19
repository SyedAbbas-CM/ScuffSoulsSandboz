using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public string weaponName;
    public float damage;
    public float weight;
    public float durability;
    public float maxDurability;

    public abstract void Equip();
    public abstract void Unequip();
    public abstract void Attack();
}