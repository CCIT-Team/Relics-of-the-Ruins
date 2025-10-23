using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RelicsOfRuins.Room;

namespace RelicsOfRuins.RoomGroup
{
    public class RoomGroup : MonoBehaviour
    {
        [SerializeField] private List<RoomGroup> _roomList;
        [SerializeField] private int _groupDifficulty;
        [SerializeField] private bool _bCanSpawnMonster;
        [SerializeField] private bool _bCanSpawnRelic;
        [SerializeField] private eObjectDifficulty _monsterDifficultyMin;
        [SerializeField] private eObjectDifficulty _monsterDifficultyMax;

        public void Init()
        {
            // 그룹 초기화
        }

        public void CleanUp()
        {
            foreach (var room in _roomList)
            {
                room.Reset();
            }
        }

        public void Reset()
        {
            CleanUp();
            // 기타 상태 초기화
        }

        public int GetGroupDifficulty() => _groupDifficulty;
    }
}
