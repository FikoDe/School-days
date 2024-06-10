using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private Health health;
    private Item_pick certificates;

    //inoitialization ob variables
    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        certificates = GameObject.FindGameObjectWithTag("Player").GetComponent<Item_pick>();
    }

    //update method for UI health and game progress certificates
    void Update()
    {
        health.HealthUpdate();
        certificates.certificateUpdate();
    }
}
