using RelicsOfTheRuins.Interfaces;
using UnityEngine;


namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataPublisher : MonoBehaviour, IExplorerDataHubInjectable
    {
        private ExplorerDataHub _dataHub;
        public void Inject(ExplorerDataHub instance)
        {
            if (instance == null)
            {
                return;
            }

            _dataHub = instance;
        }

        public void PublishUpdate(GameObject explorer)
        {
            if(_dataHub == null)
            {
                return;
            }
            _dataHub.Publish(explorer);
        }
    }
}