using UnityEngine;

public class Ammo : MonoBehaviour
{
    public enum AmmoType { Bullet, Shell, Arrow, Energy }
    public AmmoType ammoType;
    public int quantity;

    public void ConsumeAmmo(int amount)
    {
        quantity -= amount;
    }

    public void AddAmmo(int amount)
    {
        quantity += amount;
    }
}