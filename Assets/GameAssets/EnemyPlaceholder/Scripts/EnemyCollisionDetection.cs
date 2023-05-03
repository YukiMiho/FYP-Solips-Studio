using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    public EnemyCombatAI enemyCombatAI;

    private void Start()
    {
        enemyCombatAI = transform.root.GetComponent<EnemyCombatAI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (enemyCombatAI.isBasicAttacking && other.gameObject.tag == "Player")
        {
            Debug.Log("Hit " + other.transform.root.name);
            if (!enemyCombatAI.hitEnemyColliders.Contains(other.transform.root.gameObject))
            {
                enemyCombatAI.hitEnemyColliders.Add(other.transform.root.gameObject);
            }
        }
    }
}
