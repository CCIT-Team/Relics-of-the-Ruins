using System.Linq;
using RelicsOfTheRuins.DataContainer;
using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.DependencyInjection;
using RelicsOfTheRuins.Interfaces;
using RelicsOfTheRuins.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RelicsOfTheRuins.Screens
{
    public class UnitSelectionWithKey : MonoBehaviour, IClickedObjectHubInjectable, IExplorerDataHubInjectable
    {
        [SerializeField]
        private ExplorationUnitContainer _unitContainer;

        private ClickedObjectHub _clickedObjectHub;
        private ExplorerDataHub _explorerDataHub;
        
        [SerializeField]
        private Tags _tags;

        [SerializeField]
        KeyCodeData _keyCodeData;

        private GameObject _clickedObject;

        public void Inject(ClickedObjectHub instance)
        {
            _clickedObjectHub = instance;
        }

        public void Inject(ExplorerDataHub instance)
        {
            _explorerDataHub = instance;
        }



        // Update is called once per frame
        void Update()
        {
            if (!Input.anyKeyDown)
            {
                return;
            }

            _clickedObject = null;

            for (int i = 0; i < _keyCodeData.explorerKeyCode.Length; i++)
            {
                if (Input.GetKey(_keyCodeData.explorerKeyCode[i]))
                {
                    _clickedObject = _unitContainer.GetExplorerByIndex(i);
                }
            }

            for (int i = 0; i < _keyCodeData.cameraKeyCode.Length && _clickedObject == null; i++)
            {
                if (Input.GetKey(_keyCodeData.cameraKeyCode[i]))
                {
                    _clickedObject = _unitContainer.GetCameraByIndex(i);
                }
            }

            if (_clickedObject == null)
            {
                return;
            }

            _clickedObjectHub.PackEventObject(_clickedObject, Vector3.zero, PointerEventData.InputButton.Left);
            
            if (_tags._explorerDataHubPublishableTag.Contains(_clickedObject.tag))
            {
                _explorerDataHub.Publish(_clickedObject);
            }

        }
    }

}