using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDifficulty : MonoBehaviour
{
    [SerializeField]
    private eObjectDifficulty _difficulty; 
    public eObjectDifficulty GetDifficulty()
    {
        return _difficulty;
    }
}