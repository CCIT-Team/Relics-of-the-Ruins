using UnityEngine;

namespace RelicsOfTheRuins.MapIconObjects
{
    public class MarkerInterlinker : MonoBehaviour
    {
        [SerializeField]
        private GameObject _linkedObject;

        public void SetLink(GameObject target)
        {
            _linkedObject = target;
        }

        public void UnLink()
        {
            _linkedObject = null;
        }

        public GameObject GetLinkedObject()
        {
            return _linkedObject;
        }

        private void OnDestroy()
        {
            if (_linkedObject == null)
            {
                return;
            }

            MarkerInterlinker linker = GetComponent<MarkerInterlinker>();

            if (linker == null)
            {
                return;
            }

            linker.UnLink();
        }

    }
}