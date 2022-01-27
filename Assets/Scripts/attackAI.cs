using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackAI : MonoBehaviour
{
    public weapon weapon;
    public Transform shootPoint;
    public float useRateMultiplier = 1.5f;
    public float count;

    private void Awake()
    {
        
    }
    private void Update()
    {
        if(count > useRateMultiplier * weapon.useRate)
        {
            shootPoint.LookAt(player.instance.transform.position);

            weapon.activate(gameObject, shootPoint.position, shootPoint.forward, shootPoint.rotation);
            count = 0;
        }
        else
        {
            count += Time.deltaTime;
        }
    }
}
