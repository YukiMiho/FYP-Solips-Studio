using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{

    public int HP = 100;
    public Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = HP;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //if(gameObject.tag == "Sword")
    //    //{
    //    //    HP = HP - 50;
    //    //    Debug.Log("Sword detected!");
    //    //}

    //    if(HP <= 0)
    //    {
    //        Destroy(gameObject);
    //        Destroy(healthBar);
    //    }
    //}

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0)
        {
            Destroy(gameObject);
            Destroy(healthBar);
        }
    }
}
