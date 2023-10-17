using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsLikePlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    public float walkSpeed = 5f;
    public float rollSpeed = 10f;
    public float sideStepSpeed = 7f;
    public float backStepSpeed = 7f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
        HandleActions();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        if (movement.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
            rb.MovePosition(rb.position + movement.normalized * walkSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void HandleActions()
    {
        // Roll
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Roll");
            rb.MovePosition(rb.position + transform.forward * rollSpeed * Time.deltaTime);
        }

        // Backstep
        if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetTrigger("BackStep");
            rb.MovePosition(rb.position - transform.forward * backStepSpeed * Time.deltaTime);
        }

        // Sidestep (Left)
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetTrigger("SideStep");
            rb.MovePosition(rb.position - transform.right * sideStepSpeed * Time.deltaTime);
        }

        // Sidestep (Right)
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetTrigger("SideStep");
            rb.MovePosition(rb.position + transform.right * sideStepSpeed * Time.deltaTime);
        }

        // Punch (Left)
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("PunchLeft");
        }

        // Punch (Right)
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("PunchRight");
        }

        // Kick
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Kick");
        }
    }
}
