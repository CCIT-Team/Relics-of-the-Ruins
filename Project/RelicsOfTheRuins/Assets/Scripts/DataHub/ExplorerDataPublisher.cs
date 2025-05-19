using RelicsOfTheRuins.DependencyInjection;
using UnityEngine;


namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataPublisher : Injectable
    {
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