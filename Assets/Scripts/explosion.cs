using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float explosionForce,radius;
    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var item in colliders)
        {
            if(item.TryGetComponent(out Rigidbody rb))
            {
                Vector3 dir = item.transform.position - transform.position;
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
