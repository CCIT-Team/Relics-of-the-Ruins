using System.Collections;
using System.Collections.Generic;
using RelicsOfTheRuins.DataHub;
using UnityEngine;

public class PublishTestingScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] _testing = new GameObject[4];
    int idx = 0;

    ExplorerDataPublisher pub;

    void Awake()
    {
        pub = GetComponent<ExplorerDataPublisher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            idx++;
            idx%=4;
            pub.PublishUpdate(_testing[idx]);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            idx--;
            
            if(idx<0)
            {
                idx=3;
            }

            pub.PublishUpdate(_testing[idx]);
        }

    }
}
