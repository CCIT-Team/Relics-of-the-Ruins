using RelicsOfTheRuins.Commands;
using RelicsOfTheRuins.DataExchangeBundles;
using RelicsOfTheRuins.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RelicsOfTheRuins.DataHub
{
    public class ClickedObjectHub : ICommandExecuterInjectable
    {
        private MapCommandArgumentBundle _argumentBundle;

        private CommandExecuter _commandExecuter;

        private void InitBundle()
        {
            _argumentBundle.leftClickedObject = null;
            _argumentBundle.rightClickedObject = null;
            _argumentBundle.rightClickedRayHitPosition = Vector3.zero;
            _argumentBundle.leftClickedRayHitPosition = Vector3.zero;
        }

        public ClickedObjectHub()
        {
            InitBundle();
        }

        public void PackEventObject(GameObject clickedObject, Vector3 rayHitPosition, PointerEventData.InputButton mouseButton)
        {
            if (mouseButton == PointerEventData.InputButton.Left)
            {
                _argumentBundle.leftClickedObject = clickedObject;
                _argumentBundle.leftClickedRayHitPosition = rayHitPosition;
            }
            else if (mouseButton == PointerEventData.InputButton.Right)
            {
                _argumentBundle.rightClickedObject = clickedObject;
                _argumentBundle.rightClickedRayHitPosition = rayHitPosition;
            }

            Debug.Log($"{_argumentBundle.leftClickedObject == null} {_argumentBundle.rightClickedObject == null}");

        }

        public void ProcessArgumentBundle()
        {
            _commandExecuter.Execute(ref _argumentBundle);
            InitBundle();
        }

        public void Inject(CommandExecuter instance)
        {
            _commandExecuter = instance;
        }
        
    }
}