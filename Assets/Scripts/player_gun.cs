using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_gun : MonoBehaviour
{
    public GameObject user;
    public Transform usePositon;
    public weapon weapon;
    bool canBeUsed = true;
    void Start()
    {
        canBeUsed = true;
    }
    private void Update()
    {

            transform.LookAt(playerInteraction.instance.getRayCastPosition());

    }
    // Update is called once per frame
    public void Activate()
    {
        if (weapon != null)
        {
            if (canBeUsed && playerActions.instance.AMMO >= weapon.ammoUse)
            {

                weapon.activate(user, usePositon.position, usePositon.right, usePositon.rotation);
                playerActions.instance.useAmmo(weapon.ammoUse, true);
                StartCoroutine(coolDown());
            }
        }
    }
    IEnumerator coolDown()
    {
        canBeUsed = false;
        yield return new WaitForSeconds(weapon.useRate);
        canBeUsed = true;
        weapon.deactivate(user, usePositon.position, usePositon.right, usePositon.rotation);
    }
}
