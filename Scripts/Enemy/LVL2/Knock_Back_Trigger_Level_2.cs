using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knock_Back_Trigger_Level_2 : MonoBehaviour
{
    //damages and knocksback player
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.collider.CompareTag("Player"))
        {
            if (GetComponent<EnemyHealth>().getHealth() > 0)
            {
                if (collison.collider.GetComponent<Health>().getCanBeDamaged())
                {
                    if (Random.Range(1, 10) > 1)
                    {
                        collison.collider.GetComponent<PlayerMovement>().KnockBack(transform);
                        collison.collider.GetComponent<Health>().GetDamaged(10);
                        GetComponent<Enemy_Patrol_Basic>().setCanMove(false);
                        StartCoroutine(MovementAble());
                    }
                    else
                    {
                        collison.collider.GetComponent<PlayerMovement>().KnockBack(transform);
                        collison.collider.GetComponent<Health>().GetDamaged(-10);
                        GetComponent<Enemy_Patrol_Basic>().setCanMove(false);
                        StartCoroutine(MovementAble());
                    }
                }
            }

        }
    }

    private IEnumerator MovementAble()
    {
        yield return new WaitForSeconds(0.75f);
        GetComponent<Enemy_Patrol_Basic>().setCanMove(true);
    }
}
