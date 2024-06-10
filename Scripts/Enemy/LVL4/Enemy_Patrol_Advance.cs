using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol_Advance : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float chceckRadius;
    [SerializeField]
    private float speedChangeTimer;
    [SerializeField]
    private int[] speedValues;

    [SerializeField]
    private LayerMask whatIsPlayer;

    [SerializeField]
    private Enemy_LVL4_Data data;

    [SerializeField]
    public Animator moveAnimator;

    private Transform target;
    private Rigidbody2D rb;

    private bool seesPlayer = false;
    private bool canMove = true;
    private bool isChasing = false;
    private bool isKnocked = false;

    void Start()
    {
        setUpData();
        this.GetComponent<EnemyHealth>().setHealth(health);
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void setUpData()
    {
        health = data.health;
        speed = data.speed;
        chceckRadius = data.chceckRadius;
        whatIsPlayer = data.whatIsPlayer;
        speedValues = data.speedValues;
    }

    void Update()
    {
        isAlive();
        //chceks for player
        seesPlayer = Physics2D.OverlapCircle(transform.position, chceckRadius, whatIsPlayer);

        if (seesPlayer && !isChasing)
        {
            setIsChasing(true);
            StartCoroutine(setIsChasingCo(false));
            for (int i = 0; i < 4; i++)
            {
                StartCoroutine(setSpeedCo(speedValues[i], (i+1) * speedChangeTimer));
            }
        }

        if (seesPlayer && isChasing && !isKnocked)
        {
            var dir = target.position - transform.position;
            rb.velocity = dir.normalized * speed;
            if(speed > 0)
            {
                moveAnimator.SetBool("IsMoving", true);
            }
        }

        if (!seesPlayer || !canMove)
        {
            rb.velocity = Vector2.zero;
            moveAnimator.SetBool("IsMoving", false);
        }
    }


    private void isAlive()
    {
        if (GetComponent<EnemyHealth>().getHealth() <= 0)
        {
            setCanMove(false);
        }
    }

    private IEnumerator setSpeedCo(int speed, float speedChange)
    {
        yield return new WaitForSeconds(speedChange);
        setSpeed(speed);
    }
    private IEnumerator setIsChasingCo(bool value)
    {
        yield return new WaitForSeconds(4*speedChangeTimer);
        setIsChasing(value);
    }
    public void setCanMove(bool value)
    {
        canMove = value;
    }

    public void setIsChasing(bool value)
    {
        isChasing = value;
    }
    public void setIsKnocked(bool value)
    {
        isKnocked = value;
    }

    public void setSpeed(int value)
    {
        speed = value;
    }

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
