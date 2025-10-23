using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RelicsOfTheRuins.Utilities;

namespace Inventory
{
    public class NormalInventory : InventoryBase
    {

        protected override void AllocateInventorySlots()
        {
            for(int x = 0; x < _cellCnt.x; x++)
            {
                for(int y = 0; y < _cellCnt.y; y++)
                {
                    _slots[x, y] = new NormalInventorySlot();
                }
            }
        }
        public override List<ItemDataBundle> ExtractAllItems()
        {

            List<ItemDataBundle> list = new List<ItemDataBundle>(4);
            
            for(int x = 0; x < _cellCnt.x; x++)
            {
                for(int y=0; y < _cellCnt.y; y++)
                {
                    ItemBase item = _slots[x, y].GetHoldingItem();
                    if (item is null)
                    {
                        continue;
                    }
                    list.Add(item.GetItemDataBundle());
                    for (int maxX = x + item.ItemSize.x, iX = x; iX < maxX; iX++)
                    {
                        for (int maxY = y + item.ItemSize.y, iY = y; iY < maxY; iY++)
                        {
                            _slots[iX, iY].UnplaceItem();
                        }
                    }
                    Destroy(item.gameObject);
                }
            }
            
            return list;
        }

        public override ItemBase PickItem(Vector2Int gridPos)
        {
            ItemBase picked = _slots[gridPos.x, gridPos.y].GetHoldingItem();

            if (picked is null)
            {
                return null;
            }

            for (int x = 0; x < picked.ItemSize.x; x++)
            {
                for (int y = 0; y < picked.ItemSize.y; y++)
                {
                    _slots[picked.ItemInventoryOrigin.x + x, picked.ItemInventoryOrigin.y + y].UnplaceItem();
                }
            }

            picked.ItemInventoryOrigin = Vector2Int.zero;
            picked.SetImgParent(_canvasRt);

            return picked;
        }

        public override bool PlaceItem(ItemBase item, Vector2Int gridPos)
        {
            if (item is null || InventoryCalcUtils.BoundaryCheck(gridPos, item.ItemSize, CellCnt) == false)
            {
                return false;
            }

            for (int x = 0; x < item.ItemSize.x; x++)
            {
                for (int y = 0; y < item.ItemSize.y; y++)
                {
                    if (_slots[gridPos.x + x, gridPos.y + y].CanPlace() == false)//왜인진 모르겠는데, 아이템이 자기의 이전 공간을 참조하고 있는 버그가 있음
                    {
                        return false;
                    }
                }
            }

            item.SetImgParent(_gridRt);

            for (int x = 0; x < item.ItemSize.x; x++)
            {
                for (int y = 0; y < item.ItemSize.y; y++)
                {
                    _slots[gridPos.x + x, gridPos.y + y].PlaceItem(item);
                }
            }

            item.ItemInventoryOrigin = gridPos;
            item.ImgLocalPosition = InventoryCalcUtils.CalculateSpriteGridPos(gridPos, CellSize);

            return true;
        }

        public override bool Use(Vector2Int gridPos)
        {
            ItemBase picked = _slots[gridPos.x, gridPos.y].GetHoldingItem();
            if (picked is null)
            {
                return false;
            }

            //if(picked.ItemType == eItemTypes.)

            picked.Use(new GameObject[4] { this.gameObject, null, null, null });

            //if(picked.IsEmpty())
            {
                ItemDataBundle bundle = picked.GetItemDataBundle();

                for (int x = bundle.origin.x; x < bundle.origin.x + bundle.itemSize.x; x++)
                {
                    for (int y = bundle.origin.y; y < bundle.origin.y + bundle.itemSize.y; y++)
                    {
                        _slots[x, y].UnplaceItem();
                    }
                }

                Destroy(picked.gameObject);
            }


            return true;
        }

        public override bool Drop(Vector2Int gridPos)
        {
            ItemBase picked = _slots[gridPos.x, gridPos.y].GetHoldingItem();
            if (picked is null)
            {
                return false;
            }

            ItemDataBundle bundle = picked.GetItemDataBundle();

            for (int x = bundle.origin.x; x < bundle.origin.x + bundle.itemSize.x; x++)
            {
                for (int y = bundle.origin.y; y < bundle.origin.y + bundle.itemSize.y; y++)
                {
                    _slots[x, y].UnplaceItem();
                }
            }

            picked.Drop(gameObject.transform.position, picked.GetItemDataBundle());


            // Destroy(picked.gameObject);

            // ItemBase dropped = Instantiate(bundle.prefabs.prefab3d).GetComponent<ItemBase>();
            // dropped.SetItemDataBundle(bundle);
            // dropped.gameObject.transform.position = dropped.gameObject.transform.parent.position;

            return true;
        }
    }
}