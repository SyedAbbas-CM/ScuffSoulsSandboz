using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_Controller;
    private Vector3 move_Direction;

    public float speed = 5f;
    private float gravity = 20f;

    public float jump_force = 10f;
    private float verticalVelocity;

    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        movePlayer();
    }
    void movePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        if (Vector3.Magnitude(move_Direction)>1){move_Direction = Vector3.Normalize(move_Direction);} //<-mks
        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;
        ApplyGravity();
        character_Controller.Move(move_Direction);
       
    
    }
    void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;
        //jump
        PlayerJump();
        move_Direction.y = verticalVelocity * Time.deltaTime;
    }
    void PlayerJump()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jump_force;
        }
    }
}
