using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.WeaponBase
{
    public abstract class WeaponBase
    {
        protected int damage;
        protected eWeaponType.eWeaponType _weaponType;
        protected float cooldown;

        public abstract void Attack(int damageMultiplier);

        public abstract IEnumerator StartCoolDown();
      
        
        public eWeaponType.eWeaponType GetWeaponType()
        {
            return _weaponType;
        }
    }
}