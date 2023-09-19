using UnityEngine;
using System.Collections;

public class RangedWeapon : WeaponBase
{
    public enum FireMode { Single, Burst, Auto }
    public FireMode fireMode;
    public int magazineSize;
    public int currentAmmo;
    public float fireRate;
    public float reloadTime;
    public float accuracy;
    public float recoil;

    private bool isReloading = false;

    public override void Equip()
    {
        // Logic to equip the weapon
    }

    public override void Unequip()
    {
        // Logic to unequip the weapon
    }

    public override void Attack()
    {
        if (!isReloading && currentAmmo > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Logic to shoot the weapon
        currentAmmo--;
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineSize;
        isReloading = false;
    }
}