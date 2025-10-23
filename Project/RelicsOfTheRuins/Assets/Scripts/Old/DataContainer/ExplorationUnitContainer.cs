using System;
using UnityEngine;

namespace RelicsOfTheRuins.DataContainer
{
    public class ExplorationUnitContainer : MonoBehaviour
    {
        [SerializeField]
        private int _explorerMaxCnt=16;

        [SerializeField]
        private int _cameraMaxCnt=4;

        private GameObject[] _explorers;
        private GameObject[] _cameras;


        public GameObject[] GetExplorerArray()
        {
            return _explorers;
        }

        public void SetExplorerArray(GameObject[] explorerArray)
        {
            if (explorerArray == null)
            {
                return;
            }

            ClearExplorerArray();
            for (int i = 0; i < _explorerMaxCnt && i < explorerArray.Length; i++)
            {
                _explorers[i] = explorerArray[i];
            }
        }

        public void ClearExplorerArray()
        {
            Array.Fill(_explorers, null);
        }

        public void RemoveExplorerByObject(in GameObject inTarget)
        {
            int index = Array.IndexOf(_explorers, inTarget);
            _explorers[index] = null;
        }

        public void RemoveCameraByObject(in GameObject inTarget)
        {
            int index = Array.IndexOf(_cameras, inTarget);
            _cameras[index] = null;
        }

        public void AddCamera(GameObject target)
        {
            int index = Array.IndexOf(_cameras, null);
            _cameras[index] = target;
        }

        public GameObject GetExplorerByIndex(int index)
        {
            if (index < 0 || index >= _explorerMaxCnt)
            {
                return null;
            }

            return _explorers[index];
        }

        public GameObject GetCameraByIndex(int index)
        {
            if (index < 0 || index >= _cameraMaxCnt)
            {
                return null;
            }

            return _cameras[index];
        }

        private void Awake()
        {
            _explorers = new GameObject[_explorerMaxCnt];
            _cameras = new GameObject[_cameraMaxCnt];
        }

    }

}