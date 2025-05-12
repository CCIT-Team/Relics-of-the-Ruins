using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class WeaponBase : BaseClasses.ItemBase
    {
        protected int damage;
        protected Enumerators.eWeaponType _weaponType;
        protected float cooldown;

        public abstract void Attack(int damageMultiplier);

        public abstract IEnumerator StartCoolDown();
      
        
        public Enumerators.eWeaponType GetWeaponType()
        {
            return _weaponType;
        }
    }
}