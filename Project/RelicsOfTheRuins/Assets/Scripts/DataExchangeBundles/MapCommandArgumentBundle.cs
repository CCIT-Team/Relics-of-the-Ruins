using UnityEngine;

namespace RelicsOfTheRuins.DataExchangeBundles
{
    public struct MapCommandArgumentBundle
    {
        public GameObject leftClickedObject;
        public GameObject rightClickedObject;
        public Vector3 leftClickedRayHitPosition;
        public Vector3 rightClickedRayHitPosition;
    }
}