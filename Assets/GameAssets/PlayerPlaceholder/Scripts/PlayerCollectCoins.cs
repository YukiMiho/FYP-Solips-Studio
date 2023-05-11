using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectCoins : MonoBehaviour
{
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(100,100,100,100), "Score: " + points);   
    }
}
