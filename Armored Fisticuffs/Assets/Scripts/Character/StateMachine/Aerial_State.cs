using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aerial_State : State
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private LayerMask ignorePlayer;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Grounded_State Grounded_;
    private Rigidbody2D Rigidbody_;
    private bool isRunning;

    private List<inputs> input_string;

    private void Start()
    {
        Grounded_ = GetComponent<Grounded_State>();
        Rigidbody_ = GetComponent<Rigidbody2D>();
        isRunning = false;
    }
    public override State ChangeState()
    {
        isRunning = false;
        return Grounded_;
    }

    public override State RunCurrentState()
    {
        if (IsGrounded())
        {
            Debug.Log("on ground");
            isRunning = false;
            return Grounded_;
        }

        isRunning = true;
        return this;
    }

    private void FixedUpdate()
    {
        
    }

    public void checkMove(InputAction.CallbackContext context)
    {
        if (isRunning)
        {
            Vector2 temp_Vec = context.ReadValue<Vector2>();

            //if horizontal input is greater than vertical
            if (Mathf.Abs(temp_Vec.x) > Mathf.Abs(temp_Vec.y))
            {
                //if horizontal value is left or right
                if (temp_Vec.x < 0)
                {
                    addString(inputs.Left);
                }
                else
                {
                    addString(inputs.Right);
                }
            }
            //if vertical input is greater than horizontal
            else
            {
                //if vertical value is up or down
                if (temp_Vec.y < 0)
                {
                    addString(inputs.Down);
                }
                else
                {
                    addString(inputs.Up);
                }
            }
        }
    }

    public void checkLightAttack(InputAction.CallbackContext context)
    {
        if (isRunning)
        {
            if (context.action.triggered)
            {
                addString(inputs.Light);
            }
        }
    }

    public void checkHeavyAttack(InputAction.CallbackContext context)
    {
        if (isRunning)
        {
            if (context.action.triggered)
            {
                addString(inputs.Heavy);
            }
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * 0.55f), Color.red, 1);
        return Physics2D.Raycast(transform.position, Vector3.down, 0.55f, ignorePlayer);
    }

    private void addString(inputs inputtype)
    {
        Debug.Log("Adding input");
        if (input_string.Count == 2)
        {
            input_string.Remove(0);
        }

        input_string.Add(inputtype);
    }

    private void checkString()
    {
        
    }
}
