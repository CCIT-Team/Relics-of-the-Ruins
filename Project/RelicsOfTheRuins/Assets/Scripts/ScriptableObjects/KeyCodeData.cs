using UnityEngine;


namespace RelicsOfTheRuins.ScriptableObjects
{
    [CreateAssetMenu(fileName = "KeyCodeData", menuName = "ScriptableObjects/KeyCodeData", order = 1)]
    public class KeyCodeData : ScriptableObject
    {
        public KeyCode keyUpperFloor;
        public KeyCode keyLowerFloor;
        public KeyCode[] explorerKeyCode;
        public KeyCode[] cameraKeyCode;
    }
}