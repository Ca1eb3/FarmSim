using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement Components
    private CharacterController controller;
    private Animator animator;

    private float moveSpeed = 4f;

    [Header("Movement System")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        // Get movement components
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Runs the function for movement
        Move();
    }

    public void Move()
    {
        // Get the horizontal and vertical inputs as a number
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Direction in a normalized vector
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        // Is Sprint Key pressed
        if (Input.GetButton("Sprint"))
        {
            // Set the run animation and increase movespeed
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        }
        else
        {
            // Set the walk animation and decrease movespeed
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }
        // Check for movement
        if (dir.magnitude >= 0.1f)
        {
            // look towards direction
            transform.rotation = Quaternion.LookRotation(dir);

            // Move
            controller.Move(velocity);
        }
    
        animator.SetFloat("Speed", velocity.magnitude);

    }
}
