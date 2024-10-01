using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aerial_State : State
{
    private Grounded_State Grounded_;
    private InputAction CharMove;

    private void Start()
    {
        Grounded_ = GetComponent<Grounded_State>();
        CharMove = GetComponent<InputAction>();
    }
    public override State ChangeState()
    {
        return Grounded_;
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
