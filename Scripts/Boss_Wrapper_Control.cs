using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Wrapper_Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.Update();
    }

    // Update is called once per frame
    void Update()
    {
        //turns boss stand point on if enemys are dead
        if (GetComponentInParent<RoomControl>().getAliveEnemy() <= 0)
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        //turns boss stand point off if enemys are alive
        if (GetComponentInParent<RoomControl>().getAliveEnemy() > 0)
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        
    }
}
