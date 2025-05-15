using System.Collections;
using System.Collections.Generic;
using RelicsOfRuins.Spawner;
using UnityEngine;

public class SpawnerTester : MonoBehaviour
{
    public MonsterSpawner monsterSpawner;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int result = monsterSpawner.SpawnMonster(1, 3);
            Debug.Log($"총 {result}의 난도를 가진 몬스터가 생성되었습니다.");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            monsterSpawner.Clear();
            Debug.Log("몬스터 클리어됨.");
        }
    }
}
