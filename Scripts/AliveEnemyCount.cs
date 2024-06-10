using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveEnemyCount : MonoBehaviour
{
    private int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        findEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(enemyCount);
        findEnemy();
    }
    
    //finds number of enemys is the room
    public void findEnemy()
    {
        enemyCount = transform.childCount;
    }

    //is called when enemy dies

    //sends how many enemies are alive
    public int getAliveEnemyCount()
    {
        return enemyCount;
    }
}
