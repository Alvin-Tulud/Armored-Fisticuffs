using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aerial_State : State
{
    private Grounded_State Grounded_;
    private Rigidbody Rigidbody_;
    private bool isRunning;

    private void Start()
    {
        Grounded_ = GetComponent<Grounded_State>();
        Rigidbody_ = GetComponent<Rigidbody>();
        isRunning = false;
    }
    public override State ChangeState()
    {
        isRunning = false;
        return Grounded_;
    }

    public override State RunCurrentState()
    {
        isRunning = true;
        return this;
    }

    private void FixedUpdate()
    {
        
    }

    public override void checkInput(InputAction.CallbackContext context)
    {
        
    }
}
