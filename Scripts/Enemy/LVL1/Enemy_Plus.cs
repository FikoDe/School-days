using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Plus : MonoBehaviour
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
    public int healt;
    [SerializeField]
    private Enemy_LVL1_Data data;


    Vector2 wayPoint;

    private bool smer;
    private float timeSinceLastChange;
    private float timeToChange = 1.5f;
    private bool canMove = true;

    void Start()
    {
        setEnemyValues();
        this.GetComponent<EnemyHealth>().setHealth(healt);
        smer = true;
        setNewDestination();
    }

    //Sets values from scriptable object
    private void setEnemyValues()
    {
        healt = data.health;
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
        if (smer)
        {
            if (collison.transform.position.x < transform.position.x)
            {
                dir = collison.transform.position + transform.position;
            }
            else
            {
                dir = collison.transform.position - transform.position;
            }
            wayPoint = new Vector2(dir.x, transform.position.y);
        }
        else
        {
            if (collison.transform.position.y < transform.position.y)
            {
                dir = collison.transform.position + transform.position;
            }
            else
            {
                dir = collison.transform.position - transform.position;
            }
            wayPoint = new Vector2(transform.position.x, dir.y);
        }

        //Debug.Log(dir.x);
    }

    //sets new waypoint to move towards and changes axes object is moving on
    private void setNewDestination()
    {
        if (smer)
        {
            wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance) + transform.position.x, transform.position.y);
            smer = false;

        }
        else
        {
            wayPoint = new Vector2(transform.position.x, Random.Range(-maxDistance, maxDistance) + transform.position.y);
            smer = true;
        }
    }
}