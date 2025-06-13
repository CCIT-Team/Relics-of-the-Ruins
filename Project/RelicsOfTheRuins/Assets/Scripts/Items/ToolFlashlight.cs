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
        protected int _Range = 4;  // 사거리

        [TextArea]
        [SerializeField]
        protected string _effect = "바라보는 방향으로 어둠을 밝혀줌";  // 추가 효과 (없을 경우 공란)

        [TextArea]
        [SerializeField]
        protected string _description = "어둠을 밝혀준다.";  // 설명

        // 프로퍼티

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