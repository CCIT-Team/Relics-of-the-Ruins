using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.ArmorBase
{
    public abstract class ArmorBase : ItemBase.ItemBase
    {
        protected int def;
        protected eArmorPos.eArmorPos _pos;
        protected eArmorType.eArmorType _type;

        public int GetDefStatus()
        {
            return def;
        }

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
