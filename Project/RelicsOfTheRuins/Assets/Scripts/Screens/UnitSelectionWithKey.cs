using RelicsOfTheRuins.DataContainer;
using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.DependencyInjection;
using RelicsOfTheRuins.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RelicsOfTheRuins.Screens
{
    public class UnitSelectionWithKey : MonoBehaviour, IClickedObjectHubInjectable
    {
        [SerializeField]
        private ExplorationUnitContainer _unitContainer;

        private ClickedObjectHub _clickedObjectHub;

        [SerializeField]
        KeyCodeData _keyCodeData;

        private GameObject _clickedObject;

        public void Inject(ClickedObjectHub instance)
        {
            _clickedObjectHub = instance;
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
        }
    }

}