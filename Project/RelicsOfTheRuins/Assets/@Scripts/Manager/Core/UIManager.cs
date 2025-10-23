using System.Collections;
using System.Collections.Generic;
using UI;
using UI.Scene;
using UI.Toast;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

namespace Manager.Core
{
    public class UIManager
    {
        private int _order = 10;
        private int _toastOrder = 500;
        private UIScene _uiScene = null;
        private Stack<UIPopup> _uiPopupStack = new Stack<UIPopup>();
        private Stack<UIToast> _uiToastStack = new Stack<UIToast>();
        private GameObject _uiRoot;
        public void Init()
        {
            if (_uiRoot == null)
            {
                _uiRoot = GameObject.Find("@UIRoot");
                if (_uiRoot == null)
                {
                    _uiRoot = new GameObject { name = "@UIRoot" };
                }
            }
        }

        public void SetCanvas(GameObject go, bool sort = true, int sortOrder = 0, bool isToast = false)
        {
            Canvas canvas = go.GetOrAddComponent<Canvas>();
            if (canvas is null)
            {
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.overrideSorting = true;
            }

            CanvasScaler cs = go.GetOrAddComponent<CanvasScaler>();
            if (cs is not null)
            {
                cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                cs.referenceResolution = new Vector2(1080, 1920);
            }

            go.GetOrAddComponent<GraphicRaycaster>();

            if (sort)
            {
                canvas.sortingOrder = _order;
                _order++;
            }
            else
            {
                canvas.sortingOrder = sortOrder;
            }

            if (isToast)
            {
                _toastOrder++;
                canvas.sortingOrder = _toastOrder;
            }

        }

        public T MakeWorldSpaceUI<T>(Transform parent = null, string name = null) where T : UIBase
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Managers.Instance.ResourceManager.Instantiate($"{name}");
            if (parent is not null)
                go.transform.SetParent(parent);

            Canvas canvas = go.GetOrAddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.worldCamera = Camera.main;

            return go.GetOrAddComponent<T>();
        }

        public T MakeSubItem<T>(Transform parent = null, string name = null, bool pooling = true) where T : UIBase
        {
            if (string.IsNullOrEmpty(name))
            {
                name = typeof(T).Name;
            }

            GameObject go = Managers.Instance.ResourceManager.Instantiate($"{name}", parent, pooling);
            go.transform.SetParent(parent);
            return go.GetOrAddComponent<T>();
        }

        public T ShowSceneUI<T>(string name = null) where T : UIScene
        {
            if (string.IsNullOrEmpty(name))
            {
                name = typeof(T).Name;
            }

            GameObject go = Managers.Instance.ResourceManager.Instantiate($"{name}");
            T sceneUI = go.GetOrAddComponent<T>();
            _uiScene = sceneUI;

            go.transform.SetParent(_uiRoot.transform);

            return sceneUI;
        }

        public T ShowPopupUI<T>(string name = null) where T : UIPopup
        {
            if (string.IsNullOrEmpty(name))
            {
                name = typeof(T).Name;
            }

            GameObject go = Managers.Instance.ResourceManager.Instantiate($"{name}");
            T popup = go.GetOrAddComponent<T>();
            _uiPopupStack.Push(popup);

            go.transform.SetParent(_uiRoot.transform);

            //RefreshTimeScale();

            return popup;
        }

        public void ClosePopupUI(UIPopup popup)
        {
            if (_uiPopupStack.Count == 0)
            {
                return;
            }

            if (_uiPopupStack.Peek() != popup)
            {
                Debug.LogWarning("Close Popup Failed!");
                return;
            }
            //Managers.Instance.SoundManager.PlayPopupClose();
            //Managers.Instance.SoundManager.Play(); 소리 인스턴스 생기면 그때 설정
            ClosePopupUI();
        }

        public void ClosePopupUI()
        {
            if (_uiPopupStack.Count == 0)
            {
                return;
            }

            UIPopup popup = _uiPopupStack.Pop();

            Managers.Instance.ResourceManager.Destroy(popup.gameObject);
            popup = null;
            _order--;
            //RefreshTimeScale();
        }

        public void CloseAllPopupUI()
        {
            while (_uiPopupStack.Count > 0)
            {
                ClosePopupUI();
            }
        }

        public int GetPopupCount()
        {
            return _uiPopupStack.Count;
        }


        public UIToast ShowToast(string msg)
        {
            string name = typeof(UIToast).Name;
            GameObject go = Managers.Instance.ResourceManager.Instantiate($"{name}", pooling: true);
            UIToast popup = go.GetOrAddComponent<UIToast>();
            popup.SetInfo(msg);
            _uiToastStack.Push(popup);
            go.transform.SetParent(_uiRoot.transform);
            //StartCoroutine();이건 SetTime뭐시기 하나 만들어서 콜백 걸면 될거같은데
            //저거 callback관련해서 뭐 하나 만들자
            go.GetOrAddComponent<Utils.Callback.DelayedCallback>().CallAfter(CloseToastUI, 1f, false);
            return popup;
        }

        // IEnumerator CoCloseToastUI()
        // {
        //     yield return new WaitForSeconds(1f);
        //     CloseToastUI();
        // }

        public void CloseToastUI()
        {
            if (_uiToastStack.Count == 0)
                return;

            UIToast toast = _uiToastStack.Pop();
            Managers.Instance.ResourceManager.Destroy(toast.gameObject);
            toast = null;
            _toastOrder--;
        }

        public void Clear()
        {
            CloseAllPopupUI();
            Time.timeScale = 1;
            _uiScene = null;
        }


        //뭐하는 함수에요?
        // public void RefreshTimeScale()
        // {
        //     if (SceneManager.GetActiveScene().name != Utils.Defines.SceneNames.GameScene.ToString())
        //     {
        //         Time.timeScale = 1;
        //         return;
        //     }

        //     if (_uiPopupStack.Count > 0 || IsActiveSoulShop == true)
        //         Time.timeScale = 0;
        //     else
        //         Time.timeScale = 1;
        
        //     DOTween.timeScale = 1;
        //     OnTimeScaleChanged?.Invoke((int)Time.timeScale);
        // }
    }
}