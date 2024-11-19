using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grounded_State : State
{
    private Aerial_State Aerial_;
    private Rigidbody Rigidbody_;
    private bool isRunning;

    private List<inputs> input_string;

    private void Start()
    {
        Aerial_ = GetComponent<Aerial_State>();
        Rigidbody_ = GetComponent<Rigidbody>();
        isRunning = false;

        input_string = new List<inputs>(3);
    }

    public override State ChangeState()
    {
        isRunning = false;
        return Aerial_;
    }

    public override State RunCurrentState()
    {
        isRunning = false;
        return this;
    }

    private void FixedUpdate()
    {

    }

    public void checkMove(InputAction.CallbackContext context)
    {
        if (input_string.Count == 3)
        {
            input_string.Remove(0);
        }
    }

    public void CheckJump(InputAction.CallbackContext context)
    {

    }

    public void checkAttack(InputAction.CallbackContext context)
    {
        if (input_string.Count == 3)
        {
            input_string.Remove(0);
        }
    }
}
