using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.DataExchangeBundles;
using UnityEngine;
using UnityEngine.UI;

public class TestItem : ItemBase
{
    public override void Use(GameObject[] targets)
    {
        _data.nowItemStack--;
        Debug.Log($"{targets[0].name} called use");

    }
    
    public override void Drop(Vector3 targetPos, in ItemDataBundle itemData)
    {
        ItemBase item = Instantiate(itemData.prefabs.prefab3d).GetComponent<ItemBase>();
        item.SetItemDataBundle(itemData);
        item.gameObject.transform.position = targetPos;
        var t = item.transform.localScale;
        t *= _data.nowItemStack;
        item.transform.localScale = t;
        Destroy(gameObject);
    }

    public override void Pick(out ItemDataBundle itemDataBundle)
    {
        itemDataBundle = _data;
        Destroy(gameObject);
    }
}
