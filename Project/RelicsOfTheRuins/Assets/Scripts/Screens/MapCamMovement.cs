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
            transform.position = pos;
        }

        void Awake()
        {
            _mapCam = GetComponent<Camera>();
            transform.SetParent(null);
            InitPos(_initialPos);
        }

        // Update is called once per frame
        void Update()
        {
            _movementBuffer.y = Input.GetAxis("Vertical");
            _movementBuffer.x = Input.GetAxis("Horizontal");

            transform.Translate(_movementBuffer * Time.deltaTime * _movementSpeed);

        }
    }
}
