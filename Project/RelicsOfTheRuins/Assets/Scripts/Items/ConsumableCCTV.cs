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
        protected string _effect = "CCTV가 설치된 방의 정보를 지도 화면으로 볼 수 있음, 최대 2개 설치 가능";  // 추가 효과 (없을 경우 공란)

        [TextArea]
        [SerializeField]
        protected string _description = "방의 정보를 알 수 있다."; // 설명

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
