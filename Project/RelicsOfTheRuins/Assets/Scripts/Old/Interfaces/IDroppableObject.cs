using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.DataExchangeBundles;
using UnityEngine;

namespace RelicsOfTheRuins.Interfaces
{
    public interface IDroppableObject
    {
        public void Drop(Vector3 targetPos, in ItemDataBundle itemData);
    }
}