using System.Collections;
using System.Collections.Generic;
using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager.Core
{
    public class SceneManagerEx
    {
        private BaseScene _currentScene;
        public BaseScene CurrentScene { get { return _currentScene; } }

        public SceneManagerEx()
        {
            //https://highfence.tistory.com/18
            //씬 로드가 끝난 후 호출되는 콜백
            //씬이 로드되고, 거기의 OnEnable들이 호출된 후 호출되는 콜백
            //이런게 있었구나
            SceneManager.sceneLoaded += RefreshNowSceneInstance;
        }
        //에셋 로드 위한 비동기 전환 구현하기
        public void LoadScene(Utils.Defines.SceneNames name)
        {
            if (name == Utils.Defines.SceneNames.Unknown)
            {
#if UNITY_EDITOR
                Debug.LogWarning("UNKNOWN scene");
#endif
                return;
            }
            SceneManager.LoadScene(GetSceneName(name));
            Managers.Instance.ClearManagers();
        }

        void RefreshNowSceneInstance(Scene scene, LoadSceneMode mode)
        {
            //_currentScene = GameObject.FindObjectOfType<BaseScene>(); //deprecated
            _currentScene = GameObject.FindFirstObjectByType<BaseScene>();
            Managers.Instance.UIManager.Init();
        }

        string GetSceneName(Utils.Defines.SceneNames type)
        {
            return System.Enum.GetName(typeof(Utils.Defines.SceneNames), type);
        }
    }

}