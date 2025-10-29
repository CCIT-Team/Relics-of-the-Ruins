using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    //오브젝트에 붙는거다
    //유니티가 제공하는 EventSystem의 호출을 받아서 그 오브젝트가 등록한 콜백을 실행해주는 역할
    public class UIEventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Action<PointerEventData> OnClickHandler = null;
        public Action<PointerEventData> OnPressedHandler = null;
        public Action<PointerEventData> OnPointerDownHandler = null;
        public Action<PointerEventData> OnPointerUpHandler = null;
        public Action<PointerEventData> OnDragHandler = null;
        public Action<PointerEventData> OnBeginDragHandler = null;
        public Action<PointerEventData> OnEndDragHandler = null;
        public Action<PointerEventData> OnPointerEnteredHandler = null;
        public Action<PointerEventData> OnPointerExitHandler = null;

        private PointerEventData _lastEventData;
        bool _pressed = false;

        private void Update()
        {
            if (_pressed)
            {
                OnPressedHandler?.Invoke(_lastEventData);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickHandler?.Invoke(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
            OnPointerDownHandler?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
            OnPointerUpHandler?.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _pressed = true;
            OnDragHandler?.Invoke(eventData);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnBeginDragHandler?.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDragHandler?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnteredHandler?.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExitHandler?.Invoke(eventData);
        }
    }
}
