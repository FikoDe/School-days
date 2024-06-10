using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInCombat : MonoBehaviour
{
    private bool isInCombat;
    [SerializeField]
    private LayerMask enemy;
    [SerializeField] private MusicManager musicManager;
    // Update is called once per frame
    void Update()
    {
        isInCombat = Physics2D.OverlapCircle(transform.position, 18, enemy);
        //checks if in specific radius is object with tag enemy
        if (isInCombat)
        {
            musicManager.musicInCombat();
        }
        else
        {
            musicManager.basicMusic();
        }

    }

    //getter for isInCombat
    public bool getisInCombat()
    {
        return isInCombat;
    }
}
