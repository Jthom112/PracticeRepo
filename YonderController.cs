using UnityEngine;

public class SonicController : MonoBehaviour
{
    public float moveSpeed = 12f;        // Base movement speed
    public float jumpForce = 5f;         // Jump strength
    public float gravity = -20f;         // Custom gravity strength
    public float maxSpeed = 20f;         // Maximum speed after ramping
    public float acceleration = 10f;     // Speed ramping rate
    public float deceleration = 15f;     // Rate at which speed resets when idle

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private float defaultSpeed;          // Default movement speed for reset

    void Start()
    {
        controller = GetComponent<CharacterController>();
        defaultSpeed = moveSpeed;        // Store the base movement speed
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        ApplyGravity();
    }

    void HandleMovement()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Keeps player grounded and prevents constant fall
        }

        // Basic Movement (Horizontal)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Speed Ramp (Acceleration) - Increases speed while moving
        if (move.magnitude > 0 && moveSpeed < maxSpeed)
        {
            moveSpeed = Mathf.MoveTowards(moveSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (move.magnitude == 0)
        {
            // Gradually decelerate to the default speed when idle
            moveSpeed = Mathf.MoveTowards(moveSpeed, defaultSpeed, deceleration * Time.deltaTime);
        }

        // Apply both horizontal and vertical movement
        controller.Move(move * moveSpeed * Time.deltaTime + velocity * Time.deltaTime);  // Add velocity.y for vertical movement
    }


    void HandleJump()
    {
        // Jump when grounded
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Correct formula for jump height
        }
    }

    void ApplyGravity()
    {
        // Apply custom gravity manually
        velocity.y += gravity * Time.deltaTime;

        // Move the character down based on gravity
        controller.Move(velocity * Time.deltaTime);
    }
}
