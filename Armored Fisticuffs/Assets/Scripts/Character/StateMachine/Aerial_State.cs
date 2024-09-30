using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aerial_State : State
{
    private Grounded_State Grounded_;

    private void Start()
    {
        Grounded_ = GetComponent<Grounded_State>();
    }
    public override State ChangeState()
    {
        return Grounded_;
    }

    public override State RunCurrentState()
    {
        return this;
    }

    private void checkInput()
    {
        
    }
}
