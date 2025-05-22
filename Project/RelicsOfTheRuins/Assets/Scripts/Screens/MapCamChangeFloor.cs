using RelicsOfTheRuins.ScriptableObjects;
using UnityEngine;

namespace RelicsOfTheRuins.Screens
{
    public class MapCamChangeFloor : MonoBehaviour
    {
        [SerializeField]
        private MapFloorLayerName _floorNames;
        [SerializeField]
        private KeyCodeData _keyCodeData;

        [SerializeField]
        private UpdateFloorText _updateFloorText;

        private int _nowFloorLayerMask = -1;
        private int _nowFloorIndex = 0;

        Camera _mapCam;
        public void SetCameraLayerMask(in string layerName)
        {
            _nowFloorLayerMask = LayerMask.GetMask(layerName);
            _mapCam.cullingMask = _nowFloorLayerMask;
            _updateFloorText.UpdateText(layerName);
        }

        private void Awake()
        {
            _mapCam = GetComponent<Camera>();
            SetCameraLayerMask(_floorNames.LayerNames[0]);
        }

        private void Update()
        {
            if (Input.GetKeyDown(_keyCodeData.keyUpperFloor) && _nowFloorIndex < _floorNames.LayerNames.Length - 1)
            {
                _nowFloorIndex++;
                SetCameraLayerMask(_floorNames.LayerNames[_nowFloorIndex]);
            }
            else if (Input.GetKeyDown(_keyCodeData.keyLowerFloor) && _nowFloorIndex > 0)
            {
                _nowFloorIndex--;
                SetCameraLayerMask(_floorNames.LayerNames[_nowFloorIndex]);
            }
        }
    }

}