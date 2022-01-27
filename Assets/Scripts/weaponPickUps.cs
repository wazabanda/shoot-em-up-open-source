using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickUps : MonoBehaviour
{
    [SerializeField] private List<weapon> weapons;
    Material Material;
    public Transform usePositon;
    public weapon weapon;
    private SpriteRenderer spriteRender;
   public Collider Collider;
    billBoard billBoard;
    Rigidbody rb;
    DeactivateAfterX DeactivateAfterX;
    private void Start()
    {
        DeactivateAfterX = GetComponent<DeactivateAfterX>();
        rb = GetComponent<Rigidbody>();
        billBoard = GetComponent<billBoard>();
        Collider = GetComponent<Collider>();
        spriteRender = GetComponent<SpriteRenderer>();
        Material = spriteRender.material;
        weapon = weapons[Random.Range(0,weapons.Count)];
        spriteRender.sprite = weapon.displaySprite;
        spriteRender.color = weapon.Color;
/*        if(weapon.Material != null)
        {
            spriteRender.material = weapon.Material;
        }*/
        
    }
    public void OnEnable()
    {

        if (spriteRender != null)
        {
            spriteRender.sprite = weapon.displaySprite;
            spriteRender.color = weapon.Color;
            spriteRender.material = Material;
            Collider.enabled = true;
            billBoard.enabled = true;
            rb.isKinematic = false;
            DeactivateAfterX.enabled = false;
            DeactivateAfterX.setDeactivateAfterTime(60);
        }
    }
    public void pickUp(Transform parent)
    {
        rb.isKinematic = true;

        Collider.enabled = false;
        billBoard.enabled = false;
        transform.parent = parent;
        transform.localPosition = weapon.positon;
        transform.localScale = weapon.scale;
        transform.localRotation = Quaternion.Euler(weapon.rotation);
        spriteRender.material = weapon.Material;
        DeactivateAfterX.enabled = false;
        this.enabled = false;
    }
}
