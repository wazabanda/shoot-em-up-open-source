using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "dash", menuName = "ScriptableObjects/weapons/dash")]

public class dash : weapon
{
    public float dashForce;
    public override void activate(GameObject user, Vector3 activatePosition, Vector3 activateDirection, Quaternion rotation)
    {
        Rigidbody rb = user.GetComponent<Rigidbody>();
        rb.AddForce(user.transform.forward * dashForce);
    }
    public override void deactivate(GameObject user, Vector3 activatePosition, Vector3 activateDirection, Quaternion rotation)
    {
        Rigidbody rb = user.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }
    
}
