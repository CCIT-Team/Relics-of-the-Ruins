using System.Collections;
using System.Collections.Generic;
using System.Data;
using RelicsOfTheRuins.MapIconObjects;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    [SerializeField]
    GameObject _test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var tmp = gameObject.GetComponent<MarkerInterlinker>();
            Destroy(tmp.GetLinkedObject());
            Destroy(gameObject);
        }
    }
}
