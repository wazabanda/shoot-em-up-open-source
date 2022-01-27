using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public enum controlState
{
    player,
    neutral,
    enemy
}

public enum ActionState
{
   idle,
    movingDown,
    movingUp,
    movingLeft,
    movingRight,
    sliding,
    attacking,
    dashing,
    wallSliding,climbing, deafeted
}
public class StateManager : MonoBehaviour
{
    public class onStateChangedArgs: EventArgs { public ActionState Actionstate; public controlState controlState; }
    public bool isControled = false;
    public event EventHandler<onStateChangedArgs> onStateChanged;
    public controlState ControlState;
    public ActionState actionState;
    [Header("For debugging")]
    public TextMeshPro debugingText;
    public void changeActionState(ActionState newState)
    {
        if (newState != actionState)
        {
            actionState = newState;
            if (debugingText != null)
            {
                debugingText.SetText(newState.ToString());
            }
            onStateChanged?.Invoke(this, new onStateChangedArgs { Actionstate = actionState, controlState = ControlState });
        }
    }
}
