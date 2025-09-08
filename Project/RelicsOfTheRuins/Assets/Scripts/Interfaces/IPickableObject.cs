using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.DataExchangeBundles;
using UnityEngine;

namespace RelicsOfTheRuins.Interfaces
{
    public interface IPickableObject
    {
        public void Pick(out ItemDataBundle itemDataBundle);
    }
}