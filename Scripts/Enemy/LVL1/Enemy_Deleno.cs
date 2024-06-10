using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Deleno : MonoBehaviour
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
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite spriteHorizontal;
    [SerializeField]
    private Sprite spriteVertical;
    //public Health hp;

    private float changeTime = 5f;
    private float timeSinceLastChangeDir;
    private float timeSinceLastChange;
    private float deltaTimeBuffer;
    private bool direction = true;

    Vector2 wayPoint;

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
        isAlive();
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, wayPoint) < range  || timeSinceLastChange > changeTime)
        {
            setNewDestination();
            timeSinceLastChange = 0;
        }

        //changes axes after set time
        deltaTimeBuffer = Time.deltaTime;
        timeSinceLastChangeDir += deltaTimeBuffer;
        if (timeSinceLastChangeDir > changeTime && GetComponent<EnemyHealth>().getHealth() > 0)
        {
            timeSinceLastChangeDir = 0;
            changeDirection();
        }
    }


    private void setCanMove(bool value)
    {
        canMove = value;
    }

    private void isAlive()
    {
        if (GetComponent<EnemyHealth>().getHealth() <= 0)
        {
            setCanMove(false);
        }
    }


    //creates new random destination to travel to 
    private void setNewDestination()
    {
        if (!direction)
        {
            wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance) + transform.position.x, transform.position.y);
            spriteRenderer.sprite = spriteHorizontal;
        }
        if(direction)
        {
            wayPoint = new Vector2(transform.position.x, Random.Range(-maxDistance, maxDistance) + transform.position.y);
            spriteRenderer.sprite = spriteVertical;
        }
    }

    //changes direction after collision
    private void OnCollisionEnter2D(Collision2D collison)
    {
        Vector2 dir = wayPoint;
        if (!direction)
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
    private void changeDirection()
    {
        if (direction)
        {
            direction = false;
        }
        else
        {
            direction = true;
        }
        setNewDestination();
    }
}