using RelicsOfTheRuins.DependencyInjection;
using UnityEngine;

namespace RelicsOfTheRuins.DataHub
{
    public class ExplorerDataSubscriber : Injectable
    {
        public override void Inject(ExplorerDataHub instance)
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