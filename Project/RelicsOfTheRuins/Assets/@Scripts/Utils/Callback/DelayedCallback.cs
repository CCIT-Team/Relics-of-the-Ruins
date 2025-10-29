using System;
using System.Collections;
using UnityEngine;

namespace Utils.Callback
{
    public class DelayedCallback : MonoBehaviour
    {
        public void CallAfter(Action callback, float time, bool freeAfterUse)
        {   
            StartCoroutine(InternalCoroutine(callback, time,freeAfterUse));
        }

        private IEnumerator InternalCoroutine(Action callback, float time,bool freeAfterUse)
        {
            yield return new WaitForSeconds(time);//나중에 성능 최적화 필요하면 그때 개선하자
            callback?.Invoke();
            if(freeAfterUse)
            {
                Destroy(this);
            }
        }
    }
}