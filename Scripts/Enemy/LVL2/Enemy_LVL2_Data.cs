using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/EnemyLVL2", order = 1)]
public class Enemy_LVL2_Data : ScriptableObject
{
    public int health;
    public float speed;
    public float radius;
    public LayerMask player;
}
