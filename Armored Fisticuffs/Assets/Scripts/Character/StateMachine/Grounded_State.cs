using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded_State : State
{
    private Aerial_State Aerial_;

    private void Start()
    {
        Aerial_ = GetComponent<Aerial_State>();
    }

    public override State ChangeState()
    {
        return Aerial_;
    }

    public override State RunCurrentState()
    {
        return this;
    }
}
