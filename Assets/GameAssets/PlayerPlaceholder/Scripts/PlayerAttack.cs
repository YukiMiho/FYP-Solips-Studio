using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
        
    [Header("Variables")]
    [SerializeField] private InputActionReference basicAttack;
    [SerializeField] private float basicAtkDamage, basicAtkCooldown;

    [SerializeField] private bool canAttack = true; 

    private void OnEnable()
    {
        basicAttack.action.performed += ctx => BasicAttack();
    }

    private void OnDisable()
    {
        basicAttack.action.performed -= ctx => BasicAttack();
    }

    private void BasicAttack()
    {
        if (canAttack)
        {
            canAttack = false;
            animator.SetTrigger("IsBasicAttack");

            Invoke(nameof(ResetAttack), basicAtkCooldown);
        }
        
    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}
