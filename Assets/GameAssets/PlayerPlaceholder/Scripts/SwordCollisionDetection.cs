using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisionDetection : MonoBehaviour
{
    public PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = transform.root.GetComponent<PlayerAttack>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (playerAttack.isBasicAttacking && other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit " + other.transform.root.name);
            if (!playerAttack.hitEnemyColliders.Contains(other.transform.root.gameObject))
            {
                playerAttack.hitEnemyColliders.Add(other.transform.root.gameObject);
            }
        }
    }
}
