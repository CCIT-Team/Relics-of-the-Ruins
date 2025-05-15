using RelicsOfTheRuins.DependencyInjection;
using UnityEngine;

namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataSubscriber : Injectable
    {
        private GameObject _nowExplorer;

        public override void Inject(ExplorerDataHub instance)
        {
            _dataHub = instance;
            _dataHub.Subscribe(this);
        }

        public void ReceiveUpdate(GameObject explorer)
        {
            
            
            
            
            Debug.Log($"test : received : {explorer.Equals(_nowExplorer)} {explorer.name}");
            
            
            
            _nowExplorer = explorer;
        }

        private void OnDestroy()
        {
            if(_dataHub == null)
            {
                return;
            }
            
            _dataHub.UnSubscribe(this);
        }
    }
}