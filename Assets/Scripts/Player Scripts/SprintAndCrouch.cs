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
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        look_Root = transform.GetChild(0);
        footsteps = GetComponentInChildren<FootSteps>();

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

        lightspeed_code(); //mks
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = Sprintspeed;
            footsteps.stepDistance = sprintStepDistance;
            footsteps.VolumeMin = sprintVolume;
            footsteps.VolumeMax = sprintVolume;


        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = moveSpeed;
            footsteps.VolumeMax = walkVolumeMax;
            footsteps.VolumeMin = walkVolumeMin;
            footsteps.stepDistance = walkStepDistance;


        }

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

    void lightspeed_code()                 //
    {                                      //mks
        if (Input.GetKeyDown(KeyCode.P))   //
        {                                  //
            playerMovement.speed+=5f;      //
        }                                  //
    }                                      //
}
