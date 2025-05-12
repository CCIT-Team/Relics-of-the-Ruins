using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class ArmorBase : BaseClasses.ItemBase
    {
        protected int def;
        protected Enumerators.eArmorPos _pos;
        protected Enumerators.eArmorType _type;

        public int GetDefStatus()
        {
            return def;
        }

        public Enumerators.eArmorPos GetArmorPos()
        {
            return _pos;
        }

        public Enumerators.eArmorType GetArmorType()
        {
            return _type;
        }
    }
}
