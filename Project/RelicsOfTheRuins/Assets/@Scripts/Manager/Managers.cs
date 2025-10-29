using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using Utils;

namespace Manager
{
    public class Managers : MonoBehaviour
    {
        private static Managers _sInstance;
        public static Managers Instance { get { Init(); return _sInstance; } }

        #region CORE
        private Core.ResourceManager _resourceMgr = new Core.ResourceManager();
        private Core.SceneManagerEx _sceneMgr = new Core.SceneManagerEx();
        private Core.UIManager _uiMgr = new Core.UIManager();
        private Core.SoundManager _soundMgr = new Core.SoundManager();
        private Core.ObjectPoolManager _poolMgr = new Core.ObjectPoolManager();
        private Core.DataManager _dataMgr = new Core.DataManager();
        public Core.ResourceManager ResourceManager { get { return Instance?._resourceMgr; } }
        public Core.SceneManagerEx SceneManagerEx { get { return Instance?._sceneMgr; } }
        public Core.UIManager UIManager { get { return Instance?._uiMgr; } }
        public Core.SoundManager SoundManager { get { return Instance?._soundMgr; } }
        public Core.ObjectPoolManager ObjectPoolManager { get { return Instance?._poolMgr; } }
        public Core.DataManager DataManager { get { return Instance?._dataMgr; } }
        #endregion

        private static void Init()
        {
            if (_sInstance is null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go is null)
                {
                    go = new GameObject("@Managers");
                }
                DontDestroyOnLoad(go);
                _sInstance = go.GetOrAddComponent<Managers>();
                _sInstance._soundMgr.Init();
            }

            
        }


        public void ClearManagers()
        {
            
            _uiMgr.Clear();
            _poolMgr.Clear();
            _soundMgr.Clear();
        }
    }

}
/*
//라벨단위로 로드/언로드가 가능하니까, 그거 동기화하는것도 필요하네?
    //이런
    //일단, 씬 바뀔때마다 모든 캐쉬가 날아가고, 그 순간에만 로드/언로드가 일어나서 문제는 이 구조에서는 없음
    //근데, 씬이 안바껴도 하게 할거라면, 구조를 좀 많이 고쳐야 될듯

*/