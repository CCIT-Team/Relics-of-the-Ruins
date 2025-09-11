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
        protected string _effect = "HP 20 회복, 상태 이상 회복";  // 추가 효과 (없을 경우 공란)

        [TextArea]
        [SerializeField]
        protected string _description = "탐사 필수품 탐사원의 생명을 책임진다."; // 설명

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
