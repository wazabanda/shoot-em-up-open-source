using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*public enum weaponArm
{
    left,right
}*/
public class weapon : ScriptableObject
{
    public string weaponName;
    [Header("display")]
    public Material Material;
    public Color Color;
    public Sprite displaySprite;
    [Header("Transform")]
    public Vector3 positon, rotation, scale;
    [Header("Values")]
    public float damage;
    public float useRate;
    public int ammoUse;
    public virtual void activate(GameObject user, Vector3 activatePosition, Vector3 activateDirection, Quaternion rotation) { }
    public virtual void deactivate(GameObject user, Vector3 activatePosition, Vector3 activateDirection, Quaternion rotation) { }
    public virtual void onCollision(GameObject user,GameObject Collision) { }
}
