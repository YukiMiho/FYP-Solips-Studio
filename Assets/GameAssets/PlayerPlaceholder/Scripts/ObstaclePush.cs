using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField] private float ForceMagnitude = 1;

    [SerializeField] private float _speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * ForceMagnitude, transform.position, ForceMode.Impulse);

        }

        if (hit.collider.CompareTag($"MovableObject"))
        {
            if (hit.collider.gameObject.GetComponent<Rigidbody>() == null) return;
            var pushDir = new Vector3(hit.moveDirection.x, 0, 0);
            hit.collider.attachedRigidbody.velocity = pushDir * _speed;
        }
    }
}
