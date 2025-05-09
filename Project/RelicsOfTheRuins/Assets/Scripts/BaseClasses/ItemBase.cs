using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RelicsOfTheRuins.ItemBase
{
    public abstract class ItemBase : IUsableObject.IUsableObject, Pickable.IPickable
    {
        protected int maxStack;
        protected eItemType.eItemType _itemType;
        protected int itemPrice;
        protected Transform parentAfterDrag;
        protected Image image;

        public abstract void Use(GameObject[] targets);
        public abstract void Pick();

        public int GetItemMaxStack()
        {
            return maxStack;
        }

        public eItemType.eItemType GetItemType()
        {
            return _itemType;
        }

        public int GetItemPrice()
        {
            return itemPrice;
        }

    }
}
