using RelicsOfTheRuins.DataHub;
using UnityEngine;

namespace RelicsOfTheRuins.DependencyInjection
{
    public class DataHubInjector : MonoBehaviour
    {
        //[Space]
        [SerializeField]
        private Injectable []_injectionTargets;

        private void Awake()
        {
            ExplorerDataHub dataHubInstance = new ExplorerDataHub();

            if(dataHubInstance == null)
            {
                return;
            }

            if (_injectionTargets == null)
            {
                _injectionTargets = new Injectable[0];
            }
            
            foreach (Injectable target in _injectionTargets)
            {
                target.Inject(dataHubInstance);
            }
        }
    }
}