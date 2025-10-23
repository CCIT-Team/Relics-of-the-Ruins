using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.Interfaces
{
    public interface IPickableObject
    {
        public void Pick(out ItemDataBundle itemDataBundle);
    }
}