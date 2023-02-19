using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] weapons;
    private int weaponIndex;


    private void Start()
    {
        weaponIndex = 0;
        weapons[weaponIndex].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TurnOnSelectedWeapon(3);

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TurnOnSelectedWeapon(4);

        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TurnOnSelectedWeapon(5);

        }
    }
    void TurnOnSelectedWeapon(int index)
    {
        if(weaponIndex == index)
        {
            return;
        }
        weapons[weaponIndex].gameObject.SetActive(false);
        weapons[index].gameObject.SetActive(true);
        weaponIndex = index;
    }

    public WeaponHandler GetCurrentSelectWeapon()
    {
        return weapons[weaponIndex];
    }
}
