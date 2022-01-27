using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "melee", menuName = "ScriptableObjects/weapons/melee")]

public class melee : weapon
{
    public float radius;
    public float knockBack;
    public override void activate(GameObject user, Vector3 activatePosition, Vector3 activateDirection, Quaternion rotation)
    {
        Collider[] colliders = Physics.OverlapSphere(activatePosition, radius);
        foreach (var item in colliders)
        {
            if(item.gameObject == user)
            {
                continue;
            }
            if(item.TryGetComponent(out Rigidbody rb))
            {
                rb.AddExplosionForce(knockBack, activatePosition, radius);
            }
            if(item.TryGetComponent(out Ihittable hit))
            {
                hit.OnHit(damage, this, user);
            }
        }
    }
}
