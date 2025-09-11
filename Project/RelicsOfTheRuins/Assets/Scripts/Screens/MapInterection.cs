using System.Linq;
using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.DependencyInjection;
using RelicsOfTheRuins.Interfaces;
using RelicsOfTheRuins.MapIconObjects;
using RelicsOfTheRuins.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RelicsOfTheRuins.Screens
{
    public class MapInterection : MonoBehaviour,  ILayerMaskReceiver, IClickedObjectHubInjectable,IPointerClickHandler, IExplorerDataHubInjectable
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
        private ExplorerDataHub _explorerDataHub;

        [SerializeField]
        private Tags _tags;
        
        public void UpdateLayerMask(in string layerName)
        {
            _layerMask = LayerMask.GetMask(layerName);
        }

        public void Inject(ClickedObjectHub instance)
        {
            _clickedObjectHub = instance;
        }

        public void Inject(ExplorerDataHub instance)
        {
            _explorerDataHub = instance;
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

            if (_hit.collider == null || _hit.collider.gameObject == null)
            {
                return;
            }

            MarkerInterlinker markerLinker = _hit.collider.gameObject.GetComponent<MarkerInterlinker>();

            _hitObject = null;

            if (markerLinker != null)
            {
                _hitObject = markerLinker.GetLinkedObject();
            }

            _clickedObjectHub.PackEventObject(_hitObject, _hit.point, eventData.button);

            if (eventData.button == PointerEventData.InputButton.Right)
            {
                _clickedObjectHub.ProcessArgumentBundle();
            }
            else if (_hitObject != null && _tags._explorerDataHubPublishableTag.Contains(_hitObject.tag))
            {
                _explorerDataHub.Publish(_hitObject);
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