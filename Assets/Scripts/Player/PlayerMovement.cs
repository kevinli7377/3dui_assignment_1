using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;


/*
Script for playerobject. Controls movement and viewport panning
*/

public class PlayerMovement : MonoBehaviour
{
    // To asign in inspector
    public Transform player;
    //public Transform ballSpawner;

    public float playerSpeed = 4.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    // Assign touchfield
    public FixedTouchField touchField;
    public float lookSensitivity = 1.0f;
    private float cameraPitch = 0.0f;

    private CharacterController controller;
    private Transform cameraTransform;
    private PlayerControls playerControls;
    private Vector2 movementInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private void Awake()
    {
        // Initialize playerControls
        playerControls = new PlayerControls();

        // Get the CharacterController attached to the player GameObject
        controller = GetComponent<CharacterController>();

        // Find camera that should be a child of player object
        cameraTransform = GetComponentInChildren<Camera>().transform;

        // Setup input events
        playerControls.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Move.canceled += ctx => movementInput = Vector2.zero;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        HandleMovement(); // Joystick movement handling
        HandleTouchCameraLook();
    }

    private void HandleMovement()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // 2D movement
        Vector3 move = (transform.forward * movementInput.y + transform.right * movementInput.x) * playerSpeed;
        controller.Move(move * Time.deltaTime);

        // Gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void HandleTouchCameraLook()
    {

        Vector2 touchDelta = touchField.TouchDist;
        float lookX = touchDelta.x * lookSensitivity;
        //float lookY = touchDelta.y * lookSensitivity; // Add back in for vertical an change x compoenent of new Vector to cameraPitch

        // Adjust camera pitch and clamp
        //cameraPitch = Mathf.Clamp(cameraPitch - lookY, -90f, 90f); // Removed for better play experience
        cameraTransform.localEulerAngles = new Vector3(cameraTransform.localEulerAngles.x, cameraTransform.localEulerAngles.y, 0);

        // Rotate player based on horizontal touch movement
        transform.Rotate(Vector3.up, lookX);

}

}
