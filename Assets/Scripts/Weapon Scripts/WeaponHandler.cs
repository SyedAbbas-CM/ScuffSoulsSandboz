using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim
{
    NONE,SELF_AIM,AIM
}
public enum WeaponFireType
{
    SINGLE,MULTIPLE
}
public enum WeaponBulletType
{
    BULLET,AROW,SPEAR,NONE
};
public class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject muzzleFlash;
    //????Wtf
    [SerializeField]
    private AudioSource shootSound, reloadSound;

    public WeaponFireType fireType;
    public WeaponBulletType bulletType;
    public GameObject attack_Point;



    private Animator anim;
    public WeaponAim weaponAim;

    private void Awake()
    {
        anim = GetComponent<Animator>();        
    }
    public void ShootAnimation()
    {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }

    void TurnOnMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
    }
    void TurnOffMuzzleFlash()
    {
        muzzleFlash.SetActive(false);
    }
    void PlayShootSound()
    {
        shootSound.Play();
    }
    void PlayReloadSound()
    {
        reloadSound.Play();
    }
    void TurnonAttackPoint()
    {
        attack_Point.SetActive(true);
    }
    void TurnOffAttackPoint()
    {
        if (attack_Point.activeInHierarchy)
        {
            attack_Point.SetActive(false);
        }
    }

}












