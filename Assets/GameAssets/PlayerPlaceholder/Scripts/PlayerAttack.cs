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
    [SerializeField] private float basicAtkCooldown;
    [SerializeField] private int basicAtkDamage;

    [SerializeField] private bool canAttack = true; 

    public bool isBasicAttacking = false;
    public List<GameObject> hitEnemyColliders = new List<GameObject>();

    private void OnEnable()
    {
        basicAttack.action.performed += ctx => BasicAttack();
    }

    private void OnDisable()
    {
        basicAttack.action.performed -= ctx => BasicAttack();
    }

    private void Update()
    {
        if (!isBasicAttacking && hitEnemyColliders.Count != 0)
        {
            foreach (GameObject obj in hitEnemyColliders)
            {
                if (obj.GetComponent<Health>() != null)
                {
                    Health health = obj.GetComponent<Health>();
                    health.TakeDamage(basicAtkDamage);
                }
            }

            hitEnemyColliders.Clear();
        }
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

    // Used with AnimationEvents; Do not change the names unless event names are changed
    public void BasicAttackStart()
    {
        isBasicAttacking = true;
    }

    public void BasicAttackEnd()
    {
        isBasicAttacking = false;
    }
}
