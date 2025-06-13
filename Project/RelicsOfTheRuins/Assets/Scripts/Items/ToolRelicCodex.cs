using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class ToolRelicCodex : ItemBase
    {
        [TextArea]
        [SerializeField]
        protected string _effect = "����߰ų� �Ǹ��� ������ ȿ���� �� �� ����";  // �߰� ȿ�� (���� ��� ����)

        [TextArea]
        [SerializeField]
        protected string _description = ""; // ����

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