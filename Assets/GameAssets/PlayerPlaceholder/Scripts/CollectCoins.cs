using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
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
        if(gameObject.tag == "Coins")
        {
            other.GetComponent<PlayerCollectCoins>().points+=1;
            Debug.Log("It works");
            


            Destroy(gameObject);
        }
        // other.GetComponent<PlayerCollectCoins>().points--;
    }

}
