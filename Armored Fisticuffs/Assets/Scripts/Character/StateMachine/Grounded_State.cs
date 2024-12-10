using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Grounded_State : State
{
    [SerializeField]
    private CharacterStats cStats;
    private float playerSpeed;
    private float jumpHeight;
    private float gravityValue = -9.81f;
    [SerializeField]
    private LayerMask ignorePlayer;
    private Vector3 playerVelocity;
    private Vector2 temp_Vec;
    private bool holding_Down_Movement;

    private bool canInput;

    private Aerial_State Aerial_;
    private Rigidbody2D Rigidbody_;
    private Animation Animation_;
    private bool isRunning;
    private bool startedAnim;

    private List<inputs> input_string;

    private void Start()
    {
        playerSpeed = cStats.Basic_Info.Character_Speed * 100;
        jumpHeight = cStats.Basic_Info.Character_Jump * 100;

        temp_Vec = Vector2.zero;
        holding_Down_Movement = false;

        canInput = true;

        Aerial_ = GetComponent<Aerial_State>();
        Rigidbody_ = GetComponent<Rigidbody2D>();
        Animation_ = transform.GetChild(0).GetComponent<Animation>();
        isRunning = false;

        startedAnim = false;

        input_string = new List<inputs>(2);

        Debug.Log("Adding input: " + input_string.Count);
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
            //Debug.Log("in air");
            isRunning = false;
            holding_Down_Movement = false;
            return Aerial_;
        }
        else if (IsGrounded() && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        Rigidbody_.linearVelocity = playerVelocity * Time.deltaTime;



        if (Animation_.isPlaying)
        {
            Debug.Log("is playing anim");
            canInput = false;
        }
        else if (startedAnim && !Animation_.isPlaying)
        {
            Debug.Log("done anim");
            canInput = true;

            startedAnim = false;
        }

        isRunning = true;
        return this;
    }

    private void FixedUpdate()
    {
        if (isRunning && holding_Down_Movement)
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
        //Debug.Log("input");
        if (isRunning && canInput)
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

            //if horizontal input is greater than vertical
            if (Mathf.Abs(temp_Vec.x) > Mathf.Abs(temp_Vec.y) && context.started)
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
            else if (context.started)
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
        if (isRunning && canInput)
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
        if (isRunning && canInput)
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
        if (isRunning && canInput)
        {
            if (context.action.triggered)
            {
                Debug.Log("input jump");
                jumpChar();
            }
        }
    }

    private void addString(inputs inputtype)
    {
        
        input_string.Add(inputtype);

        Debug.Log("Adding input: " + input_string.Count);
        if (input_string.Count == 2)
        {
            Debug.Log("checking string: " + input_string[0] + " , " + input_string[1]);
            checkString();
        }
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
            Debug.Log("jumped");
            Rigidbody_.AddForceY(jumpHeight, ForceMode2D.Force);
        }
    }

    private void checkString()
    {
        //Debug.Log("check");
        if (input_string[1] == inputs.Light)
        {
            //Debug.Log("check light");
            if (input_string[0] == inputs.Light)
            {
                Debug.Log("jab");
                Animation_.clip = cStats.Grounded_Moves.Jab.Hit_Anim;
            }
            if (input_string[0] == inputs.Left || input_string[0] == inputs.Right)
            {
                Debug.Log("ftilt");
                Animation_.clip = cStats.Grounded_Moves.SideTilt.Hit_Anim;
            }
            if (input_string[0] == inputs.Down)
            {
                Debug.Log("dtilt");
                Animation_.clip = cStats.Grounded_Moves.DownTilt.Hit_Anim;
            }
            if (input_string[0] == inputs.Up)
            {
                Debug.Log("utilt");
                Animation_.clip = cStats.Grounded_Moves.UpTilt.Hit_Anim;
            }
        }
        else if (input_string[1] == inputs.Heavy)
        {
            //Debug.Log("check heavy");
            if (input_string[0] == inputs.Left || input_string[0] == inputs.Right)
            {
                Debug.Log("fsmash");
                Animation_.clip = cStats.Grounded_Moves.Heavy_SildeTilt.Hit_Anim;
            }
            if (input_string[0] == inputs.Down)
            {
                Debug.Log("dsmash");
                Animation_.clip = cStats.Grounded_Moves.Heavy_Down_Tilt.Hit_Anim;
            }
            if (input_string[0] == inputs.Up)
            {
                Debug.Log("usmash");
                Animation_.clip = cStats.Grounded_Moves.Heavy_Up_Tilt.Hit_Anim;
            }
        }
        else 
        {
            input_string.Clear();
            return;
        }

        Rigidbody_.linearVelocity = Vector2.zero;
        input_string.Clear();

        Animation_.Play();

        startedAnim = true;


        Debug.Log("Playing anim: " + Animation_.isPlaying + " , " + Animation_.clip);
    }
}
