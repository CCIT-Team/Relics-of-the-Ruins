using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class ConsumableSedativeInjector : ItemBase
    {
        [TextArea]
        [SerializeField]
        protected string _effect = "���ŷ� ȸ�� 20 ȸ��";  // �߰� ȿ�� (���� ��� ����)

        [TextArea]
        [SerializeField]
        protected string _description = "������ �����ȴ�."; // ����

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
