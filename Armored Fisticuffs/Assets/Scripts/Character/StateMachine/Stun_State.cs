using UnityEngine;

public class Stun_State : State
{
    private Aerial_State Aerial_;
    private Grounded_State Grounded_;

    void Start()
    {
        Aerial_ = GetComponent<Aerial_State>();
        Grounded_ = GetComponent<Grounded_State>();
    }

    public override State ChangeState()
    {
        throw new System.NotImplementedException();
    }

    public override State RunCurrentState()
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
