using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingTrap : MonoBehaviour
{
    [SerializeField]
    private float lenght = 2f;
    [SerializeField]
    private float newSpeed = 1f;
    //chcecks for collision with player and calls function knockback sends its current location
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().Slow(lenght, newSpeed);
        }
    }
}
