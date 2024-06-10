using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Trigger : MonoBehaviour
{
    //after collison slows player
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.collider.CompareTag("Player"))
        {
            collison.collider.GetComponent<PlayerMovement>().KnockBack(transform);
            collison.collider.GetComponent<PlayerMovement>().Slow(GetComponent<Slow_Enemy_Patrol>().getDuration(), GetComponent<Slow_Enemy_Patrol>().getSlow());
            Destroy(this.gameObject);
        }
    }
}
