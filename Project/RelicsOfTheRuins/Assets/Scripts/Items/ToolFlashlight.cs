using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class ToolFlashlight : ItemBase
    {
        [SerializeField]
        protected int _Range = 4;  // ��Ÿ�

        [TextArea]
        [SerializeField]
        protected string _effect = "�ٶ󺸴� �������� ����� ������";  // �߰� ȿ�� (���� ��� ����)

        [TextArea]
        [SerializeField]
        protected string _description = "����� �����ش�.";  // ����

        // ������Ƽ

        public int Range
        {
            get { return _Range; }
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