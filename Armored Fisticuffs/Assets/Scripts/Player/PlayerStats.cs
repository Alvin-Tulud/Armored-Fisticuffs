using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private int MaxHealth;
    private int Currhealth;
    public GameObject Yourheatlh;
    public GameObject Enemyhealth;
    
    public void setMaxHeatlh(int maxHeatlh)
    {
        MaxHealth = maxHeatlh;
        Currhealth = maxHeatlh;
    }

    public void takeDmg(int dmg)
    {
        Debug.Log(Currhealth + " : took dmg : " + dmg);
        Currhealth -= dmg;
        Yourheatlh.GetComponent<Slider>().value = Currhealth;
    }

    public void setYourHPSlider(GameObject obj)
    {
        Yourheatlh = obj;
    }
    public void setEnemyHPSlider(GameObject obj)
    {
        Enemyhealth = obj;
    }
}
