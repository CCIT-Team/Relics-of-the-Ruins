using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.Interfaces
{
    public interface IUsableObject
    {
        public virtual void Use(GameObject[] targets) { }
    }
}