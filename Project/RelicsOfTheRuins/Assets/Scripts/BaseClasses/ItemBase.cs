using UnityEngine;
using RelicsOfTheRuins.Interfaces;
using RelicsOfTheRuins.DataExchangeBundles;
using RelicsOfTheRuins.Enumerators;

namespace RelicsOfTheRuins.BaseClasses
{
    public abstract class ItemBase : MonoBehaviour, IDroppableObject, IPickableObject, IUsableObject
    {
        [SerializeField]
        protected int _maxItemStack=1;

        protected int _nowItemStack = 0;

        [SerializeField]
        protected int _itemPrice = 0;

        [SerializeField]
        protected int _itemYSize = 1;
        [SerializeField]
        protected int _itemXSize = 1;


        [SerializeField]
        protected eItemType _itemType = eItemType.DEFAULT_ENUM_TYPE;

        [SerializeField]
        protected GameObject _prefab2D = null;
        [SerializeField]
        protected GameObject _prefab3D = null;

        

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

        public int ItemYSize
        {
            get
            {
                return _itemYSize;
            }
        }

        public int ItemXSize
        {
            get
            {
                return _itemXSize;
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
