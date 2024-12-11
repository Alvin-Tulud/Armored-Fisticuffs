using UnityEngine;

public class Stun_State : State
{
    [SerializeField]
    private LayerMask ignorePlayer;

    private Aerial_State Aerial_;
    private Grounded_State Grounded_;

    private bool inStun;


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


        return this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool IsGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * 1f), Color.red, 1);
        return Physics2D.Raycast(transform.position, Vector3.down, 1f, ignorePlayer);
    }
}
