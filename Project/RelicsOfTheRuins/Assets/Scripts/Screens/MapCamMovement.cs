using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfTheRuins.Screens
{
    public class MapCamMovement : MonoBehaviour
    {
        private Camera _mapCam;

        [SerializeField]
        private float _movementSpeed;
        private Vector3 _movementBuffer;
        [SerializeField]
        private Vector3 _initialPos;


        public void InitPos(Vector3 pos)
        {
            if (pos == null)
            {
                pos = _initialPos;
            }

            transform.position = pos;
        }

        void Awake()
        {
            _mapCam = GetComponent<Camera>();
            transform.position = _initialPos;
        }

        // Update is called once per frame
        void Update()
        {
            _movementBuffer.y = Input.GetAxis("Vertical") * _movementSpeed;
            _movementBuffer.x = Input.GetAxis("Horizontal") * _movementSpeed;

            transform.Translate(_movementBuffer);

        }
    }
}
