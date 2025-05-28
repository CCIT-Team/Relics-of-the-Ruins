using RelicsOfTheRuins.DataExchangeBundles;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RelicsOfTheRuins.DataHub
{
    public class ClickedObjectHub
    {
        private MapCommandArgumentBundle _argumentBundle;

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

        public void PackEventObject(ref GameObject refClickedObject, Vector3 rayHitPosition, PointerEventData.InputButton mouseButton)
        {
            if (mouseButton == PointerEventData.InputButton.Left)
            {
                _argumentBundle.leftClickedObject = refClickedObject;
                _argumentBundle.leftClickedRayHitPosition = rayHitPosition;
            }
            else if (mouseButton == PointerEventData.InputButton.Right)
            {
                _argumentBundle.rightClickedObject = refClickedObject;
                _argumentBundle.rightClickedRayHitPosition = rayHitPosition;
            }
        }

        public void ProcessArgumentBundle()
        {
            //명령어 처리기에 보내는 함수
            
            InitBundle();
        }


    }
}