using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class WeaponCombatKnife : ItemBase
    {
        [Header("Combat Knife Stats")]
        [SerializeField]
        protected string _itemName = "Combat Knife";

        [SerializeField]
        protected int _range = 1;             // 사거리

        [SerializeField]
        protected int _attackDamage = 3;            // 공격력

        [SerializeField]
        protected float _attackSpeed = 1.5f;        // 공격 속도 (초당 공격 횟수)

        [SerializeField]
        protected float _damagePerSecond = 4.5f;    // 초당 피해량

        [SerializeField]
        protected eWeaponAttackMode _weaponAttackMode;      // 공격 방식

        [SerializeField]
        protected eWeaponAttackType _weaponAttackType;      // 공격 타입

        [SerializeField]
        protected float _accuracy = 0f;              // 명중률 (기본값 0)

        [SerializeField]
        protected int _magazine = 0;                // 탄창 (해당 아이템은 탄창 없음)

        [TextArea]
        [SerializeField]
        protected string _effect = "";              // 추가 효과 (없을 경우 공란)

        [TextArea]
        [SerializeField]
        protected string _description = "짧은 검 빠르게 공격할 수 있다."; // 설명

        // 프로퍼티
        public string ItemName
        {
            get { return _itemName; }
        }

        public int Range
        {
            get { return _range; }
        }

        public int AttackDamage
        {
            get { return _attackDamage; }
        }

        public float AttackSpeed
        {
            get { return _attackSpeed; }
        }

        public float DamagePerSecond
        {
            get { return _damagePerSecond; }
        }

        public eWeaponAttackMode WeaponAttackMode
        {
            get { return _weaponAttackMode; }
        }

        public eWeaponAttackType WeaponAttackType
        {
            get { return _weaponAttackType; }
        }

        public float Accuracy
        {
            get { return _accuracy; }
        }

        public int Magazine
        {
            get { return _magazine; }
        }

        public string Effect
        {
            get { return _effect; }
        }

        public string Description
        {
            get { return _description; }
        }
    }
}
