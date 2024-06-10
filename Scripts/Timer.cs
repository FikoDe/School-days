using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time = 0;
    private float seconds;
    private float minutes;

    // Update for score
    void Update()
    {
        //ads time and changes it to minutes
        time += Time.deltaTime;
        minutes = time / 60 - (time % 60) / 60;
        seconds = time - minutes * 60 - time % 1;
    }

    //getter for minutes
    public float getMinutes()
    {
        return minutes;
    }

    //getter for seconds
    public float getSeconds()
    {
        return seconds;
    }
}
