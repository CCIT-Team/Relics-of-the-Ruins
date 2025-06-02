using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptTest : MonoBehaviour
{
    Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<Camera>();
        //_cam.cullingMask = LayerMask.GetMask("Water");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
