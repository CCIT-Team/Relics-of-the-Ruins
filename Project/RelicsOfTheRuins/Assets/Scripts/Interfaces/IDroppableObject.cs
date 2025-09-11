using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.DataExchangeBundles;
using UnityEngine;

namespace RelicsOfTheRuins.Interfaces
{
    public interface IDroppableObject
    {
        public bool Drop(Vector3 targetPos);
    }
}