using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.ArmorBase
{
    public abstract class ArmorBase
    {
        protected int def;
        protected eArmorPos.eArmorPos _pos;
        protected eArmorType.eArmorType _type;

        public abstract int GetDefStatus();

        public eArmorPos.eArmorPos GetArmorPos()
        {
            return _pos;
        }

        public eArmorType.eArmorType GetArmorType()
        {
            return _type;
        }
    }
}
