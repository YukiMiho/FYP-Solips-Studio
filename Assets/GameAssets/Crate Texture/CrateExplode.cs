using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateExplode : MonoBehaviour
{
    public GameObject originalObject;
    public GameObject fracturedObject;
    public GameObject explosionVFX;
    public float explosionMinForce = 5;
    public float explosionMaxForce = 100;
    public float explosionForceRadius = 10;
    public float fragScaleFactor = 1;

    private GameObject fractObj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    void Explode()
    {
        
        if (originalObject != null)
        {
            originalObject.SetActive(false);
            

            if(fracturedObject != null)
            {
                fractObj = Instantiate(fracturedObject) as GameObject;

                foreach (Transform t in fractObj.transform)
                {
                    var rb = t.GetComponent<Rigidbody>();

                    if (rb != null)
                        rb.AddExplosionForce(Random.Range(explosionMinForce, explosionMaxForce), originalObject.transform.position, explosionForceRadius);
                    StartCoroutine(Shrink(t, 2));
                }

                Destroy(fractObj, 5);

                if (explosionVFX != null)
                {
                    GameObject exploVFX = Instantiate(explosionVFX) as GameObject;
                    Destroy(exploVFX, 7);
                }
            }
        }
    }

    void Reset()
    {
        Destroy(fractObj);
        originalObject.SetActive(true);
    }

    IEnumerator Shrink (Transform t, float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 newScale = t.localScale;

        while(newScale.x >= 0)
        {
            newScale -= new Vector3(fragScaleFactor, fragScaleFactor, fragScaleFactor);

            t.localScale = newScale;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
