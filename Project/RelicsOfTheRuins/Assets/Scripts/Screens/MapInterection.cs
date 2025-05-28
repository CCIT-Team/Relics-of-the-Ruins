using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.DependencyInjection;
using RelicsOfTheRuins.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RelicsOfTheRuins.Screens
{
    public class MapInterection : MonoBehaviour,  ILayerMaskReceiver, IClickedObjectHubInjectable,IPointerClickHandler
    {
        private Vector2 _canvasClickPoint;
        private Vector2 _coordinateCalibrationValue;
        private RectTransform _rt;
        [SerializeField]
        private Camera _mapCam;

        private Ray _ray;
        private RaycastHit _hit;

        [SerializeField]
        private float _rayLength = Mathf.Infinity;

        private int _layerMask;

        private ClickedObjectHub _clickedObjectHub;

        private GameObject _hitObject;

        public void UpdateLayerMask(in string layerName)
        {
            _layerMask = LayerMask.GetMask(layerName);
        }

        public void Inject(ClickedObjectHub instance)
        {
            _clickedObjectHub = instance;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            bool bIsPointerInRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(_rt, eventData.pressPosition, null, out _canvasClickPoint);

            if (!bIsPointerInRect)
            {
                return;
            }

            _canvasClickPoint += _coordinateCalibrationValue;
            _canvasClickPoint.x /= _rt.rect.width;
            _canvasClickPoint.y /= _rt.rect.height;

            _ray = _mapCam.ViewportPointToRay(_canvasClickPoint);

            if (!Physics.Raycast(_ray, out _hit, _rayLength, _layerMask))
            {
                return;
            }

            _hitObject = _hit.collider.gameObject;
            _clickedObjectHub.PackEventObject(ref _hitObject, _hit.point, eventData.button);
            //원본 오브젝트가 있는 좌표로의 변환은 다른곳에서 처리

            if (eventData.button == PointerEventData.InputButton.Right)
            {
                _clickedObjectHub.ProcessArgumentBundle();
            }
        }

        void Awake()
        {
            _rt = GetComponent<RawImage>().rectTransform;
            _coordinateCalibrationValue.x = _rt.rect.width / 2;
            _coordinateCalibrationValue.y = _rt.rect.height / 2;
        }
    }

}