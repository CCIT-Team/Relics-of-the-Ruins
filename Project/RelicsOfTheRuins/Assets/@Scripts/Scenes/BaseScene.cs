using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes
{
    public abstract class BaseScene : MonoBehaviour
    {
        public Utils.Defines.SceneNames SceneType { get; protected set; } = Utils.Defines.SceneNames.Unknown;
        void Awake()
        {
            Init();
        }

        
        protected virtual void Init()
        {
    //이벤트 시스템만들고 @EventSystem만들고 달아주는 코드 넣기
        }
    }

}