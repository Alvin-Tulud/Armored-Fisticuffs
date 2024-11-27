using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Grounded_State : State
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private CharacterController controller;
    private Aerial_State Aerial_;
    private Rigidbody Rigidbody_;
    private bool isRunning;

    private List<inputs> input_string;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
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
        isRunning = true;
        return this;
    }

    private void Update()
    {
        
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
                Debug.Log("input jump");
            }
        }
    }

    private void addString(inputs inputtype)
    {
        //Debug.Log("Adding input");
        if (input_string.Count == 3)
        {
            input_string.Remove(0);
        }

        input_string.Add(inputtype);
    }

    private void checkString()
    {

    }
}
