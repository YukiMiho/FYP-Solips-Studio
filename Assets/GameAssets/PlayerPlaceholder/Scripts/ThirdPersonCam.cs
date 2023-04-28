using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform playerObj;

    [SerializeField] private InputActionReference movement;

    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // rotate orientation
        Vector3 viewDir = playerObj.position - new Vector3(transform.position.x, 0, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player object
        Vector2 movementInput = movement.action.ReadValue<Vector2>();
        Vector3 inputDir = orientation.forward * movementInput.y + orientation.right * movementInput.x;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

    }
}
