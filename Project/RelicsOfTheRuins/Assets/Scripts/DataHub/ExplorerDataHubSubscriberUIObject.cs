using RelicsOfTheRuins.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataSubscriberUIObject : Graphic, IExplorerDataHubInjectable, IExplorerDataSubscriber
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

        protected override void Awake()
        {
            if (_dataHub == null)
            {
                _dataHub = new ExplorerDataHub();
            }
        }

        protected override void OnDestroy()
        {
            if (_dataHub == null)
            {
                return;
            }
            
            _dataHub.UnSubscribe(this);
        }
    }
}