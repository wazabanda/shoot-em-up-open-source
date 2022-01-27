using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public static player instance;
    public CharacterStats cs;
    public playerMovement playerMovement;
    public playerActions playerActions;
    public PlayerInput inputActions;
    private void Awake()
    {
        instance = this;
        cs = GetComponent<CharacterStats>();
        playerActions = GetComponent<playerActions>();
        playerMovement = GetComponent<playerMovement>();
        #region input
        inputActions = new PlayerInput();
        inputActions.playerControls.Enable();
        inputActions.playerControls.xMovment.performed += playerMovement.XMovment_performed;
        inputActions.playerControls.zMovement.performed += playerMovement.ZMovment_performed;
        inputActions.playerControls.jump.performed += playerMovement.Jump_performed;
        inputActions.playerControls.fireLeft.performed += playerActions.FireLeft_performed;
        inputActions.playerControls.fireRight.performed += playerActions.FireRight_performed;
        inputActions.playerControls.pickLeft.performed += playerActions.PickLeft_performed;
        inputActions.playerControls.pickRight.performed += playerActions.PickRight_performed;
        #endregion
    }

   
}
