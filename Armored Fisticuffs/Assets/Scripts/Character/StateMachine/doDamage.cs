using UnityEngine;

public class doDamage : MonoBehaviour
{
    [SerializeField]
    private CharacterStats cStats;
    private Transform dmgLoc;
    private int canHit;

    private void Start()
    {
        dmgLoc = transform.GetChild(1).GetComponent<Transform>();
        canHit = 0;
    }

    private void Update()
    {
        if (canHit != 0)
        {
            checkHit();
        }
    }

    public void setcanHit(int hit)
    {
        canHit = hit;
    }

    private void checkHit()
    {
        RaycastHit2D hit;
        hit = Physics2D.CircleCast(dmgLoc.position, 0.2f, Vector2.zero);

        if (hit)
        {
            Rigidbody2D rb = hit.transform.GetComponent<Rigidbody2D>();

            Vector2 angle = Vector2.zero;

            float magnitude = 0f;

            int damage = 0;

            switch (canHit)
            {
                case 1:
                    damage = cStats.Grounded_Moves.Jab.Damage;
                    angle = cStats.Grounded_Moves.Jab.Launch_Angle;
                    magnitude = cStats.Grounded_Moves.Jab.Launch_Magnitude;
                    break;
                case 2:
                    damage = cStats.Grounded_Moves.SideTilt.Damage;
                    angle = cStats.Grounded_Moves.SideTilt.Launch_Angle;
                    magnitude = cStats.Grounded_Moves.SideTilt.Launch_Magnitude;
                    break;
                case 3:
                    damage = cStats.Grounded_Moves.DownTilt.Damage;
                    angle = cStats.Grounded_Moves.DownTilt.Launch_Angle;
                    magnitude = cStats.Grounded_Moves.DownTilt.Launch_Magnitude;
                    break;
                case 4:
                    damage = cStats.Grounded_Moves.UpTilt.Damage;
                    angle = cStats.Grounded_Moves.UpTilt.Launch_Angle;
                    magnitude = cStats.Grounded_Moves.UpTilt.Launch_Magnitude;
                    break;
                case 5:
                    damage = cStats.Grounded_Moves.Heavy_SildeTilt.Damage;
                    angle = cStats.Grounded_Moves.Heavy_SildeTilt.Launch_Angle;
                    magnitude = cStats.Grounded_Moves.Heavy_SildeTilt.Launch_Magnitude;
                    break;
                case 6:
                    damage = cStats.Grounded_Moves.Heavy_Down_Tilt.Damage;
                    angle = cStats.Grounded_Moves.Heavy_Down_Tilt.Launch_Angle;
                    magnitude = cStats.Grounded_Moves.Heavy_Down_Tilt.Launch_Magnitude;
                    break;
                case 7:
                    damage = cStats.Grounded_Moves.Heavy_Up_Tilt.Damage;
                    angle = cStats.Grounded_Moves.Heavy_Up_Tilt.Launch_Angle;
                    magnitude = cStats.Grounded_Moves.Heavy_Up_Tilt.Launch_Magnitude;
                    break;
                default:
                    break;
            }

            canHit = 0;

            if (transform.parent.transform.rotation.y < 0)
            {
                angle.x = -angle.x;
            }

            if (hit.transform.GetComponent<Grounded_State>().getRunning())
            {
                hit.transform.GetComponent<Grounded_State>().doStun();
            }
            else
            {
                hit.transform.GetComponent<Aerial_State>().doStun();
            }

            hit.transform.GetComponent<PlayerStats>().takeDmg(damage);

            rb.AddForce(angle * magnitude, ForceMode2D.Impulse);
        }
    }
}
