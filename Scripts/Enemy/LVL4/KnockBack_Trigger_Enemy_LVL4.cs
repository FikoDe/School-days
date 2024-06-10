using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack_Trigger_Enemy_LVL4 : MonoBehaviour
{
    //knocbacks enemy and damges them
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.collider.CompareTag("Player"))
        {
            if (GetComponent<EnemyHealth>().getHealth() > 0)
            {
                if (collison.collider.GetComponent<Health>().getCanBeDamaged())
                {
                    collison.collider.GetComponent<PlayerMovement>().KnockBack(transform);
                    collison.collider.GetComponent<Health>().GetDamaged(10);
                    GetComponent<Enemy_Patrol_Advance>().setCanMove(false);
                    StartCoroutine(MovementAble());
                }
            }
        }
    }

    private IEnumerator MovementAble()
    {
        yield return new WaitForSeconds(0.75f);
        GetComponent<Enemy_Patrol_Advance>().setCanMove(true);
    }
}
