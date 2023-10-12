using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAttack : MonoBehaviour
{

    private WeaponManager weaponManager;
    private bool aiminggun = false;
    public float fireRate;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;
    private Camera mainCam;
    private GameObject crosshair;
    private bool isAiming;
    [SerializeField]
    private GameObject arrow_prefab, spear_prefab;
    [SerializeField]
    private Transform arrow_bow_Startpos;
    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);
        mainCam = Camera.main;
    }

    void Start()
    {
        
    }


    void Update()
    {
        zoomInAndOut();
        weaponShoot();
    }
    void weaponShoot()
    {
        if (weaponManager.GetCurrentSelectWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire)//0 is left click its not up and down this one executes as long as you hold the button.
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weaponManager.GetCurrentSelectWeapon().ShootAnimation();
            }

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(weaponManager.GetCurrentSelectWeapon().tag == Tags.AXE_TAG)
                {
                    weaponManager.GetCurrentSelectWeapon().ShootAnimation();
                }
                if(weaponManager.GetCurrentSelectWeapon().bulletType == WeaponBulletType.BULLET)
                {

                    weaponManager.GetCurrentSelectWeapon().ShootAnimation();
                    BulletFired();
                }
                else
                {
                    if (isAiming)
                    {
                        weaponManager.GetCurrentSelectWeapon().ShootAnimation();
                        if(weaponManager.GetCurrentSelectWeapon().bulletType == WeaponBulletType.AROW)
                        {
                            ShootArrowSpear(true);
                        }
                        else if (weaponManager.GetCurrentSelectWeapon().bulletType == WeaponBulletType.SPEAR)
                        {
                            ShootArrowSpear(false);
                        }
                    }
                }
            }
        }
    }
    void zoomInAndOut()
    {
        if (weaponManager.GetCurrentSelectWeapon().weaponAim == WeaponAim.AIM)
        {
            //1 is right moust button
            if (Input.GetMouseButtonDown(1))
            {
                if(aiminggun == true){aiminggun = false;}
                else{  aiminggun = true;}
            }

            if (aiminggun)
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);
                crosshair.SetActive(false);
            }
            else {
                  zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                  crosshair.SetActive(true);
            }
        }
        if (weaponManager.GetCurrentSelectWeapon().weaponAim == WeaponAim.SELF_AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                weaponManager.GetCurrentSelectWeapon().Aim(true);
                isAiming = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                weaponManager.GetCurrentSelectWeapon().Aim(false);
                isAiming = false;
            }
        }
    }
    void ShootArrowSpear(bool throwingarrow)
    {
        if (throwingarrow)
        {
            GameObject arrow = Instantiate(arrow_prefab);
            arrow.transform.position = arrow_bow_Startpos.position;
            arrow.GetComponent<ArrowScript>().launch(mainCam);

        }
        else
        {
            GameObject spear = Instantiate(spear_prefab);
            spear.transform.position = arrow_bow_Startpos.position;
            spear.GetComponent<ArrowScript>().launch(mainCam);
        }
    }
    void BulletFired()
    {
        RaycastHit Hit;
        if (Physics.Raycast(mainCam.transform.position,mainCam.transform.forward,out Hit))
        {
            print("WE Hit " + Hit.transform.gameObject.name);
        }
    }
}
