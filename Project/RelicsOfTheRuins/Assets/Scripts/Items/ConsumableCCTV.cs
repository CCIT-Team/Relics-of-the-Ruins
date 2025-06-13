using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class ConsumableCCTV : ItemBase
    {
        [TextArea]
        [SerializeField]
        protected string _effect = "CCTV�� ��ġ�� ���� ������ ���� ȭ������ �� �� ����, �ִ� 2�� ��ġ ����";  // �߰� ȿ�� (���� ��� ����)

        [TextArea]
        [SerializeField]
        protected string _description = "���� ������ �� �� �ִ�."; // ����

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
