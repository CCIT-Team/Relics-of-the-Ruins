using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.Utilities;
using UnityEngine;


namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        private InventoryBase _inventory;
        private ItemBase _pickedItem;
        public void SetInventory(InventoryBase inventory)
        {
            _inventory = inventory;
        }

        public void UnsetInventory(InventoryBase inventory)
        {
            if (_inventory != inventory)
            {
                return;
            }
            _inventory = null;
        }

        void Update()
        {
            if (_pickedItem is not null)
            {
                _pickedItem.ImgPosition = Input.mousePosition;
            }

            if (_inventory is null)
            {
                return;
            }

            Vector2Int gridPos;

            if (Input.GetMouseButtonDown(0))
            {
                gridPos = InventoryCalcUtils.GetClickedCellCoord(Input.mousePosition, _inventory.CellSize, _inventory.Position);
                ItemBase tmp = _inventory.PickItem(gridPos);
                if (tmp is not null)
                {
                    _pickedItem = tmp;
                }

            } 
            
            if (Input.GetMouseButtonUp(0))
            {
                gridPos = InventoryCalcUtils.GetClickedCellCoord(Input.mousePosition, _inventory.CellSize, _inventory.Position);
                if(_inventory.PlaceItem(_pickedItem, gridPos))
                {
                    _pickedItem = null;
                }
                
            }

            if (Input.GetMouseButtonDown(1))
            {
                gridPos = InventoryCalcUtils.GetClickedCellCoord(Input.mousePosition, _inventory.CellSize, _inventory.Position);
                _inventory.Use(gridPos);
            }
            
            if (Input.GetMouseButtonDown(2))
            {
                gridPos = InventoryCalcUtils.GetClickedCellCoord(Input.mousePosition, _inventory.CellSize, _inventory.Position);
                _inventory.Drop(gridPos);
            }

        }


    }
}
