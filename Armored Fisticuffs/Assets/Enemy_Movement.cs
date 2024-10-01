using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy_Movement : MonoBehaviour
{
    public GameObject Tank_Hull;
    public Rigidbody2D rb;
    private Vector2 moveInput;
    public Sprite[] hull;
    private float speed;

    void Start()
    {
        rb = Tank_Hull.GetComponent<Rigidbody2D>();
        speed = 0f;
    }

    void FixedUpdate()
    {
        if (this.moveInput.y > 0 && this.moveInput.x == 0)//up
        {
            Tank_Hull.GetComponent<SpriteRenderer>().sprite = hull[6];
        }
        else if (this.moveInput.y < 0 && this.moveInput.x == 0)//down
        {
            Tank_Hull.GetComponent<SpriteRenderer>().sprite = hull[2];
        }
        else if (this.moveInput.y == 0 && this.moveInput.x > 0)//right
        {
            Tank_Hull.GetComponent<SpriteRenderer>().sprite = hull[4];
        }
        else if (this.moveInput.y == 0 && this.moveInput.x < 0)//left
        {
            Tank_Hull.GetComponent<SpriteRenderer>().sprite = hull[0];
        }
        else if (this.moveInput.y > 0 && this.moveInput.x > 0)//up right
        {
            Tank_Hull.GetComponent<SpriteRenderer>().sprite = hull[5];
        }
        else if (this.moveInput.y < 0 && this.moveInput.x < 0)//down left
        {
            Tank_Hull.GetComponent<SpriteRenderer>().sprite = hull[1];
        }
        else if (this.moveInput.y > 0 && this.moveInput.x < 0)//up left
        {
            Tank_Hull.GetComponent<SpriteRenderer>().sprite = hull[7];
        }
        else if (this.moveInput.y < 0 && this.moveInput.x > 0)//down right
        {
            Tank_Hull.GetComponent<SpriteRenderer>().sprite = hull[3];
        }
        this.rb.velocity = this.moveInput * this.speed * Time.deltaTime;
    }

    public void OnMove(Vector2 move)
    {
        moveInput = move;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
