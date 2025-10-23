using System.Collections;
using System.Collections.Generic;
using RelicsOfRuins.Spawner;
using UnityEngine;

namespace RelicsOfRuins.Room
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private RealicSpawner _relicSpawner;
        [SerializeField] private MonsterSpawner _monsterSpawner;

        public void SpawnRelics(int difficulty)
        {
            _relicSpawner.SpawnRelics(difficulty);
        }

        public int SpawnMonsters(int max, int min)
        {
            return _monsterSpawner.SpawnMonster(max, min);
        }

        public void Reset()
        {
            _relicSpawner.Clear();
            _monsterSpawner.Clear();
        }

        public Room()
        {
            
        }
    }
}
