using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Krat: MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float range;
    [SerializeField]
    public float maxDistance;
    [SerializeField]
    public int damage;
    [SerializeField]
    public int health;
    //public Health hp;
    [SerializeField]
    private Enemy_LVL1_Data data;

    //public Health hp;

    Vector2 wayPoint;
    private float timeSinceLastChange;
    private float timeToChange = 1.5f;
    private bool canMove = true;


    void Start()
    {
        setEnemyValues();
        this.GetComponent<EnemyHealth>().setHealth(health);
        setNewDestination();
    }

    private void setEnemyValues()
    {
        health = data.health;
        speed = data.speed;
        range = data.range;
        damage = data.damage;
        maxDistance = data.maxDistance;
        //hp = Health.set;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastChange += Time.deltaTime;
        isAlive();
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, wayPoint) < range || timeToChange < timeSinceLastChange)
        {
            setNewDestination();
            timeSinceLastChange = 0;
        }
    }

    private void setCanMove(bool value)
    {
        canMove = value;
    }

    //checks if object is alive
    private void isAlive()
    {
        if (GetComponent<EnemyHealth>().getHealth() <= 0)
        {
            setCanMove(false);
        }
    }

    //changes direction after collision
    private void OnCollisionEnter2D(Collision2D collison)
    {
        Vector2 dir = wayPoint;
        if (collison.transform.position.x < transform.position.x)
        {
                dir.x = collison.transform.position.x + transform.position.x;
        }
        else
        {
            dir.x = collison.transform.position.x - transform.position.x;
        }
        if (collison.transform.position.y < transform.position.y)
        {
            dir.y = collison.transform.position.y + transform.position.y;
        }
        else
        {
            dir.y = collison.transform.position.y - transform.position.y;
        }
        wayPoint = new Vector2(dir.x, dir.y);
        


        //Debug.Log(dir.x);
    }


    //creates new random destination to travel to 
    private void setNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance) + transform.position.x, Random.Range(-maxDistance, maxDistance) + transform.position.y);
    }
}

