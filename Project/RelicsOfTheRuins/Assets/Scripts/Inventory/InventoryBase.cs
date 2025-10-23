using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.DataExchangeBundles;
using Unity.VisualScripting;
using UnityEngine;

namespace Inventory
{
    public abstract class InventoryBase : MonoBehaviour
    {

        protected Vector2Int _cellSize;

        protected Vector2Int _cellCnt;

        protected Vector3 _gridPos;
        protected RectTransform _gridRt;
        [SerializeField]
        protected GameObject _gridPrefab;
        [SerializeField]
        protected RectTransform _canvasRt;

        public Vector2Int CellSize { get { return _cellSize; } }
        public Vector2Int CellCnt { get { return _cellCnt; } }
        public Vector3 Position { get { return _gridRt.position; } }

        protected GameObject _inventoryRoot;

        protected InventorySlotBase[,] _slots;

        //drop, use같은것도 써야지
        public void MakeInventory(Vector2Int cellCnt, Vector2Int cellSize, Vector3 pos)
        {
            _gridPos = pos;
            _cellCnt = cellCnt;
            _cellSize = cellSize;
            _inventoryRoot = Instantiate(_gridPrefab);
            _gridRt = _inventoryRoot.GetComponent<RectTransform>();
            _gridRt.SetParent(_canvasRt);
            _gridRt.anchoredPosition = _gridPos;
            _gridRt.name = $"{name}_Inventory";
            _inventoryRoot.GetComponent<GridInteractor>().Setup(this);
            _slots = new InventorySlotBase[cellCnt.x, cellCnt.y];
            _gridRt.sizeDelta = new Vector2(_cellCnt.x * _cellSize.x, _cellCnt.y * _cellSize.y);
            AllocateInventorySlots();
            gameObject.SetActive(false);
        }
        //그리드 위치 설정 함수 짜기

        public abstract ItemBase PickItem(Vector2Int gridPos);

        public abstract bool PlaceItem(ItemBase item, Vector2Int gridPos);
        public abstract List<ItemDataBundle> ExtractAllItems();
        //사용, drop만들기

        public abstract bool Use(Vector2Int gridPos);
        public abstract bool Drop(Vector2Int gridPos);


        protected abstract void AllocateInventorySlots();
        //이거도 고치기
        void OnEnable()
        {
            if(_inventoryRoot is null || _inventoryRoot.IsDestroyed())
            {
                return;
            }
            _inventoryRoot.SetActive(true);
        }

        void OnDisable()
        {
            if (_inventoryRoot is null || _inventoryRoot.IsDestroyed())
            {
                return;
            }
            _inventoryRoot.SetActive(false);
        }

        


    }
}
