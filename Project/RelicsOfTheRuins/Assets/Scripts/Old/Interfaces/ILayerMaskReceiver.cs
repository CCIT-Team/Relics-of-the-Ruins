using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.Interfaces
{
    public interface ILayerMaskReceiver
    {
        public abstract void UpdateLayerMask(in string layerName);
    }
}