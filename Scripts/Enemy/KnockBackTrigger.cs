using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackTrigger : MonoBehaviour
{
    //chcecks for collision with player and calls function knockback sends its current location
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.collider.CompareTag("Player"))
        {
            if (GetComponent<EnemyHealth>().getHealth() > 0) {
                if (collison.collider.GetComponent<Health>().getCanBeDamaged())
                {
                    collison.collider.GetComponent<PlayerMovement>().KnockBack(transform);
                    collison.collider.GetComponent<Health>().GetDamaged(10);
                }
            }
        }
    }
}
