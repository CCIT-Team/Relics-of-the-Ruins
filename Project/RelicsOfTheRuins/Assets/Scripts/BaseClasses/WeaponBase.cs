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
    protected bool IsCooldownEnd{ get; private set; } = true;

    public abstract void Attack(float damageMultiplier);
}
