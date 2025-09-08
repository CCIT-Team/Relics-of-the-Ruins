using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using RelicsOfTheRuins.Enumerators;
using UnityEngine;

namespace RelicsOfTheRuins.Items
{
    public class EquipmentSpaceSuit : ItemBase
    {
        [SerializeField]
        protected int _defense = 5; // 방어력
        
        [TextArea]
        [SerializeField]
        protected string _effect = "";  // 추가 효과 (없을 경우 공란)

        [TextArea]
        [SerializeField]
        protected string _description = "기본 우주복 평범하다."; // 설명

        // 프로퍼티

        public int Defense
        {
            get { return _defense; }
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
