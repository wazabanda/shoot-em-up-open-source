using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="gun",menuName ="ScriptableObjects/weapons/gun")]

public class gun : weapon
{
    public GameObject bullet,particle;
    public string gunSound;
    public int bulletNumber;
    public float rotaitonOffset;
    public float speed;
    public override void activate(GameObject user, Vector3 activatePosition, Vector3 activateDirection,Quaternion rotation)
    {
        audioManager.instance.playSound(gunSound);
        for (int i = 0; i < bulletNumber; i++)
        {

        GameObject bullet = Instantiate(this.bullet, activatePosition, rotation);
        bullet.transform.Rotate(0, Random.Range(0, rotaitonOffset), Random.Range(0, rotaitonOffset));
        projectileScript projectileScript = bullet.GetComponent<projectileScript>();
            projectileScript.particle = particle;
        projectileScript.setDamage(damage);
        projectileScript.firedBy = user;
        projectileScript.speed = speed;
        projectileScript.direction = activateDirection;
        projectileScript.setParams();

        }
        
    }
}
