using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HpBase : MonoBehaviour
{
    protected IMonsterStats _monsterStats;
    protected float _hp;
    protected float _dp;

    public void TakeDamage(in float inDamage)
    {
        _hp -= inDamage * (1 - _dp / 20);
    }
    protected void Start()
    {
        _monsterStats = GetComponent<IMonsterStats>();
        _hp = _monsterStats.maxHealth;
        _dp = _monsterStats.defence;
    }

    protected void Update()
    {
        if(_hp<=0)
        {
            Destroy(gameObject);
        }
    }
}
