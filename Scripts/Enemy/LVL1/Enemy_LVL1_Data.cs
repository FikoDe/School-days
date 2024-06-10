using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/EnemyLVL1", order = 1)]
public class Enemy_LVL1_Data : ScriptableObject
{
    public float speed;
    public float range;
    public float maxDistance;
    public int damage;
    public int health;
}
