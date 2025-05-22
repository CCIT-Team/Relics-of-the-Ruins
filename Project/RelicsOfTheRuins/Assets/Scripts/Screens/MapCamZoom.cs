using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.ScriptableObjects;
using UnityEngine;

namespace RelicsOfTheRuins.Screens
{
    public class MapCamZoom : MonoBehaviour
    {
        [SerializeField]
        private MapCamOptions _options;
        private Camera _mapCam;

        [SerializeField]
        private float _scrollSpeed = 0.1f;

        void Awake()
        {
            _mapCam = GetComponent<Camera>();
            _mapCam.orthographicSize = _options.defaultZoom;
        }


        void Update()
        {
            float scrollValue = Input.mouseScrollDelta.y * _scrollSpeed;
            if (_mapCam.orthographicSize > _options.zoomInMax && scrollValue < 0)
            {
                _mapCam.orthographicSize += scrollValue;
            }

            if (_mapCam.orthographicSize < _options.zoomOutMax && scrollValue > 0)
            {
                _mapCam.orthographicSize += scrollValue;
            }

            if (_mapCam.orthographicSize < 0)
            {
                _mapCam.orthographicSize = 0;
            }
        }
    }

}