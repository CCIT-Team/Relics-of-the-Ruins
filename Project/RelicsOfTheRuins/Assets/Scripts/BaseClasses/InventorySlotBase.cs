using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class InventorySlotBase : BaseClasses.ItemBase
    {
        protected int _slotNum;
        protected ItemBase _item; //이거 맞음?

        public abstract void SetItem(ItemBase item);

        public abstract ItemBase GetItem();

        public abstract void Reset();

        public abstract void OnBeginDrag(PointerEventData eventData);
        
        public abstract void OnDrag(PointerEventData eventData);

        public abstract void OnEndDrag(PointerEventData eventData);

        public abstract int GetSlotNum();
    }
}
