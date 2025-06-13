using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class EquipmentSpaceSuit : ItemBase
    {
        [SerializeField]
        protected int _defense = 5; // ����
        
        [TextArea]
        [SerializeField]
        protected string _effect = "";  // �߰� ȿ�� (���� ��� ����)

        [TextArea]
        [SerializeField]
        protected string _description = "�⺻ ���ֺ� ����ϴ�."; // ����

        // ������Ƽ

        public int Defense
        {
            get { return _defense; }
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
