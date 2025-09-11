using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class RelicStoneKnifeBlue : ItemBase
    {
        [SerializeField]
        protected string _visualEffects = "Blue";

        [SerializeField]
        protected int _grade = 2;

        [SerializeField]
        protected RelicActivationType _relicActivationType;

        [SerializeField]
        protected RelicEffectType _relicEffectType;

        [TextArea]
        [SerializeField]
        protected string _effect = "20초 동안 방어력 +2 / 중첩 불가";  // 추가 효과 (없을 경우 공란)

        // 프로퍼티
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
