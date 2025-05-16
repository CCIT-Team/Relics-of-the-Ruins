using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.BaseClasses;
using UnityEngine;

namespace RelicsOfTheRuins.Inventory
{
    public abstract class Inventory
    {
        protected InventorySlot[][] _slot;
        protected EquipmentSlot[] _equipment;

        public abstract List<ItemBase> GetAllItems();
        public abstract bool IncreaselInventory(int amount);
        public abstract bool DecreaseInventory(int amount);
        public abstract void Clear();
        public abstract void AddItem(ItemBase item);
    }
}

