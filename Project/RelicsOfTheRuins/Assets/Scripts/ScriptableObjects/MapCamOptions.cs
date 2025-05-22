using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RelicsOfTheRuins.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MapCamOptions", menuName = "ScriptableObjects/MapCamOptions", order = 2)]
    public class MapCamOptions : ScriptableObject
    {
        public float zoomInMax = 0;
        public float zoomOutMax = 10;
        public float defaultZoom = 5;
    }
}