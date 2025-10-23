using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils
{
    public static class GameObjectUtils
    {
        public static GameObject GetChildGameObject(this GameObject go, string name = null, bool recursive = false)
        {
            Transform child = go.GetChild<Transform>(name, recursive);
            if (child is null)
            {
                return null;
            }

            return child.gameObject;
        }

        public static T GetChild<T>(this GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
        {
            if (go is null)
            {
                return null;
            }

            if (recursive)
            {
                foreach (T component in go.GetComponentsInChildren<T>())
                {
                    if (component.name == name || string.IsNullOrEmpty(name))
                    {
                        return component;
                    }
                }
            }

            for (int i = 0, maxCnt = go.transform.childCount; i < maxCnt; i++)
            {
                Transform transform = go.transform.GetChild(i);
                T component = null;
                if (string.IsNullOrEmpty(name) == false && transform.name != name)//if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    continue;
                }

                if (transform.TryGetComponent<T>(out component))
                {
                    return component;
                }

            }

            return null;
        }
        
        public static void BindUIEvent(this GameObject go, Action<PointerEventData> action = null, Utils.Defines.UIEventTypes type = Utils.Defines.UIEventTypes.CLICK)
        {
            UIBase.BindEvent(go, action, type);
        }
    }
}