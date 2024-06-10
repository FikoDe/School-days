using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    private int aliveEnemy;

    // Start is called before the first frame update
    void Start()
    {
        this.Update();
    }

    // Update is called once per frame
    void Update()
    {
        //calles from Enemy wrapper code to chceck how many enemies are still alive (active)
        aliveEnemy = GetComponentInChildren<AliveEnemyCount>().getAliveEnemyCount();
        //if are all enemys inactive opens the doors
        if(aliveEnemy <= 0)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    //getter for aliveEnemy
    public int getAliveEnemy()
    {
        return aliveEnemy;
    }
}
