using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class ConsumableMedInjector : ItemBase
    {
        [TextArea]
        [SerializeField]
        protected string _effect = "HP 20 ȸ��, ���� �̻� ȸ��";  // �߰� ȿ�� (���� ��� ����)

        [TextArea]
        [SerializeField]
        protected string _description = "Ž�� �ʼ�ǰ Ž����� ������ å������."; // ����

        // ������Ƽ

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
