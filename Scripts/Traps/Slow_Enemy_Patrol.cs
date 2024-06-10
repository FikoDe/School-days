using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Enemy_Patrol : MonoBehaviour
{

    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float chceckRadius;
    [SerializeField]
    private float slowDuration;
    [SerializeField]
    private float slowValue;

    [SerializeField]
    private LayerMask whatIsPlayer;

    [SerializeField]
    private Slow_enemy_data data;

    private Transform target;
    private Rigidbody2D rb;

    private bool seesPlayer = false;

    void Start()
    {
        setUpData();
        this.GetComponent<Slow_Health>().setHealth(health);
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void setUpData()
    {
        health = data.health;
        speed = data.speed;
        chceckRadius = data.chceckRadius;
        whatIsPlayer = data.whatIsPlayer;
        slowDuration = data.slowDuration;
        slowValue = data.slowValue;
    }

    void Update()
    {
        seesPlayer = Physics2D.OverlapCircle(transform.position, chceckRadius, whatIsPlayer);
        
        //var dir = target.position;

        if (seesPlayer)
        {
            var dir = target.position - transform.position;
            rb.velocity = dir.normalized * speed;
        }

        if (!seesPlayer)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public float getSlow()
    {
        return slowValue;
    }

    public float getDuration()
    {
        return slowDuration;
    }
}
