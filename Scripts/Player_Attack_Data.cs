using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/PlayerAttack", order = 1)]
public class Player_Attack_Data : ScriptableObject
{
    public int damage;
    public float thrust;
    public float knockBackTime;
}
