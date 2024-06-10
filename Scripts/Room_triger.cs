using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_triger : MonoBehaviour
{
    public Vector3 playerChange;
    public Vector3 camChange;

    public Camera cam;

    //method for move Player object to specific location
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TransitionRoom(collision);
        }
    }

    //method for room transition
    private void TransitionRoom(Collider2D collision)
    {
        //changes position of camera
        cam.transform.position += camChange;
        //changes position of player
        collision.transform.position += playerChange;

    }
}
