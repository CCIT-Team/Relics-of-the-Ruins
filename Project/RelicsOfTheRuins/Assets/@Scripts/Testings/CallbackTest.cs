using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class CallbackTest : MonoBehaviour
{
    int ccnt = 0;
    [ContextMenu("f")]
    void Fun()
    {
        gameObject.GetOrAddComponent<Utils.Callback.DelayedCallback>().CallAfter(Func, 1f, true);
    }
    
    void Func()
    {
        Debug.Log(++ccnt);
    }
}
