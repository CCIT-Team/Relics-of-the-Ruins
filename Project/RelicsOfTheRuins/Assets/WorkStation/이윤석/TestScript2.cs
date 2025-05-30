using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.DataContainer;
using UnityEngine;

public class TestScript2 : MonoBehaviour
{

    [SerializeField]
    ExplorationUnitContainer con;

    [SerializeField]
    GameObject[] arr;

    // Start is called before the first frame update
    void Start()
    {
        con.SetExplorerArray(arr);Input.GetKey(KeyCode.None);
    }

}
