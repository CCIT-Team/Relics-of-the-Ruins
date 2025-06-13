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
        protected int _range = 1;             // ��Ÿ�

        [SerializeField]
        protected int _attackDamage = 3;            // ���ݷ�

        [SerializeField]
        protected float _attackSpeed = 1.5f;        // ���� �ӵ� (�ʴ� ���� Ƚ��)

        [SerializeField]
        protected float _damagePerSecond = 4.5f;    // �ʴ� ���ط�

        [SerializeField]
        protected eWeaponAttackMode _weaponAttackMode;      // ���� ���

        [SerializeField]
        protected eWeaponAttackType _weaponAttackType;      // ���� Ÿ��

        [SerializeField]
        protected float _accuracy = 0f;              // ���߷� (�⺻�� 0)

        [SerializeField]
        protected int _magazine = 0;                // źâ (�ش� �������� źâ ����)

        [TextArea]
        [SerializeField]
        protected string _effect = "";              // �߰� ȿ�� (���� ��� ����)

        [TextArea]
        [SerializeField]
        protected string _description = "ª�� �� ������ ������ �� �ִ�."; // ����

        // ������Ƽ
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
