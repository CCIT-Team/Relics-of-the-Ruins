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
        protected string _effect = "사용했거나 판매한 유물의 효과를 알 수 있음";  // 추가 효과 (없을 경우 공란)

        [TextArea]
        [SerializeField]
        protected string _description = ""; // 설명

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