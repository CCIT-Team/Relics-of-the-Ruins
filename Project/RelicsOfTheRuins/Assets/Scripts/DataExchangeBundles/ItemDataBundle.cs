using System;
using UnityEngine;

namespace RelicsOfTheRuins.DataExchangeBundles
{
    [Serializable]
    public struct ItemDataBundle
    {
        public GameObject prefab2D;
        public GameObject prefab3D;
        public Vector2Int itemSize;
        public int nowItemStack;
        public int maxItemStack;
    }
}