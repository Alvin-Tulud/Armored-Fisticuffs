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
    private Stun_State Stun_;
    private Rigidbody2D Rigidbody_;
    private bool isRunning;
    private bool gotStun;

    private void Start()
    {
        playerSpeed = cStats.Basic_Info.Character_Speed;

        temp_Vec = Vector2.zero;
        holding_Down_Move = false;

        Grounded_ = GetComponent<Grounded_State>();
        Stun_ = GetComponent<Stun_State>();
        Rigidbody_ = GetComponent<Rigidbody2D>();
        isRunning = false;
        gotStun = false;
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

        checkHorizontalMove();

        isRunning = true;
        return this;
    }

    public bool getRunning()
    {
        return isRunning;
    }

    public void doStun()
    {
        gotStun = true;
    }

    public void checkHorizontalMove()
    {
        if (isRunning && holding_Down_Move)
        {
            if (Mathf.Abs(temp_Vec.x) > Mathf.Abs(temp_Vec.y))
            {
                //if horizontal value is left or right
                if (temp_Vec.x < 0)
                {
                    Rigidbody_.linearVelocityX = -playerSpeed;
                }
                else if (temp_Vec.x > 0)
                {
                    Rigidbody_.linearVelocityX = playerSpeed;
                }
            }
            else
            {
                Rigidbody_.linearVelocityX = 0;
            }
        }
        else if (!holding_Down_Move)
        {
            Rigidbody_.linearVelocityX = 0;
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
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * 1f), Color.red, 1);
        return Physics2D.Raycast(transform.position, Vector3.down, 1f, ignorePlayer);
    }
}
