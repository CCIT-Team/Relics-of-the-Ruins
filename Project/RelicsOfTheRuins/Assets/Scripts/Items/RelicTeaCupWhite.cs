using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class RelicTeaCupWhite : ItemBase
    {
        [SerializeField]
        protected string _visualEffects = "White";

        [SerializeField]
        protected int _grade = 1;

        [SerializeField]
        protected RelicActivationType _relicActivationType;

        [SerializeField]
        protected RelicEffectType _relicEffectType;

        [TextArea]
        [SerializeField]
        protected string _effect = "���ŷ� 10 ~ 20 ȸ��";  // �߰� ȿ�� (���� ��� ����)

        // ������Ƽ
        public int Grade
        {
            get { return _grade; }
        }
        public string VisualEffects
        {
            get { return _visualEffects; }
        }
        public RelicActivationType RelicActivationType
        {
            get { return _relicActivationType; }
        }
        public RelicEffectType RelicEffectType
        {
            get { return _relicEffectType; }
        }
        public string Effect
        {
            get { return _effect; }
        }
    }
}
