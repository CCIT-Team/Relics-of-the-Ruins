using System.Collections;
using System.Collections.Generic;
using Inventory;
using RelicsOfTheRuins.DataExchangeBundles;
using UnityEngine;

namespace Inventory
{
    public class EquipmentInventory : InventoryBase
    {
        public override bool Drop(Vector2Int gridPos)
        {
            throw new System.NotImplementedException();
        }

        public override List<ItemDataBundle> ExtractAllItems()
        {
            throw new System.NotImplementedException();
        }

        public override ItemBase PickItem(Vector2Int gridPos)
        {
            throw new System.NotImplementedException();
        }

        public override bool PlaceItem(ItemBase item, Vector2Int gridPos)
        {
            throw new System.NotImplementedException();
        }

        public override bool Use(Vector2Int gridPos)
        {
            throw new System.NotImplementedException();
        }

        protected override void AllocateInventorySlots()
        {
            throw new System.NotImplementedException();
        }
    }

}