using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/SlowData", order = 1)]
public class Slow_enemy_data : ScriptableObject
{
    public int health;
    public float speed;
    public float chceckRadius;
    public float slowDuration;
    public float slowValue;
    public LayerMask whatIsPlayer;
}
