using UnityEngine;
using RelicsOfTheRuins.Interfaces;
using RelicsOfTheRuins.DataExchangeBundles;
using RelicsOfTheRuins.Enumerators;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class ItemBase : MonoBehaviour, IDroppableObject, IPickableObject, IUsableObject
    {
        [SerializeField]
        private int _maxItemStack=1;

        private int _nowItemStack = 0;

        [SerializeField]
        private int _itemPrice = 0;

        [SerializeField]
        private int _itemSize = 1;


        [SerializeField]
        private eItemType _itemType = eItemType.DEFAULT_ENUM_TYPE;

        [SerializeField]
        private GameObject _prefab2D = null;
        [SerializeField]
        private GameObject _prefab3D = null;

        

        public int MaxItemStack
        {
            get
            {
                return _maxItemStack;
            }
        }

        public int NowItemStack
        {
            get
            {
                return _nowItemStack;
            }
            set
            {
                if (value <= _maxItemStack)
                {
                    _nowItemStack = value;
                }
            }
        }

        public int ItemPrice
        {
            get
            {
                return _itemPrice;
            }
        }

        public int ItemSize
        {
            get
            {
                return _itemSize;
            }
        }

        public eItemType ItemType
        {
            get
            {
                return _itemType;
            }
        }


        public bool Drop(Vector3 targetPos)
        {
            if (_prefab3D == null)
            {
                return false;
            }

            ItemBase tmp = Instantiate(_prefab3D, targetPos, Quaternion.identity, null).GetComponent<ItemBase>();

            if (tmp == null)
            {
                Destroy(tmp.gameObject);
                return false;
            }

            tmp.NowItemStack = _nowItemStack;

            Destroy(gameObject);
            return true;
        }

        public void Pick(out ItemDataBundle itemDataBundle)
        {
            itemDataBundle.nowItemStack = _nowItemStack;
            itemDataBundle.prefab2D = _prefab2D;
            itemDataBundle.prefab3D = _prefab3D;
            Destroy(gameObject);
        }
    }
}
