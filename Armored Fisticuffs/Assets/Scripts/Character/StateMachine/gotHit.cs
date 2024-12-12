using UnityEngine;

public class gotHit : MonoBehaviour
{
    private bool cangetHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cangetHit = true;
    }

    public void setgetHit(bool hit)
    {
        cangetHit = hit;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if got hit by a damage obj
        if (cangetHit && collision.gameObject.layer == 8)
        {

        }
    }
}
