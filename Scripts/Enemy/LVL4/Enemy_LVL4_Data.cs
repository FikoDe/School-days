using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/EnemyLVL4", order = 1)]
public class Enemy_LVL4_Data : ScriptableObject
{
    public int health;
    public float speed;
    public float chceckRadius;
    public float speedChangeTimer;
    public int[] speedValues;
    public LayerMask whatIsPlayer;
}