using System.Collections;
using System.Collections.Generic;
using RelicsOfRuins.BaseClasses;
using UnityEngine;

namespace RelicsOfRuins.Spawner
{
    public class RealicSpawner : BaseSpawner
    {
        private void Awake()
        {
            _spawnedObjects = new List<GameObject>(); //유물 리스트 생성
        }

        public void SpawnRelics(int difficulty)
        {
            if (_bSpawned) return;

            int spawnCount = Mathf.Min(_spawnPoints.Length, _prefabs.Length);

            for (int i = 0; i < spawnCount; i++)
            {
                int prefabIndex = Random.Range(0, _prefabs.Length);
                GameObject prefab = _prefabs[prefabIndex];

                Vector3 spawnPos = _spawnPoints[i].transform.position;
                GameObject relic = Instantiate(prefab, spawnPos, Quaternion.identity);

                ObjectDifficulty diff = relic.GetComponent<ObjectDifficulty>();

                if (diff != null)
                {
                    int relicLevel = (int)diff.GetDifficulty();

                    if (relicLevel == difficulty)
                    {
                        _spawnedObjects.Add(relic); // 난도 일치 → 유지
                    }
                    else
                    {
                        Destroy(relic); // 난도 다르면 제거
                    }
                }
                else
                {
                    Debug.LogWarning(relic.name + "에 ObjectDifficulty 컴포넌트 없음!");
                    Destroy(relic);
                }
            }

            _bSpawned = _spawnedObjects.Count > 0;
        }

        public override void Spawn()
        {
            throw new System.NotImplementedException();
        }
    }
}

