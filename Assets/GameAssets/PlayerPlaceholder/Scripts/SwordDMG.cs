using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDMG : MonoBehaviour
{

    public int damageAmount = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());
        if(other.tag == "TestEnemy1")
        {
            other.GetComponent<EnemyHP>().TakeDamage(damageAmount);
        }
    }


}
