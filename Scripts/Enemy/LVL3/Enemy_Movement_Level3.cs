using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement_Level3 : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Enemy_LVL3_Data data;

    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = data.speed;
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        //after collison sets next waypoint 
        if(transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex++;
            //Debug.Log("indexChange");
        }
        //after reaching last waypoint heads to start
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }

    }
    
}
