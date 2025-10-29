

using System.Collections.Generic;
using ObjectPool;
using UnityEngine;

namespace Manager.Core
{
    public class ObjectPoolManager
    {
        private Dictionary<string, ObjectPool.GameObjectPool> _pools = new Dictionary<string, ObjectPool.GameObjectPool>();
        void CreatePool(GameObject originalPrefab)
        {
            if (_pools.ContainsKey(originalPrefab.name))
            {
                return;
            }

            GameObjectPool pool = new GameObjectPool(originalPrefab,originalPrefab.name);
            _pools.Add(originalPrefab.name, pool);
        }

        public GameObject GetFromPool(GameObject prefab)
        {
            if (_pools.ContainsKey(prefab.name) == false)
            {
                CreatePool(prefab);
            }

            return _pools[prefab.name].Pop();
        }

        public bool ReturnToPool(GameObject go)
        {
            if (_pools.ContainsKey(go.name) == false)
            {
                return false;
            }

            _pools[go.name].Push(go);
            return true;
        }

        public void Clear()
        {
            foreach (var pool in _pools)
            {
                pool.Value.DisposePool();
            }
            _pools.Clear();
        }
    }
}