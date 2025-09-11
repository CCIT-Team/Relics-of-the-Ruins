using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.Interfaces;
using UnityEngine;

namespace RelicsOfTheRuins.DependencyInjection
{
    public class DataHubInjector : MonoBehaviour, IExplorerDataHubInjectable
    {
        //[Space]
        [SerializeField]
        private GameObject[] _injectionTargets;
        private ExplorerDataHub _dataHubInstance;

        public void Inject(ExplorerDataHub instance)
        {
            _dataHubInstance = instance;
        }

        private void Start()
        {
            if (_dataHubInstance == null)
            {
                return;
            }

            if (_injectionTargets == null)
            {
                _injectionTargets = new GameObject[0];
            }

            foreach (GameObject obj in _injectionTargets)
            {
                IExplorerDataHubInjectable[] targetLists = obj.GetComponents<IExplorerDataHubInjectable>();
                foreach (IExplorerDataHubInjectable target in targetLists)
                {
                    target.Inject(_dataHubInstance);
                }
            }
        }
    }
}