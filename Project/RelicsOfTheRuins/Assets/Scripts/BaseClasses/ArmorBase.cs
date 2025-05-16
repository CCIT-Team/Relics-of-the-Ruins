using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class ArmorBase : BaseClasses.ItemBase
    {
        protected int _def;
        protected Enumerators.eArmorPos _pos;
        protected Enumerators.eArmorType _type;

        public int GetDefStatus()
        {
            return _def;
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
