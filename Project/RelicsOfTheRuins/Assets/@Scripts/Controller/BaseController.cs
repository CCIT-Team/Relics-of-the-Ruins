
using UnityEngine;
using Utils.Defines;

namespace Controller
{
    public class BaseController : MonoBehaviour
    {
        public ObjectType ObjectType { get; protected set; }
        private bool _init = false;
        void Awake()
        {
            Init();
        }

        public virtual bool Init()
        {
            if (_init)
                return false;

            _init = true;
            return true;
        }
    }
}