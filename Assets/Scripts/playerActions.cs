using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class playerActions : MonoBehaviour
{
    public int AMMO;
    public TextMeshProUGUI ammoText;
    public LayerMask pickLayer;
    public float pickDistance;
    [Header("Abilities")]
    public Animator kickAnimation;
    public string kickTrigger;
    public player_gun leftWeopon, rightWeopon;
    public static playerActions instance;
    Camera mainCamera;
    public bool shootingLeft, shootingRight;
    private void Awake()
    {
        instance = this;
        mainCamera = Camera.main;
        ammoText?.SetText("AMMO: " + AMMO.ToString());
        shootingLeft = false;
        shootingRight = false;
    }
    private void Update()
    {

        #region pickUP
       


        #endregion
        if (shootingRight)
        {
            rightWeopon.Activate();

        }
        if (shootingLeft)
        {
            leftWeopon.Activate();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            kickAnimation.SetTrigger(kickTrigger);
        }
        }
    public void useAmmo(int amount,bool usingAmmo) {

        AMMO += (usingAmmo == true) ? -amount : amount;
        ammoText?.SetText("AMMO: " + AMMO.ToString());
    }
   

    public  RaycastHit getHit()
    {
        RaycastHit hit = new RaycastHit();
        if (mainCamera != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, pickDistance, pickLayer))
            {
                return hit;
            }
        }
        return hit;

    }

    #region events
    public void FireLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        shootingLeft = obj.ReadValue<float>() > 0 ? true : false;

    }
    public void FireRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        shootingRight = obj.ReadValue<float>() > 0 ? true : false;

    }
    public void PickLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (getHit().collider != null)
        {
            weaponPickUps weaponPickUps = getHit().collider.gameObject.GetComponent<weaponPickUps>();
            if (leftWeopon.transform.childCount > 0)
            {
                Transform pickTransform = leftWeopon.transform.GetChild(0).transform;

                if (pickTransform != null)
                {
                    pickTransform.parent = null;
                    pickTransform.GetComponent<weaponPickUps>().enabled = true;

                }
            }
            weaponPickUps.pickUp(leftWeopon.transform);
            leftWeopon.weapon = weaponPickUps.weapon;
            leftWeopon.usePositon = weaponPickUps.usePositon;
        }
    }
    public void PickRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (getHit().collider != null )
        {
            weaponPickUps weaponPickUps = getHit().collider.gameObject.GetComponent<weaponPickUps>();
            if (rightWeopon.transform.childCount > 0)
            {
                Transform pickTransform = rightWeopon.transform.GetChild(0).transform;
                if (pickTransform != null)
                {
                    pickTransform.parent = null;
                    pickTransform.GetComponent<weaponPickUps>().enabled = true;
                }
            }

            weaponPickUps.pickUp(rightWeopon.transform);
            rightWeopon.weapon = weaponPickUps.weapon;
            rightWeopon.usePositon = weaponPickUps.usePositon;
        }
    }
    #endregion
}
