using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class ComponentUtils
    {
        public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
        {
            T component = go.GetComponent<T>();
            if (component is null)
            {
                component = go.AddComponent<T>();
            }
            return component;
        }

        
    }

}