using RelicsOfTheRuins.DataHub;
using RelicsOfTheRuins.Interfaces;
using UnityEngine;

namespace RelicsOfTheRuins.DependencyInjection
{
    public class DataHubInjector : MonoBehaviour
    {
        //[Space]
        [SerializeField]
        private GameObject []_injectionTargets;

        private void Awake()
        {
            ExplorerDataHub dataHubInstance = new ExplorerDataHub();

            if(dataHubInstance == null)
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
                    target.Inject(dataHubInstance);
                }
            }
        }
    }
}