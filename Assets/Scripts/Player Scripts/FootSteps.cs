using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    private AudioSource footstepSound;

    [SerializeField]
    private AudioClip[] footstepClips;

    private CharacterController charecterController;

    [HideInInspector]
    public float VolumeMax, VolumeMin;


    private float accumulated_Distance;
    [HideInInspector]
    public float stepDistance;


    private void Update()
    {
        footStepSounds();
    }

    private void Awake()
    {
        footstepSound = GetComponent<AudioSource>();
        charecterController = GetComponentInParent<CharacterController>();

    }
    void footStepSounds()
    {
        if (!charecterController.isGrounded)
        {
            return;
        }
        if(charecterController.velocity.sqrMagnitude > 0)
        {
  
            accumulated_Distance += Time.deltaTime;
            if(accumulated_Distance > stepDistance)
            {
                footstepSound.volume = Random.Range(VolumeMin, VolumeMax);
                footstepSound.clip = footstepClips[Random.Range(0,footstepClips.Length)];
                footstepSound.Play();
                
                accumulated_Distance = 0f;
            }

        }
        else {
            accumulated_Distance = 0f;

        }




    }

}
