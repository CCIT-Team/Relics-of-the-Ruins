using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.DataExchangeBundles;
using RelicsOfTheRuins.Interfaces;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IPickableObject, IUsableObject, IDroppableObject
{
    [SerializeField]
    protected ItemDataBundle _data;

    public string Name { get; set; }
    public string Description { get; set; }

    public eItemTypes ItemType
    {
        get
        {
            return _data.itemType;
        }
    }

    public int NowItemStack
    {
        get
        {
            return _data.nowItemStack;
        }
        set
        {
            _data.nowItemStack = value;
        }
    }

    public int MaxItemStack
    {
        get
        {
            return _data.maxItemStack;
        }
        set
        {
            _data.maxItemStack = value;
        }
    }

    public int ItemPrice
    {
        get
        {
            return _data.itemPrice;
        }
        set
        {
            _data.itemPrice = value;
        }
    }

    public Vector2Int ItemSize
    {
        get
        {
            return _data.itemSize;
        }
    }

    public bool IsEmpty()
    {
        return _data.nowItemStack <= 0;
    }

    public bool IsFull()
    {
        return _data.nowItemStack >= _data.maxItemStack;
    }

    public abstract void Pick(out ItemDataBundle itemDataBundle);

    public virtual void Use(GameObject[] targets) { }

    public abstract void Drop(Vector3 targetPos, in ItemDataBundle itemData);

    public ItemDataBundle GetItemDataBundle()
    {
        return _data;
    }

    public void SetItemDataBundle(ItemDataBundle bundle)
    {
        _data = bundle;
    }
}
