using RelicsOfTheRuins.Interfaces;
using UnityEngine;

namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataSubscriberObject : MonoBehaviour, IExplorerDataHubInjectable, IExplorerDataSubscriber
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

        protected virtual void Awake()
        {
            if (_dataHub == null)
            {
                _dataHub = new ExplorerDataHub();
            }
        }
        
        protected void OnDestroy()
        {
            if (_dataHub == null)
            {
                return;
            }
            
            _dataHub.UnSubscribe(this);
        }
    }
}