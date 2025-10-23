
using RelicsOfTheRuins.Interfaces;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IPickableObject, IUsableObject, IDroppableObject
{
    [SerializeField]
    protected ItemDataBundle _data;

    public string Name { get; set; }
    public string Description { get; set; }

    // public eItemTypes ItemType
    // {
    //     get
    //     {
    //         return _data.itemType;
    //     }
    // }
    // //이거는 나중에 타입 만들어서 넣으면 되고


    public int ItemRarity
    {
        get
        {
            return _data.itemRarity;
        }
        set
        {
            _data.itemRarity = value;
        }
    }

    public Vector2Int ItemSize
    {
        get
        {
            return _data.itemSize;
        }
    }

    public Vector2Int ItemInventoryOrigin
    {
        get
        {
            return _data.origin;
        }
        set
        {
            _data.origin = value;
        }
    }


    protected RectTransform _rt;

    public Vector3 ImgPosition
    {
        get
        {
            if (_rt is null)
            {
                return default;
            }
            return _rt.position;
        }
        set
        {
            if (_rt is null)
            {
                return;
            }
            _rt.position = value;
        }
        
    }

    public Vector3 ImgLocalPosition
    {
        get
        {
            if (_rt is null)
            {
                return default;
            }
            return _rt.localPosition;
        }
        set
        {
            if (_rt is null)
            {
                return;
            }
            _rt.localPosition = value;
        }
        
    }

    public void SetImgParent(RectTransform parent)
    {
        if (_rt is null)
        {
            return;
        }

        _rt.SetParent(parent);
    }

    public void SetImgSize(int inventoryCellSize)
    {
        _rt.sizeDelta = new Vector2(ItemSize.x * inventoryCellSize, ItemSize.y * inventoryCellSize);
    }

    protected virtual void Awake()
    {
        _rt = GetComponent<RectTransform>();
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

//아이템도 그냥 한 스크립트로 하지 말고, 3d,2d로 나눠서 해