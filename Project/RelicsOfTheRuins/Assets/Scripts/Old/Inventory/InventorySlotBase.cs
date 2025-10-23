using Unity.VisualScripting;
using UnityEngine;


namespace Inventory
{
    public class InventorySlotBase
    {
        private ItemBase _holdingItem;
        public bool Lock { get; set; }
        public virtual bool CanPlace()
        {
            return Lock == false || _holdingItem is null || _holdingItem.IsDestroyed() || _holdingItem.enabled == false;
        }

        public ItemBase GetHoldingItem()
        {
            return _holdingItem;
        }

        public virtual void PlaceItem(ItemBase item)
        {
            _holdingItem = item;
        }

        public virtual void UnplaceItem()
        {
            _holdingItem = null;
        }
    }
}
