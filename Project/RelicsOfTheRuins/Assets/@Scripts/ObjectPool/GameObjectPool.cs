using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPool
{
    public class GameObjectPool
    {
        private GameObject _prefab;
        private IObjectPool<GameObject> _pool;

        private Transform _root;

        public GameObjectPool(GameObject prefab, string poolName,int defaultCapacity = 16, int maxCapacity = 8192)
        {
            _prefab = prefab;
            _pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy, true, defaultCapacity, maxCapacity);
            _root = new GameObject($"@{poolName}Pool").transform;
        }

        public void Clear()
        {
            _pool.Clear();
        }

        public void DisposePool()
        {
            Clear();
            GameObject.Destroy(_root.gameObject);
        }

        public void Push(GameObject go)
        {
            if (go.activeSelf)
            {
                _pool.Release(go);
            }
        }

        public GameObject Pop()
        {
            return _pool.Get();
        }

        GameObject OnCreate()
        {
            GameObject go = GameObject.Instantiate(_prefab);
            go.transform.SetParent(_root);
            go.name = _prefab.name;
            return go;
        }

        void OnGet(GameObject go)
        {
            go.name = _prefab.name;
            go.SetActive(true);
        }

        void OnRelease(GameObject go)
        {
            go.transform.SetParent(_root);
            go.SetActive(false);
        }

        void OnDestroy(GameObject go)
        {
            GameObject.Destroy(go);
        }

    }

}