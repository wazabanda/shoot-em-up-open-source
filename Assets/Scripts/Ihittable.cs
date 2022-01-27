using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ihittable{
    void OnHit(float damage = 0, weapon firedWeapon = null,GameObject Hitter = null);
    void DrainStamina(float drainAmount = 0);
}
