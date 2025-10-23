using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RelicsOfRuins.BaseClasses
{
    public abstract class BaseSpawner : MonoBehaviour
    {
        [SerializeField]
        protected GameObject[] _prefabs; //
        [SerializeField]
        protected GameObject[] _spawnPoints; //몬스터 최대치
        protected bool _bSpawned = false; //스폰 상태
        protected List<GameObject> _spawnedObjects; //스폰된 오브젝트 목록

        public abstract void Spawn();
        public bool IsSpawned() => _bSpawned; //외부에서 스폰 상태 확인
        
        public void Clear() //스폰상태 초기화
        {
            foreach (var obj in _spawnedObjects)
            {
                if (obj != null)
                    Destroy(obj);
            }

            _spawnedObjects.Clear();
            _bSpawned = false;
        }
    }
}