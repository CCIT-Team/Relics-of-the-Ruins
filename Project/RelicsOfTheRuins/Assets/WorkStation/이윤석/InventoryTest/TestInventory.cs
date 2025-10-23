using System.Collections;
using System.Collections.Generic;
using Inventory;
using RelicsOfTheRuins.DataExchangeBundles;
using UnityEngine;
using RelicsOfTheRuins.Utilities;

public class TestInventory : MonoBehaviour
{
    public Vector2Int cellcnt, cellsiz;
    public Vector3 pos;
    public InventoryBase b;
    public GameObject pref;
    public Vector2Int p;
    [ContextMenu("c")]
    public void create()
    {
        b.MakeInventory(cellcnt, cellsiz, pos);

    }

    [ContextMenu("p")]
    public void d()
    {
        var i = Instantiate(pref).GetComponent<ItemBase>();
        b.PlaceItem(i, p);
    }
    public List<ItemDataBundle> arr;

    [ContextMenu("e")]
    public void Ex()
    {
        arr = b.ExtractAllItems();
        foreach (var i in arr)
        {
            Debug.Log($"{i.nowItemStack} {i.origin}");
        }
    }

    public ItemBase tar;
    [ContextMenu("P")]
    public void Pick()
    {
        ItemDataBundle data;
        tar.Pick(out data);
        ItemBase itemB = Instantiate(data.prefabs.prefab2d).GetComponent<ItemBase>();
        itemB.SetItemDataBundle(data);
        b.PlaceItem(itemB, Vector2Int.zero);
    }
}
