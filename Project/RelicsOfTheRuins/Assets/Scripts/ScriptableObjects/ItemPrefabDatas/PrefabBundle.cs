using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabBundle", menuName = "Scriptable Object/PrefabBundle", order = int.MaxValue)]
public class PrefabBundle : ScriptableObject
{
    public GameObject prefab2d;
    public GameObject prefab3d;
}
