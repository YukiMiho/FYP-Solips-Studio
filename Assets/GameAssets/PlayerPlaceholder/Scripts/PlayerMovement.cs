using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform orientation;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private InputActionReference movement, jump, run, dodge;

    [SerializeField] private float moveSpeed, jumpForce = 5f, jumpCooldown = 2f, airMultiplier = 0.4f, gravity = -9.18f, runMultiplier = 1.5f, dodgeCooldown = 2f, dodgeSpeedMultiplier = 4f;
    

    [Header("Ground Check")]
    [SerializeField] private Transform groundSphereChecker;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGrounded;

    [Header("Animations")]
    [SerializeField] private Animator animator;

    // Animation Variable
    private Vector3 playerVelocity;
    private float timer;
    private bool isWalking, isRunning, isDodging, canJump = true, canDodge = true;

    private void Start()
    {

    }

    private void OnEnable()
    {
        jump.action.performed += ctx => Jump();
        run.action.performed += ctx => Run();
        run.action.canceled += ctx => ResetRun();
        dodge.action.performed += ctx => Dodge();
    }

    private void OnDisable()
    {
        jump.action.performed -= ctx => Jump();
        run.action.performed -= ctx => Run();
        run.action.canceled -= ctx => ResetRun();
        dodge.action.performed -= ctx => Dodge();
    }

    private void Update()
    {
        GroundCheck();
        MovePlayer();
    }

    private void MovePlayer()
    {
        // reads player input
        Vector2 movementInput = movement.action.ReadValue<Vector2>();

        // Calculate movement direction
        Vector3 moveValue = orientation.forward * movementInput.y + orientation.right * movementInput.x;

        // implement gravity
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -1f;
        }

        if (isRunning)
        {
            moveValue *= runMultiplier;
        }

        if (isDodging)
        {
            if (timer >= 0f)
            {
                timer -= Time.deltaTime;

                Vector3 dodgeForward = transform.forward * dodgeSpeedMultiplier * animator.GetFloat("DodgeMultiplierCurve");
                characterController.Move(dodgeForward * Time.deltaTime * moveSpeed);
            }
            else
            {
                isDodging = false;
            }
        }

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);


        if (isGrounded && !isDodging)
        {
            characterController.Move(moveValue * Time.deltaTime * moveSpeed);
        }
        else if (!isDodging)
        {
            characterController.Move(moveValue * Time.deltaTime * moveSpeed * airMultiplier);
        }

        // animation controls
        if (moveValue != Vector3.zero)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("IsRunning", isRunning);
    }

    private void GroundCheck()
    {
        // draws a sphere at player feet to check with in contact with ground
        isGrounded = Physics.CheckSphere(groundSphereChecker.position, groundCheckRadius, whatIsGround);
    }

    private void Jump()
    {
        if (isGrounded && canJump)
        {
            canJump = false;

            // animation controls
            animator.SetTrigger("IsJumping");

            // jump function
            playerVelocity.y = Mathf.Sqrt(jumpForce * -1.0f * gravity);

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        
    }

    private void ResetJump()
    {
        canJump = true;
    }

    private void Dodge()
    {
        if (isGrounded && canDodge)
        {
            canDodge = false;

            // animation controls
            animator.SetTrigger("IsDodge");

            // dodge function
            isDodging = true;
            timer = dodgeCooldown / 3f;

            Invoke(nameof(ResetDodge), dodgeCooldown);
        }
    }

    private void ResetDodge()
    {
        canDodge = true;
    }

    private void Run()
    {
        isRunning = true;
    }

    private void ResetRun()
    {
        isRunning = false;
    }
}   
