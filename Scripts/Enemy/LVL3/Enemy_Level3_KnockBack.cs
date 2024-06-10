using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Level3_KnockBack : MonoBehaviour
{
    //chcecks for collision with player and calls function knockback sends its current location
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Health>().getCanBeDamaged()) {
                collision.GetComponent<PlayerMovement>().KnockBack(transform);
                collision.GetComponent<Health>().GetDamaged(10);
            }
        }
    }

}
