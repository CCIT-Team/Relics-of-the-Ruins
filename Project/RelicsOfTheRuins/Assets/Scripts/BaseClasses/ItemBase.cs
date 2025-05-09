using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RelicsOfTheRuins.ItemBase
{
    class ItemBase
    {
        protected int maxStack;
        protected eItemType.eItemType _itemType;
        protected int itemPrice;
        protected Transform parentAfterDrag;
        protected Image image;

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
