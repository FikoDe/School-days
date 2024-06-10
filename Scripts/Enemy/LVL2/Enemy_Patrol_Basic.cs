using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol_Basic : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float chceckRadius;

    [SerializeField]
    private LayerMask whatIsPlayer;

    [SerializeField]
    private Enemy_LVL2_Data data;

    private Transform target;
    private Rigidbody2D rb;

    private bool seesPlayer = false;
    private bool canMove = true;
    private bool isKnocked = false;

    void Start()
    {
        setUpData();
        this.GetComponent<EnemyHealth>().setHealth(health);
        rb = GetComponent<Rigidbody2D>();
        //sets player as targer
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void setUpData()
    {
        health = data.health;
        speed = data.speed;
        chceckRadius = data.radius;
        whatIsPlayer = data.player;
    }

    void Update()
    {
        isAlive();
        //chcecking if player is near
        seesPlayer = Physics2D.OverlapCircle(transform.position, chceckRadius, whatIsPlayer);
        //var dir = target.position;

        if (seesPlayer && canMove && !isKnocked)
        {
            var dir = target.position - transform.position; 
            rb.velocity = dir.normalized * speed;
        }

        if(!seesPlayer || !canMove)
        {
            rb.velocity = Vector2.zero;
        }
    }


    public void setCanMove(bool value)
    {
        canMove = value;
    }
    public void setIsKnocked(bool value)
    {
        isKnocked = value;
    }

    private void isAlive()
    {
        if (GetComponent<EnemyHealth>().getHealth() <= 0)
        {
            setCanMove(false);
        }
    }

    //if enemy is damaged knocks him back
    public void KnockBackEnemy(Transform t, float knockBackValue, float time)
    {
        var dir = transform.position - t.position;
        setIsKnocked(true);
        rb.velocity = dir.normalized * knockBackValue;
        StartCoroutine(UnKnockBack(time));
    }

    private IEnumerator UnKnockBack(float knockBackTime)
    {
        yield return new WaitForSeconds(knockBackTime);
        setIsKnocked(false);
    }
}
