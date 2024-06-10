using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject hearth;

    //spawns hearth when called
    public void SpawnHearth(Transform place)
    {
        Instantiate(hearth, place.position, hearth.transform.rotation);
    }
}
