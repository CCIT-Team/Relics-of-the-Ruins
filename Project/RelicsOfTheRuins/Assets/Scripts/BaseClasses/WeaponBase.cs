using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class WeaponBase : BaseClasses.ItemBase
    {
        protected int _damage;
        protected Enumerators.eWeaponType _weaponType;
        protected float _cooldown;

        public abstract void Attack(int damageMultiplier);

        public abstract IEnumerator StartCoolDown();
      
        
        public Enumerators.eWeaponType GetWeaponType()
        {
            return _weaponType;
        }
    }
}