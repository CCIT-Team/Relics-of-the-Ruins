using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RelicsOfTheRuins.ScriptableObjects
{
    [CreateAssetMenu(fileName = "KeyCodeData", menuName = "ScriptableObjects/KeyCodeData", order = 1)]
    public class KeyCodeData : ScriptableObject
    {
        public KeyCode keyUpperFloor;
        public KeyCode keyLowerFloor;
    }
}