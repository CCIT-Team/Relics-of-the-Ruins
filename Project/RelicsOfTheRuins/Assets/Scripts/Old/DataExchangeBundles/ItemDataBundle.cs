using System;
using UnityEngine;

namespace RelicsOfTheRuins.DataExchangeBundles
{
    [Serializable]
    public struct ItemDataBundle
    {
        public PrefabBundle prefabs;
        public Vector2Int itemSize;
        public Vector2Int origin;
        public eItemTypes itemType;
        public int nowItemStack;
        public int maxItemStack;
        public int itemPrice;
        public int itemRarity;
    }
}