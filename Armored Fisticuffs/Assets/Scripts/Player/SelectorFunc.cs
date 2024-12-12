using UnityEngine;
using UnityEngine.InputSystem;

public class SelectorFunc : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 temp_Vec;
    private bool holding_Down_Movement;
    public int playerspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        temp_Vec = Vector2.zero;
        holding_Down_Movement = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkMove();
    }

    public void checkMove()
    {
        if (holding_Down_Movement)
        {
            rb.linearVelocity = temp_Vec * playerspeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void moveCursor(InputAction.CallbackContext context)
    {
        //check if input is the same as before
        //if so hold value that it is moving
        if (temp_Vec != context.ReadValue<Vector2>())
        {
            temp_Vec = context.ReadValue<Vector2>();

            holding_Down_Movement = context.started;
        }
        //wait until input is over
        else if (context.canceled)
        {
            holding_Down_Movement = false;
        }
    }
    public void chooseCursor(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {

        }
    }
}
