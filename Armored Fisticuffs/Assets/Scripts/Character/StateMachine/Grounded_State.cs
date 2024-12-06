using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Grounded_State : State
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 3.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private LayerMask ignorePlayer;

    private Vector3 playerVelocity;

    private Aerial_State Aerial_;
    private Rigidbody2D Rigidbody_;
    private bool isRunning;

    private List<inputs> input_string;

    private void Start()
    {
        Aerial_ = GetComponent<Aerial_State>();
        Rigidbody_ = GetComponent<Rigidbody2D>();
        isRunning = false;

        input_string = new List<inputs>(2);
    }

    public override State ChangeState()
    {
        isRunning = false;
        return Aerial_;
    }

    public override State RunCurrentState()
    {
        if (!IsGrounded())
        {
            Debug.Log("in air");
            isRunning = false;
            return Aerial_;
        }

        if (IsGrounded() && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        Rigidbody_.velocity = playerVelocity * Time.deltaTime;

        isRunning = true;
        return this;
    }

    private void FixedUpdate()
    {

    }

    public void checkMove(InputAction.CallbackContext context)
    {
        //Debug.Log("input");
        if (isRunning)
        {
            Vector2 temp_Vec = context.ReadValue<Vector2>();

            //if horizontal input is greater than vertical
            if (Mathf.Abs(temp_Vec.x) > Mathf.Abs(temp_Vec.y))
            {
                //if horizontal value is left or right
                if (temp_Vec.x < 0)
                {
                    Debug.Log("input left");
                    addString(inputs.Left);
                }
                else if (temp_Vec.x > 0)
                {
                    Debug.Log("input right");
                    addString(inputs.Right);
                }
            }
            //if vertical input is greater than horizontal
            else
            {
                //if vertical value is up or down
                if (temp_Vec.y < 0)
                {
                    Debug.Log("input down");
                    addString(inputs.Down);
                }
                else if (temp_Vec.y > 0)
                {
                    Debug.Log("input up");
                    addString(inputs.Up);
                }
            }
        }
    }

    public void checkLightAttack(InputAction.CallbackContext context)
    {
        //Debug.Log("input");
        if (isRunning)
        {
            if (context.action.triggered)
            {
                Debug.Log("input light");
                addString(inputs.Light);
            }
        }
    }

    public void checkHeavyAttack(InputAction.CallbackContext context)
    {
        //Debug.Log("input");
        if (isRunning)
        {
            if (context.action.triggered)
            {
                Debug.Log("input heavy");
                addString(inputs.Heavy);
            }
        }
    }

    public void checkJump(InputAction.CallbackContext context)
    {
        //Debug.Log("input");
        if (isRunning)
        {
            if (context.action.triggered)
            {
                //Debug.Log("input jump");
                jumpChar();
            }
        }
    }

    private void addString(inputs inputtype)
    {
        if (inputtype < inputs.Light)
        {
            moveChar(inputtype);
        }

        //Debug.Log("Adding input");
        if (input_string.Count == 2)
        {
            checkString();

            input_string.Remove(0);
        }

        input_string.Add(inputtype);
    }

    private bool IsGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * 0.55f), Color.blue, 1);
        return Physics2D.Raycast(transform.position, Vector3.down, 0.55f, ignorePlayer);
    }

    private void jumpChar()
    {
        if (IsGrounded())
        {
            //Debug.Log("jumped");
            Rigidbody_.AddForceY(jumpHeight, ForceMode2D.Force);
        }
    }

    private void moveChar(inputs inputtype)
    {
        if (inputtype == inputs.Left)
        {
            playerVelocity.x -= playerSpeed;
        }
        else if (inputtype == inputs.Right)
        {
            playerVelocity.x += playerSpeed;
        }
    }

    private void checkString()
    {
        if (input_string[0] < inputs.Light && input_string[1] >= inputs.Light)
        {

        }
    }
}
