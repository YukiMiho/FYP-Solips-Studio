using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCombatAI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform target;
    [SerializeField] private Health health;

    [SerializeField] private int basicAtkDamage;
    [SerializeField] private float basicAtkCooldown, attackDistance;

    private bool canAttack = true;

    public bool isBasicAttacking = false;
    public List<GameObject> hitEnemyColliders = new List<GameObject>();

    private void Start()
    {
        if (animator != null)
        {
            animator = GetComponent<Animator>();
        }
        
        if (health != null)
        {
            health = GetComponent<Health>();
        }
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= attackDistance && canAttack && !health.isDead)
        {
            BasicAttack();
        }

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

    public void EnemyAttackStart()
    {
        isBasicAttacking = true;
    }

    public void EnemyAttackEnd()
    {
        isBasicAttacking = false;
    }
}
