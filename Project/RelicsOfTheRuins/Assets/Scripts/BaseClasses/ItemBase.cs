using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RelicsOfTheRuins;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class ItemBase : Interfaces.IPickable , Interfaces.IUsableObject
    {
        protected int maxStack;
        protected Enumerators.eItemType _itemType;
        protected int itemPrice;
        protected Transform parentAfterDrag;
        protected Image image;

        public abstract void Use(GameObject[] targets);
        public abstract void Pick();

        public int GetItemMaxStack()
        {
            return maxStack;
        }

        public Enumerators.eItemType GetItemType()
        {
            return _itemType;
        }

        public int GetItemPrice()
        {
            return itemPrice;
        }

    }
}
