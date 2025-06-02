using RelicsOfTheRuins.Interfaces;
using UnityEngine;

namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataSubscriber : MonoBehaviour, IExplorerDataHubInjectable
    {
        ExplorerDataHub _dataHub;
        public void Inject(ExplorerDataHub instance)
        {
            if (instance == null)
            {
                return;
            }

            _dataHub = instance;
            _dataHub.Subscribe(this);
        }

        public virtual void ReceiveUpdate(GameObject explorer)
        { 
        }

        protected void Awake()
        {
            if (_dataHub == null)
            {
                _dataHub = new ExplorerDataHub();
            }
        }
        
        protected void OnDestroy()
        {
            _dataHub.UnSubscribe(this);
        }
    }
}