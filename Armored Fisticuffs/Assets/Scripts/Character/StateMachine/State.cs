using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class State : MonoBehaviour
{
    public abstract State RunCurrentState();

    public abstract State ChangeState();

    public abstract void checkMove(InputAction.CallbackContext context);

    public abstract void checkAttack(InputAction.CallbackContext context);
}
