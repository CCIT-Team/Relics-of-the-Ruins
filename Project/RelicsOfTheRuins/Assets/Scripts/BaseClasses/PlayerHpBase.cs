using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpBase : MonoBehaviour
{
    protected IPlayerStats _playerStats;
    protected float _curHealth;
    protected float _curDefence;
    public static int ii=0;
    public void TakeDamage(in float inDamage)
    {
        _curHealth -= inDamage * (1 - _curDefence / 20);
    }

    public void TakeHeal(in float inHeal)
    {
        _curHealth += inHeal;
    }

    protected void Start()
    {
        _playerStats = GetComponent<IPlayerStats>();
        _curHealth = _playerStats.maxHealth;
        _curDefence = _playerStats.curDefence;
    }

    protected void Update()
    {
        if (_curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
