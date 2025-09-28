using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : ItemBase
{
    [SerializeField]
    protected float _damage = 0;
    [SerializeField]
    protected float _cooldown = 0;
    [SerializeField]
    protected GameObject _attackAreaObject;

    public abstract void Attack(float damageMultiplier);
}
