using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Turret_Action : MonoBehaviour
{
    private CharacterController controller;

    public GameObject Tank_Turret;
    public GameObject Tank_Bullet;
    public GameObject ShootPoint;
    public Transform ShootPointObject;

    public Rigidbody2D rb;
    public Rigidbody2D rbShootPoint;
    private Vector2 turretlookdirection;
    private Vector2 turretshootdirection;
    private Vector2 moveShootPoint;
    private Vector2 shootdirection;
    public Sprite[] turret;
    private float bulletspeed;
    private float canshoot;
    private float countframe;
    private float shootspeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        rb = Tank_Turret.GetComponent<Rigidbody2D>();
        bulletspeed = 100f;
        countframe = 0f;
        shootspeed = 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbShootPoint = ShootPoint.GetComponent<Rigidbody2D>();
        moveShootPoint = rb.position;

        if (this.turretlookdirection.y > 0 && this.turretlookdirection.x == 0)//up
        {
            Tank_Turret.GetComponent<SpriteRenderer>().sprite = turret[6];
            moveShootPoint.x -= 0.015f;
            moveShootPoint.y += 0.28f;
            rbShootPoint.MovePosition(moveShootPoint);
            turretshootdirection.y = 1 + rbShootPoint.position.y;
            turretshootdirection.x = rbShootPoint.position.x;
        }
        else if (this.turretlookdirection.y < 0 && this.turretlookdirection.x == 0)//down
        {
            Tank_Turret.GetComponent<SpriteRenderer>().sprite = turret[2];
            moveShootPoint.x -= 0.01f;
            moveShootPoint.y -= 0.084f;
            rbShootPoint.MovePosition(moveShootPoint);
            turretshootdirection.y = rbShootPoint.position.y - 1;
            turretshootdirection.x = rbShootPoint.position.x;
        }
        else if (this.turretlookdirection.y == 0 && this.turretlookdirection.x > 0)//right
        {
            Tank_Turret.GetComponent<SpriteRenderer>().sprite = turret[4];
            moveShootPoint.x += 0.351f;
            moveShootPoint.y += 0.101f;
            rbShootPoint.MovePosition(moveShootPoint);
            turretshootdirection.y = rbShootPoint.position.y;
            turretshootdirection.x = 1 + rbShootPoint.position.x;
        }
        else if (this.turretlookdirection.y == 0 && this.turretlookdirection.x < 0)//left
        {
            Tank_Turret.GetComponent<SpriteRenderer>().sprite = turret[0];
            moveShootPoint.x -= 0.351f;
            moveShootPoint.y += 0.101f;
            rbShootPoint.MovePosition(moveShootPoint);
            turretshootdirection.y = rbShootPoint.position.y;
            turretshootdirection.x = rbShootPoint.position.x - 1;
        }
        else if (this.turretlookdirection.y > 0 && this.turretlookdirection.x > 0)//up right
        {
            Tank_Turret.GetComponent<SpriteRenderer>().sprite = turret[5];
            moveShootPoint.x += 0.23f;
            moveShootPoint.y += 0.216f;
            rbShootPoint.MovePosition(moveShootPoint);
            turretshootdirection.y = 0.6f + rbShootPoint.position.y;
            turretshootdirection.x = 1 + rbShootPoint.position.x;
        }
        else if (this.turretlookdirection.y < 0 && this.turretlookdirection.x < 0)//down left
        {
            Tank_Turret.GetComponent<SpriteRenderer>().sprite = turret[1];
            moveShootPoint.x -= 0.2473f;
            moveShootPoint.y -= 0.024f;
            rbShootPoint.MovePosition(moveShootPoint);
            turretshootdirection.y = rbShootPoint.position.y - 0.6f;
            turretshootdirection.x = rbShootPoint.position.x - 1;
        }
        else if (this.turretlookdirection.y > 0 && this.turretlookdirection.x < 0)//up left
        {
            Tank_Turret.GetComponent<SpriteRenderer>().sprite = turret[7];
            moveShootPoint.x -= 0.2561f;
            moveShootPoint.y += 0.226f;
            rbShootPoint.MovePosition(moveShootPoint);
            turretshootdirection.y = 0.6f + rbShootPoint.position.y;
            turretshootdirection.x = rbShootPoint.position.x - 1;
        }
        else if (this.turretlookdirection.y < 0 && this.turretlookdirection.x > 0)//down right
        {
            Tank_Turret.GetComponent<SpriteRenderer>().sprite = turret[3];
            moveShootPoint.x += 0.2639f;
            moveShootPoint.y -= 0.024f;
            rbShootPoint.MovePosition(moveShootPoint);
            turretshootdirection.y = rbShootPoint.position.y - 0.6f;
            turretshootdirection.x = 1 + rbShootPoint.position.x;
        }
        rbShootPoint.MovePosition(moveShootPoint);
        shootdirection = turretshootdirection - rbShootPoint.position;
        float shootangle = Mathf.Atan2(shootdirection.y, shootdirection.x) * Mathf.Rad2Deg - 90f;
        rbShootPoint.rotation = shootangle;

        countframe += 1f * Time.deltaTime;
        if (canshoot == 1f && countframe >= shootspeed)
        {
            Shoot();
            countframe = 0f;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        turretlookdirection = context.ReadValue<Vector2>();
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        canshoot = context.ReadValue<float>();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(Tank_Bullet, ShootPointObject.position, ShootPointObject.rotation);
        GetComponent<AudioSource>().Play();
        Rigidbody2D rbbullet = bullet.GetComponent<Rigidbody2D>();
        rbbullet.velocity = shootdirection * bulletspeed * Time.deltaTime;
    }

    public void ShootSpeed(float speed)
    {
        this.shootspeed = speed;
    }
}
