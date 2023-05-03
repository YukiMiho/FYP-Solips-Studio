using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Place this script in root of GameObject
public class Health : MonoBehaviour
{
    public Animator animator;
    public int maxHealth;
    public int health;

    public bool isDead = false;
    
    private void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            TriggerDeath();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void RecoverHealth(int heal)
    {
        health -= heal;
    }

    public void TriggerDeath()
    {
        isDead = true;
        animator.SetBool("IsDead", true);
    }

}
