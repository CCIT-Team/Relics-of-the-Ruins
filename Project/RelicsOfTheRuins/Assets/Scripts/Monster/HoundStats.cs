using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoundStats : MonoBehaviour, IMonsterStats
{
    public float houndAttackRange = 2.5f;
    public float attackRange => houndAttackRange;

    public float houndMaxHp = 30f;

    public float maxHealth => houndMaxHp;

    public float strength = 10.0f;
    public float curStrength => strength;

    public float houndDefence = 5f;
    public float defence => houndDefence;
}
