using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grounded_State : State
{
    private Aerial_State Aerial_;
    private InputAction CharMove;

    private void Start()
    {
        Aerial_ = GetComponent<Aerial_State>();
        CharMove = GetComponent<InputAction>();
    }

    public override State ChangeState()
    {
        return Aerial_;
    }

    public override State RunCurrentState()
    {
        return this;
    }

    public override void checkMove(InputAction.CallbackContext context)
    {
        
    }

    public override void checkAttack(InputAction.CallbackContext context)
    {
        
    }
}
