using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RelicsOfTheRuins.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MapFloorLayerName", menuName = "ScriptableObjects/MapFloorLayerName", order = 3)]
    public class MapFloorLayerName : ScriptableObject
    {
        public string[] LayerNames;
    }
}