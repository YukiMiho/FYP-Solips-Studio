using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScriptManager : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInput playerInput;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerInput = GetComponent<PlayerInput>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (health.isDead)
        {
            playerAttack.enabled = false;
            playerMovement.enabled = false;
            playerInput.enabled = false;
        }
    }
}
