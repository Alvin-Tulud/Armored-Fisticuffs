using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aerial_State : State
{
    [SerializeField]
    private CharacterStats cStats;
    private float playerSpeed;
    [SerializeField]
    private LayerMask ignorePlayer;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Vector2 temp_Vec;
    private bool holding_Down_Move;

    private Grounded_State Grounded_;
    private Rigidbody2D Rigidbody_;
    private bool isRunning;

    private List<inputs> input_string;

    private void Start()
    {
        playerSpeed = cStats.Basic_Info.Character_Speed;

        temp_Vec = Vector2.zero;
        holding_Down_Move = false;

        Grounded_ = GetComponent<Grounded_State>();
        Rigidbody_ = GetComponent<Rigidbody2D>();
        isRunning = false;

        input_string = new List<inputs>(2);
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
            //Debug.Log("on ground");
            isRunning = false;
            holding_Down_Move = false;
            return Grounded_;
        }

        isRunning = true;
        return this;
    }

    private void FixedUpdate()
    {
        if (isRunning && holding_Down_Move)
        {
            if (Mathf.Abs(temp_Vec.x) > Mathf.Abs(temp_Vec.y))
            {
                //if horizontal value is left or right
                if (temp_Vec.x < 0)
                {
                    Rigidbody_.AddForceX(-playerSpeed, ForceMode2D.Force);
                }
                else if (temp_Vec.x > 0)
                {
                    Rigidbody_.AddForceX(playerSpeed, ForceMode2D.Force);
                }
            }
        }
    }

    public void checkMove(InputAction.CallbackContext context)
    {
        if (isRunning)
        {
            //check if input is the same as before
            //if so hold value that it is moving
            if (temp_Vec != context.ReadValue<Vector2>())
            {
                temp_Vec = context.ReadValue<Vector2>();

                holding_Down_Move = context.started;
            }
            //wait until input is over
            else if (context.canceled)
            {
                holding_Down_Move = false;
            }

            //if horizontal input is greater than vertical
            if (Mathf.Abs(temp_Vec.x) > Mathf.Abs(temp_Vec.y))
            {
                //if horizontal value is left or right
                if (temp_Vec.x < 0)
                {
                    //Debug.Log("left");
                    addString(inputs.Left);
                }
                else
                {
                    //Debug.Log("right");
                    addString(inputs.Right);
                }
            }
            //if vertical input is greater than horizontal
            else
            {
                //if vertical value is up or down
                if (temp_Vec.y < 0)
                {
                    //Debug.Log("down");
                    addString(inputs.Down);
                }
                else if (temp_Vec.y > 0)
                {
                    //Debug.Log("up");
                    addString(inputs.Up);
                }
            }
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * 1f), Color.red, 1);
        return Physics2D.Raycast(transform.position, Vector3.down, 1f, ignorePlayer);
    }

    private void addString(inputs inputtype)
    {
        //Debug.Log("Adding input");
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
