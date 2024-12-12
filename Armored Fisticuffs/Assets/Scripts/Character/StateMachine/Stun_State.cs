using System.Collections;
using UnityEngine;

public class Stun_State : State
{
    [SerializeField]
    private LayerMask ignorePlayer;

    private Aerial_State Aerial_;
    private Grounded_State Grounded_;

    private bool inStun;
    private bool firstCall;


    void Start()
    {
        Aerial_ = GetComponent<Aerial_State>();
        Grounded_ = GetComponent<Grounded_State>();

        inStun = false;
    }

    public override State ChangeState()
    {
        throw new System.NotImplementedException();
    }

    public override State RunCurrentState()
    {
        if (firstCall)
        {
            inStun = true;

            StartCoroutine(stunTimer());
        }

        else if (!inStun)
        {
            firstCall = true;

            if (IsGrounded())
            {
                return Grounded_;
            }
            else
            {
                return Aerial_;
            }
        }

        return this;
    }

    IEnumerator stunTimer()
    {
        firstCall = false;
        yield return new WaitForSeconds(0.2f);

        inStun = false;
    }

    private bool IsGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * 1f), Color.red, 1);
        return Physics2D.Raycast(transform.position, Vector3.down, 1f, ignorePlayer);
    }
}
