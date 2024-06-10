using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Minus : MonoBehaviour
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
    [SerializeField]
    private Enemy_LVL1_Data data;

    //private GameObject player;

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

    //Sets values from scriptable object
    private void setEnemyValues()
    {
        health = data.health;
        speed = data.speed;
        range = data.range;
        damage = data.damage;
        maxDistance = data.maxDistance;
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

    //setter for moving
    private void setCanMove(bool value)
    {
        canMove = value;
    }

    //chcecks if object is alive
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
        if(collison.transform.position.x < transform.position.x)
        {
            dir = collison.transform.position + transform.position;
        }
        else
        {
            dir = collison.transform.position - transform.position;
        }
        wayPoint = new Vector2(dir.x, transform.position.y);
        //Debug.Log(dir.x);
    }

    //sets new waypoint to move towards
    private void setNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance) + transform.position.x, transform.position.y);
    }
}