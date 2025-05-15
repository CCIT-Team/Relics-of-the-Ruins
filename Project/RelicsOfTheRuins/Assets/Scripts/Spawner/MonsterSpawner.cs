using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using RelicsOfRuins.BaseClasses;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace RelicsOfRuins.Spawner
{
    public class MonsterSpawner : BaseSpawner
    {
        
        private void Awake()
        {
            _spawnedObjects = new List<GameObject>(); //몬스터 리스트 생성
        }

        public int SpawnMonster(int min, int max)
        {
            
            if(_bSpawned)
            {
                return 0;
            }

            int sum = 0; //몬스터들의 각 난도 총합
            int MonsterCount = UnityEngine.Random.Range(1, _spawnPoints.Length + 1); //몬스터 수 정하기

            for(int i = 0; i < MonsterCount; i++) //몬스터 생성
            {
                //프리팹에서 랜덤 선택
                int PrefabIndex = UnityEngine.Random.Range(0, _prefabs.Length);
                GameObject prefab = _prefabs[PrefabIndex];

                //생성
                Vector3 SpawnPos = _spawnPoints[i].transform.position;
                GameObject monster = Instantiate(prefab, SpawnPos, Quaternion.identity);
                monster.name = $"monster {i}";

                //난도 부여
                ObjectDifficulty difficulty = monster.GetComponent<ObjectDifficulty>();

                if (difficulty == null) //난도 부여 확인
                {
                    Debug.Log($"{monster.name} 에는 ObjectDifficulty가 부여되어있지 않습니다.");
                    Destroy(monster);
                    continue;
                }

                int level = (int)difficulty.GetDifficulty(); //난도 가져오기

                if (level >= min && level <= max) //난도 기준에 따라 파괴
                {
                    _spawnedObjects.Add(monster);
                    sum = sum + level;
                }
                else
                {
                    Destroy(monster);
                }
            }

            _bSpawned = sum > 0;
            return sum;
        }

    }

}
