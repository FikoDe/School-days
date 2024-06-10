using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float thrust = 5;
    [SerializeField]
    private float knockTime = 5F;
    [SerializeField]
    private Player_Attack_Data data;
    //private GameObject player = GameObject.FindGameObjectWithTag("Player");

    private void Start()
    {
        damage = data.damage;
        thrust = data.thrust;
        knockTime = data.knockBackTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if collision with somethinh finds out if it is enemy a then damages him and knocks him back
        if(collider.CompareTag("Enemy"))
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            collider.GetComponent<EnemyHealth>().getDamageEnemy(damage);
            //Debug.Log("Attack zavolany");
            try
            {
                collider.GetComponent<Enemy_Patrol_Basic>().KnockBackEnemy(player, thrust, knockTime);
            }
            catch (System.Exception) {}
            try
            {
                collider.GetComponent<Enemy_Patrol_Advance>().KnockBackEnemy(player, thrust, knockTime);
            }
            catch (System.Exception){}
        }
    }

}
