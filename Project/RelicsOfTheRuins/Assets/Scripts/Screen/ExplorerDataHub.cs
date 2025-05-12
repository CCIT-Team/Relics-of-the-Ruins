using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerDataHub : MonoBehaviour
{
    private GameObject _nowSelectedExplorer;

    public void SetExplorer(GameObject explorer)
    {
        _nowSelectedExplorer = explorer;
    }

    public GameObject GetExplorer()
    {
        return _nowSelectedExplorer;
    }
}
