using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Health : MonoBehaviour
{
    private int health;

    // Update is called once per frame
    void Update()
    {
        death();
    }

    //health in this function is set from other scritpr so we need setter to set it
    public void setHealth(int value)
    {
        health = value;
    }

    public int getHealth()
    {
        return health;
    }

    //function is called when enemy gets damaged
    public void getDamageEnemy(int damage)
    {
        health = health - damage;
    }

    //function chcecks if enemy has more health then 0 if not it "kills" him (sets activity to false)
    public void death()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
