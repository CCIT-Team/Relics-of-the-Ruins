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
        protected string _effect = "정신력 회복 20 회복";  // 추가 효과 (없을 경우 공란)

        [TextArea]
        [SerializeField]
        protected string _description = "마음이 안정된다."; // 설명

        // 프로퍼티

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
