using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptManager : MonoBehaviour
{
    [SerializeField] private EnemyCombatAI enemyCombatAI;
    [SerializeField] private EnemyMovementAI enemyMovementAI;
    [SerializeField] private Health health;

    private void Start()
    {
        enemyCombatAI = GetComponent<EnemyCombatAI>();
        enemyMovementAI = GetComponent<EnemyMovementAI>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (health.isDead)
        {
            enemyCombatAI.enabled = false;
            enemyMovementAI.enabled = false;
        }
    }
}
