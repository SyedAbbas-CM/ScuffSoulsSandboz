using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintAndCrouch : MonoBehaviour
{

    private PlayerMovement playerMovement;
    public float Sprintspeed = 10f;
    public float moveSpeed = 5f;
    public float crouchSpeed = 2f;

    private Transform look_Root;
    private float stand_Height = 0f;
    private float crouch_height = -0.65f;

    private bool isCrouching = false;

    private FootSteps footsteps;
    private float sprintVolume = 1f;
    private float crouchVolume = 0.1f;
    private float walkVolumeMin = 0.2f, walkVolumeMax = 0.6f;

    private float walkStepDistance = 0.4f;
    private float sprintStepDistance = 0.25f;
    private float courchStepDistance = 0.5f;

    private CharecterStats playerStats;
    private PlayerAttritbutes player;
    private float sprint_value = 100f;
    private float sprint_threshhold = 10f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        look_Root = transform.GetChild(0);
        footsteps = GetComponentInChildren<FootSteps>();
        player = GetComponent<PlayerAttritbutes>();
        playerStats = GetComponent<CharecterStats>();
    }

    private void Start()
    {
        footsteps.VolumeMax = walkVolumeMax;
        footsteps.VolumeMin = walkVolumeMin;
        footsteps.stepDistance = walkStepDistance;
    }
    private void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {

        if(playerStats.currentStamina > 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
            {
                playerMovement.speed = Sprintspeed;
                footsteps.stepDistance = sprintStepDistance;
                footsteps.VolumeMin = sprintVolume;
                footsteps.VolumeMax = sprintVolume;


            }
        }



        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = moveSpeed;
            footsteps.VolumeMax = walkVolumeMax;
            footsteps.VolumeMin = walkVolumeMin;
            footsteps.stepDistance = walkStepDistance;
        }
        if(Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            playerStats.currentStamina -= sprint_threshhold * Time.deltaTime;
            if (playerStats.currentStamina < 0f){
                playerStats.currentStamina = 0f;
                playerMovement.speed = moveSpeed;
                footsteps.VolumeMax = walkVolumeMax;
                footsteps.VolumeMin = walkVolumeMin;
                footsteps.stepDistance = walkStepDistance;

            }
        }
        else
        {
            if(playerStats.currentStamina != 100f)
            {
                if (!(playerStats.currentStamina > playerStats.stamina)) {
                    playerStats.currentStamina += (sprint_threshhold / 2f) * Time.deltaTime;
                }

                
            }
        }
        player.Display_AttributeStats(playerStats.currentHealth, playerStats.currentStamina);
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching)
            {
                look_Root.localPosition = new Vector3(0f, stand_Height, 0f);
                playerMovement.speed = moveSpeed;
                footsteps.VolumeMax = walkVolumeMax;
                footsteps.VolumeMin = walkVolumeMin;
                footsteps.stepDistance = walkStepDistance;
                isCrouching = false;
            }
            else
            {
                look_Root.localPosition = new Vector3(0f, crouch_height, 0f);
                playerMovement.speed = crouchSpeed;
                footsteps.stepDistance = courchStepDistance;
                footsteps.VolumeMax = crouchVolume;
                footsteps.VolumeMin = crouchVolume;
                isCrouching = true;

            }
        }
    }

}
